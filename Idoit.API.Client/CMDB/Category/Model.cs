using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Anemonis.JsonRpc.ServiceClient;
using Idoit.API.Client.CMDB.Category.Request;
using Idoit.API.Client.CMDB.Category.Response;
using ModelRequest = Idoit.API.Client.CMDB.Category.Request.Model;
namespace Idoit.API.Client.CMDB.Category
{
  public  class Model : SingleValueCategory
  {
        Dictionary<string, object> parameter;

        List<Response.Model[]> modelResponse;

        public Model(Client myClient) : base(myClient)
        {
            category = "C__CATG__MODEL";
        }

        //Read
        public List<Response.Model[]> Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return modelResponse;
        }
        async Task Reading(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            modelResponse = new List<Response.Model[]>();
            modelResponse.Add(await client.GetConnection().InvokeAsync<Response.Model[]>
           ("cmdb.category.read", parameter));           
        }
  }
}
