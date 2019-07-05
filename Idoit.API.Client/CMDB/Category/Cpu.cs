using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Anemonis.JsonRpc.ServiceClient;
using Idoit.API.Client.CMDB.Category.Request;
using Idoit.API.Client.CMDB.Category.Response;
using System.Reflection;

namespace Idoit.API.Client.CMDB.Category
{
    public class Cpu : MultiValueCategory
    {
        Dictionary<string, object> parameter;
        List<Response.Cpu[]> cpuResponse;
        public Cpu(Client myClient) : base(myClient)
        {
            category= "C__CATG__CPU";
        }
        //Read
        public List<Response.Cpu[]> Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return cpuResponse;
        }
        async Task Reading(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            cpuResponse = new List<Response.Cpu[]>();
            cpuResponse.Add(await client.GetConnection().InvokeAsync<Response.Cpu[]>
            ("cmdb.category.read", parameter));
            
        }
    }
}
