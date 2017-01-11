using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picavi.JsonRpc.Server
{
  public static  class ErrorMessage
    {
        public const string Msg_ParseError = "Parse error";

        public const string Msg_InvalidRequest = "Invalid Request";

        public const string Msg_MethodNoFound = "Method not found";

        public const string Msg_InvalidParams = "Invalid params";

        public const string Msg_InternalError = "Internal error";
        public const string Msg_ServerError = "Server error";



        public const string Dsc_ParseError = "Invalid JSON was received by the server.An error occurred on the server while parsing the JSON text";

        public const string Dsc_InvalidRequest = "The JSON sent is not a valid Request object";

        public const string Dsc_MethodNoFound = "The method does not exist / is not available";

        public const string Dsc_InvalidParams = "Invalid method parameter(s)";

        public const string Dsc_InternalError = "Internal JSON-RPC error";
        public const string Dsc_ServerError = "Reserved for implementation-defined server-errors";





      



    }
}
