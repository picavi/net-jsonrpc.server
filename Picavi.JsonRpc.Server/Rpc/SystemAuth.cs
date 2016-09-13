namespace Picavi.JsonRpc.Server.Rpc
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Picavi.JsonRpc.Server.Model;
    using System;

    public class SystemAuth
    {
        // public Methods

        public JsonRpcResponse Login(JsonRpcRequest jsonRpcRequest)
        {
            var credentials = ((JObject)jsonRpcRequest.Params).ToObject<Credentials>();

            //TODO login to external system

            Console.WriteLine(JsonConvert.SerializeObject(credentials));

            var error = new JsonRpcError() { Code = ErrorCodes.E_Ok };

            return new JsonRpcResponse() { Id = jsonRpcRequest.Id, Error = error };
        }
    }
}
