using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idoit.API.Client.Idoit
{
    public class Constants
    {
        public Client client;
        private object responseConstants;
        JObject responseJObject;
        private string key;
        private JToken value;
        private Dictionary<string, object> parameter;
        private string groupName;
        private string childName;
        private string keyName;
        private string valueName;
        Dictionary<string, string> response;

        public Constants(Client myClient)
        {
            client = myClient;
        }

        //constants
        async Task constants()
        {
            parameter = client.GetParameter();
            responseConstants = await client.GetConnection().InvokeAsync<object>("idoit.constants", parameter);
        }

        //Read
        Dictionary<string, string> Read()
        {
            responseJObject = (JObject)JsonConvert.DeserializeObject(responseConstants.ToString());
            response = new Dictionary<string, string>();

            foreach (var parentGroup in responseJObject)
            {
                key = parentGroup.Key;
                value = parentGroup.Value;
                if (key == groupName)
                {
                    foreach (var childGroup in value)
                    {
                        if(groupName == "categories")
                        {
                            valueName = childGroup.ToObject<JProperty>().Name;
                            if (valueName == childName)
                            {
                                foreach (var child in childGroup.First)
                                {
                                    keyName = child.First.ToString();
                                    valueName = child.ToObject<JProperty>().Name;
                                    response.AddSafe(keyName, valueName);
                                }
                            }
                        }
                        else
                        {
                            keyName = childGroup.First.ToString();
                            valueName = childGroup.ToObject<JProperty>().Name;
                            response.Add(keyName, valueName);

                        }
                    }
                }
            }
            return response;
        }
        //ReadGlobalCategories
        public Dictionary<string, string> ReadGlobalCategories()
        {
            groupName = "categories";
            childName = "g";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }
        //ReadSpecificCategories
        public Dictionary<string, string> ReadSpecificCategories()
        {
            groupName = "categories";
            childName = "s";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }
        //ReadObjectTypes
        public Dictionary<string, string> ReadObjectTypes()
        {
            groupName = "objectTypes";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }
       // ReadRecordStates
        public Dictionary<string, string> ReadRecordStates()
        {
            groupName = "recordStates";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }

        //ReadRelationTypes
        public Dictionary<string, string> ReadRelationTypes()
        {
            groupName = "relationTypes";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }

        //ReadStaticObjects
        public Dictionary<string, string> ReadStaticObjects()
        {
            groupName = "staticObjects";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }
    }
    static class Extensions
    {
        public static void AddSafe(this Dictionary<string, string> dictionary, string key, string value)
        {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
        }
    }

}
