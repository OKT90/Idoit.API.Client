using Idoit.API.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Result = Idoit.API.Client.CMDB.ObjectTypes.Response.Result;
using ObjectTypesRead = Idoit.API.Client.CMDB.ObjectTypes.ObjectTypes;
using ObjectTypesCreate = Idoit.API.Client.CMDB.Object.Object;
using Categories = Idoit.API.Client.CMDB.ObjectTypeCategories.ObjectTypeCategories;
using ObjectTypeCategoriesResult = Idoit.API.Client.CMDB.ObjectTypeCategories.Response.Result;
using Customs = Idoit.API.Client.CMDB.ObjectTypeCategories.Response.Customs;
using System.IO;

namespace UnitTestApi.CMDB.ObjectTypeCategories
{
    [TestClass]
    public class ObjectTypeCategoriesTest
    {
        string URL;
        string APIKEY;
        string LANGUAGE;
        public ObjectTypeCategoriesTest()
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
            string costumId = "";
            string objectTypeId = "";
            List<Result[]> lists = new List<Result[]>();
            List<Customs> custom = new List<Customs>();
            ObjectTypeCategoriesResult objectTypeCategoriesResult = new ObjectTypeCategoriesResult();

            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            ObjectTypesRead request = new ObjectTypesRead(myClient);
            ObjectTypesCreate requestCreate = new ObjectTypesCreate(myClient);
            Categories objectTypeCategories = new Categories(myClient);
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
            objectTypeCategoriesResult = objectTypeCategories.Read(objectTypeId);
            custom = objectTypeCategoriesResult.Custom;
            foreach (Customs element in custom)
            {
                if (element.title == "Diary")
                {
                    costumId = element.id;
                }
            }
            Assert.IsNotNull(costumId);
        }
    }
}
