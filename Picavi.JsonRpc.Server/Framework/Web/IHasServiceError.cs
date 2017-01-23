namespace Picavi.JsonRpc.Server.Framework.Exceptions.Web
{
    using Nancy;

    /// <summary>
    /// Interface IHasHttpServiceError
    /// </summary>
    public interface IHasHttpServiceError
    {
        /// <summary>
        /// Gets HttpServiceError
        /// </summary>
        HttpServiceError HttpServiceError { get; }
    }
}