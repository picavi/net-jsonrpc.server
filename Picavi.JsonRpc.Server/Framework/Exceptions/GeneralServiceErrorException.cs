// <copyright file="GeneralServiceErrorException.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server.Framework.Exceptions
{
    using System;
    using Picavi.JsonRpc.Server.Framework.Exceptions.Web;

    /// <summary>
    /// class GeneralServiceErrorException
    /// </summary>
    public class GeneralServiceErrorException : Exception, IHasHttpServiceError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralServiceErrorException"/> class.
        /// </summary>
        public GeneralServiceErrorException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralServiceErrorException"/> class.
        /// </summary>
        /// <param name="message">Error message</param>
        public GeneralServiceErrorException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralServiceErrorException"/> class.
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">inner Exception</param>
        public GeneralServiceErrorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Gets  HttpServiceError
        /// </summary>
        public HttpServiceError HttpServiceError
        {
            get { return HttpServiceErrorDefinition.GeneralError; }
        }
    }
}