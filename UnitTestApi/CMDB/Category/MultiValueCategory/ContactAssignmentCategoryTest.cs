using System;
using System.Collections.Generic;
using Idoit.API.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactAssignment = Idoit.API.Client.CMDB.Category.ContactAssignment;
using ContactAssignmentRequset = Idoit.API.Client.CMDB.Category.Request.ContactAssignment;
using ContactAssignmentResponse = Idoit.API.Client.CMDB.Category.Response.ContactAssignment;
using MyObject = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using System.IO;

namespace UnitTestApi.CMDB.Category.MultiValueCategory
{

    [TestClass]
    public class ContactAssignmentCategoryTest
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
            int categoryId, serverId, personId;
            List<ContactAssignmentResponse[]> contactAssignmentResponse = new List<ContactAssignmentResponse[]>();
            ContactAssignmentRequset categoryRequest = new ContactAssignmentRequset();
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            MyObject objectRequest = new MyObject(myClient);
            ContactAssignment contactAssignment = new ContactAssignment(myClient);

            //Act:Create the server object
            objectRequest.type = ObjectType.SERVER;
            objectRequest.title = "Server01";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            serverId = objectRequest.Create();

            //Act:Create the person object
            objectRequest.type = ObjectType.PERSON;
            objectRequest.title = "Person01";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            personId = objectRequest.Create();

            //Act:Create category entry
            categoryRequest.contact = personId;
            categoryRequest.role = 1;
            categoryId = contactAssignment.Create(serverId, categoryRequest);

            //Assert
            Assert.IsNotNull(categoryId);

            //Act:Read category entry
            categoryRequest.category_id = categoryId;
            contactAssignmentResponse = contactAssignment.Read(serverId);

            //Assert
            foreach (ContactAssignmentResponse[] row in contactAssignmentResponse)
            {
                foreach (ContactAssignmentResponse element in row)
                {
                    Assert.IsNotNull(element.role);
                    Assert.IsNotNull(element.id);
                }
            }

