// <copyright file="MethodDispatcherModule.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Nancy;
    using Nancy.Extensions;
    using Newtonsoft.Json;
    using Picavi.JsonRpc.Server.Model;

    /// <summary>
    /// class Method Dispatcher Module
    /// </summary>
    public class MethodDispatcherModule : NancyModule
    {
         /// <summary>
        /// private field request Broker which is readonly
        /// </summary>
        private readonly RequestBroker requestBroker;
       
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodDispatcherModule"/> class.
        /// </summary>
        /// <param name="requestBroker">Parameter request Broker</param>
        public MethodDispatcherModule(RequestBroker requestBroker)
        {
            this.requestBroker = requestBroker;

            Post["/async", true] = async (parameters, ct) => await DispatchMethodAsync(parameters, ct);
            Post["/"] = DispatchMethod;
        }

        /// <summary>
        /// private method Dispatch Method Asynchronously
        /// </summary>
        /// <param name="parameters">method parameters</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns>returns response</returns>
        private async Task<Response> DispatchMethodAsync(dynamic parameters, CancellationToken ct)
        {
            var request = await this.Request.Body.AsStringAsync(ct);

            var jsonRpcRequest = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<JsonRpcRequest>(request));

            var dispatchMethod = await requestBroker.GetValueAsync(jsonRpcRequest.Method);

            ct.ThrowIfCancellationRequested();

            JsonRpcResponse jsonRpcResponse;
            if (dispatchMethod != null)
            {
                jsonRpcResponse = dispatchMethod(jsonRpcRequest);
            }
            else
            {
                throw new MissingMethodException("jsonRpcRequest", jsonRpcRequest.Method);
            }

            return Response.AsJson(jsonRpcResponse);
        }

        /// <summary>
        /// Private method Dispatch method
        /// </summary>
        /// <param name="parameters">method parameters</param>
        /// <returns>returns response</returns>
        private Response DispatchMethod(dynamic parameters)
        {
            var request = this.Request.Body.AsString();

            var jsonRpcRequest = JsonConvert.DeserializeObject<JsonRpcRequest>(request);

            Func<JsonRpcRequest, JsonRpcResponse> dispatchMethod;
            JsonRpcResponse jsonRpcResponse = null;
            if (requestBroker.TryGetValue(jsonRpcRequest.Method, out dispatchMethod))
            {
                jsonRpcResponse = dispatchMethod(jsonRpcRequest);

                if (jsonRpcResponse != null && jsonRpcResponse.Result == null)
                {
                    return Convert.ToString(jsonRpcResponse);
                }
            }
            else
            {
                var id = jsonRpcRequest.Id;
                string[] methodname = jsonRpcRequest.Method.Split('.');
                string error = ErrorMessages.Dsc_MethodNoFound;
             error = error.Replace("{0}", methodname[1]);
             var respone = ResponseFactory.BuildError(ErrorCodes.E_MethodNoFound, ErrorMessages.Msg_MethodNotFound, error, id);
             return Convert.ToString(respone);
            }

            return Response.AsJson(jsonRpcResponse);
        }
    }
}
