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
                    var ID = jsonRPCRequest.Id;
                    if (!jsonRPCRequest.IsValid())
                    {
                        
                        var respone = ResponseFactory.BuildError(ErrorCodes.E_InvalidRequest, "Request is not valid json-rpc","The JSON sent is not a valid Request object",ID);
                        return respone.ToString();
                    }
                    
                }
                catch (JsonReaderException ex)
                {
                  //  var respone = ResponseFactory.BuildError(ErrorCodes.E_ParseError, "Parse error", "Invalid JSON was received by the server.An error occurred on the server while parsing the JSON text");
                   
                    var respone = ResponseFactory.BuildError(ErrorCodes.E_ParseError, "Parse error", "Invalid JSON was received by the server.An error occurred on the server while parsing the JSON text",null);
                    return respone.ToString();
                }
            }
            else
            {
                var respone = ResponseFactory.BuildError(ErrorCodes.E_InvalidRequest, "Request is not valid json-rpc", "The JSON sent is not a valid Request object", null);
                return respone.ToString();
            }
          

            return null;
        }
    }
}
