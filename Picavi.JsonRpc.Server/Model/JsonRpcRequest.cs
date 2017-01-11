namespace Picavi.JsonRpc.Server.Model
{
    using Newtonsoft.Json;

    public class JsonRpcRequest
    {
        // public Properties

        [JsonProperty(PropertyName = "jsonrpc")]
        public string JsonRpc { get { return "2.0"; } }

        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }

        [JsonProperty(PropertyName = "params")]
        public object Params { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public bool IsValid()
        {
            return (!string.IsNullOrEmpty(this.Id))
                    && (!string.IsNullOrEmpty(this.JsonRpc))
                    && (this.JsonRpc.Equals("2.0"))
                    && (!string.IsNullOrEmpty(this.Method));
        }

       // public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);

        public override string ToString()
        {
          return   JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
