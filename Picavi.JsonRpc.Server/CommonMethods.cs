using Picavi.JsonRpc.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picavi.JsonRpc.Server
{
    public static class CommonMethods
    {
        public static JsonRpcResponse GetErrorHandlerException(Exception ex,JsonRpcRequest req)
        {
           
            if(ex != null && ex.InnerException != null)
            {
                string error = ex.InnerException.ToString();
                var respone = ResponseFactory.BuildError(ErrorCodes.E_InternalError, ErrorMessages.Msg_InternalError, ErrorMessages.Dsc_InternalError + "" + error, req.Id);
                return respone;
            }
            return null ;
        }

    }
}
