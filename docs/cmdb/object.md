# CMDB.object namespace

This namespace helps you to create objects in i-doit by using the method `Create` as well as updating them with the method `Update`,
deleting with the method `Delete`, archiving with the method `Archive`, quick purging with the method `Quickpurge` and
reading with the method `Read`.


### Create Object 

```cs
using System;
using Idoit.API.Client;
using idoit = Idoit.API.Client.Idoit.Idoit;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int objId;
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            myClient.Username = "admin";
            myClient.Password = "admin";
            idoit idoit = new idoit(myClient);
            Obj request = new Obj(myClient);
            request.type = ObjectType.TYPE_PRINTER;
            request.title = "My Printer";
            request.cmdbStatus = CmdbStatus.sorted;
            objId = request.Create();
            Console.WriteLine("The objectId is: " + "'" + objId + "'");  
                 
        }
    }
}
```

### Delete Object 

```cs
using System;
using Idoit.API.Client;
using idoit = Idoit.API.Client.Idoit.Idoit;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using Idoit.API.Client.CMDB.Object.Response;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int objId;
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            myClient.Username = "admin";
            myClient.Password = "admin";
            idoit idoit = new idoit(myClient);
            Obj request = new Obj(myClient);
            Result list = new Result();
            request.type = ObjectType.TYPE_CITY;
            request.title = "Dormagen";
            request.cmdbStatus = CmdbStatus.planned;
            objId = request.Create();
            request.Delete(objId);
            list = request.Read(objId);
            /* "1": Unfinished,
             * "2": Normal,
             * "3": Archived,
             * "4": Deleted, 
             * "6": Template and
             * "7": Mass change template
             */
            if (list.status == "4")
            {
              Console.WriteLine("The object "+ "'" + request.title + "'" +  " with the objectId " + "'" 
              + objId + "'" + " has been deleted");
            }
        }
    }
}
```
### Archive Object 

```cs
using System;
using Idoit.API.Client;
using idoit = Idoit.API.Client.Idoit.Idoit;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using Idoit.API.Client.CMDB.Object.Response;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int objId;
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            myClient.Username = "admin";
            myClient.Password = "admin";
            idoit idoit = new idoit(myClient);
            Obj request = new Obj(myClient);
            Result list = new Result();
            request.type = ObjectType.CITY;
            request.title = "Duesseldorf";
            request.cmdbStatus = CmdbStatus.planned;
            objId = request.Create();
            request.Archive(objId);
            list = request.Read(objId);
            /* "1": Unfinished,
             * "2": Normal,
             * "3": Archived,
             * "4": Deleted, 
             * "6": Template and
             * "7": Mass change template
             */
            if (list.status == "3")
            {
                Console.WriteLine("The object "+ "'" + request.title + "'" +  " with the objectId " + "'"
                + objId + "'" + " has been archived");
            }
        }
    }
}
```

### purge Object 

```cs
using System;
using Idoit.API.Client;
using idoit = Idoit.API.Client.Idoit.Idoit;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int objId;
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            myClient.Username = "admin";
            myClient.Password = "admin";
            idoit idoit = new idoit(myClient);
            Obj request = new Obj(myClient);
            request.type = ObjectType.CITY;
            request.title = "Koeln";
            request.cmdbStatus = CmdbStatus.planned;
            objId = request.Create();
            request.Purge(objId);
            Console.WriteLine("The object "+ "'" + request.title + "'" +  " with the objectId " + "'" 
            + objId + "'" + " has been purged");
        }
    }
}
```

### Update Object 

```cs
using System;
using Idoit.API.Client;
using idoit = Idoit.API.Client.Idoit.Idoit;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int objId;
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            myClient.Username = "admin";
            myClient.Password = "admin";
            idoit idoit = new idoit(myClient);
            Obj request = new Obj(myClient);
            request.type = ObjectType.BUILDING;
            request.title = "A2";
            request.cmdbStatus = CmdbStatus.inOperation;
            objId = request.Create();
            request.title = "B2";
            request.Update(objId);
            Console.WriteLine("The objectId " + "'" + objId + "'" + " has been updated" +" to" + "'" 
            + request.title + "'");
        }
    }
}
```

### Read Object 

```cs
using System;
using Idoit.API.Client;
using idoit = Idoit.API.Client.Idoit.Idoit;
using Obj = Idoit.API.Client.CMDB.Object.Object;
using ObjectType = Idoit.API.Client.Contants.ObjectTypes;
using CmdbStatus = Idoit.API.Client.Contants.CmdbStatus;
using System.Collections.Generic;
using Idoit.API.Client.CMDB.Object.Response;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int objId;
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            myClient.Username = "admin";
            myClient.Password = "admin";
            idoit idoit = new idoit(myClient);
            Obj request = new Obj(myClient);
            Result list = new Result();
            request.type = ObjectType.BUILDING;
            request.title = "A2";
            request.cmdbStatus = CmdbStatus.inOperation;
            objId = request.Create();
            list = request.Read(objId);
            Console.WriteLine("The objectId is " + "'" + objId + "'");
            Console.WriteLine("The object title is " + "'" + list.title + "'");
            Console.WriteLine("The object type is " + "'" + list.typeTitle+ "'");
            Console.WriteLine("The object CMDB-Status is " + "'" + list.cmdbStatusTitle+ "'");
        }
    }
}
```
