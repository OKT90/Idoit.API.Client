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
            string custom = "";
            string objectTypeId = "";
            List<Result[]> objectTypes = new List<Result[]>();
            List<Customs> customlist = new List<Customs>();
            ObjectTypeCategoriesResult objectTypeCategoriesResult = new ObjectTypeCategoriesResult();

            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            ObjectTypesRead request = new ObjectTypesRead(myClient);
            ObjectTypesCreate requestCreate = new ObjectTypesCreate(myClient);
            Categories objectTypeCategories = new Categories(myClient);
            objectTypes = request.Read();
            foreach (Result[] row in objectTypes)
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
            customlist = objectTypeCategoriesResult.Custom;
            foreach (Customs element in customlist)
            {
                if (element.title == "Diary")
                {
                    custom = element.id;
                }
            }
            Assert.IsNotNull(custom);
        }
    }
}
