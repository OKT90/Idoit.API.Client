## CMDB.Objects namespace

This namespace helps you to read objects from i-doit by using the method `Read`.

```cs
using System;
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Objects;
using System.Collections.Generic;
using Idoit.API.Client.CMDB.Objects.Request;
using Idoit.API.Client.CMDB.Objects.Response;
using idoit = Idoit.API.Client.Idoit.Idoit;
using ObjectsRead = Idoit.API.Client.CMDB.Objects.Objects;
using Result = Idoit.API.Client.CMDB.Objects.Response.Result;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using Idoit.API.Client.CMDB.Object.Response;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Result[]> lists = new List<Result[]>();
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            myClient.Username = "admin";
            myClient.Password = "admin";
            ObjectsRead request = new ObjectsRead(myClient);
            Obj requestToCreateObjects= new Obj(myClient);
            Filter filter = new Filter();
            int[] ObjectId = new int[10];
            for (int i = 0; i < 10; i++)
            {
                requestToCreateObjects.type = ObjectType.ROUTER;
                requestToCreateObjects.title = " Router " + i;
                requestToCreateObjects.cmdbStatus = CmdbStatus.INOPERATION;
                ObjectId[i] = requestToCreateObjects.Create();
            }
            request.limit = "0,10";
            request.orderBy = OrderBy.Title;
            request.sort = Sort.Acsending;
            filter.ids = new int[] { ObjectId[0], ObjectId[8] };
            filter.type = ObjectType.ROUTER;
            lists = request.Read(filter);
            foreach (Result[] row in lists)
            {
                foreach (Result element in row)
                {
                    Console.WriteLine("ObjectId  " + "'" + element.id
                     + "' has" + "'" + element.title + "' as Title");
                }
            }
            for (int i = 0; i < 10; i++)
            {
                requestToCreateObjects.Purge(ObjectId[i]);
            }
        }
    }
}
```
