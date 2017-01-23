// <copyright file="PicaviRequestStream.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server.Extensions
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Nancy.IO;

   /// <summary>
    /// Class RequestStream
   /// </summary>
    public static class PicaviRequestStream
    {
        /// <summary>
        /// method  AsStringAsync
        /// </summary>
        /// <param name="request">request Stream</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns>returns Result</returns>
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
