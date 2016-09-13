namespace Picavi.JsonRpc.Server
{
    using Newtonsoft.Json;

    public class JsonRpcError
    {
        // public Properties

        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "data")]
        public object Data { get; set; }
    }
}
