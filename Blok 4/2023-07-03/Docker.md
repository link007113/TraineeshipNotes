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


