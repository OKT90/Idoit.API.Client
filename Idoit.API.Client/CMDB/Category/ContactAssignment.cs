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
    public class ContactAssignment : MultiValueCategory
    {
        Dictionary<string, object> parameter;
        List<Response.ContactAssignment[]> contactAssignmentResponse;
        public ContactAssignment(Client myClient) : base(myClient)
        {
            category = "C__CATG__CONTACT";
        }
        //Read
        public List<Response.ContactAssignment[]> Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return contactAssignmentResponse;
        }
        async Task Reading(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            contactAssignmentResponse = new List<Response.ContactAssignment[]>();
            contactAssignmentResponse.Add(await client.GetConnection().InvokeAsync<Response.ContactAssignment[]>   
            ("cmdb.category.read", parameter));
            
        }
    }
}
