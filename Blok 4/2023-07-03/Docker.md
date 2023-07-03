Docker is een tool die het mogelijk maakt om je applicaties te isoleren in zogenaamde containers. Deze containers kunnen worden gezien als een losse verpakking - net als een containerschip - waarin alles zit wat nodig is om de applicatie te laten draaien. 

## Klassieke Deployment vs Docker Deployment

Bij een klassieke deployment hebben applicaties hun eigen omgeving op de server nodig en kunnen ze conflicteren met andere applicaties vanwege verschillende vereisten. Dit kan bijvoorbeeld zijn vanwege verschillende versies van bibliotheken en afhankelijkheden. 

Docker deployment daarentegen verpakt elke applicatie in een aparte container met alles wat het nodig heeft om te draaien. Deze containers kunnen naast elkaar op dezelfde machine draaien zonder conflicten.

## Verschil tussen Docker Containers en Virtualisatie

Virtualisatie draait meerdere besturingssystemen op dezelfde hardware, waarbij elke virtuele machine een volledig besturingssysteem bevat. Docker containers daarentegen delen hetzelfde besturingssysteem, maar isoleren de applicatieprocessen van elkaar. Hierdoor zijn Docker containers lichter en starten ze sneller op dan virtuele machines.

## Console App Dockerfile en Commands
```c#
namespace ArgumentEcho
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", args));
        }
    }
}
```
Het Dockerfile voor de console-app ziet er zo uit:
```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:7.0 
WORKDIR /app
COPY ./bin/Debug/net7.0 .
ENTRYPOINT ["dotnet", "ArgumentEcho.dll"]
```
Om een image te bouwen, voer je de volgende opdracht uit:
```bash
docker build -t argument-echo .
```
En om de container te draaien:
```bash
docker run argument-echo hallo world
```
## ASP.NET App Dockerfile en Commands
```c#
namespace ArgumentEcho.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/{*args}", (string? args) => String.Join(", ", (args ?? "").Split('/')));

            app.Run("http://0.0.0.0:3000");
        }
    }
}
```
Het Dockerfile voor de ASP.NET-app ziet er zo uit:
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet
WORKDIR /app
COPY ./bin/Release/net7.0/publish .
EXPOSE 3000
ENTRYPOINT ["dotnet", "ArgumentEcho.Web.dll"]
```
Om een image te bouwen, voer je de volgende opdracht uit:
```bash
docker build -t argument-echo-web .
```
En om de container te draaien:
```bash
docker run -d -p 3010:3000 argument-echo-web
```

### Uitleg Dockerfile van asp

1. `FROM mcr.microsoft.com/dotnet/aspnet`: Dit is het basis Docker image dat wordt gebruikt voor de applicatie. Hier wordt het aspnet image van Microsoft's containerregister geselecteerd. Dit image bevat de ASP.NET runtime die nodig is om ASP.NET-applicaties uit te voeren.

2. `WORKDIR /app`: Dit stelt de werkdirectory in de container in. Alle volgende instructies (`RUN`, `CMD`, `ENTRYPOINT`, `COPY`, en `ADD`) zullen in deze directory worden uitgevoerd.

3. `COPY ./bin/Release/net7.0/publish .`: Dit kopieert de inhoud van de lokale `./bin/Release/net7.0/publish` directory naar de huidige directory in de container (dat wil zeggen, `/app` zoals gedefinieerd door de `WORKDIR` instructie). Dit zijn de gepubliceerde bestanden van jouw .NET-applicatie.

4. `EXPOSE 3000`: Dit informeert Docker dat de container luistert op de gespecificeerde netwerkpoorten bij runtime. Hier wordt poort 3000 geopend voor netwerkverbindingen.

5. `ENTRYPOINT ["dotnet", "ArgumentEcho.Web.dll"]`: De `ENTRYPOINT` instructie stelt het uitvoerbare bestand in dat moet worden uitgevoerd wanneer de container wordt gestart. In dit geval is het de `dotnet` runtime, gevolgd door de DLL-naam van jouw applicatie. 

Samengevat bouwt deze Dockerfile een Docker-image voor een ASP.NET webapplicatie, met de broncode in `./bin/Release/net7.0/publish` en stelt deze in om te luisteren op poort 3000. Bij het opstarten van de container zal de .NET runtime de `ArgumentEcho.Web.dll` uitvoeren.
