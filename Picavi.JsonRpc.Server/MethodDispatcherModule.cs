namespace Picavi.JsonRpc.Server
{
    using Extensions;
    using Nancy;
    using Nancy.Extensions;
    using Newtonsoft.Json;
    using Picavi.JsonRpc.Server.Model;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class MethodDispatcherModule : NancyModule
    {
        // private Fields

        private readonly RequestBroker requestBroker;

        // Constructors

        public MethodDispatcherModule(RequestBroker requestBroker)
        {
            this.requestBroker = requestBroker;

            Post["/async", true] = async (parameters, ct) => await DispatchMethodAsync(parameters, ct);
            Post["/"] = DispatchMethod;
        }

        // private Methods

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

        private Response DispatchMethod(dynamic parameters)
        {
            var request = this.Request.Body.AsString();

            var jsonRpcRequest = JsonConvert.DeserializeObject<JsonRpcRequest>(request);

            Func<JsonRpcRequest, JsonRpcResponse> dispatchMethod;
            JsonRpcResponse jsonRpcResponse;
          //added


            if (requestBroker.TryGetValue(jsonRpcRequest.Method, out dispatchMethod))
            {
                jsonRpcResponse = dispatchMethod(jsonRpcRequest);
                if(jsonRpcResponse.Result==null)
                {
                  return jsonRpcResponse.ToString();
                }

            }
            else
            {

             
                var ID = jsonRpcRequest.Id;
                var respone = ResponseFactory.BuildError(ErrorCodes.E_MethodNoFound, "Method not found","The method does not exist / is not available",ID);
                return respone.ToString();
            //    throw new MissingMethodException("jsonRpcRequest", jsonRpcRequest.Method);
            }

            return Response.AsJson(jsonRpcResponse);
        }
    }
}
