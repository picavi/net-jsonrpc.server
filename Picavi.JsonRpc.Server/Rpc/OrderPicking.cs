namespace Picavi.JsonRpc.Server.Rpc
{
    using Newtonsoft.Json.Linq;
    using Picavi.JsonRpc.Server.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OrderPicking
    {
        // public Methods

        public JsonRpcResponse GetPickList(JsonRpcRequest jsonRpcRequest)
        {
            var pickRequest = ((JObject)jsonRpcRequest.Params).ToObject<Picklist>();

            //TODO query WMS and return pickList

            var pickList = new Picklist() { Ident = pickRequest.Ident };
            pickList.Lines.Add(new Pickline() { Ident = "1", Location = "01-05-34-04", Item = "Guinness", Quantity = 120M, Unit = "gallon" });
            pickList.Lines.Add(new Pickline() { Ident = "2", Location = "01-08-46-01", Item = "Smithwick's", Quantity = 200M, Unit = "gallon" });
            pickList.Lines.Add(new Pickline() { Ident = "3", Location = "01-12-11-03", Item = "Murphy's Irish Red", Quantity = 80M, Unit = "gallon" });
            pickList.Lines.Add(new Pickline() { Ident = "4", Location = "01-22-34-05", Item = "Curim Gold Celtic Wheat", Quantity = 40M, Unit = "gallon" });

            var error = new JsonRpcError() { Code = ErrorCodes.E_Ok };

            return new JsonRpcResponse() { Id = jsonRpcRequest.Id, Error = error, Result = pickList };
        }
    }
}
