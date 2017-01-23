// <copyright file="HttpServiceError.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server.Framework.Exceptions.Web
{
    using Nancy;

    /// <summary>
    /// class HttpServiceError
    /// </summary>
    public class HttpServiceError
    {
        /// <summary>
        /// Gets or sets ServiceErrorModel
        /// </summary>
        public ServiceErrorModel ServiceErrorModel { get; set; }

        /// <summary>
        /// Gets or sets HttpStatusCode
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }
    }
} 