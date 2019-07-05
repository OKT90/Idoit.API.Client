using Anemonis.JsonRpc.ServiceClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
  public  class Memory : MultiValueCategory
  {
        Dictionary<string, object> parameter;
        List<Response.Memory[]> memoryResponse ;
        public Memory(Client myClient) : base(myClient)
        {
            category = "C__CATG__MEMORY";
        }
        //Read
        public List<Response.Memory[]> Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return memoryResponse;
        }
        async Task Reading(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            memoryResponse = new List<Response.Memory[]>();
            memoryResponse.Add(await client.GetConnection().InvokeAsync<Response.Memory[]>
            ("cmdb.category.read", parameter));
        }
  }
}
