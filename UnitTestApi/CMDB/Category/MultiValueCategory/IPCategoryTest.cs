using System;
using System.Collections.Generic;
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Object.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IP = Idoit.API.Client.CMDB.Category.IP;
using IPRequset = Idoit.API.Client.CMDB.Category.Request.IP;
using IPResponse = Idoit.API.Client.CMDB.Category.Response.IP;
using IResponse = Idoit.API.Client.CMDB.Category.Response.IResponse;
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
            objectRequest.type = ObjectType.CLUSTER;
            objectRequest.title = " My Cluster";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.ipv4_address = "1.1.1.2";
            categoryRequest.description = "Web GUI description";
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
                    Assert.IsNotNull(element.ipv4_address);
                    Assert.IsNotNull(element.id);
                }
            }

            ////Act:Delete the Object
            objectRequest.Delete(objectId);
        }

        ////Delete
        //[TestMethod]
        //public void DeleteTest()
        //{
        //    //Arrange
        //    int cateId, objectId;
        //    List<IPResponse[]> list = new List<IPResponse[]>();
        //    Client myClient = new Client(URL, APIKEY, LANGUAGE);
        //    myClient.Username = "admin";
        //    myClient.Password = "admin";
        //    Obj objectRequest = new Obj(myClient);
        //    IPRequset categoryRequest = new IPRequset();
        //    IP IP = new IP(myClient);

        //    //Act:Create the Object
        //    objectRequest.type = ObjectType.Client;
        //    objectRequest.title = " My Client";
        //    objectRequest.cmdbStatus = CmdbStatus.inOperation;
        //    objectId = objectRequest.Create();

        //    //Act: Create the Category
        //    categoryRequest.title = "Web GUI";
        //    categoryRequest.description = "Web GUI description";
        //    categoryRequest.type = " ES";
        //    categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
        //    categoryRequest.primary = "3";
        //    cateId = IP.Create(objectId, categoryRequest);

        //    //Act
        //    IP.Delete(objectId, cateId);

        //    //Act:Read the Category
        //    categoryRequest.category_id = cateId;
        //    list = IP.Read(objectId);

        //    //Assert
        //    foreach (IPResponse[] row in list)
        //    {
        //        foreach (IPResponse element in row)
        //        {
        //            Assert.IsNotNull(element.title);
        //            Assert.IsNotNull(element.id);
        //        }
        //    }

        //}

        ////Quickpurge
        //[TestMethod]
        //public void QuickpurgeTest()
        //{

        //    //Arrange
        //    int cateId, objectId;
        //    Client myClient = new Client(URL, APIKEY, LANGUAGE);
        //    myClient.Username = "admin";
        //    myClient.Password = "admin";
        //    Obj objectRequest = new Obj(myClient);
        //    IPRequset categoryRequest = new IPRequset();
        //    IP IP = new IP(myClient);

        //    //Act:Create the Object
        //    objectRequest.type = ObjectType.Client;
        //    objectRequest.title = " My Client";
        //    objectRequest.cmdbStatus = CmdbStatus.inOperation;
        //    objectId = objectRequest.Create();

        //    //Act: Create the Category
        //    categoryRequest.title = "Web GUI";
        //    categoryRequest.description = "Web GUI description";
        //    categoryRequest.type = " ES";
        //    categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
        //    categoryRequest.primary = "3";
        //    cateId = IP.Create(objectId, categoryRequest);

        //    //Act
        //    IP.Quickpurge(objectId, cateId);
        //}

        ////Update
        //[TestMethod]
        //public void UpdateTest()
        //{
        //    //Arrange
        //    int cateId, objectId;
        //    List<IPResponse[]> list = new List<IPResponse[]>();
        //    Client myClient = new Client(URL, APIKEY, LANGUAGE);
        //    myClient.Username = "admin";
        //    myClient.Password = "admin";
        //    Obj objectRequest = new Obj(myClient);
        //    IPRequset categoryRequest = new IPRequset();
        //    IP IP = new IP(myClient);

        //    //Act:Create the Object
        //    objectRequest.type = ObjectType.Client;
        //    objectRequest.title = " My Client";
        //    objectRequest.cmdbStatus = CmdbStatus.inOperation;
        //    objectId = objectRequest.Create();

        //    //Act: Create the Category
        //    categoryRequest.title = "Web GUI";
        //    categoryRequest.description = "Web GUI description";
        //    categoryRequest.type = " ES";
        //    categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
        //    categoryRequest.primary = "3";
        //    cateId = IP.Create(objectId, categoryRequest);

        //    //Act: Update the Category
        //    categoryRequest.title = "Web GUI 2";
        //    categoryRequest.description = "Web GUI 2 description";
        //    categoryRequest.type = " SE";
        //    categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
        //    categoryRequest.primary = "4";
        //    categoryRequest.category_id = cateId;
        //    IP.Update(objectId, categoryRequest);

        //    //Act:Read the Category
        //    categoryRequest.category_id = cateId;
        //    list = IP.Read(objectId);

        //    //Assert
        //    foreach (IPResponse[] row in list)
        //    {
        //        foreach (IPResponse element in row)
        //        {
        //            Assert.AreEqual("Web GUI 2", categoryRequest.title);
        //        }
        //    }

        //    //Act:Delete the Object
        //    objectRequest.Delete(objectId);

        //}

        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            int cateId, objectId;
            List<IPResponse[]> list = new List<IPResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            IPRequset categoryRequest = new IPRequset();
            IP IP = new IP(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType.CLUSTER;
            objectRequest.title = " My Cluster 2";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.ipv4_address = "1.1.1.2";
            categoryRequest.description = "Web GUI description";
            cateId = IP.Create(objectId, categoryRequest);

          
            //Act:Read the Category
            categoryRequest.category_id = cateId;
            list = IP.Read(objectId);

            //Assert
            foreach (IPResponse[] row in list)
            {
                foreach (IPResponse element in row)
                {
                    Assert.IsNotNull(element.ipv4_address.refTitle);
                }
            }
            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }
    }
}
