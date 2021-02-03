using System.Collections.Generic;
using System.Threading.Tasks;
using Idoit.API.Client.CMDB.ObjectTypes.Response;

namespace Idoit.API.Client.CMDB.ObjectTypes
{
    public class ObjectTypes
    {
        public ObjectTypes(Client myClient)
        {
            client = myClient;
        }

        Dictionary<string, object> parameter;
        List<Result[]> response;
        public Client client;
        public List<Result[]> Read()
        {
            Task t = Task.Run(() => { Reading().Wait(); }); t.Wait();
            return response;
        }

        async Task Reading()
        {
            parameter = client.GetParameter();

            response = new List<Result[]>();
            response.Add(await client.GetConnection().InvokeAsync<Result[]>
                ("cmdb.object_types", parameter));

        }

    }
}
