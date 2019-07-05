using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Anemonis.JsonRpc.ServiceClient;
using Newtonsoft.Json;
using  Idoit.API.Client.CMDB.Object.Response;
using Idoit.API.Client.ApiException;

namespace Idoit.API.Client.CMDB.Object
{
   public class Object
   {
        Dictionary<string, object> parameter;
        public string success;
        public int id;
        public Client client;
        public string type, title, category, purpose, cmdbStatus, description;//Create
        Result response ;
        public Object(Client myClient)
        {
            client = myClient;
        }

        //Create
        public int Create()
        {
            if (type == null)
            {
                throw new IdoitAPIClientBadResponseException("Type is missing");
            }
            else if (title == null)
            {
                throw new IdoitAPIClientBadResponseException("Title is missing");
            }
            Task t = Task.Run(() => { Creating().Wait(); }); t.Wait();
            return id;
        }
        async Task Creating()
        {
            parameter = client.GetParameter();
            parameter.Add("type", type);
            parameter.Add("title", title);
            parameter.Add("purpose", purpose);
            parameter.Add("cmdb_status", cmdbStatus);
            parameter.Add("description", description);
            parameter.Add("category", category);
            Response.Response response = await client.GetConnection().InvokeAsync<Response.Response>
            ("cmdb.object.create", parameter);
            id = response.id;
              if (response.success == false)
              {
                 throw new IdoitAPIClientBadResponseException(response.message);
              }
        }

        //Update
        public void Update(int objectId)
        {
            if (title == null)
            {
                throw new IdoitAPIClientBadResponseException("Title is missing");
            }
            Task t = Task.Run(() => { Updating(objectId).Wait(); }); t.Wait();
        }
        async Task Updating(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("id", objectId);
            parameter.Add("title", title);
            Response.Response response = await client.GetConnection().InvokeAsync<Response.Response>
            ("cmdb.object.update", parameter);
               if (response.success==false)
               {
                  throw new IdoitAPIClientBadResponseException("Nope!");
               }
        }
        //Delete
        public void Delete(int objectId)
        {
            Task t = Task.Run(() => { Deleting(objectId).Wait(); }); t.Wait();
        }
        async Task Deleting(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("id", objectId);
            parameter.Add("status", "C__RECORD_STATUS__DELETED");
            Response.Response response = await client.GetConnection().InvokeAsync<Response.Response>
            ("cmdb.object.delete", parameter);
               if (response.success == false)
               {
                  throw new IdoitAPIClientBadResponseException("Nope!");
               }
        }

        //purge
        public void Purge(int objectId)
        {
            Task t = Task.Run(() => { Purging(objectId).Wait(); }); t.Wait();
        }
        async Task Purging(int objectId)
        {
            //The return Values as Object from diffrence Classes
            parameter = client.GetParameter();
            parameter.Add("id", objectId);
            parameter.Add("status", "C__RECORD_STATUS__PURGE");
            Response.Response response = await client.GetConnection().InvokeAsync<Response.Response>
            ("cmdb.object.delete", parameter);
               if (response.success == false)
               {
                  throw new IdoitAPIClientBadResponseException("Nope!");
               }   
        }
        
        //archive
        public void Archive(int objectId)
        {
            Task t = Task.Run(() => { Archiving(objectId).Wait(); }); t.Wait();
        }
        async Task Archiving(int objectId)
        {


            parameter = client.GetParameter();
            parameter.Add("id", objectId);
            parameter.Add("status", "C__RECORD_STATUS__ARCHIVED");
            Response.Response response = await client.GetConnection().InvokeAsync<Response.Response>
            ("cmdb.object.delete", parameter);
               if (response.success == false)
               {
                   throw new IdoitAPIClientBadResponseException("Nope!");
               }      
        }
        //Read
        public Result Read(int objectId)
        { 
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return response;
        }
        async Task Reading(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("id", objectId);
            response = await client.GetConnection().InvokeAsync<Result>("cmdb.object.read", parameter);      
        }
   }
}
