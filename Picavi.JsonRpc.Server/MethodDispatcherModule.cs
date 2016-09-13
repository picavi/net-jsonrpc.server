namespace Picavi.JsonRpc.Server
{
    using Nancy;
    using Nancy.Extensions;
    using Newtonsoft.Json;
    using Picavi.JsonRpc.Server.Model;
    using System;

    public class MethodDispatcherModule : NancyModule
    {
        // private Fields

        private readonly RequestBroker requestBroker;

        // Constructors

        public MethodDispatcherModule(RequestBroker requestBroker)
        {
            this.requestBroker = requestBroker;

            Post["/"] = DispatchMethod;
        }

        // private Methods

        private Response DispatchMethod(dynamic parameters)
        {
            var request = this.Request.Body.AsString();

            var jsonRpcRequest = JsonConvert.DeserializeObject<JsonRpcRequest>(request);

            Func<JsonRpcRequest, JsonRpcResponse> dispatchMethod;
            JsonRpcResponse jsonRpcResponse;

            if (requestBroker.TryGetValue(jsonRpcRequest.Method, out dispatchMethod))
            {
                jsonRpcResponse = dispatchMethod(jsonRpcRequest);
            }
            else
            {
                throw new MissingMethodException("jsonRpcRequest", jsonRpcRequest.Method);
            }

            return Response.AsJson(jsonRpcResponse);
        }
    }
}
