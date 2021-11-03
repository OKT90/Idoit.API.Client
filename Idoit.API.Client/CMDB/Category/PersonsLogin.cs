using System.Collections.Generic;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
    public class PersonsLogin : SingleValueCategory
    {
        Dictionary<string, object> parameter;

        List<Response.PersonsLogin[]> PersonsLoginResponse;

        public PersonsLogin(Client myClient) : base(myClient)
        {
            category = "C__CATS__PERSON_LOGIN";
        }

        //Read
        public List<Response.PersonsLogin[]> Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return PersonsLoginResponse;
        }
        async Task Reading(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            PersonsLoginResponse = new List<Response.PersonsLogin[]>();
            PersonsLoginResponse.Add(await client.GetConnection().InvokeAsync<Response.PersonsLogin[]>
           ("cmdb.category.read", parameter));
        }
    }
}
