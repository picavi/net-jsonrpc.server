// <copyright file="HttpServiceErrorUtilities.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server.Framework.Exceptions.Web
{
    using System;

    /// <summary>
    /// class HttpServiceErrorUtilities
    /// </summary>
    public static class HttpServiceErrorUtilities
    {
        /// <summary>
        /// Extract From Exception
        /// </summary>
        /// <param name="exception">exception message</param>
        /// <param name="defaultValue">error default value</param>
        /// <returns>returns error</returns>
        public static HttpServiceError ExtractFromException(Exception exception, HttpServiceError defaultValue)
        {
            HttpServiceError result = defaultValue;

            if (exception != null)
            {
                IHasHttpServiceError exceptionWithServiceError = exception as IHasHttpServiceError;

                if (exceptionWithServiceError != null)
                {
                    result = exceptionWithServiceError.HttpServiceError;
                }
            }

            return result;
        }
    }
}