
[![LICENSE](http://img.shields.io/badge/Licence-MIT-brightgreen.svg)](LICENSE.md)

# Introduction

IdentityServer4 with in-memory identity resources (openid + oauth2)


Currently runs with:

- dotnet v3.1.102

With this sample, you can :

- Run your app in a local development environment 
- Run your app in a production environment
- Package your app into an executable file for Linux, Windows & Mac

## Getting Started

Clone this repository locally :

``` bash
git@github.com:rud9321/IdentityServer4.git
```

Install dependencies with nuget :

``` bash
dotnet restore
```



Running identityserver4 app as authentication provider apart from it consist two more applications as client    
WebApp as Client.  
WebApi as Client.  

as more frequent changes and develpement i use watch tools to make things easier...

``` bash
dotnet watch run
```



## Included Commands

|port|Description|command
|--|--|--|
|`http://localhost:5000`| Execute the identityserver |`dotnet watch run`
|`https://localhost:3701`| Execure the WebApp |`dotnet watch run`
|`https://localhost:3801`| Execute the api  |`dotnet run`


## Branch & Packages version


identitysevice4-: [(master)](https://github.com/rud9321/IdentityServer4/tree/master)


