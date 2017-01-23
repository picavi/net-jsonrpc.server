// <copyright file="HttpServiceErrorDefinition.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server.Framework.Exceptions.Web
{
    using Nancy;

    /// <summary>
    /// class HttpServiceErrorDefinition
    /// </summary>
    public static class HttpServiceErrorDefinition
    {
        /// <summary>
        /// NotFound Error
        /// </summary>
        public static HttpServiceError NotFoundError = new HttpServiceError
        {
            HttpStatusCode = HttpStatusCode.NotFound,
            ServiceErrorModel = new ServiceErrorModel
            {
                Code = ServiceErrorCode.NotFound,
                Details = "The requested entity was not found."
            }
        };

        /// <summary>
        /// General Error
        /// </summary>
        public static HttpServiceError GeneralError = new HttpServiceError
        {
            HttpStatusCode = HttpStatusCode.BadRequest,
            ServiceErrorModel = new ServiceErrorModel
            {
                Code = ServiceErrorCode.GeneralError,
                Details = "An error occured during processing the request."
            }
        };

        /// <summary>
        /// Internal Server Error
        /// </summary>
         public static HttpServiceError InternalServerError = new HttpServiceError
        {
            HttpStatusCode = HttpStatusCode.InternalServerError,
            ServiceErrorModel = new ServiceErrorModel
            {
                Code = ServiceErrorCode.InternalServerError,
                Details = "There was an internal server error during processing the request."
            }
        };

        /// <summary>
        /// Invalid TokenError
        /// </summary>
        public static HttpServiceError InvalidTokenError = new HttpServiceError
        {
            HttpStatusCode = HttpStatusCode.BadRequest,
            ServiceErrorModel = new ServiceErrorModel
            {
                Code = ServiceErrorCode.InvalidToken,
                Details = "Invalid API Token."
            }
        };
    }
}