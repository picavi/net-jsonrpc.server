// <copyright file="NotFoundErrorException.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server.Framework.Exceptions
{
    using System;
    using Picavi.JsonRpc.Server.Framework.Exceptions.Web;

    /// <summary>
    /// class NotFoundErrorException
    /// </summary>
    public class NotFoundErrorException : Exception, IHasHttpServiceError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundErrorException"/> class.
        /// </summary>
        public NotFoundErrorException()
            : base() 
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundErrorException"/> class.
        /// </summary>
        /// <param name="message">Error message</param>
        public NotFoundErrorException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundErrorException"/> class.
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">NotFound Exception</param>
        public NotFoundErrorException(string message, Exception innerException)
            : base(message, innerException) 
        { 
        }

        /// <summary>
        /// Gets HttpServiceError
        /// </summary>
        public HttpServiceError HttpServiceError
        { 
            get { return HttpServiceErrorDefinition.NotFoundError; } 
        }
    }
}