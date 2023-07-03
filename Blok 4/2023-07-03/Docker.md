Uitleg doormiddel van container schepen.

klasieke deployment vs docker deployment

Verschil tussen docker containers en virtualisatie

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:7.0 
WORKDIR /app
COPY ./bin/Debug/net7.0 .
ENTRYPOINT ["dotnet", "ArgumentEcho.dll"]
```