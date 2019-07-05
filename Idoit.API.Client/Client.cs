using Idoit.API.Client.CMDB.Category.Request;
using Idoit.API.Client.CMDB.Objects;
using ObjectsFilter = Idoit.API.Client.CMDB.Objects.Request.Filter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
 using Anemonis.JsonRpc.ServiceClient;
using System.Threading.Tasks;
using Idoit.API.Client.Idoit;
using Idoit.API.Client.ApiException;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Idoit.API.Client
{
   public class Client
   {
        public string Url;
        public string Apikey;
        public string Language;
        public string Username;
        public string Password;
        public string sessionId;
        JsonRpcClient JsonRpcClient;

        public Client(string url, string apikey, string language)
        {
            Language = language;
            Apikey = apikey;
            Url = url;
        }
        public JsonRpcClient GetConnection()
        {
            if (JsonRpcClient == null)
            {
               JsonRpcClient = new JsonRpcClient(Url, GetClient());
            }
            return JsonRpcClient;
        }
        public Dictionary<string, object> GetParameter()
        {
            var parameters = new Dictionary<string, object>
            {
                ["apikey"] = Apikey,
                ["language"] = Language
            };
            return parameters;
        }
        public object GetData(IRequest request)
        {
            string Json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            { DefaultValueHandling = DefaultValueHandling.Ignore });
            object data = JsonConvert.DeserializeObject(Json);
            return data;
        }
        public object GetData(ObjectsFilter filter)
        {
            string Json = JsonConvert.SerializeObject(filter, new JsonSerializerSettings
            { DefaultValueHandling = DefaultValueHandling.Ignore });
            object data = JsonConvert.DeserializeObject(Json);
            return data;
        }       
        // Basic auth
        public HttpClient GetClient()
        {
            if (sessionId == null)
            {
                var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Username}:{Password}")));
                var client = new HttpClient()
                {
                    DefaultRequestHeaders = { Authorization = authValue }
                };
                return client;
            }
            else
            {
                var authValue = new AuthenticationHeaderValue("Session", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{sessionId}")));
                var client = new HttpClient()
                {
                    DefaultRequestHeaders = { Authorization = authValue }
                };
                return client;
            }

        }
   }
}
