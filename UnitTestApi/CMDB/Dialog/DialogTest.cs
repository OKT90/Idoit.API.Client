using System;
using Idoit.API.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Idoit.API.Client.CMDB.Object.Response;
using Idoit.API.Client.CMDB.Object;
using Dia=Idoit.API.Client.CMDB.Dialog.Dialog;
using Result = Idoit.API.Client.CMDB.Dialog.Response.Result;
using CategoryName=Idoit.API.Client.Contants.Category;
using Idoit.API.Client.CMDB.Dialog.Request;
using UnitTestApi.CMDB;
using System.IO;
using System.Collections.Generic;

namespace UnitTestApi.CMDB.Dialog
{
    [TestClass]
    public class DialogTest
    {
        string URL;
        string APIKEY;
        string LANGUAGE;
        public DialogTest()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Api.env");
            DotNetEnv.Env.Load(path); URL = DotNetEnv.Env.GetString("URL");
            APIKEY = DotNetEnv.Env.GetString("APIKEY");
            LANGUAGE = DotNetEnv.Env.GetString("LANGUAGE");
        }
        //Create
        [TestMethod]
        public void CreateTest()
        {
            //Arrange
            int objID;
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Dia request = new Dia(myClient);
            request.property =Cpu.Type;
            request.value = "Athlon XP";
            request.category = CategoryName.CPU;

            objID = request.Create();

            //Assert
            Assert.IsNotNull(objID);
            Assert.IsNotNull(request.property);
            Assert.IsNotNull(request.value);
            Assert.IsNotNull(request.category);

            //Act:Delete the Value
            request.Delete(objID);
        }

        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Dia request = new Dia(myClient);
            List<Result[]> lists = new List<Result[]>();
            //Act:Read 
            request.property = Global.Category;
            request.category = CategoryName.GLOBAL;
            lists = request.Read();
            //Assert
            foreach (Result[] row in lists)
            {
                foreach (Result element in row)
                {
                    Assert.IsNotNull(element.id);
                    Assert.IsNotNull(element.title);
                    Assert.IsNotNull(element.Const);
                }
            }
        }

        //Delete
        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            int objID;
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Dia request = new Dia(myClient);
            List<Result[]> lists = new List<Result[]>();
            //Act:Create 
            request.property = Access.Type;
            request.value = "ES23";
            request.category = CategoryName.ACCESS;
            objID = request.Create();
            //Act:Delete the Value
            request.Delete(objID);
        }

        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int objID;
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Dia request = new Dia(myClient);
            List<Result[]> lists = new List<Result[]>();
            //Act:Create 
            request.property = Port.PortType;
            request.value = "WLAN23";
            request.category = CategoryName.PORT;
            objID = request.Create();
            //Act:Update
            request.property = Port.PortType;
            request.value = "WLAN32";
            request.category = CategoryName.PORT;
            request.Update(objID);
            //Assert
            foreach (Result[] row in lists)
            {
                foreach (Result element in row)
                {
                    Assert.IsNotNull(element.id);
                    Assert.IsNotNull(element.title);
                    Assert.IsNotNull(element.Const);
                }
            }
            //Act:Delete the Value
            request.Delete(objID);
        }
    }
}
