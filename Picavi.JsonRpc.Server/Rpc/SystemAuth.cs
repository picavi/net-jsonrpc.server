// <copyright file="SystemAuth.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server.Rpc
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Picavi.JsonRpc.Server.Model;

    /// <summary>
    /// class  System Authentication
    /// </summary>
    public class SystemAuth
    {
        /// <summary>
        /// method login
        /// </summary>
        /// <param name="jsonRpcRequest">JSONRPC Request</param>
        /// <returns>returns JSONRPC Response</returns>
        public JsonRpcResponse Login(JsonRpcRequest jsonRpcRequest)
        {
            var credentials = ((JObject)jsonRpcRequest.Params).ToObject<Credentials>();

            // TODO login to external system
            Console.WriteLine(JsonConvert.SerializeObject(credentials));

            var error = new JsonRpcError() { Code = ErrorCodes.E_Ok };

            return new JsonRpcResponse() { Id = jsonRpcRequest.Id, Error = error };
        }
    }
}
