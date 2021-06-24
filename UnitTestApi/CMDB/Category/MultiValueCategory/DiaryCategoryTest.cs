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
            objectRequest.title = "Server01";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.f_wysiwyg_c_1581927732804 = "Test the Entry";
            categoryRequest.f_popup_c_1581927717973 = "2001-04-04";
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
            objectRequest.title = "Server01";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.f_wysiwyg_c_1581927732804 = "Install a software";
            categoryRequest.f_popup_c_1581927723207 = 522;
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
            objectRequest.title = "Server01";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.f_wysiwyg_c_1581927732804 = "Install a software";
            categoryRequest.f_popup_c_1581927723207 = 522;
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
            objectRequest.title = "Server01";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.f_wysiwyg_c_1581927732804 = "Install a software";
            categoryRequest.f_popup_c_1581927723207 = 522;
            cateId = diary.Create(objectId, categoryRequest);

            //Act: Update the Category
            categoryRequest.description = "Test the description";
            categoryRequest.f_wysiwyg_c_1581927732804 = "Install a software";
            categoryRequest.f_popup_c_1581927723207 = 522;
            categoryRequest.category_id = cateId;
            diary.Update(objectId, categoryRequest);

            //Act:Read the Category
            categoryRequest.category_id = cateId;
            list = diary.Read(objectId);

            //Assert
            foreach (DiaryResponse[] row in list)
            {
                foreach (DiaryResponse element in row)
                {
                    Assert.AreEqual("Test the description", categoryRequest.description);
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
            List<DiaryResponse[]> list = new List<DiaryResponse[]>();
            Client myClient = new Client(URL, APIKEY, LANGUAGE);
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj objectRequest = new Obj(myClient);
            DiaryRequset categoryRequest = new DiaryRequset();
            Diary diary = new Diary(myClient);

            //Act:Create the Object
            objectRequest.type = ObjectType.SERVER;
            objectRequest.title = "Server01";
            objectRequest.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.f_wysiwyg_c_1581927732804 = "Install a software";
            categoryRequest.f_popup_c_1581927723207 = 522;
            categoryRequest.description = "Test the description";
            cateId = diary.Create(objectId, categoryRequest);

            //Act:Read the Category
            categoryRequest.category_id = cateId;
            list = diary.Read(objectId);

            //Assert
            foreach (DiaryResponse[] row in list)
            {
                foreach (DiaryResponse element in row)
                {
                    Assert.AreEqual("Test the description", categoryRequest.description);
                }
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }
    }
}