            //Act:Delete the server object
            objectRequest.Delete(serverId);
            //Act:Delete the person object
            objectRequest.Delete(personId);
        }

        //Delete
        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            int categoryId, serverId, personId;
            List<ContactAssignmentResponse[]> contactAssignmentResponse = new List<ContactAssignmentResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            MyObject objectRequest = new MyObject(myClient);
            ContactAssignmentRequset categoryRequest = new ContactAssignmentRequset();
            ContactAssignment contactAssignment = new ContactAssignment(myClient);

            //Act:Create the server object
            objectRequest.type = ObjectType.SERVER;
            objectRequest.title = "Server01";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            serverId = objectRequest.Create();

            //Act:Create the person object
            objectRequest.type = ObjectType.PERSON;
            objectRequest.title = "Person01";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            personId = objectRequest.Create();

            //Act:Create category entry
            categoryRequest.contact = personId;
            //categoryRequest.role = 1;
            categoryId = contactAssignment.Create(serverId, categoryRequest);

            //Assert
            Assert.IsNotNull(categoryId);

            //Act:Read category entry
            categoryRequest.category_id = categoryId;
            contactAssignmentResponse = contactAssignment.Read(serverId);

            //Assert
            foreach (ContactAssignmentResponse[] row in contactAssignmentResponse)
            {
                foreach (ContactAssignmentResponse element in row)
                {
                    Assert.IsNull(element.role);
                    Assert.IsNotNull(element.id);
                    Assert.AreEqual("Person01", element.contactObject.title);

                }
            }
            //Act:Delete category entry
            contactAssignment.Delete(serverId, categoryId);
            //Act:Delete the server object
            objectRequest.Delete(serverId);
            //Act:Delete the person object
            objectRequest.Delete(personId);
        }

        //Quickpurge
        [TestMethod]
        public void QuickpurgeTest()
        {
            //Arrange
            int categoryId, serverId, personId;
            List<ContactAssignmentResponse[]> contactAssignmentResponse = new List<ContactAssignmentResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            MyObject objectRequest = new MyObject(myClient);
            ContactAssignmentRequset categoryRequest = new ContactAssignmentRequset();
            ContactAssignment contactAssignment = new ContactAssignment(myClient);

            //Act:Create the server object
            objectRequest.type = ObjectType.SERVER;
            objectRequest.title = "Server01";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            serverId = objectRequest.Create();

            //Act:Create the person object
            objectRequest.type = ObjectType.PERSON;
            objectRequest.title = "Person01";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            personId = objectRequest.Create();

            //Act:Create category entry
            categoryRequest.contact = personId;
            categoryRequest.role = 1;
            categoryId = contactAssignment.Create(serverId, categoryRequest);

            //Assert
            Assert.IsNotNull(categoryId);

            //Act:Read category entry
            categoryRequest.category_id = categoryId;
            contactAssignmentResponse = contactAssignment.Read(serverId);

            //Assert
            foreach (ContactAssignmentResponse[] row in contactAssignmentResponse)
            {
                foreach (ContactAssignmentResponse element in row)
                {
                    Assert.IsNotNull(element.role);
                    Assert.IsNotNull(element.id);
                    Assert.AreEqual("Person01", element.contactObject.title);

                }
            }
            //Act:Delete category entry
            contactAssignment.Quickpurge(serverId, categoryId);
            //Act:Delete the server object
            objectRequest.Delete(serverId);
            //Act:Delete the person object
            objectRequest.Delete(personId);
        }
        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int categoryId, serverId, personId;
            List<ContactAssignmentResponse[]> contactAssignmentResponse = new List<ContactAssignmentResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            MyObject objectRequest = new MyObject(myClient);
            ContactAssignmentRequset categoryRequest = new ContactAssignmentRequset();
            ContactAssignment contactAssignment = new ContactAssignment(myClient);

            //Act:Create the server object
            objectRequest.type = ObjectType.SERVER;
            objectRequest.title = "Server01";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            serverId = objectRequest.Create();

            //Act:Create the person object
            objectRequest.type = ObjectType.PERSON;
            objectRequest.title = "Person01";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            personId = objectRequest.Create();

            //Act:Create category entry
            categoryRequest.contact = personId;
            categoryId = contactAssignment.Create(serverId, categoryRequest);

            //Assert
            Assert.IsNotNull(categoryId);

            //Act:Update category entry
            categoryRequest.role = 2;
            categoryRequest.category_id = categoryId;
            contactAssignment.Update(serverId, categoryRequest);

            //Act:Read category entry
            categoryRequest.category_id = categoryId;
            contactAssignmentResponse = contactAssignment.Read(serverId);

            //Assert
            foreach (ContactAssignmentResponse[] row in contactAssignmentResponse)
            {
                foreach (ContactAssignmentResponse element in row)
                {
                    Assert.IsNotNull(element.role);
                    Assert.IsNotNull(element.id);
                    Assert.AreEqual("Person01", element.contactObject.title);
                    Assert.AreEqual("2", element.role.id);
                    Assert.AreEqual("User", element.role.title);
                }
            }
            //Act:Delete the server object
            objectRequest.Delete(serverId);
            //Act:Delete the person object
            objectRequest.Delete(personId);
        }
        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            int categoryId, serverId, personId;
            List<ContactAssignmentResponse[]> contactAssignmentResponse = new List<ContactAssignmentResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            MyObject objectRequest = new MyObject(myClient);
            ContactAssignmentRequset categoryRequest = new ContactAssignmentRequset();
            ContactAssignment contactAssignment = new ContactAssignment(myClient);

            //Act:Create the server object
            objectRequest.type = ObjectType.SERVER;
            objectRequest.title = "Server01";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            serverId = objectRequest.Create();

            //Act:Create the person object
            objectRequest.type = ObjectType.PERSON;
            objectRequest.title = "Person01";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            personId = objectRequest.Create();

            //Act:Create category entry
            categoryRequest.contact = personId;
            categoryRequest.role = 1;
            categoryId = contactAssignment.Create(serverId, categoryRequest);

            //Assert
            Assert.IsNotNull(categoryId);

            //Act:Read category entry
            categoryRequest.category_id = categoryId;
            contactAssignmentResponse = contactAssignment.Read(serverId);

            //Assert
            foreach (ContactAssignmentResponse[] row in contactAssignmentResponse)
            {
                foreach (ContactAssignmentResponse element in row)
                {
                    Assert.IsNotNull(element.role);
                    Assert.IsNotNull(element.id);
                    Assert.AreEqual("Person01", element.contactObject.title);
                    Assert.AreEqual("1", element.role.id);
                    Assert.AreEqual("Administrator", element.role.title);
                    Assert.AreEqual("C__CONTACT_TYPE__ADMIN", element.role._const);
                    Assert.AreEqual("Administrator", element.role.titleLang);

                }
            }
            //Act:Delete the server object
            objectRequest.Delete(serverId);
            //Act:Delete the person object
            objectRequest.Delete(personId);
        }
    }
}
