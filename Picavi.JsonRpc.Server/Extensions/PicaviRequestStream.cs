namespace Picavi.JsonRpc.Server.Extensions
{
    using Nancy.IO;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public static class PicaviRequestStream
    {
        public static async Task<string> AsStringAsync(this RequestStream request, CancellationToken ct)
        {
            using (var reader = new StreamReader(request))
            {
                var result = await reader.ReadToEndAsync();
                ct.ThrowIfCancellationRequested();
                // set streams position to beginning
                request.Seek(0, SeekOrigin.Begin);
                return result;
            }
        }
    }
}
