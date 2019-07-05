using Anemonis.JsonRpc.ServiceClient;
using Idoit.API.Client.ApiException;
using Idoit.API.Client.CMDB.Category.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
    public abstract class MultiValueCategory : Category
    {
        Dictionary<string, object> parameter;
        public MultiValueCategory(Client myClient) : base(myClient)
        {
        }
        //Update
        new public void Update(int objectId, IRequest request)
        {
            if (request.category_id == 0)
            { 
                throw new Exception("CateId is missing");
            }
            base.Update(objectId, request);
        }
        //Delete
        public void Delete(int objectId, int entryID)
        {
            if (entryID == 0)
            {
                throw new Exception("EntryID is missing");
            }
            Task t = Task.Run(() => { Deleting(objectId, entryID).Wait(); }); t.Wait();
        }
        async Task Deleting(int objectId, int entryID)
        {
            //The return Values as Object from diffrence Classes
            parameter = client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("cateID", entryID);
            parameter.Add("category", category);
            Response.Response result = await client.GetConnection().InvokeAsync<Response.Response>
            ("cmdb.category.delete", parameter);
            if (result.success == false)
            {
               throw new IdoitAPIClientBadResponseException(result.message);
            }    
        }
    }
}
