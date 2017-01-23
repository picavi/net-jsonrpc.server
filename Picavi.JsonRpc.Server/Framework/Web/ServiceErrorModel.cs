// <copyright file="ServiceErrorModel.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server.Framework.Exceptions.Web
{
    /// <summary>
    /// class ServiceErrorModel
    /// </summary>
    public class ServiceErrorModel
    {
        /// <summary>
        /// Gets or sets Code
        /// </summary>
        public ServiceErrorCode Code { get; set; }

        /// <summary>
        /// Gets or sets Details
        /// </summary>
        public string Details { get; set; }
    }
}