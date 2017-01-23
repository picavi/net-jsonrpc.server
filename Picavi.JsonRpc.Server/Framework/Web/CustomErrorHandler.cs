// <copyright file="CustomErrorHandler.cs" company="Picavi">
//     Company copyright tag.
// </copyright>

namespace Picavi.JsonRpc.Server.Framework.Exceptions.Web
{
    using System;
    using System.Reflection;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Responses.Negotiation;

    /// <summary>
    /// class Custom Error Handler
    /// </summary>
    public static class CustomErrorHandler
    {
        /// <summary>
        /// method enable
        /// </summary>
        /// <param name="pipelines">parameter pipelines</param>
        /// <param name="responseNegotiator">response Negotiator</param>
        public static void Enable(IPipelines pipelines, IResponseNegotiator responseNegotiator)
        {
            if (pipelines == null)
            {
                throw new ArgumentNullException("pipelines");
            }

            if (responseNegotiator == null)
            {
                throw new ArgumentNullException("responseNegotiator");
            }

            pipelines.OnError += (context, exception) => HandleException(context, exception, responseNegotiator);
        }

        /// <summary>
        /// Handle Exception
        /// </summary>
        /// <param name="context">Nancy Context</param>
        /// <param name="exception">Exception exception</param>
        /// <param name="responseNegotiator">response Negotiator</param>
        /// <returns>returns Error</returns>
        private static string HandleException(NancyContext context, Exception exception, IResponseNegotiator responseNegotiator)
        {
            return ResponseFactory.BuildError(ErrorCodes.E_InternalError, ErrorMessages.Msg_InternalError, ErrorMessages.Msg_InternalError, string.Empty).ToString();
        }
    }
}