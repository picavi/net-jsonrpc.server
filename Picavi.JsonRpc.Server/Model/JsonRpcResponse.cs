namespace Picavi.JsonRpc.Server.Model
{
    using Newtonsoft.Json;

    public class JsonRpcResponse
    {
        // public Properties

        [JsonProperty(PropertyName = "jsonrpc")]
        public string JsonRpc { get { return "2.0"; } }

        [JsonProperty(PropertyName = "result")]
        public object Result { get; set; }

        [JsonProperty(PropertyName = "error")]
        public object Error { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

       // public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);
        public override string ToString()
        {
           return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
