# RealStateAPI
## _Web API_


This application is a Web API that work with EF DbContext and connect to a Database for obtain and modify information for Real State company.


## Features

- Create a property Building
- Add image from property
- Change property price
- Update views counter from property
- List a property by specific filters

## Tech

Dillinger uses a number of open source projects to work properly:

- [.NET 5] - Cross-platform successor to .NET Framework
- [Swagger] - Swagger offers the most powerful and easiest to use tools to take full advantage of the OpenAPI Specification.
- [MSSQL Server] - Relational database management system developed by Microsoft.
- [NUnit] - Open-source unit testing framework for the.NET Framework and Mono
- [C#] - General-purpose, multi-paradigm programming language encompassing static typing, strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented, and component-oriented programming disciplines.

And of course this app itself is open source with a [public repository][Kamo] on GitHub.

## Run

Dillinger requires [IISExpress](https://www.microsoft.com/en-us/download/details.aspx?id=48264) or any similar application server to run.


```sh
dotnet build
dotnet run
```

## NuGet Packages

This are the NuGet packages used into the application

| Plugin | README |
| ------ | ------ |
| Mapper | [AutoMapper/blob/master/README.md][Mapper] |
| Linkit | [LINQKit/blob/master/README.md][Linkit] |
| EF Core | [efcore/blob/main/README.md][EFCore] |

## License

MIT

**Free Software, Hell Yeah!**


   
   [.NET 5]: <https://dotnet.microsoft.com/download/dotnet/5.0g>
   [Swagger]: <https://swagger.io>
   [MSSQL Server]: <https://www.microsoft.com/en-us/sql-server/sql-server-downloads>
   [NUnit]: <https://nunit.org> 
   [C#]: <https://en.wikipedia.org/wiki/C_Sharp_%28programming_language%29> 
   [Kamo]: <https://github.com/K4m0/RealStateAPI>
   

   [Mapper]: <https://github.com/AutoMapper/AutoMapper/blob/master/README.md>
   [Linkit]: <https://github.com/scottksmith95/LINQKit/blob/master/README.md>
   [EFCore]: <https://github.com/dotnet/efcore/blob/main/README.md>
   
