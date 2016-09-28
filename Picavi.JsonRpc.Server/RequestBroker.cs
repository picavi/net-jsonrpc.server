namespace Picavi.JsonRpc.Server
{
    using Picavi.JsonRpc.Server.Model;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RequestBroker
    {
        // private Fields

        private readonly Dictionary<string, Func<JsonRpcRequest, JsonRpcResponse>> methodMap;

        // Constructors

        public RequestBroker()
        {
            this.methodMap = new Dictionary<string, Func<JsonRpcRequest, JsonRpcResponse>>();
        }

        // public Methods

        public void Add(string methodName, Func<JsonRpcRequest, JsonRpcResponse> method)
        {
            if (String.IsNullOrEmpty(methodName))
            {
                throw new ArgumentNullException("methodName");
            }

            if (method == null)
            {
                throw new ArgumentNullException("method");
            }

            methodMap.Add(methodName, method);
        }

        public bool TryGetValue(string method, out Func<JsonRpcRequest, JsonRpcResponse> callback)
        {
            return methodMap.TryGetValue(method, out callback);
        }

        public async Task<Func<JsonRpcRequest, JsonRpcResponse>> GetValueAsync(string method)
        {
            return await Task.FromResult(methodMap[method]);
        }
    }
}
