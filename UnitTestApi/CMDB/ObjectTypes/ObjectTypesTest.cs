using Idoit.API.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Result = Idoit.API.Client.CMDB.ObjectTypes.Response.Result;
using ObjectTypesRead = Idoit.API.Client.CMDB.ObjectTypes.ObjectTypes;
using ObjectTypesCreate = Idoit.API.Client.CMDB.Object.Object;
using System.IO;

namespace UnitTestApi.CMDB.ObjectTypes
{
    [TestClass]
    public class ObjectTypesTest
    {
        string URL;
        string APIKEY;
        string LANGUAGE;

        [TestInitialize]
        public void Setup()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Api.env");
            DotNetEnv.Env.Load(path); URL = DotNetEnv.Env.GetString("URL");
            APIKEY = DotNetEnv.Env.GetString("APIKEY");
            LANGUAGE = DotNetEnv.Env.GetString("LANGUAGE");
        }

        //Read
        [TestMethod]
        public void ReadTest()
        {
            string objectTypeId = "";
            List<Result[]> lists = new List<Result[]>();

            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            ObjectTypesRead request = new ObjectTypesRead(myClient);
            ObjectTypesCreate requestCreate = new ObjectTypesCreate(myClient);
            lists = request.Read();
            foreach (Result[] row in lists)
            {
                foreach (Result element in row)
                {
                    if (element.title == "Server")
                    {
                        objectTypeId = element.id.ToString();
                        break;
                    }
                }
            }
            Assert.IsNotNull(objectTypeId);
        }
    }
}