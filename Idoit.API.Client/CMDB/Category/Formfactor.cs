using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Anemonis.JsonRpc.ServiceClient;
using Idoit.API.Client.CMDB.Category.Request;
using Idoit.API.Client.CMDB.Category.Response;
using System.Reflection;

namespace Idoit.API.Client.CMDB.Category
{
   public class Formfactor : SingleValueCategory
    {
        Dictionary<string, object> parameter;
        List<Response.Formfactor[]> formfactorResponse;
        public Formfactor(Client myClient) : base(myClient)
        {
            category = "C__CATG__FORMFACTOR";
        }
        //Read
        public List<Response.Formfactor[]> Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return formfactorResponse;
        }
        async Task Reading(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            formfactorResponse = new List<Response.Formfactor[]>();
            formfactorResponse.Add(await client.GetConnection().InvokeAsync<Response.Formfactor[]>
            ("cmdb.category.read", parameter));
            
        }

    }
}
