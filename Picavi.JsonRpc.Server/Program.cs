// <copyright file="Program.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server
{
    using System;
    using Nancy.Hosting.Self;
    using Newtonsoft.Json;
    using Picavi.JsonRpc.Server.Model;

    /// <summary>
    /// class Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Method 
        /// </summary>
        /// <param name="args">parameters arguments</param>
        public static void Main(string[] args)
        {
            try
            {
                using (var host = new NancyHost(new HostConfiguration() { RewriteLocalhost = false }, new Uri(@"http://localhost:9130")))
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
