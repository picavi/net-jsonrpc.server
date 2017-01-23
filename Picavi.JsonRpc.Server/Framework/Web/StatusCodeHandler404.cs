// <copyright file="StatusCodeHandler404.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server.Framework.Exceptions.Web
{
    using Nancy;
    using Nancy.ErrorHandling;
    using Nancy.Responses.Negotiation;

    /// <summary>
    /// Class StatusCodeHandler404
    /// </summary>
    public class StatusCodeHandler404 : IStatusCodeHandler
    {
        /// <summary>
        /// response Negotiator
        /// </summary>
        private IResponseNegotiator responseNegotiator;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusCodeHandler404"/> class.
        /// </summary>
        /// <param name="responseNegotiator">response Negotiator</param>
        public StatusCodeHandler404(IResponseNegotiator responseNegotiator)
        {
            this.responseNegotiator = responseNegotiator;
        }

        /// <summary>
        /// Handles Status Code
        /// </summary>
        /// <param name="statusCode">Http status code</param>
        /// <param name="context">Nancy context></param>
        /// <returns>returns status code</returns>
        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.NotFound;
        }

        /// <summary>
        /// method Handle
        /// </summary>
        /// <param name="statusCode">http status code</param>
        /// <param name="context">Nancy context</param>
        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            context.NegotiationContext = new NegotiationContext();

            Negotiator negotiator = new Negotiator(context)
                .WithStatusCode(HttpServiceErrorDefinition.NotFoundError.HttpStatusCode)
                .WithModel(HttpServiceErrorDefinition.NotFoundError.ServiceErrorModel);
             
           // context.Response = ResponseFactory.BuildError(HttpServiceErrorDefinition.NotFoundError.HttpStatusCode, ErrorMessages.Dsc_ResourceNotFoundError);
           // var code = HttpStatusCode.BadRequest;
            int code = (int)HttpStatusCode.NotFound;
            context.Response = ResponseFactory.BuildSpecicErrors(code, ErrorMessages.Msg_NotFound, ErrorMessages.Dsc_ResourceNotFoundError, null);
        }
    }
}