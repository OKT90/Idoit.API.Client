using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Anemonis.JsonRpc.ServiceClient;
using Newtonsoft.Json;
using Idoit.API.Client.CMDB.Objects.Request;
using Idoit.API.Client.CMDB.Objects.Response;

namespace Idoit.API.Client.CMDB.Objects
{
   public class Objects
   {
        public Objects(Client myClient)
        {
            client = myClient;
        }
        Dictionary<string, object> parameter;
        List<Result[]> response;
         public int id;
        public string type, title, category, purpose, cmdbStatus, description;//Create
        public Client client;
      

        //Read Objects
        public string limit,orderBy,sort; //ReadObjects

        public List<Result[]> Read(Filter filter)
        {
            Task t = Task.Run(() => { Reading(filter).Wait(); }); t.Wait();
            return response;
        }

        async Task Reading(Filter filter)
        {
            object data = client.GetData(filter);
            parameter = client.GetParameter();
            parameter.Add("filter", data);
            parameter.Add("sort", sort);
            parameter.Add("limit", limit);
            parameter.Add("order_by", orderBy);
            response = new List<Result[]>();
            response.Add(await client.GetConnection().InvokeAsync<Result[]> ("cmdb.objects.read",parameter));    
        }
   }
}
