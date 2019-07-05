using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Idoit.API.Client.CMDB.Category.Request;
using Idoit.API.Client.CMDB.Category.Response;
using System.Reflection;
namespace Idoit.API.Client.CMDB.Category
{
   public class Access : MultiValueCategory
    {
        List<Response.Access[]> accessResponse;
        Dictionary<string, object> parameter;

        public Access(Client myClient) : base(myClient)
        {
            category = "C__CATG__ACCESS";
        }
         //Read
        public List<Response.Access[]> Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return accessResponse;
        }
        async Task Reading(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            accessResponse = new List<Response.Access[]>();
            accessResponse.Add(await client.GetConnection().InvokeAsync<Response.Access[]>
            ("cmdb.category.read",parameter));
        }
    }
}
