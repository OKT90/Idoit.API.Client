using System;
using System.Collections.Generic;
using Idoit.API.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diary = Idoit.API.Client.CMDB.Category.Diary;
using DiaryRequset = Idoit.API.Client.CMDB.Category.Request.Diary;
using DiaryResponse = Idoit.API.Client.CMDB.Category.Response.Diary;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using Result = Idoit.API.Client.CMDB.Object.Response.Result;
using System.IO;

namespace UnitTestApi.CMDB.Category.MultiValueCategory
{

    [TestClass]
    public class DiaryCategoryTest
    {
        string URL;
        string APIKEY;
        string LANGUAGE;

        [TestInitialize]
        public void Setup()
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
            int cateId, objectId;
            List<DiaryResponse[]> list = new List<DiaryResponse[]>();
            DiaryRequset categoryRequest = new DiaryRequset();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            Diary diary = new Diary(myClient);
            //Act:Create the Object
            objectRequest.type = ObjectType.SERVER;
            objectRequest.title = "My Server";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.f_wysiwyg_c_1581927732804 = "New Entry";
            categoryRequest.f_popup_c_1581927717973 = "2021-02-01";
            cateId = diary.Create(objectId, categoryRequest);

            //Assert
            Assert.IsNotNull(cateId);

            //Act: Read the Category
            categoryRequest.category_id = cateId;
            list = diary.Read(objectId);

            //Assert
            foreach (DiaryResponse[] row in list)
            {
                foreach (DiaryResponse element in row)
                {
                    Assert.IsNotNull(element.date.date);
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
            List<DiaryResponse[]> list = new List<DiaryResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            DiaryRequset categoryRequest = new DiaryRequset();
            Diary diary = new Diary(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType.SERVER;
            objectRequest.title = "My Server";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.f_wysiwyg_c_1581927732804 = "New Entry";
            categoryRequest.f_popup_c_1581927717973 = "2020-04-04";
            cateId = diary.Create(objectId, categoryRequest);

            //Act
            diary.Delete(objectId, cateId);

            //Act:Read the Category
            categoryRequest.category_id = cateId;
            list = diary.Read(objectId);

            //Assert
            foreach (DiaryResponse[] row in list)
            {
                foreach (DiaryResponse element in row)
                {
                    Assert.IsNotNull(element.entry);
                    Assert.IsNotNull(element.author.title);
                }
            }
            //Act: Delete the Object
            objectRequest.Delete(objectId);
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
            DiaryRequset categoryRequest = new DiaryRequset();
            Diary diary = new Diary(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType.SERVER;
            objectRequest.title = "My Server";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.f_wysiwyg_c_1581927732804 = "New Entry";
            categoryRequest.f_popup_c_1581927717973 = "2020-04-04";
            cateId = diary.Create(objectId, categoryRequest);

            //Act: Delete the Category
            diary.Quickpurge(objectId, cateId);

            //Act: Delete the Object
            objectRequest.Delete(objectId);
        }

        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int cateId, objectIdServer, objectIdPerson01, objectIdPerson02;
            List<DiaryResponse[]> list = new List<DiaryResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Result readObject = new Result();
            Obj objectRequest = new Obj(myClient);
            DiaryRequset categoryRequest = new DiaryRequset();
            Diary diary = new Diary(myClient);

            //Act:Create the Object Server
            objectRequest.type = ObjectType.SERVER;
            objectRequest.title = "MY Server";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectIdServer = objectRequest.Create();

            //Act:Create the Object Person 1
            objectRequest.type = ObjectType.PERSON;
            objectRequest.title = "Person01";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectIdPerson01 = objectRequest.Create();

            //Act:Create the Object Person 2
            objectRequest.type = ObjectType.PERSON;
            objectRequest.title = "Person02";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectIdPerson02 = objectRequest.Create();

            //Act:Read the Object Person 1
            readObject = objectRequest.Read(objectIdPerson01);

            //Act: Create the Category
            categoryRequest.f_wysiwyg_c_1581927732804 = "New Entry";
            categoryRequest.f_popup_c_1581927717973 = "2020-04-04";
            categoryRequest.f_popup_c_1581927723207 = readObject.id;
            cateId = diary.Create(objectIdServer, categoryRequest);

            //Act:Read the Object Person 2
            readObject = objectRequest.Read(objectIdPerson02);

            //Act: Update the Category
            categoryRequest.f_wysiwyg_c_1581927732804 = "Install a software";
            categoryRequest.f_popup_c_1581927717973 = "2021-04-01";
            categoryRequest.f_popup_c_1581927723207 = readObject.id;
            categoryRequest.category_id = cateId;
            diary.Update(objectIdServer, categoryRequest);

            //Act:Read the Category
            categoryRequest.category_id = cateId;
            list = diary.Read(objectIdServer);

            //Assert
            foreach (DiaryResponse[] row in list)
            {
                foreach (DiaryResponse element in row)
                {
                    Assert.AreEqual("2021-04-01", categoryRequest.f_popup_c_1581927717973);
                }
            }

            //Act:Delete the Object Server
            objectRequest.Delete(objectIdServer);
            //Act:Delete the Object Person 1
            objectRequest.Delete(objectIdPerson01);
            //Act:Delete the Object Person 2
            objectRequest.Delete(objectIdPerson02);
        }

        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            int cateId, objectId;
            List<DiaryResponse[]> list = new List<DiaryResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            DiaryRequset categoryRequest = new DiaryRequset();
            Diary diary = new Diary(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType.SERVER;
            objectRequest.title = "My Server";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.f_wysiwyg_c_1581927732804 = "New Entry";
            categoryRequest.f_popup_c_1581927717973 = "2022-03-04";
            cateId = diary.Create(objectId, categoryRequest);

            //Act:Read the Category
            categoryRequest.category_id = cateId;
            list = diary.Read(objectId);

            //Assert
            foreach (DiaryResponse[] row in list)
            {
                foreach (DiaryResponse element in row)
                {
                    Assert.AreEqual("2022-03-04", categoryRequest.f_popup_c_1581927717973);
                }
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }
    }
}
