using System;
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Objects;
using Idoit.API.Client.CMDB.Objects.Request;
using Idoit.API.Client.CMDB.Objects.Response;
using Result = Idoit.API.Client.CMDB.Objects.Response.Result;
using ObjectsRead= Idoit.API.Client.CMDB.Objects.Objects;
using ObjectCreate= Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace UnitTestApi.CMDB.Objects
{
    [TestClass]
    public class ObjectsTest
    {
        string URL;
        string APIKEY;
        string LANGUAGE;
        public ObjectsTest()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Api.env");
            DotNetEnv.Env.Load(path); URL = DotNetEnv.Env.GetString("URL");
            APIKEY = DotNetEnv.Env.GetString("APIKEY");
            LANGUAGE = DotNetEnv.Env.GetString("LANGUAGE");
        }

        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            List<Result[]> lists = new List<Result[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            ObjectsRead request = new ObjectsRead(myClient);
            ObjectCreate requestCreate = new ObjectCreate(myClient);
            Filter filter = new Filter();
            int[] ObjectId = new int[10];

            //Act:Create the Objects
            for (int i = 0; i < 10; i++)
            {
                requestCreate.type = ObjectType.SYSTEM_SERVICE;
                requestCreate.title = " System Service "+i;
                requestCreate.cmdbStatus = CmdbStatus.PLANNED;
                ObjectId[i]=requestCreate.Create();
            }

            //Act : Read Objects
            request.limit = "0,10";
            request.orderBy = OrderBy.Title;
            request.sort = Sort.Acsending;
            filter.ids = new int[] { ObjectId[0], ObjectId[8] };
            filter.type = "C__OBJTYPE__SERVICE";
            //filter.title = "SystemService";
            lists = request.Read(filter);

            //Assert
            foreach (Result[] row in lists)
            {
                foreach (Result element in row)
                {
                    Assert.IsNotNull(element.title);
                    Assert.IsNotNull(element.id);
                }
            }

            //Act:Delete the Objects
            for (int i = 0; i < 10; i++)
            {
                requestCreate.Purge(ObjectId[i]);
            }
        }
    }
}
