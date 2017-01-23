// <copyright file="JsonRpcResponse.cs" company="Picavi">
//     Company copyright tag.
// </copyright>

namespace Picavi.JsonRpc.Server.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// class JSONRPC Response
    /// </summary>
    public class JsonRpcResponse
    {
        // public Properties

        /// <summary>
        /// Gets JSONRPC
        /// </summary>
        [JsonProperty(PropertyName = "jsonrpc")]
        public string JsonRpc 
        {
            get { return "2.0"; } 
        }

        /// <summary>
        /// Gets or sets Result
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public object Result { get; set; }

        /// <summary>
        /// Gets or sets Error
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public object Error { get; set; }

        /// <summary>
        /// Gets or sets Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

       // public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);

        /// <summary>
        /// overrides the TOString method
        /// </summary>
        /// <returns>returns string </returns>
        public override string ToString()
        {
           return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
