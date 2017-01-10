namespace Picavi.JsonRpc.Server.Rpc
{
 //   using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Picavi.JsonRpc.Server.Model;

    public class OrderPicking
    {
        // public Methods

        //public JsonRpcResponse GetPickList(JsonRpcRequest jsonRpcRequest)
        //{

        //    JsonRpcResponse response = null;
        //    try
        //    {
        //        //TODO query WMS and return pickList
        //        if (jsonRpcRequest.Params != null)
        //        {
        //            var pickRequest = ((JObject)jsonRpcRequest.Params).ToObject<Picklist>();
        //            var pickList = new Picklist() { Ident = pickRequest.Ident };
        //            pickList.Lines.Add(new Pickline() { Ident = "1", Location = "01-05-34-04", Item = "Guinness", Quantity = 120M, Unit = "gallon" });
        //            pickList.Lines.Add(new Pickline() { Ident = "2", Location = "01-08-46-01", Item = "Smithwick's", Quantity = 200M, Unit = "gallon" });
        //            pickList.Lines.Add(new Pickline() { Ident = "3", Location = "01-12-11-03", Item = "Murphy's Irish Red", Quantity = 80M, Unit = "gallon" });
        //            pickList.Lines.Add(new Pickline() { Ident = "4", Location = "01-22-34-05", Item = "Curim Gold Celtic Wheat", Quantity = 40M, Unit = "gallon" });

        //            var error = new JsonRpcError() { Code = ErrorCodes.E_Ok };
        //            response = new JsonRpcResponse() { Id = jsonRpcRequest.Id, Error = error, Result = pickList };
        //        //    return new JsonRpcResponse() { Id = jsonRpcRequest.Id, Error = error, Result = pickList };
        //        }
        //        else
        //        {
        //            var ID = jsonRpcRequest.Id;
        //            response = ResponseFactory.BuildError(ErrorCodes.E_InternalError, "Internal error", "Internal JSON-RPC error.", ID);
        //          //  return respone;
        //        }
        //    }
        //    catch(System.Exception ex)
        //    {
        //        var ID = jsonRpcRequest.Id;
        //        response = ResponseFactory.BuildError(ErrorCodes.E_InvalidParams, "Invalid params", "Invalid method parameter(s)", ID);
        //     //   return respone;
              
        //    }

        //    return response;
        //}


        public JsonRpcResponse GetPickList(JsonRpcRequest jsonRpcRequest)
        {

            JsonRpcResponse response = null;
            try
            {
                //TODO query WMS and return pickList
              
                
                    var pickRequest = ((JObject)jsonRpcRequest.Params).ToObject<Picklist>();
                    var pickList = new Picklist() { Ident = pickRequest.Ident };
                    pickList.Lines.Add(new Pickline() { Ident = "1", Location = "01-05-34-04", Item = "Guinness", Quantity = 120M, Unit = "gallon" });
                    pickList.Lines.Add(new Pickline() { Ident = "2", Location = "01-08-46-01", Item = "Smithwick's", Quantity = 200M, Unit = "gallon" });
                    pickList.Lines.Add(new Pickline() { Ident = "3", Location = "01-12-11-03", Item = "Murphy's Irish Red", Quantity = 80M, Unit = "gallon" });
                    pickList.Lines.Add(new Pickline() { Ident = "4", Location = "01-22-34-05", Item = "Curim Gold Celtic Wheat", Quantity = 40M, Unit = "gallon" });

                    var error = new JsonRpcError() { Code = ErrorCodes.E_Ok };
                    response = new JsonRpcResponse() { Id = jsonRpcRequest.Id, Error = error, Result = pickList };
                    //    return new JsonRpcResponse() { Id = jsonRpcRequest.Id, Error = error, Result = pickList };
                
              
                  
                    //  return respone;
               
            }
            catch (System.Exception ex)
            {
                var ID = jsonRpcRequest.Id;

                if (jsonRpcRequest.Params == null)
                {
                   
                    response = ResponseFactory.BuildError(ErrorCodes.E_InternalError, "Internal error", "Internal JSON-RPC error.", ID);
                }
                else
                {

                    response = ResponseFactory.BuildError(ErrorCodes.E_InvalidParams, "Invalid params", "Invalid method parameter(s)", ID);
                }
              

            }

            return response;
        }

        public JsonRpcResponse GetPicks(JsonRpcRequest jsonresp)
        {
            var pickRequest = ((JObject)jsonresp.Params).ToObject<Picklist>();
            var pickList = new Picklist() { Ident = pickRequest.Ident };
            var error = new JsonRpcError() { Code = ErrorCodes.E_Ok };
            return new JsonRpcResponse() { Id = jsonresp.Id, Error = error, Result = pickList };
        }

    }
}
