using Anemonis.JsonRpc.ServiceClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
   public class IP : MultiValueCategory
    {
        Dictionary<string, object> parameter;
        List<Response.IP[]> ipResponse;
        public IP(Client myClient) : base(myClient)
        {
            category = "C__CATG__IP";
        }
        //Read
        public List<Response.IP[]> Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return ipResponse;
        }
        async Task Reading(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            ipResponse = new List<Response.IP[]>();
            ipResponse.Add(await client.GetConnection().InvokeAsync<Response.IP[]>
            ("cmdb.category.read", parameter));
             
        }
    }
}
