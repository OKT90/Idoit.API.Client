using Anemonis.JsonRpc.ServiceClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
   public class Location : SingleValueCategory
    {
        Dictionary<string, object> parameter;
        List<Response.Location[]> locationResponse;
        public Location(Client myClient) : base(myClient)
        {
            category = "C__CATG__LOCATION";
        }
        //Read
        public List<Response.Location[]> Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return locationResponse;
        }
        async Task Reading(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            locationResponse = new List<Response.Location[]>();
            locationResponse.Add(await client.GetConnection().InvokeAsync<Response.Location[]>
            ("cmdb.category.read", parameter));
             
        }
    }
}
