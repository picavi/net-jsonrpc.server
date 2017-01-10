namespace Picavi.JsonRpc.Server
{
    using Model;
    using System;
    public class ResponseFactory
    {
        public static JsonRpcResponse BuildError(int code, String message, object data, string id)
        {
            var error = new JsonRpcError() { Code = code, Message = message,Data=data };
            return new JsonRpcResponse() { Error = error, Id = id };
        }
     
    }
}
