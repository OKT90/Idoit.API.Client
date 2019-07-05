using Anemonis.JsonRpc.ServiceClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
    public class Port : MultiValueCategory
    {
        Dictionary<string, object> parameter;

        List<Response.Port[]> portfaktorResponse;
        public Port(Client myClient) : base(myClient)
        {
            category = "C__CATG__NETWORK_PORT";
        }
        //Read
        public List<Response.Port[]> Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return portfaktorResponse;
        }
        async Task Reading(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            portfaktorResponse = new List<Response.Port[]>();
            portfaktorResponse.Add(await client.GetConnection().InvokeAsync<Response.Port[]>
            ("cmdb.category.read", parameter));     
        }
    }
}
