// <copyright file="InternalServerErrorException.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server.Framework.Exceptions
{
    using System;
    using Picavi.JsonRpc.Server.Framework.Exceptions.Web;

    /// <summary>
    /// class InternalServerErrorException
    /// </summary>
    public class InternalServerErrorException : Exception, IHasHttpServiceError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerErrorException"/> class.
        /// </summary>
        public InternalServerErrorException()
            : base() 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerErrorException"/> class.
        /// </summary>
        /// <param name="message">Error message</param>
        public InternalServerErrorException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerErrorException"/> class.
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">Internal Server Exception</param>
        public InternalServerErrorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Gets HttpServiceError
        /// </summary>
        public HttpServiceError HttpServiceError 
        {
            get { return HttpServiceErrorDefinition.InternalServerError; }
        }
    }
}