// <copyright file="RequestJsonValidator.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Model;
    using Nancy;
    using Nancy.Bootstrapper;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// class Validates the Request
    /// </summary>
    public class RequestJsonValidator : IApplicationStartup
    {
        /// <summary>
        /// private field list contains JSON parameters
        /// </summary>
       private List<string> jsonlist = new List<string>();

        /// <summary>
        /// private field name
        /// </summary>
        private string name;

        /// <summary>
        /// private field holds list of invalid parameters
        /// </summary>
       private string invalidparams = string.Empty;

        /// <summary>
        /// private field count
        /// </summary>
       private int count = 0;

        /// <summary>
        /// method Initialize add items to pipeline
        /// </summary>
        /// <param name="pipelines">parameter pipelines </param>
        public void Initialize(IPipelines pipelines)
        {
            pipelines.BeforeRequest.AddItemToStartOfPipeline(async (x, ct) => await this.Validate(x, ct));
        }
      
        /// <summary>
        /// validates sub JSON string  
        /// </summary>
        /// <param name="token">Token JToken</param>
        /// <returns>List of JSON parameters</returns>
        public List<string> Validatesubjson(JToken token)
        {
            if (token == null)
            {
                return null;
            }

            JObject jobj = JObject.Parse(Convert.ToString(token));
            foreach (JProperty y in (JToken)jobj)
            {
                string name = y.Name;
                JToken value1 = y.Value;
                if (name.Contains("\r\n"))
                {
                    name = name.Replace("\r\n", string.Empty);
                }

                this.jsonlist.Add(name);
            }

            return this.jsonlist;
        }

        /// <summary>
        /// parses JSON string and get all the invalid parameters
        /// </summary>
        /// <param name="obj">JSON object</param>
        /// <param name="propertiesList">List of properties</param>
        private void GetInvalidParams(JObject obj, List<string> propertiesList)
        {
            foreach (JProperty x in (JToken)obj)
            {
                this.name = x.Name;
                JToken value = x.Value;

                if (value.HasValues)
                {
                    this.Validatesubjson(value);
                }

                if (this.name.Contains("\r\n"))
                {
                    this.name = this.name.Replace("\r\n", string.Empty);
                }

                this.jsonlist.Add(this.name);
            }

            if (this.jsonlist.Count != 0)
            {
                foreach (var item in this.jsonlist)
                {
                    if (propertiesList.Count != 0)
                    {
                        if (propertiesList.FindIndex(x => x.Equals(item, StringComparison.OrdinalIgnoreCase)) != -1)
                        {
                            continue;
                        }
                        else
                        {
                            // Console.WriteLine(item + "   is invalid parameter");
                            if (this.count == 0)
                            {
                                this.count++;
                                this.invalidparams = item;
                            }
                            else
                            {
                                this.invalidparams = this.invalidparams + "," + item;
                            }
                        }
                    }
                }
            }

            this.count = 0;
            this.jsonlist.Clear();
        }

        /// <summary>
        /// used to get all properties from class
        /// </summary>
        /// <returns>returns list of properties from model classes</returns>
        private List<string> GetPropertiesNameOfClass()
        {
            // this will get all the properties from  JsonRpcRequest class
            JsonRpcRequest jreq = new JsonRpcRequest();

            System.Collections.Generic.List<string> propertyList = new System.Collections.Generic.List<string>();
            if (jreq != null)
            {
                foreach (var prop in jreq.GetType().GetProperties())
                {
                    propertyList.Add(prop.Name);
                }
            }

            // this will get all the properties from  Picklist class
            Picklist plist = new Picklist();
            if (plist != null)
            {
                foreach (var prop in plist.GetType().GetProperties())
                {
                    propertyList.Add(prop.Name);
                }
            }
            //// returns list of properties from classes
            return propertyList;
        }

        // private Methods

        /// <summary>
        /// Validates Request using nancy context
        /// </summary>
        /// <param name="context">Nancy context</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns>returns result</returns>
        private async Task<Nancy.Response> Validate(NancyContext context, CancellationToken ct)
        {
            var jsonString = await context.Request.Body.AsStringAsync(ct);
            ct.ThrowIfCancellationRequested();
            
            // set streams position to beginning
            context.Request.Body.Seek(0, SeekOrigin.Begin);
           
             System.Collections.Generic.List<string> proplist = this.GetPropertiesNameOfClass();
            if (!string.IsNullOrEmpty(jsonString))
            {
                try
                {
                  JObject rawobj = JObject.Parse(jsonString);
                  var jsonRPCRequest = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<JsonRpcRequest>(jsonString));
                  var id = jsonRPCRequest.Id;

                    // used to get invalid parameters 
                 this.GetInvalidParams(rawobj, proplist);
                 
                   if (this.invalidparams != string.Empty)
                   {
                       string error = ErrorMessages.Dsc_InvalidParams;
                       string[] paramss = this.invalidparams.Split(',');
                       if (paramss.Length == 1)
                       {
                           error = error.Replace("{0}", this.invalidparams + " is ");
                       }
                       else
                       {
                           error = error.Replace("{0}", this.invalidparams + " are ");
                       }

                       var respone = ResponseFactory.BuildError(ErrorCodes.E_InvalidParams, ErrorMessages.Msg_InvalidParams, error, id);
                       this.invalidparams = string.Empty;
                       return Convert.ToString(respone);
                   }
               
                    if (!jsonRPCRequest.IsValid())
                    {
                        var respone = ResponseFactory.BuildError(ErrorCodes.E_InvalidRequest, ErrorMessages.Msg_InvalidRequest, ErrorMessages.Dsc_InvalidRequest, id);
                        return Convert.ToString(respone);
                    }

                    // This condition is only valid, if we expect atleast one parameter for every request.  If not, we need to remove below condition here.
                    if (jsonRPCRequest.Params == null)
                    {
                        var respone = ResponseFactory.BuildError(ErrorCodes.E_InvalidRequest, ErrorMessages.Msg_InvalidRequest, ErrorMessages.Dsc_InvalidRequest, id);
                        return Convert.ToString(respone);
                    }
                }
                catch (JsonReaderException ex)
                {
                   var respone = ResponseFactory.BuildError(ErrorCodes.E_ParseError, ErrorMessages.Msg_ParseError, ErrorMessages.Dsc_ParseError, null);
                   return Convert.ToString(respone);
                }
            }
            else
            {
                var respone = ResponseFactory.BuildError(ErrorCodes.E_InvalidRequest, ErrorMessages.Msg_InvalidRequest, ErrorMessages.Dsc_InvalidRequest, null);
                return Convert.ToString(respone);
            }

            return null;
        }
    } 
}
