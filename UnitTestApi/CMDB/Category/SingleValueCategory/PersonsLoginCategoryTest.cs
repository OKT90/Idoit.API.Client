using System;
using System.Collections.Generic;
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Object.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonsLogin = Idoit.API.Client.CMDB.Category.PersonsLogin;
using PersonsLoginRequset = Idoit.API.Client.CMDB.Category.Request.PersonsLogin;
using PersonsLoginResponse = Idoit.API.Client.CMDB.Category.Response.PersonsLogin;
using IResponse = Idoit.API.Client.CMDB.Category.Response.IResponse;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using System.IO;

namespace UnitTestApi.CMDB.Category.SingleValueCategory
{
    //[Ignore]
    [TestClass]
    public class PersonsLoginCategoryTest
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

        //Create
        [TestMethod]
        public void CreateTest()
        {
            //Arrange
            int cateId, objectId;
            List<PersonsLoginResponse[]> list = new List<PersonsLoginResponse[]>();
            PersonsLoginRequset categoryRequest = new PersonsLoginRequset();
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            PersonsLogin PersonsLogin = new PersonsLogin(myClient);
            //Act:Create the Object
            objectRequest.type = ObjectType.PERSON;
            objectRequest.title = "Person1";

            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.disabled_login = "Yes";
            categoryRequest.description = "description";
            cateId = PersonsLogin.Create(objectId, categoryRequest);

            //Assert
            Assert.IsNotNull(cateId);

            //Act: Read the Category
            list = PersonsLogin.Read(objectId);

            //Assert
            foreach (PersonsLoginResponse[] row in list)
            {
                foreach (PersonsLoginResponse element in row)
                {
                    Assert.IsNotNull(element.id);
                    Assert.AreEqual(element.disabledLogin.title, "Yes");
                }
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }

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
            PersonsLoginRequset categoryRequest = new PersonsLoginRequset();
            PersonsLogin PersonsLogin = new PersonsLogin(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType. PERSON;
            objectRequest.title = "Person1";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.disabled_login = "Yes";
            categoryRequest.title = "Test";
            categoryRequest.user_pass = "Password1234";
            categoryRequest.user_pass2 = "Password1234";
            categoryRequest.description = "description";
            cateId = PersonsLogin.Create(objectId, categoryRequest);

            //Act
            PersonsLogin.Quickpurge(objectId, cateId);
        }

        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int cateId, objectId;
            List<PersonsLoginResponse[]> list = new List<PersonsLoginResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            PersonsLoginRequset categoryRequest = new PersonsLoginRequset();
            PersonsLogin PersonsLogin = new PersonsLogin(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType.PERSON;
            objectRequest.title = "Person 1";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.disabled_login = "Yes";
            categoryRequest.description = "description";

            cateId = PersonsLogin.Create(objectId, categoryRequest);

            //Act: Update the Category
            categoryRequest.disabled_login = "No";

            PersonsLogin.Update(objectId, categoryRequest);

            //Act:Read the Category
            list = PersonsLogin.Read(objectId);

            //Assert
            foreach (PersonsLoginResponse[] row in list)
            {
                foreach (PersonsLoginResponse element in row)
                {
                    Assert.AreEqual("No", categoryRequest.disabled_login);
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
            List<PersonsLoginResponse[]> list = new List<PersonsLoginResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            PersonsLoginRequset categoryRequest = new PersonsLoginRequset();
            PersonsLogin PersonsLogin = new PersonsLogin(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType.PERSON;
            objectRequest.title = "Person 1";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.disabled_login = "Yes";
            categoryRequest.description = "description";

            cateId = PersonsLogin.Create(objectId, categoryRequest);

            //Act:Read the Category
            list = PersonsLogin.Read(objectId);

            //Assert
            foreach (PersonsLoginResponse[] row in list)
            {
                foreach (PersonsLoginResponse element in row)
                {
                    Assert.AreEqual("description", categoryRequest.description);
                    Assert.AreEqual("Yes", categoryRequest.disabled_login);
                }
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }
    }
}
