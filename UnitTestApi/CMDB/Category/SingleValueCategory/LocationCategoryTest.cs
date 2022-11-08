using System;
using System.Collections.Generic;
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Object.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Location = Idoit.API.Client.CMDB.Category.Location;
using LocationRequset = Idoit.API.Client.CMDB.Category.Request.Location;
using LocationResponse = Idoit.API.Client.CMDB.Category.Response.Location;
using IResponse = Idoit.API.Client.CMDB.Category.Response.IResponse;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using System.IO;

namespace UnitTestApi.CMDB.Category.SingleValueCategory
{
    //[Ignore]
    [TestClass]
    public class LocationCategoryTest
    {
        string URL;
        string APIKEY;
        string LANGUAGE;
        ProxySettings proxySettings = new ProxySettings();

        [TestInitialize]
        public void Setup()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Api.env");
            DotNetEnv.Env.Load(path); URL = DotNetEnv.Env.GetString("URL");
            APIKEY = DotNetEnv.Env.GetString("APIKEY");
            LANGUAGE = DotNetEnv.Env.GetString("LANGUAGE");
            proxySettings.proxyAddress = DotNetEnv.Env.GetString("ADDRESS");
            proxySettings.proxyPort = DotNetEnv.Env.GetString("PORT");
            proxySettings.proxyUserName = DotNetEnv.Env.GetString("USERNAME");
            proxySettings.proxyPassword = DotNetEnv.Env.GetString("PASSWORD");
        }

        //[Ignore]
        //Create
        [TestMethod]
        public void CreateTest()
        {
            //Arrange
            int cateId, objectId;
            List<LocationResponse[]> list = new List<LocationResponse[]>();
            LocationRequset categoryRequest = new LocationRequset();
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            Location Location = new Location(myClient);
            //Act:Create the Object
            objectRequest.type = ObjectType.CLIENT;
            objectRequest.title = " My Client";

            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            
            categoryRequest.description = "Web GUI description";
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            cateId = Location.Create(objectId, categoryRequest);

            //Assert
            Assert.IsNotNull(cateId);

            //Act: Read the Category
            list = Location.Read(objectId);


            //Assert
            foreach (LocationResponse[] row in list)
            {
                foreach (LocationResponse element in row)
                {
                    Assert.IsNotNull(element.id);
                }
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }

        //[Ignore]
        //Quickpurge
        [TestMethod]
        public void QuickpurgeTest()
        {

            //Arrange
            int cateId, objectId;
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            LocationRequset categoryRequest = new LocationRequset();
            Location Location = new Location(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType.CLIENT;
            objectRequest.title = " My Client";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            categoryRequest.description = "Web GUI description";
            cateId = Location.Create(objectId, categoryRequest);

            //Act
            Location.Quickpurge(objectId, cateId);
        }

        //[Ignore]
        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int cateId, objectId;
            List<LocationResponse[]> list = new List<LocationResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            LocationRequset categoryRequest = new LocationRequset();
            Location Location = new Location(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType.CLIENT;
            objectRequest.title = " My Client";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            categoryRequest.description = "Web GUI description";

            cateId = Location.Create(objectId, categoryRequest);

            //Act: Update the Category
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            categoryRequest.description = "Web GUI 2 description";

            Location.Update(objectId, categoryRequest);

            //Act:Read the Category
            list = Location.Read(objectId);

            //Assert
            foreach (LocationResponse[] row in list)
            {
                foreach (LocationResponse element in row)
                {
                    Assert.AreEqual("Web GUI 2 description", categoryRequest.description);
                }
            }
            //Act:Delete the Object
            objectRequest.Delete(objectId);

        }

        //[Ignore]
        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            int cateId, objectId;
            List<LocationResponse[]> list = new List<LocationResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            LocationRequset categoryRequest = new LocationRequset();
            Location Location = new Location(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType.CLIENT;
            objectRequest.title = " My Client";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            categoryRequest.description = "Web GUI description";

            cateId = Location.Create(objectId, categoryRequest);

            //Act:Read the Category
            list = Location.Read(objectId);

            //Assert
            foreach (LocationResponse[] row in list)
            {
                foreach (LocationResponse element in row)
                {
                    Assert.AreEqual("Web GUI description", categoryRequest.description);
                }
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }
    }
}
