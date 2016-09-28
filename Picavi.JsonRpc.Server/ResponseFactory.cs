namespace Picavi.JsonRpc.Server
{
    using Model;
    using System;
    public class ResponseFactory
    {
        public static JsonRpcResponse BuildError(int code, String message)
        {
            var error = new JsonRpcError() { Code = code, Message = message };
            return new JsonRpcResponse() { Error = error };
        }
    }
}
