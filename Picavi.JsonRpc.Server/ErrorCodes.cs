// <copyright file="ErrorCodes.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server
{
    /// <summary>
    /// class Defines Constant Error codes
    /// </summary>
    public static class ErrorCodes
    {
        // public Constants

        /// <summary>
        /// field Parse error
        /// </summary>
        public const int E_ParseError = -32700;

        /// <summary>
        /// field Invalid request
        /// </summary>
        public const int E_InvalidRequest = -32600;

        /// <summary>
        /// field Method not Found
        /// </summary>
        public const int E_MethodNoFound = -32601;

        /// <summary>
        /// Field Invalid parameters
        /// </summary>
        public const int E_InvalidParams = -32602;

        /// <summary>
        /// field Internal Error
        /// </summary>
        public const int E_InternalError = -32603;

        /// <summary>
        /// field ok
        /// </summary>
        public const int E_Ok = 0x00000000;
    }
}
