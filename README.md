# Idoit.API.Client

Make your i-doit API calls in C#

[![NuGet package](https://img.shields.io/badge/nuget-Idoit.API.Client-blue.svg)](https://www.nuget.org/packages/Idoit.API.Client/)

## About i-doit

[i-doit](https://www.i-doit.com/en) stands for „I document IT“. By using i-doit you obtain the “point of information” 
for all your IT processes. Everything, that needs to be documented is centralized in one single spot.

Updates are carried out automatically or manually. This gives you a comprehensive overview of your IT.

However, with i-doit you do not document your hardware only. You also have a full-fledged CMDB at hand, 
with which you can interrelate all aspects of your IT environment.
 
## Project Details

The `Idoit.API.Client` is going to make your work faster and more efficient, especially in the work relating to Visual studio.
You will be able to open a user session, which will help you to save resources on the server side and will 
additionally allow to perform more calls in a shorter time frame. 

By using the request and response HTTP headers, the `Idoit.API.Client` will help you to search for objects and 
furthermore to get the current version of i-doit.

Relating to objects, this library will help you to search for them as well as
`create`, `delete`, `archive`, `purge`, `update` and `read` objects and `read` object types.

In addition you will be able to `create`, `delete`, `archive`, `purge`, `update` and `read` 
multi-value categories and single-value categories.

## Requirements 

The following requirements are necessary before installing or using the `Idoit.API.Client`.

- A running instance of [i-doit](https://www.i-doit.com/en/i-doit/trial-version/) pro or open, version 1.12.4 or higher
- i-doit [API add-on](https://www.i-doit.com/en/i-doit/add-ons/api-add-on/), version 1.10.3 or higher
- Windows 7 or 10
- Visual Studio 2017 version 15.9 or higher
- .Net framework version 4.7.2 or higher

## Install and update

- You can find the `Idoit.API.Client` by searching in the NuGet Package Manager,
  click on the menu bar `Project > Manage NuGet Package`.
- There is another way for install or update the `Idoit.API.Client` by executing the following code 
  after clicking on the menu bar `Tools > NuGetPackage Manager > Package Manager Console`
  
    PM> Install-Package Idoit.API.Client 

    or

    PM> Update-Package Idoit.API.Client

## A simple example

```cs
using System;
using Idoit.API.Client;
using idoit = Idoit.API.Client.Idoit.Idoit;
using Version = Idoit.API.Client.Idoit.Response.Version;

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
            response = idoit.Version();
            Console.WriteLine("The  currently i-doit version is: " +"'"+ response.version+"'");
            Console.WriteLine("The currently i-doit type is: " + "'" + response.type + "'" );
            Console.WriteLine("The steps are: " + "'" + response.step+"'" );
            Console.WriteLine("Your userId is: " + "'" + response.login.userId+ "'" );
            Console.WriteLine("The name is: " + "'" + response.login.name+ "'" );
            Console.WriteLine("The mail is: " + "'" + response.login.mail+ "'" );
            Console.WriteLine("The username is: " + "'" + response.login.userName+ "'" );
            Console.WriteLine("The mandator is: " + "'" + response.login.mandator+ "'" );
            Console.WriteLine("The language is:  " + "'" + response.login.language+ "'" );
        }
    }
}
```
## Documentation
 
 If you want to see more examples, click on the following links

- Under [idoit](docs/idoit.md) you can search for objects, 
  it is possible to login or logout and it shows you the currently version of  your i-doit.

- Under [cmdb](docs/cmdb/README.md) you can easily work with the objects, object types, categories and
  dialog fields.

## Problems?

Please, report any issues to [our issue tracker](https://github.com/OKT90/Idoit.API.Client/issues). 
Pull requests are very welcomed. If you like to get involved see file [CONTRIBUTING.md](CONTRIBUTING.md) for details.

## Copyright & license

Copyright (C) 2019 [synetics GmbH](https://i-doit.com/en)

[MIT license](LICENSE)
