// <copyright file="JsonRpcError.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server
{
    using Newtonsoft.Json;

    /// <summary>
    /// class JSON Error
    /// </summary>
    public class JsonRpcError
    {
        // public Properties

        /// <summary>
        /// Gets or sets code
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets Message
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets Data
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public object Data { get; set; }
    }
}
