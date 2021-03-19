using System;
using System.Collections.Generic;
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Object.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Access = Idoit.API.Client.CMDB.Category.Access;
using AccessRequset = Idoit.API.Client.CMDB.Category.Request.Access;
using AccessResponse = Idoit.API.Client.CMDB.Category.Response.Access;
using IResponse = Idoit.API.Client.CMDB.Category.Response.IResponse;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using System.IO;

namespace UnitTestApi.CMDB.Category.MultiValueCategory
{
  
    [TestClass]
    public class AccessCategoryTest
    {
 
        string URL;
        string APIKEY;
        string LANGUAGE;
        public   AccessCategoryTest()
        {
            /*You can find the Api.env in the following path:-
             *Idoit.API.Client\UnitTestApi\bin\Debug\Data
             */
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
             int cateId,objectId;
            List<AccessResponse[]> list = new List<AccessResponse[]>();
            AccessRequset categoryRequest = new AccessRequset();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            Access access = new Access(myClient);
            //Act:Create the Object
            objectRequest.type = ObjectType.CLIENT;
            objectRequest.title = " My Client";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            cateId = access.Create(objectId,categoryRequest);

            //Assert
            Assert.IsNotNull(cateId);

            //Act: Read the Category
            categoryRequest.category_id = cateId;
            list = access.Read(objectId);


            //Assert
            foreach (AccessResponse[] row in list)
            {
                foreach (AccessResponse element in row)
                {
                    Assert.IsNotNull(element.title);
                    Assert.IsNotNull(element.id);
                }
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }

        //Delete
        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
             int cateId, objectId;
            List<AccessResponse[]> list = new List<AccessResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            AccessRequset categoryRequest = new AccessRequset();
            Access access = new Access(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType.CLIENT;
            objectRequest.title = " My Client";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            cateId = access.Create(objectId, categoryRequest);

            //Act
            access.Delete(objectId, cateId);

            //Act:Read the Category
            categoryRequest.category_id = cateId;
            list = access.Read(objectId);

            //Assert
            foreach (AccessResponse[] row in list)
            {
                foreach (AccessResponse element in row)
                {
                    Assert.IsNotNull(element.title);
                    Assert.IsNotNull(element.id);
                }
            }

        }

        //Quickpurge
        [TestMethod]
        public void QuickpurgeTest()
        {

            //Arrange
            int cateId, objectId;
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            AccessRequset categoryRequest = new AccessRequset();
            Access access = new Access(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType.CLIENT;
            objectRequest.title = " My Client";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            cateId = access.Create(objectId, categoryRequest);

            //Act
            access.Quickpurge(objectId, cateId);
        }

        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int cateId, objectId;
             List<AccessResponse[]> list = new List<AccessResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            AccessRequset categoryRequest = new AccessRequset();
            Access access = new Access(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType.CLIENT;
            objectRequest.title = " My Client";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            cateId = access.Create(objectId, categoryRequest);

            //Act: Update the Category
            categoryRequest.title = "Web GUI 2";
            categoryRequest.description = "Web GUI 2 description";
            categoryRequest.type = " SE";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            categoryRequest.category_id = cateId;
            access.Update(objectId, categoryRequest);

            //Act:Read the Category
            categoryRequest.category_id = cateId;
            list = access.Read(objectId);

            //Assert
            foreach (AccessResponse[] row in list)
            {
                foreach (AccessResponse element in row)
                {
                    Assert.AreEqual("Web GUI 2",categoryRequest.title);
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
             List<AccessResponse[]> list = new List<AccessResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            AccessRequset categoryRequest = new AccessRequset();
            Access access = new Access(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType.CLIENT;
            objectRequest.title = " My Client";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            cateId = access.Create(objectId, categoryRequest);
             
            //Act:Read the Category
            categoryRequest.category_id = cateId;
            list = access.Read(objectId);

            //Assert
            foreach (AccessResponse[] row in list)
            {
                foreach (AccessResponse element in row)
                {
                    Assert.AreEqual("Web GUI", categoryRequest.title);
                }
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }
        }
}
