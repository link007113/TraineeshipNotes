Uitleg doormiddel van container schepen.

klasieke deployment vs docker deployment

Verschil tussen docker containers en virtualisatie


Console app
```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:7.0 
WORKDIR /app
COPY ./bin/Debug/net7.0 .
ENTRYPOINT ["dotnet", "ArgumentEcho.dll"]
```
```bash
C:\WORK\BD23\AnthonyEllenbroek\Blok 4\2023-07-03\ArgumentEcho\ArgumentEcho>docker build -t argument-echo .

docker run argument-echo hallo world
```
ASP.NET App

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet
WORKDIR /app
COPY ./bin/Release/net7.0/publish .
EXPOSE 3000
ENTRYPOINT ["dotnet", "ArgumentEcho.Web.dll"]
```

```bash
C:\WORK\BD23\AnthonyEllenbroek\Blok 4\2023-07-03\ArgumentEcho.Web\ArgumentEcho.Web>docker build -t argument-echo-web .

docker run -d -p 3010:3000 argument-echo-web
```