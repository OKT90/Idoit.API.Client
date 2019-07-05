# CMDB.dialog namespace

This namespace helps you to set new values in the dialog fields by using the method `Create` as well as
updating them with the method `Update`, deleting with the method `Delete` and reading with the method `Read`  

## Code examples

### Create

```cs
using System;
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Dialog.Request;
using Dialog = Idoit.API.Client.CMDB.Dialog.Dialog;
using Category = Idoit.API.Client.Contants.Category;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int Id;
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            Dialog request = new Dialog(myClient);
            request.property = Cpu.Manufacturer;
            request.value = "Intel";
            request.category = Category.CPU;
            Id = request.Create();
            Console.WriteLine("The Id is" + "'" + Id + "'");
        }
    }
}
```

### Update

```cs
using System;
using Idoit.API.Client;
using System.IO;
using System.Collections.Generic;
using Dialog = Idoit.API.Client.CMDB.Dialog.Dialog;
using Category = Idoit.API.Client.Contants.Category;
using Idoit.API.Client.CMDB.Dialog.Request;
using Result = Idoit.API.Client.CMDB.Dialog.Response.Result;
using Idoit.API.Client.CMDB.Object.Response;
using Idoit.API.Client.CMDB.Object;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int Id;
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            Dialog request = new Dialog(myClient);
            List<Result[]> lists = new List<Result[]>();
            request.property = Cpu.Manufacturer;
            request.value = "IBM";
            request.category = Category.CPU;
            Id = request.Create();
            lists = request.Read();
            foreach (Result[] row in lists)
            {
                foreach (Result element in row)
                {
                    Console.WriteLine("The Id is" + "'" + element.id + "'");
                    Console.WriteLine("The title is" + "'" + element.title + "'");
                }
            }
            request.property = Cpu.Manufacturer;
            request.value = "Intel";
            request.category = Category.CPU;
            request.Update(Id);
            lists = request.Read();
            foreach (Result[] row in lists)
            {
                foreach (Result element in row)
                {
                    Console.WriteLine("The Id is" + "'" + element.id + "'");
                    Console.WriteLine("The title is" + "'" + element.title + "'");
                }
            }
        }
    }
}

```

### Delete

```cs
using System;
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Dialog.Request;
using Dialog = Idoit.API.Client.CMDB.Dialog.Dialog;
using Category = Idoit.API.Client.Contants.Category;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int Id;
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            Dialog request = new Dialog(myClient);
            request.property = Cpu.Manufacturer;
            request.value = "IBM";
            request.category = Category.CPU;
            Id = request.Create();            
            request.Delete(Id);
        }
    }
}
```

### Read

```cs
using System;
using Idoit.API.Client;
using System.IO;
using System.Collections.Generic;
using Dialog = Idoit.API.Client.CMDB.Dialog.Dialog;
using Category = Idoit.API.Client.Contants.Category;
using Idoit.API.Client.CMDB.Dialog.Request;
using Result = Idoit.API.Client.CMDB.Dialog.Response.Result;
using Idoit.API.Client.CMDB.Object.Response;
using Idoit.API.Client.CMDB.Object;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            Dialog request = new Dialog(myClient);
            List<Result[]> lists = new List<Result[]>();
            request.property = Cpu.Frequency;
            request.category = Category.CPU;
            lists = request.Read();
            foreach (Result[] row in lists)
            {
                foreach (Result element in row)
                {
                    Console.WriteLine("The Id is" + "'" + element.id + "'");
                    Console.WriteLine("The title is" + "'" + element.title + "'");
                }
            }
        }
    }
}
```
