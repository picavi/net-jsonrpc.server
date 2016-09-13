using Nancy.Hosting.Self;
using Newtonsoft.Json;
using Picavi.JsonRpc.Server.Model;
using System;

namespace Picavi.JsonRpc.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(new HostConfiguration() { RewriteLocalhost = false }, new Uri("http://localhost:9130")))
            {
                host.Start();

                Console.WriteLine("Running on http://localhost:9130");

                var credentials = new Credentials() { Username = "John.Doe", Password = "secret" };
                var jsonRpcRequest = new JsonRpcRequest() { Id = "1", Method = "system.login", Params = credentials };

                Console.WriteLine("\nExample system.login request:");
                Console.WriteLine(JsonConvert.SerializeObject(jsonRpcRequest));

                var pickList = new Picklist() { Ident = "4711" };
                jsonRpcRequest = new JsonRpcRequest() { Id = "2", Method = "orderPicking.getPickList", Params = pickList };

                Console.WriteLine("\nExample orderPicking.getPickList request:");
                Console.WriteLine(JsonConvert.SerializeObject(jsonRpcRequest));

                Console.ReadLine();
            }
        }
    }
}
