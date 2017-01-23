// <copyright file="InvalidTokenErrorException.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server.Framework.Exceptions
{
    using System;
    using Picavi.JsonRpc.Server.Framework.Exceptions.Web;

    /// <summary>
    /// class InvalidTokenErrorException
    /// </summary>
    public class InvalidTokenErrorException : Exception, IHasHttpServiceError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTokenErrorException"/> class.
        /// </summary>
        public InvalidTokenErrorException()
            : base()
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTokenErrorException"/> class.
        /// </summary>
        /// <param name="message">Error message</param>
        public InvalidTokenErrorException(string message)
            : base(message) 
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTokenErrorException"/> class.
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">Invalid Token Exception</param>
        public InvalidTokenErrorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Gets HttpServiceError
        /// </summary>
        public HttpServiceError HttpServiceError
        { 
            get { return HttpServiceErrorDefinition.InvalidTokenError; }
        }
    }
}