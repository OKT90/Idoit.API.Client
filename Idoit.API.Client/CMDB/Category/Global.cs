using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
   public class Global : SingleValueCategory
    {
        Dictionary<string, object> parameter;
        List<Response.Global[]> globalResponse;
        public Global(Client myClient) : base(myClient)
        {
            category = "C__CATG__GLOBAL";
        }
        //Read
        public List<Response.Global[]> Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return globalResponse;
        }
        async Task Reading(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            globalResponse = new List<Response.Global[]>();
            globalResponse.Add(await client.GetConnection().InvokeAsync<Response.Global[]>
            ("cmdb.category.read", parameter));
             
        }
    }
}
