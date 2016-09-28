namespace Picavi.JsonRpc.Server.Extensions
{
    using Model;

    public static class RequestValidationExtensions
    {
        public static bool IsValid(this JsonRpcRequest request)
        {
            return     (!string.IsNullOrEmpty(request.Id))
                    && (!string.IsNullOrEmpty(request.JsonRpc))
                    && (!string.IsNullOrEmpty(request.Method));
        }
    }
}
