using APICoronaTracker.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using RestSharp;
using Newtonsoft.Json.Linq;
using RestSharp.Serialization.Json;
using System.Configuration;
using System.IO;

namespace APICoronaTracker.Controllers
{
    public class CoronaCountryController : ApiController
    {
        // GET: api/CoronaCountry
        /// <summary>
        /// Status Modeli içerisindeki Listeyi Döndürür.
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
            string dataFilePath = string.Format("{0}\\CoronaCountry.json", ConfigurationManager.AppSettings["DataPath"]);

            FileInfo fileInfo = new FileInfo(dataFilePath);
            
            if (!fileInfo.Exists || (DateTime.Now - fileInfo.LastWriteTime).TotalMinutes > 10)
            {
                var client = new RestClient(ConfigurationManager.AppSettings["ApiURL"]);
                var request = new RestRequest(Method.GET);
                request.AddHeader("authorization", string.Format("apikey {0}", ConfigurationManager.AppSettings["ApiKey"]));
                request.AddHeader("content-type", "application/json");

                IRestResponse response = client.Execute(request);
                CoronaCountryDataset c = Newtonsoft.Json.JsonConvert.DeserializeObject<CoronaCountryDataset>(response.Content.ToString());
                if (!Directory.Exists(ConfigurationManager.AppSettings["DataPath"])) { Directory.CreateDirectory(ConfigurationManager.AppSettings["DataPath"]); }
                System.IO.File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(c.Result)); 
            }

            return System.IO.File.ReadAllText(dataFilePath);
        }
    }
}
