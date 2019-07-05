## SingleValueCategory namespace

This namespace helps you to create a single-value category in i-doit by using the method `Create` as well as
updating it with the method `Update`, quick purging with the method `Quickpurge` and reading with the method `Read`  

## Code examples

### Create

```cs
using System;
using System.IO;
using System.Collections.Generic;
using Idoit.API.Client;
using Model = Idoit.API.Client.CMDB.Category.Model;
using Requset = Idoit.API.Client.CMDB.Category.Request.Model;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int cateId, objectId;
            Requset request = new Requset();
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj obj = new Obj(myClient);
            Model Model = new Model(myClient);
            obj.type = ObjectType.CLIENT;
            obj.title = "Laptop 001";
            obj.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = obj.Create();
            request.title = "T-450s";
            request.manufacturer = 1;
            cateId = Model.Create(objectId, request);
            Console.WriteLine("You have created a category with the id  '" + cateId + "'");
        }
    }
}
```

### Read

```cs
using System;
using System.IO;
using System.Collections.Generic;
using Idoit.API.Client;
using Model = Idoit.API.Client.CMDB.Category.Model;
using Requset = Idoit.API.Client.CMDB.Category.Request.Model;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using Response = Idoit.API.Client.CMDB.Category.Response.Model;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int cateId, objectId;
            Requset request = new Requset();
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            List<Response[]> list = new List<Response[]>();
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj obj = new Obj(myClient);
            Model Model = new Model(myClient);
            obj.type = ObjectType.CLIENT;
            obj.title = "Laptop 001";
            obj.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = obj.Create();
            request.title = " T-450s";
            request.manufacturer = 1;
            request.serial = "57852374";
            cateId = Model.Create(objectId, request);
            list = Model.Read(objectId);
            foreach (Response[] row in list)
            {
                foreach (Response element in row)
                {
                    Console.WriteLine("The serial number is '" +element.serial + "'");
                }
            }
        }
    }
}
```

### Quickpurge

```cs
using System;
using System.IO;
using System.Collections.Generic;
using Idoit.API.Client;
using Model = Idoit.API.Client.CMDB.Category.Model;
using Requset = Idoit.API.Client.CMDB.Category.Request.Model;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int cateId, objectId;
            Requset request = new Requset();
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj obj = new Obj(myClient);
            Model Model = new Model(myClient);
            obj.type = ObjectType.CLIENT;
            obj.title = "Laptop 001";
            obj.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = obj.Create();
            request.title = "Web GUI";
            request.title = " T-450s";
            request.manufacturer = 1;
            cateId = Model.Create(objectId, request);
            Model.Quickpurge(objectId, cateId);
        }
    }
}
```

### Update

```cs
using System;
using System.IO;
using System.Collections.Generic;
using Idoit.API.Client;
using Model = Idoit.API.Client.CMDB.Category.Model;
using Requset = Idoit.API.Client.CMDB.Category.Request.Model;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using Response = Idoit.API.Client.CMDB.Category.Response.Model;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int cateId, objectId;
            List<Response[]> list = new List<Response[]>();
            Requset request = new Requset();
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            myClient.Username = "admin";
            myClient.Password = "admin";
            Obj obj = new Obj(myClient);
            Model Model = new Model(myClient);
            obj.type = ObjectType.CLIENT;
            obj.title = "Laptop 001";
            obj.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = obj.Create();
            request.title = " T-450ws";
            request.manufacturer = 1;
            request.serial = "57853s4";
            cateId = Model.Create(objectId, request);
            request.title = " T-450s";
            request.serial = "57852374";
            Model.Update(objectId, request);
            list = Model.Read(objectId);
            foreach (Response[] row in list)
            {
                foreach (Response element in row)
                {
                    Console.WriteLine("The serial is: " + "'" + element.serial + "'");
                }
            }
        }
    }
}
```
