using System;
using Idoit.API.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Idoit.API.Client.CMDB.Object.Response;
using System.Collections.Generic;
using Idoit.API.Client.CMDB.Object;
using UnitTestApi.CMDB;
using System.IO;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using IResponse = Idoit.API.Client.CMDB.Category.Response.IResponse;


namespace UnitTestApi.CMDB.Object
{
    [TestClass]
    public class ObjectTest
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
            int objID;
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj request = new Obj(myClient);
            //Act
            request.type = ObjectType.APPLICATION;
            request.title = "Chrome";
            request.cmdbStatus = CmdbStatus.INOPERATION;
            objID = request.Create();
            //Assert
            Assert.IsNotNull(objID);
            Assert.IsNotNull(request.title);
            Assert.IsNotNull(request.type);
            Assert.IsNotNull(request.cmdbStatus);
            //Act:Delete the Object
            request.Delete(objID);
        }

        //Delete
        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            int objID;
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj request = new Obj(myClient);
            //Act:Create the Object
            request.type = ObjectType. CLIENT;
            request.title = " My Client";
            request.cmdbStatus = CmdbStatus.INOPERATION;
            objID = request.Create();
            //Act:Delete the Object
            request.Delete(objID);
            //Assert
            Assert.IsNotNull(objID);
        }

        //Delete and than check if the Object is deleted
        [TestMethod]
        public void DeleteTestCheckIfTheObjectDeleted()
        {
            //Arrange
            int objID;
            Result list = new Result();
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj request = new Obj(myClient);
            //Act:Create the Object
            request.type = ObjectType. CLIENT;
            request.title = "Laptop 001";
            request.cmdbStatus = CmdbStatus.PLANNED;
            objID = request.Create();
            //Act:Delete the Object
            request.Delete(objID);
            //Act:Read the Object
            list = request.Read(objID);
            //Assert
            Assert.AreEqual("4", list.status);
        }

        //Archive
        [TestMethod]
        public void ArchiveTest()
        {
            //Arrange
            int objID;
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj request = new Obj(myClient);
            //Act
            request.type = ObjectType. PRINTER;
            request.title = "HQ Printer";
            request.cmdbStatus = CmdbStatus.INOPERATION;
            objID = request.Create();
            request.Archive(objID);
            //Assert
            Assert.IsNotNull(objID);
        }

        //Archive and than check if the Object is archied
        [TestMethod]
        public void ArchiveTestCheckIfTheObjectArchived()
        {
            //Arrange
            int objID;
            Result list = new Result();
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj request = new Obj(myClient);

            //Act:Create the Object
            request.type = ObjectType. ROUTER;
            request.title = "HQ Gateway";
            request.cmdbStatus = CmdbStatus.DEFECT;
            objID = request.Create();

            //Act:Archive the Object
            request.Archive(objID);

            //Act:Read the Object
            list = request.Read(objID);

            //Assert
            Assert.AreEqual("3", list.status);
        }


        //Purge
        [TestMethod]
        public void PurgeTest()
        {
            //Arrange
            int objID;
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj request = new Obj(myClient);

            //Act:Create the Object
            request.type = ObjectType. MONITOR;
            request.title = "TFT 001";
            request.cmdbStatus = CmdbStatus.STORED;
            objID = request.Create();

            //Act:Purge the Object
            request.Purge(objID);

            //Assert
            Assert.IsNotNull(objID);

        }

        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int objID;
            Result list = new Result();
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj request = new Obj(myClient);
            //Act:Create the Object
            request.type = ObjectType. SERVER;
            request.title = " Switch Colo A001 02";
            request.cmdbStatus = CmdbStatus.INOPERATION;
            objID = request.Create();
            //Act:Update the Object
            request.title = "Switch Colo A001 01";
            request.Update(objID);
            //Act:Read the Object
            list = request.Read(objID);
            //Assert
            Assert.AreEqual("Switch Colo A001 01", list.title);
        }

        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            int objID;
            Result list = new Result();
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj request = new Obj(myClient);
            //Act:Create the Object
            request.type = ObjectType.SERVER;
            request.title = "Ceph Storage Pod A001 01";
            request.cmdbStatus = CmdbStatus.PLANNED;
            objID = request.Create();
            //Act:Read the Object
            list = request.Read(objID);
            //Assert
            Assert.AreEqual(objID, list.id);
            Assert.AreEqual("Ceph Storage Pod A001 01", list.title);
            Assert.IsNotNull(list.title);
            Assert.IsNotNull(list.cmdbStatus);
            //Act:Delete the Object
            request.Purge(objID);
        }
    }
}
