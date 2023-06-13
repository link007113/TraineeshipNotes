Het uitrollen van een webtoepassing betekent in wezen dat de toepassing op een server wordt geplaatst waar andere mensen deze kunnen bereiken en gebruiken. Er zijn veel verschillende manieren om een ASP.NET Core-webtoepassing uit te rollen, maar ik zal me concentreren op drie populaire methoden: Azure, IIS en Docker.

**1. Azure:**
Azure is een cloudserviceplatform van Microsoft. Het biedt eenvoudige en handige manieren om .NET Core-toepassingen te implementeren. Je kunt bijvoorbeeld Azure App Service gebruiken, een volledig beheerde platformservice die het eenvoudig maakt om web- en mobiele toepassingen te bouwen, te implementeren en te schalen. Je kunt de Azure-portal gebruiken om een nieuwe webtoepassing te maken en deze te verbinden met je broncode-repository (GitHub, Azure DevOps, etc.). Azure zal dan automatisch je toepassing bouwen en implementeren telkens wanneer je naar je repository pusht.

**2. IIS:**
Internet Information Services (IIS) is een webserver van Microsoft die op Windows draait. Om een .NET Core-toepassing in IIS te implementeren, moet je je toepassing publiceren (wat je kunt doen met behulp van de `dotnet publish`-opdracht) en vervolgens een nieuwe website in IIS maken die naar de gepubliceerde bestanden wijst.

**3. Docker:**
Docker is een platform dat het mogelijk maakt om je toepassing en de omgeving waarin deze draait in te pakken in een container. Hier is een basisstroom van hoe je een .NET Core-toepassing in Docker zou implementeren:

  a. Maak een `Dockerfile` in de root van je project. Dit bestand bevat instructies voor het bouwen van je Docker-image. Een basis `Dockerfile` voor een .NET Core-webtoepassing kan er als volgt uitzien:

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY ./bin/Release/net5.0/publish/ .
ENTRYPOINT ["dotnet", "yourapp.dll"]
```
   Deze `Dockerfile` begint met een basisimage die al ASP.NET Core 5.0 geïnstalleerd heeft, stelt `/app` in als de werkmap, kopieert de gepubliceerde bestanden van je toepassing naar de image en stelt tenslotte `dotnet yourapp.dll` in als het commando dat wordt uitgevoerd wanneer een container van de image wordt gestart.

  b. Bouw de Docker-image met de `docker build`-opdracht:

```bash
docker build -t yourapp .
```
  
  c. Start een container van je image met de `docker run`-opdracht:

```bash
docker run -d -p 8080:80 --name yourapp_container yourapp
```

Dit zal je toepassing draaien in een Docker-container en toegankelijk maken op poort 8080 van je machine.

  d. Als je Docker Compose gebruikt, kun je je service toevoegen aan je `docker-compose.yml`-bestand zoals dit:

```yml
version: '3'
services:
  yourapp:
    image: yourapp
    ports:
      - "8080:80"
```

En vervolgens start je