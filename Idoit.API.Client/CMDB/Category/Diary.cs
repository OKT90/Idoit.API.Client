using System.Collections.Generic;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
    public class Diary : MultiValueCategory
    {
        List<Response.Diary[]> diaryResponse;
        Dictionary<string, object> parameter;

        public Diary(Client myClient) : base(myClient)
        {
            category = "C__CATG__CUSTOM_FIELDS_DIARY";
        }
        //Read
        public List<Response.Diary[]> Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return diaryResponse;
        }
        async Task Reading(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            diaryResponse = new List<Response.Diary[]>();
            diaryResponse.Add(await client.GetConnection().InvokeAsync<Response.Diary[]>
            ("cmdb.category.read", parameter));
        }
    }
}
