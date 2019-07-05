using Anemonis.JsonRpc.ServiceClient;
using Idoit.API.Client.ApiException;
using Idoit.API.Client.CMDB.Dialog.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Dialog
{
     public class Dialog
     {
        List<Result[]> result;
        public int id;
        public Client client;
        public string property, value, category;//Create
        Dictionary<string, object> parameter;

        public Dialog(Client myClient)
        {
            client = myClient;
        }

        //Create
        public int Create()
        {
            if (property == null)
            {
                throw new IdoitAPIClientBadResponseException("Property is missing");
            }
            else if (value == null)
            {
                throw new IdoitAPIClientBadResponseException("Value is missing");
            }
            else if (category == null)
            {
                throw new IdoitAPIClientBadResponseException("Category is missing");
            }
            Task t = Task.Run(() => { Creating().Wait(); }); t.Wait();
            return id;
        }
        async Task Creating()
        {
            parameter = client.GetParameter();
            parameter.Add("value", value);
            parameter.Add("property", property);
            parameter.Add("category", category);
            Response.Response response = await client.GetConnection().InvokeAsync<Response.Response>
            ("cmdb.dialog.create", parameter);
            id = response.entryId;
             
        }

        //Update
        public void Update(int entryId)
        {
            if (entryId == null)
            {
                throw new IdoitAPIClientBadResponseException("Entry_id is missing");
            }
            else if (property == null)
            {
                throw new IdoitAPIClientBadResponseException("Property is missing");
            }
            else if (value == null)
            {
                throw new IdoitAPIClientBadResponseException("Value is missing");
            }
            else if (category == null)
            {
                throw new IdoitAPIClientBadResponseException("Category is missing");
            }

            Task t = Task.Run(() => { Updating(entryId).Wait(); }); t.Wait();
        }
        async Task Updating(int entryId)
        {
            parameter = client.GetParameter();
            parameter.Add("value", value);
            parameter.Add("entry_id", entryId);
            parameter.Add("property", property);
            parameter.Add("category", category);
            Response.Response response = await client.GetConnection().InvokeAsync<Response.Response>
            ("cmdb.dialog.update", parameter);
             
             
        }

        //Delete
        public void Delete(int entryId)
        {
            if (entryId == null)
            {
                throw new IdoitAPIClientBadResponseException("Entry_id is missing");
            }
            else if (property == null)
            {
                throw new IdoitAPIClientBadResponseException("Property is missing");
            }
            else if (category == null)
            {
                throw new IdoitAPIClientBadResponseException("Category is missing");
            }

            Task t = Task.Run(() => { Deleting(entryId).Wait(); }); t.Wait();
        }
        async Task Deleting(int entryId)
        {
            //The return Values as Object from diffrence Classes
            parameter = client.GetParameter();
            parameter.Add("entry_id", entryId);
            parameter.Add("property", property);
            parameter.Add("category", category);
            Response.Response response = await client.GetConnection().InvokeAsync<Response.Response>
            ("cmdb.dialog.delete", parameter);  
        }

        //Read
        public List<Result[]> Read()
        {
            Task t = Task.Run(() => { Reading().Wait(); }); t.Wait();
            return result;
        }
        async Task Reading()
        {
            parameter = client.GetParameter();
            parameter.Add("property", property);
            parameter.Add("category", category);
            result = new List<Result[]>();
            result.Add(await client.GetConnection().InvokeAsync<Result[]>
            ("cmdb.dialog.read", parameter)); 
        }
     }
}
