using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Idoit.API.Client.CMDB.Category.Request;
using Idoit.API.Client.CMDB.Category.Response;
using Idoit.API.Client.ApiException;

namespace Idoit.API.Client.CMDB.Category
{
   public abstract class  Category 
    {
        public string category;
        public int id;
        public Client client;
        Dictionary<string, object> parameter;

        public Category(Client myClient)
        {
            client = myClient;
        }
        //Create
        public int Create(int objectId, IRequest request)
        {
            Task t = Task.Run(() => { Creating(request, objectId).Wait();}); t.Wait();
            return id;
        }
        
        async Task Creating(IRequest request ,int objectId)
        {
            object data = client.GetData(request);
            if (data == null)
            {
                throw new Exception("Data is missing");
            }
            parameter = client.GetParameter();
            parameter.Add("data", data);
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            Response.Response response = await client.GetConnection().InvokeAsync<Response.Response>
            ("cmdb.category.create", parameter);
            id = response.id;
            if (response.success == false)
            {
               throw new IdoitAPIClientBadResponseException(response.message);
            }
        }
        //Update
        public void Update(int objectId,IRequest request)
        {
            Task t = Task.Run(() => { Updating(objectId, request).Wait();}); t.Wait();
        }
        async Task Updating( int objectId,IRequest request )
        {
            object data = client.GetData(request);
            
            if (data == null)
            {
                throw new Exception("Data is missing");
            }
            parameter = client.GetParameter();
            parameter.Add("data", data);
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            Response.Response response = await client.GetConnection().InvokeAsync<Response.Response>
                    ("cmdb.category.update", parameter);
            if (response.success == false)
            {
               throw new IdoitAPIClientBadResponseException(response.message);
            }
        }
        //Quickpurge
        public void Quickpurge(int objectId, int entryID)
        {
            if (entryID == 0)
            {
                throw new Exception("EntryID is missing");
            }
            Task t = Task.Run(() => { QuickPurging(objectId, entryID).Wait(); }); t.Wait();
        }
        async Task QuickPurging(int objectId, int entryID)
        {
            parameter = client.GetParameter();
            parameter.Add("cateID", entryID);
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            Response.Response result = await client.GetConnection().InvokeAsync<Response.Response>
            ("cmdb.category.quickpurge", parameter);
            if (result.success == false)
            {
                throw new IdoitAPIClientBadResponseException(result.message);
            }
        }
    }
}
