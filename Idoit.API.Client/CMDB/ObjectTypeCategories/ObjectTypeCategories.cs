using System.Threading.Tasks;
using System.Collections.Generic;
using Result = Idoit.API.Client.CMDB.ObjectTypeCategories.Response.Result;

namespace Idoit.API.Client.CMDB.ObjectTypeCategories
{
    public class ObjectTypeCategories
    {
        public ObjectTypeCategories(Client myClient)
        {
            client = myClient;
        }
        Dictionary<string, object> parameter;
        Result response;
        public Client client;
        public Result Read(string type)
        {
            Task t = Task.Run(() => { Reading(type).Wait(); }); t.Wait();
            return response;
        }

        async Task Reading(string type)
        {
            parameter = client.GetParameter();
            parameter.Add("type", type);
            response = await client.GetConnection().InvokeAsync<Result>("cmdb.object_type_categories.read", parameter);
        }
    }
}
