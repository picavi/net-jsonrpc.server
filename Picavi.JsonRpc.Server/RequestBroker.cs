// <copyright file="RequestBroker.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Picavi.JsonRpc.Server.Model;

    /// <summary>
    /// class Request Broker
    /// </summary>
    public class RequestBroker
    {
        // private Fields

        /// <summary>
        /// private field which holds method is of dictionary type
        /// </summary>
        private readonly Dictionary<string, Func<JsonRpcRequest, JsonRpcResponse>> methodMap;

        // Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestBroker"/> class.
        /// </summary>
        public RequestBroker()
        {
            this.methodMap = new Dictionary<string, Func<JsonRpcRequest, JsonRpcResponse>>();
        }

        // public Methods

        /// <summary>
        /// method adds methods to dictionary
        /// </summary>
        /// <param name="methodName">name of the method</param>
        /// <param name="method">method data</param>
        public void Add(string methodName, Func<JsonRpcRequest, JsonRpcResponse> method)
        {
            if (string.IsNullOrEmpty(methodName))
            {
                throw new ArgumentNullException("methodName");
            }

            if (method == null)
            {
                throw new ArgumentNullException("method");
            }

            this.methodMap.Add(methodName, method);
        }

        /// <summary>
        /// method Get value
        /// </summary>
        /// <param name="method">method name</param>
        /// <param name="callback">Call back function</param>
        /// <returns>returns boolean value</returns>
        public bool TryGetValue(string method, out Func<JsonRpcRequest, JsonRpcResponse> callback)
        {
            return this.methodMap.TryGetValue(method, out callback);
        }

        /// <summary>
        /// Gets value asynchronously from a method
        /// </summary>
        /// <param name="method">method name</param>
        /// <returns>returns result</returns>
        public async Task<Func<JsonRpcRequest, JsonRpcResponse>> GetValueAsync(string method)
        {
            return await Task.FromResult(this.methodMap[method]);
        }
    }
}
