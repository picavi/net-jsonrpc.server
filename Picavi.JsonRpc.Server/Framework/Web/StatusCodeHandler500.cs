// <copyright file="StatusCodeHandler500.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server.Framework.Exceptions.Web
{
    using Nancy;
    using Nancy.ErrorHandling;
    using Nancy.Responses.Negotiation;

    /// <summary>
    /// class StatusCodeHandler500s
    /// </summary>
    public class StatusCodeHandler500 : IStatusCodeHandler
    {
        /// <summary>
        /// field responseNegotiator
        /// </summary>
        private IResponseNegotiator responseNegotiator;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusCodeHandler500"/> class.
        /// </summary>
        /// <param name="responseNegotiator">response Negotiator</param>
        public StatusCodeHandler500(IResponseNegotiator responseNegotiator)
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
            return statusCode == HttpStatusCode.InternalServerError;
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
                .WithStatusCode(HttpServiceErrorDefinition.InternalServerError.HttpStatusCode)
                .WithModel(HttpServiceErrorDefinition.InternalServerError.HttpStatusCode);

            int code = (int)HttpStatusCode.InternalServerError;
            context.Response = ResponseFactory.BuildSpecicErrors(code, ErrorMessages.Msg_InternalServerError, ErrorMessages.Dsc_InternalServerError, null);
        }
    }
}