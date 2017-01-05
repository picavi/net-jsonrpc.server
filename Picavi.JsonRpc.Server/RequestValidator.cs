namespace Picavi.JsonRpc.Server
{
    using Extensions;
    using Model;
    using Nancy;
    using Nancy.Bootstrapper;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    public class RequestJsonValidator : IApplicationStartup
    {
        public void Initialize(IPipelines pipelines)
        {
            pipelines.BeforeRequest.AddItemToStartOfPipeline(async (x, ct) => await Validate(x, ct));
        }

        // private Methods

        private async Task<Nancy.Response> Validate(NancyContext context, CancellationToken ct)
        {
            var jsonString = await context.Request.Body.AsStringAsync(ct);
            ct.ThrowIfCancellationRequested();

            // set streams position to beginning
            context.Request.Body.Seek(0, SeekOrigin.Begin);

            if (!string.IsNullOrEmpty(jsonString))
            {
                try
                {
                    JObject.Parse(jsonString);
                    var jsonRPCRequest = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<JsonRpcRequest>(jsonString));
                    if (!jsonRPCRequest.IsValid())
                    {
                        var respone = ResponseFactory.BuildError(ErrorCodes.E_InvalidRequest, "Request is not valid json-rpc");
                        return respone.ToString();
                    }
                }
                catch (JsonReaderException)
                {
                    var respone = ResponseFactory.BuildError(ErrorCodes.E_InvalidRequest, "Request is not valid json");
                    return respone.ToString();
                }
            }

            return null;
        }
    }
}
