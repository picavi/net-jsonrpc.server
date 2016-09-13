namespace Picavi.JsonRpc.Server
{
    public static class ErrorCodes
    {
        // public Constants

        public const int E_ParseError = -32700;

        public const int E_InvalidRequest = -32600;

        public const int E_MethodNoFound = -32601;

        public const int E_InvalidParams = -32602;

        public const int E_InternalError = -32603;

        public const int E_Ok = 0x00000000;
    }
}
