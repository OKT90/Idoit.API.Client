using System;
using System.Collections.Generic;
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Object.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model = Idoit.API.Client.CMDB.Category.Model;
using ModelRequset = Idoit.API.Client.CMDB.Category.Request.Model;
using ModelResponse = Idoit.API.Client.CMDB.Category.Response.Model;
using IResponse = Idoit.API.Client.CMDB.Category.Response.IResponse;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using System.IO;

namespace UnitTestApi.CMDB.Category.SingleValueCategory
{
    //[Ignore]
    [TestClass]
    public class ModelCategoryTest
    {
        string URL;
        string APIKEY;
        string LANGUAGE;
        public   ModelCategoryTest()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Api.env");
            DotNetEnv.Env.Load(path);
             URL = DotNetEnv.Env.GetString("URL");
            APIKEY = DotNetEnv.Env.GetString("APIKEY");
            LANGUAGE = DotNetEnv.Env.GetString("LANGUAGE");
        }
        //[Ignore]
        //Create
        [TestMethod]
        public void CreateTest()
        {
            //Arrange
             int cateId, objectId;
            List<ModelResponse[]> list = new List<ModelResponse[]>();
            ModelRequset categoryRequest = new ModelRequset();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            Model model = new Model(myClient);
            //Act:Create the Object
            objectRequest.type = ObjectType.CLIENT;
            objectRequest.title = " My Client";
 
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.manufacturer=1;
            categoryRequest.description = "Web GUI description";
            cateId = model.Create(objectId, categoryRequest);
           
            //Assert
            Assert.IsNotNull(cateId);

            //Act: Read the Category
            list = model.Read(objectId);


            //Assert
            foreach (ModelResponse[] row in list)
            {
                foreach (ModelResponse element in row)
                {
                    Assert.IsNotNull(element.title);
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
             Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            ModelRequset categoryRequest = new ModelRequset();
            Model model = new Model(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType.CLIENT;
            objectRequest.title = " My Client";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.manufacturer = 1;
            cateId = model.Create(objectId, categoryRequest);

            //Act
            model.Quickpurge(objectId, cateId);
        }

        //[Ignore]
        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int cateId, objectId;
             List<ModelResponse[]> list = new List<ModelResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            ModelRequset categoryRequest = new ModelRequset();
            Model model = new Model(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType.CLIENT;
            objectRequest.title = " My Client";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.manufacturer = 1;

            cateId = model.Create(objectId, categoryRequest);

            //Act: Update the Category
            categoryRequest.title = "Web GUI 2";
            categoryRequest.description = "Web GUI 2 description";

            model.Update(objectId, categoryRequest);

            //Act:Read the Category
             list = model.Read(objectId);

            //Assert
            foreach (ModelResponse[] row in list)
            {
                foreach (ModelResponse element in row)
                {
                    Assert.AreEqual("Web GUI 2", categoryRequest.title);
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
             List<ModelResponse[]> list = new List<ModelResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            ModelRequset categoryRequest = new ModelRequset();
            Model model = new Model(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType. CLIENT;
            objectRequest.title = " My Client";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.manufacturer = 1;

            cateId = model.Create(objectId, categoryRequest);

            //Act:Read the Category
             list = model.Read(objectId);

            //Assert
            foreach (ModelResponse[] row in list)
            {
                foreach (ModelResponse element in row)
                {
                    Assert.AreEqual("Web GUI", categoryRequest.title);
                }
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }
    }
}
