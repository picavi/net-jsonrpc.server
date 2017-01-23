// <copyright file="ResponseFactory.cs" company="Picavi">
//     Company copyright tag.
// </copyright>

namespace Picavi.JsonRpc.Server
{
    using System;
    using System.IO;
    using Model;
    using Nancy;
    using Nancy.Conventions;

    /// <summary>
    /// Class builds response
    /// </summary>
    public class ResponseFactory
    {
        /// <summary>
        /// method builds error from JSON string
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="message">Error message</param>
        /// <param name="data">Error Description</param>
        /// <param name="id">Request Id</param>
        /// <returns>Returns Response</returns>
        public static JsonRpcResponse BuildError(int code, string message, object data, string id)
        {
            var error = new JsonRpcError() { Code = code, Message = message, Data = data };
            return new JsonRpcResponse() { Error = error, Id = id };
        }

        /// <summary>
        /// method builds error from JSON string
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="message">Error message</param>
        /// <param name="data">Error Description</param>
        /// <param name="id">Request Id</param>
        /// <returns>Returns Response</returns>
        public static Response BuildSpecicErrors(int code, string message, object data, string id)
        {
            var error = new JsonRpcError() { Code = code, Message = message, Data = data };
           JsonRpcResponse res = new JsonRpcResponse() { Error = error, Id = id };
           string resp = Convert.ToString(res);
            var error1 = new Nancy.Response()
            {
                Contents = stream =>
                {
                    var writer = new StreamWriter(stream) { AutoFlush = true };
                    writer.Write(resp);
                }
        };
            error1 = resp;
            return error1;
        }
    }
}
