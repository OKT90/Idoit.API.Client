using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idoit.API.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using idoit = Idoit.API.Client.Idoit.Idoit;
using Version = Idoit.API.Client.Idoit.Response.Version;
using Logout = Idoit.API.Client.Idoit.Response.Logout;
using Login = Idoit.API.Client.Idoit.Response.Login;
using Search = Idoit.API.Client.Idoit.Response.Search;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using System.IO;
using System.Net.Http;
using Idoit.API.Client.Idoit;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace UnitTestApi.Idoit
{
    //[Ignore]
    [TestClass]
    public class IdoitTest
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
      
        //Version
        [TestMethod]
        public void VersionTest()
        {
            //Arrange
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            idoit idoit = new idoit(myClient);
            Version request = new Version();
            Logout logout = new Logout();
            Login login = new Login();

            //login
            login = idoit.Login();
            
            //Version
            myClient.sessionId = login.sessionId;
            request = idoit.Version();

            //Logout
            logout = idoit.Logout();
            
           //Assert
            Assert.IsNotNull(request.version);
            Assert.IsNotNull(request.type);
            Assert.IsNotNull(request.login.language);
        }

        //Logout
        [TestMethod]
        public void LogoutTest()
        {
            //Arrange
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            idoit idoit = new idoit(myClient);
            Logout request = new Logout();

            //Act
            request = idoit.Logout();

            //Assert
            Assert.IsNotNull(request.message);
            Assert.IsTrue(request.result);
        }
        //Login
        [TestMethod]
        public void LoginTest()
        {

            //Arrange
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            idoit idoit = new idoit(myClient);
            Login request = new Login();

            //Act
            request = idoit.Login();

            //Assert
            Assert.IsTrue(request.result);
            Assert.IsNotNull(request.userId);
        }

        //Search
        [TestMethod]
        public void SearchTest()
        {
            //Arrange
            int objID;
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            idoit idoit = new idoit(myClient);
            Obj request = new Obj(myClient);
            List<Search[]> lists = new List<Search[]>();

            //Act
            request.type = ObjectType.PRINTER;
            request.title = "Printer 01";
            request.cmdbStatus = CmdbStatus.DEFECT;
            objID = request.Create();


            //Act:Search 
            lists = idoit.Search(request.title);

            //Assert
            foreach (Search[] row in lists)
            {
                foreach (Search element in row)
                {
                    Assert.IsNotNull(element.link);
                    Assert.IsNotNull(element.key);
                    Assert.IsNotNull(element.value);
                }
            }
            //Assert
            Assert.IsNotNull(objID);
            Assert.IsNotNull(request.title);
            Assert.IsNotNull(request.type);
            Assert.IsNotNull(request.cmdbStatus);

            //Act:Delete the Object
            request.Delete(objID);

        }

        //Constants
        [TestMethod]
        public void ConstantsReadObjectTypesTest()
        {
            //Arrange
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Constants constants = new Constants(myClient);
            Dictionary<string, string> lists = new Dictionary<string, string>();

            lists = constants.ReadObjectTypes();

            foreach (var pair in lists)
            {
                Console.WriteLine(pair.Key, pair.Value);
            }
        }

        //Constants
        [TestMethod]
        public void ConstantsReadRecordStatesTest()
        {
            //Arrange
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Constants constants = new Constants(myClient);
            Dictionary<string, string> lists = new Dictionary<string, string>();

            lists = constants.ReadRecordStates();

            foreach (var pair in lists)
            {
                Console.WriteLine(pair.Key, pair.Value);
            }
        }
        //Constants
        [TestMethod]
        public void ConstantsReadCategoriesGlobalTest()
        {
            //Arrange
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Constants constants = new Constants(myClient);
            Dictionary<string, string> lists = new Dictionary<string, string>();

            lists = constants.ReadGlobalCategories();

            foreach (var pair in lists)
            {
                //Assert
                Assert.IsNotNull(pair.Key);
                Assert.IsNotNull(pair.Value);
            }

        }
        //Constants
        [TestMethod]
        public void ConstantsReadCategoriesSpecificTest()
        {
            //Arrange
            Client myClient = new Client(URL, APIKEY, LANGUAGE, proxySettings);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Constants constants = new Constants(myClient);
            Dictionary<string, string> lists = new Dictionary<string, string>();

            lists = constants.ReadSpecificCategories();

            foreach (var pair in lists)
            {
                //Assert
                Assert.IsNotNull(pair.Key);
                Assert.IsNotNull(pair.Value);
             }
        }
    }
}
