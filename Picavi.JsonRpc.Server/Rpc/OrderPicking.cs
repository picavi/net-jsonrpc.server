// <copyright file="OrderPicking.cs" company="Picavi">
//     Company copyright tag.
// </copyright>

namespace Picavi.JsonRpc.Server.Rpc
{
 // using Newtonsoft.Json;
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using Picavi.JsonRpc.Server.Model;

    /// <summary>
    /// class Order Picking
    /// </summary>
    public class OrderPicking 
    {
         // public Methods 

        /// <summary>
        /// Adds items to list
        /// </summary>
        /// <param name="jsonRpcRequest">JSONRPC Request</param>
        /// <returns>returns JSON Response</returns>
        public JsonRpcResponse GetPickList(JsonRpcRequest jsonRpcRequest)
        {
            JsonRpcResponse response = null;
          
            try
            {
                // TODO query WMS and return pickList
                if (jsonRpcRequest == null)
                {
                    return response;
                }

               if (jsonRpcRequest.Params != null)
               {
                    var pickRequest = ((JObject)jsonRpcRequest.Params).ToObject<Picklist>();
                    var pickList = new Picklist() { Ident = pickRequest.Ident };
                    pickList.Lines.Add(new Pickline() { Ident = "1", Location = "01-05-34-04", Item = "Guinness", Quantity = 120M, Unit = "gallon" });
                    pickList.Lines.Add(new Pickline() { Ident = "2", Location = "01-08-46-01", Item = "Smithwick's", Quantity = 200M, Unit = "gallon" });
                    pickList.Lines.Add(new Pickline() { Ident = "3", Location = "01-12-11-03", Item = "Murphy's Irish Red", Quantity = 80M, Unit = "gallon" });
                    pickList.Lines.Add(new Pickline() { Ident = "4", Location = "01-22-34-05", Item = "Curim Gold Celtic Wheat", Quantity = 40M, Unit = "gallon" });

                    var error = new JsonRpcError() { Code = ErrorCodes.E_Ok };
                    response = new JsonRpcResponse() { Id = jsonRpcRequest.Id, Error = error, Result = pickList };
               }
                else
                {
                new ArgumentNullException(ErrorMessages.Msg_InvalidRequest);
               }
            }
            catch (Exception ex)
            {
                 response = CommonMethods.GetErrorHandlerException(ex, jsonRpcRequest);
            }

            return response;
        }
    }
}
