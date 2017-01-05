# Picavi API reference implementation in C#/.NET
The Picavi API is a standard interface for logistic warehouse's processes. The
technical interface is based on JSON-RPC over HTTP. An implementation of this
JSON-RPC Web Service enables a backend ERP-System or WMS to connect and
communicate with Picavi Smart Glasses.

This is the C#/.NET reference implementation.


## System Requirements

* [Microsoft .NET Framework 4.5.2](https://www.microsoft.com/en-us/download/details.aspx?id=42642) >= 4.5.2

* [Mono Framework](http://www.mono-project.com/download/) >= 4.4


## NuGet Packages

[NancyFx](http://nancyfx.org/)  
Nancy is a lightweight, low-ceremony, framework for building HTTP based services
on .NET and Mono.

[Json.NET](http://www.newtonsoft.com/json)  
Popular high-performance JSON framework for .NET

[Simple Injector](https://simpleinjector.org/)  
Simple Injector is an open source dependency injection (DI) library for .NET

[Topshelf](http://topshelf-project.com/)  
An easy service hosting framework for building Windows services using .NET
