namespace Picavi.JsonRpc.Server.Framework.Exceptions.Web
{
    using System.Xml.Serialization;

    /// <summary>
    /// enum ServiceErrorCode
    /// </summary>
    public enum ServiceErrorCode
    {
        /// <summary>
        /// Type of GeneralError
        /// </summary>
        [XmlEnum("0")]
        GeneralError = 0,

        /// <summary>
        /// Type of NotFound
        /// </summary>
        [XmlEnum("10")]
        NotFound = 10,

        /// <summary>
        /// Type of InternalServerError
        /// </summary>
        [XmlEnum("20")]
        InternalServerError = 20,

        /// <summary>
        /// Type of InvalidToken
        /// </summary>
        [XmlEnum("30")]
        InvalidToken = 30,
    }
}