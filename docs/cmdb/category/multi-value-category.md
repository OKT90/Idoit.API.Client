## MultiValueCategory namespace

This namespace helps you to create a multi-value category in i-doit by using the method `Create` as well as 
updating it with the method `Update`, deleting with the method `Delete`, quick purging with the method `Quickpurge` and 
reading with the method `Read`  

## Code examples

### Create

```cs
using System;
using System.Collections.Generic;
using Idoit.API.Client;
using System.IO;
using Access = Idoit.API.Client.CMDB.Category.Access;
using Requset = Idoit.API.Client.CMDB.Category.Request.Access;
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
            Access access = new Access(myClient);
            obj.type = ObjectType.TYPE_CLIENT;
            obj.title = "Laptop 001";
            obj.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = obj.Create();
            request.title = "Web GUI";
            request.type = " ES";
            cateId = access.Create(objectId, request);
            Console.WriteLine("You have created a category with the id  '" + cateId + "'");
        }
    }
}
```

### Read

```cs
using System;
using System.Collections.Generic;
using Idoit.API.Client;
using System.IO;
using Access = Idoit.API.Client.CMDB.Category.Access;
using Requset = Idoit.API.Client.CMDB.Category.Request.Access;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using Response = Idoit.API.Client.CMDB.Category.Response.Access;
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
            Access access = new Access(myClient);
            obj.type = ObjectType.CLIENT;
            obj.title = "Laptop 001";
            obj.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = obj.Create();
            request.title = "Web GUI";
            request.type = " ES";
            cateId = access.Create(objectId, request);
            list = access.Read(objectId);
            foreach (Response[] row in list)
            {
                foreach (Response element in row)
                {
                    Console.WriteLine("The title is '" +  element.title + "'");
                }
            }
        }
    }
}
```

### Quickpurge

```cs
using System;
using System.Collections.Generic;
using System.IO;
using Idoit.API.Client;
using Access = Idoit.API.Client.CMDB.Category.Access;
using Requset = Idoit.API.Client.CMDB.Category.Request.Access;
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
            Access access = new Access(myClient);
            obj.type = ObjectType.CLIENT;
            obj.title = "Laptop 001";
            obj.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = obj.Create();
            request.title = "Web GUI";
            request.type = " ES";
            cateId = access.Create(objectId, request);
            access.Quickpurge(objectId, cateId);
        }
    }
}
```

### Delete

```cs
using System;
using System.Collections.Generic;
using Idoit.API.Client;
using System.IO;
using Access = Idoit.API.Client.CMDB.Category.Access;
using Requset = Idoit.API.Client.CMDB.Category.Request.Access;
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
            Access access = new Access(myClient);
            obj.type = ObjectType.CLIENT;
            obj.title = "Laptop 001";
            obj.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = obj.Create();
            request.title = "Web GUI";
            request.type = " ES";
            cateId = access.Create(objectId, request);
            access.Delete(objectId, cateId);
        }
    }
}
```

### Update

```cs
using System;
using System.Collections.Generic;
using Idoit.API.Client;
using System.IO;
using Access = Idoit.API.Client.CMDB.Category.Access;
using Requset = Idoit.API.Client.CMDB.Category.Request.Access;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using Response = Idoit.API.Client.CMDB.Category.Response.Access;

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
            Access access = new Access(myClient);
            obj.type = ObjectType.CLIENT;
            obj.title = "Laptop 001";
            obj.cmdbStatus = CmdbStatus.INOPERATION;
            objectId = obj.Create();
            request.title = "Wib GUI";
            request.type = " WS";
            cateId = access.Create(objectId, request);
            request.title = "Web GUI";
            request.type = " ES";
            request.category_id = cateId;
            access.Update(objectId, request);
            list = access.Read(objectId);
            foreach (Response[] row in list)
            {
                foreach (Response element in row)
                {
                    Console.WriteLine("The title is: " + "'" + element.title + "'");
                }
            }
        }
    }
}
```
