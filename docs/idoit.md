# idoit namespace 

This namespace helps you to search for objects by using the method `Search` as well as opening and closing a user session
by using `Login` and `Logout` methods and you are able to get the current version of i-doit by using the method `Version`

## Code examples

### Search

```cs
using System;
using Idoit.API.Client;
using idoit = Idoit.API.Client.Idoit.Idoit;
using Search = Idoit.API.Client.Idoit.Response.Search;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            myClient.Username = "admin";
            myClient.Password = "admin";
            idoit idoit = new idoit(myClient);
            List<Search[]> lists = new List<Search[]>();
            lists = idoit.Search("Client");
            foreach (Search[] row in lists)
            {
                foreach (Search element in row)
                {
                    Console.WriteLine("The Link is: " + "'" + element.link + "'");
                    Console.WriteLine("The Source is: " + "'" + element.key + "'");
                    Console.WriteLine("The Object name is: " + "'" + element.value + "'");
                    Console.WriteLine("------------------------------------------------------------");
                }
            }
        }
    }
}
```

### Login

```cs
using System;
using Idoit.API.Client;
using idoit = Idoit.API.Client.Idoit.Idoit;
using Login = Idoit.API.Client.Idoit.Response.Login;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            myClient.Username = "admin";
            myClient.Password = "admin";
            idoit idoit = new idoit(myClient);
            Login response = new Login();
            response = idoit.Login();
            Console.WriteLine("logging in i-doit: " + "'" + response.result + "'");     
            Console.WriteLine("Your userId is: " + "'" + response.userId + "'");
        }
    }
}
```

### Logout

```cs
using System;
using Idoit.API.Client;
using idoit = Idoit.API.Client.Idoit.Idoit;
using Logout = Idoit.API.Client.Idoit.Response.Logout;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            myClient.Username = "admin";
            myClient.Password = "admin";
            idoit idoit = new idoit(myClient);
            Logout response = new Logout();
            response = idoit.Logout();
            Console.WriteLine("logging out i-doit: " + "'" + response.result + "'");
            Console.WriteLine("Message from i-doit, you have: " + "'" + response.message + "'");
        }
    }
}
```

### Version

```cs
using System;
using Idoit.API.Client;
using idoit = Idoit.API.Client.Idoit.Idoit;
using Version = Idoit.API.Client.Idoit.Response.Version;
using Logout = Idoit.API.Client.Idoit.Response.Logout;
using Login = Idoit.API.Client.Idoit.Response.Login;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Client myClient = new Client("https://example.com/src/jsonrpc.php", "Apikey", "en");
            myClient.Username = "admin";
            myClient.Password = "admin";
            idoit idoit = new idoit(myClient);
            Version response = new Version();
            Logout logout = new Logout();
            Login login = new Login();
            login = idoit.Login();
            myClient.sessionId = login.sessionId;
            response = idoit.Version();
            Console.WriteLine("The  currently i-doit version is: " +"'"+ response.version+"'");
            Console.WriteLine("The currently i-doit type is: " + "'" + response.type + "'" );
            Console.WriteLine("The steps are: " + "'" + response.step+"'" );
            Console.WriteLine("The userId is: " + "'" + response.login.userId+ "'" );
            Console.WriteLine("The name is: " + "'" + response.login.name+ "'" );
            Console.WriteLine("The mail is: " + "'" + response.login.mail+ "'" );
            Console.WriteLine("The username is: " + "'" + response.login.userName+ "'" );
            Console.WriteLine("The mandator is: " + "'" + response.login.mandator+ "'" );
            Console.WriteLine("The language is:  " + "'" + response.login.language+ "'" );
            logout = idoit.Logout();
        }
    }
}
```
