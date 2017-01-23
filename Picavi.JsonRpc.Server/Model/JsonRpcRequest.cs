// <copyright file="JsonRpcRequest.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server.Model
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// class JSON Request
    /// </summary>
    public class JsonRpcRequest
    {
        // public Properties

        /// <summary>
        /// Gets JSON RPC
        /// </summary>
        [JsonProperty(PropertyName = "jsonrpc")]
        public string JsonRpc
        {
            get { return "2.0"; } 
        }

        /// <summary>
        /// Gets or sets Method
        /// </summary>
        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets parameters
        /// </summary>
        [JsonProperty(PropertyName = "params")]
        public object Params { get; set; }

        /// <summary>
        /// Gets or sets Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
      
        /// <summary>
        /// method IsValid
        /// </summary>
        /// <returns>returns valid or not </returns>
        public bool IsValid()
        {
            return (!string.IsNullOrEmpty(this.Id))
                    && (!string.IsNullOrEmpty(this.JsonRpc))
                    && (this.JsonRpc.Equals("2.0"))
                    && (!string.IsNullOrEmpty(this.Method));
        }

       // public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);

        /// <summary>
        /// overrides the TOString method
        /// </summary>
        /// <returns>returns string</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
