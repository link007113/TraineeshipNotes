Uitleg doormiddel van container schepen.

klasieke deployment vs docker deployment

Verschil tussen docker containers en virtualisatie

```dockerfile
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ArgumentEcho/ArgumentEcho.csproj", "ArgumentEcho/"]
RUN dotnet restore "ArgumentEcho/ArgumentEcho.csproj"
COPY . .
WORKDIR "/src/ArgumentEcho"
RUN dotnet build "ArgumentEcho.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArgumentEcho.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArgumentEcho.dll"]
```