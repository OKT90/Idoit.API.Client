using System;
using System.Collections.Generic;
using Idoit.API.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IP = Idoit.API.Client.CMDB.Category.IP;
using IPRequset = Idoit.API.Client.CMDB.Category.Request.IP;
using IPResponse = Idoit.API.Client.CMDB.Category.Response.IP;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using System.IO;

namespace UnitTestApi.CMDB.Category.MultiValueCategory
{
    [TestClass]
    public class IPCategoryTest
    {
        string URL;
        string APIKEY;
        string LANGUAGE;
        public IPCategoryTest()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Api.env");
            DotNetEnv.Env.Load(path);
            URL = DotNetEnv.Env.GetString("URL");
            APIKEY = DotNetEnv.Env.GetString("APIKEY");
            LANGUAGE = DotNetEnv.Env.GetString("LANGUAGE");
        }

        //Create
        [TestMethod]
        public void CreateTest()
        {
            //Arrange
            int cateId, objectId;
            List<IPResponse[]> list = new List<IPResponse[]>();
            IPRequset categoryRequest = new IPRequset();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            IP IP = new IP(myClient);
            //Act:Create the Object
            objectRequest.type = ObjectType.SERVER;
            objectRequest.title = " My Server";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.ipv4_address = "0.0.0.100";
            categoryRequest.primary = 0;
            categoryRequest.active = 0;
            categoryRequest.domain = "Domain";
            categoryRequest.net_type = 1;
            categoryRequest.description = "IP category test description";
            cateId = IP.Create(objectId, categoryRequest);

            //Assert
            Assert.IsNotNull(cateId);

            //Act: Read the Category
            categoryRequest.category_id = cateId;
            list = IP.Read(objectId);

            //Assert
            foreach (IPResponse[] row in list)
            {
                foreach (IPResponse element in row)
                {
                    Assert.IsNotNull(element.iPV4Address);
                    Assert.AreEqual(element.active.title,"No");
                    Assert.IsNotNull(element.id);
                }
            }

            ////Act:Delete the Object
            objectRequest.Delete(objectId);
        }

        //Delete
        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            int cateId, objectId;
            List<IPResponse[]> list = new List<IPResponse[]>();
            IPRequset categoryRequest = new IPRequset();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            IP IP = new IP(myClient);
            //Act:Create the Object
            objectRequest.type = ObjectType.SERVER;
            objectRequest.title = " My Server";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.ipv4_address = "0.0.0.100";
            categoryRequest.primary = 0;
            categoryRequest.active = 0;
            categoryRequest.domain = "Domain";
            categoryRequest.net_type = 1;
            categoryRequest.description = "IP category test description";
            cateId = IP.Create(objectId, categoryRequest);

            //Assert
            Assert.IsNotNull(cateId);

            //Act
            IP.Delete(objectId, cateId);

            //Act: Read the Category
            categoryRequest.category_id = cateId;
            list = IP.Read(objectId);

            //Assert
            foreach (IPResponse[] row in list)
            {
                foreach (IPResponse element in row)
                {
                    Assert.IsNotNull(element.iPV4Address);
                    Assert.AreEqual(element.active.title, "No");
                    Assert.IsNotNull(element.id);
                }
            }

            ////Act:Delete the Object
            objectRequest.Delete(objectId);
        }

        //Quickpurge
        [TestMethod]
        public void QuickpurgeTest()
        {
            //Arrange
            int cateId, objectId;
            List<IPResponse[]> list = new List<IPResponse[]>();
            IPRequset categoryRequest = new IPRequset();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            IP IP = new IP(myClient);
            //Act:Create the Object
            objectRequest.type = ObjectType.SERVER;
            objectRequest.title = " My Server";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.ipv4_address = "0.0.0.100";
            categoryRequest.primary = 0;
            categoryRequest.active = 0;
            categoryRequest.domain = "Domain";
            categoryRequest.net_type = 1;
            categoryRequest.description = "IP category test description";
            cateId = IP.Create(objectId, categoryRequest);

            //Assert
            Assert.IsNotNull(cateId);

            //Act
            IP.Quickpurge(objectId, cateId);

            //Act: Read the Category
            categoryRequest.category_id = cateId;
            list = IP.Read(objectId);

            //Assert
            foreach (IPResponse[] row in list)
            {
                foreach (IPResponse element in row)
                {
                    Assert.IsNotNull(element.iPV4Address);
                    Assert.AreEqual(element.active.title, "No");
                    Assert.IsNotNull(element.id);
                }
            }

            ////Act:Delete the Object
            objectRequest.Delete(objectId);
        }

        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int cateId, objectId;
            List<IPResponse[]> list = new List<IPResponse[]>();
            IPRequset categoryRequest = new IPRequset();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            IP IP = new IP(myClient);
            //Act:Create the Object
            objectRequest.type = ObjectType.SERVER;
            objectRequest.title = " My Server";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.ipv4_address = "0.0.0.100";
            categoryRequest.primary = 0;
            categoryRequest.active = 0;
            categoryRequest.domain = "Domain";
            categoryRequest.net_type = 1;
            categoryRequest.description = "IP category test description";
            cateId = IP.Create(objectId, categoryRequest);

            //Act: Update the Category
            categoryRequest.primary = 1;
            categoryRequest.active = 1;
            categoryRequest.domain = "Domain";
            categoryRequest.net_type = 1;
            categoryRequest.category_id = cateId;
            IP.Update(objectId, categoryRequest);

            //Act:Read the Category
            categoryRequest.category_id = cateId;
            list = IP.Read(objectId);

            //Assert
            foreach (IPResponse[] row in list)
            {
                foreach (IPResponse element in row)
                {
                    Assert.IsNotNull(element.iPV4Address);
                    Assert.AreEqual(element.active.title, "Yes");
                    Assert.IsNotNull(element.id);
                }
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);

        }

        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            int cateId, objectId;
            List<IPResponse[]> list = new List<IPResponse[]>();
            IPRequset categoryRequest = new IPRequset();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            IP IP = new IP(myClient);
            //Act:Create the Object
            objectRequest.type = ObjectType.SERVER;
            objectRequest.title = " My Server";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.ipv4_address = "0.0.0.100";
            categoryRequest.primary = 0;
            categoryRequest.active = 0;
            categoryRequest.domain = "Domain";
            categoryRequest.net_type = 1;
            categoryRequest.description = "IP category test description";
            cateId = IP.Create(objectId, categoryRequest);

            //Assert
            Assert.IsNotNull(cateId);

            //Act: Read the Category
            categoryRequest.category_id = cateId;
            list = IP.Read(objectId);

            //Assert
            foreach (IPResponse[] row in list)
            {
                foreach (IPResponse element in row)
                {
                    Assert.IsNotNull(element.iPV4Address);
                    Assert.AreEqual(element.active.title, "No");
                    Assert.IsNotNull(element.id);
                }
            }

            ////Act:Delete the Object
            objectRequest.Delete(objectId);
        }
    }
}
