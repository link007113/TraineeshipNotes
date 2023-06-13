In ASP.NET Core zijn "secrets" een manier om gevoelige data op te slaan tijdens de ontwikkeling van een applicatie. De `Secret Manager` tool slaat gevoelige data op tijdens de ontwikkeling van de applicatie. Dit helpt bij het beschermen van de applicatie tegen het per ongeluk delen van deze gevoelige data, bijvoorbeeld door de data op te slaan in broncodebeheer. 

Een typisch voorbeeld van een geheim kan een database-connectionstring zijn. Andere voorbeelden kunnen API sleutels, OAuth tokens, of andere gevoelige data zijn.

### Hoe werkt het?

Het `Secret Manager` hulpmiddel slaat de gevoelige data op in een bestand op het lokale systeem, buiten het projectdirectory. Dit bestand is niet ingecheckt bij de broncode van het project. Het is dus veiliger dan het opslaan van geheimen in configuratiebestanden binnen het project.

### Hoe gebruik je het?

1. **Installeren en initialiseren**: Installeer de Secret Manager tool als een global tool via de terminal:

```bash
dotnet tool install --global dotnet-user-secrets
```

2. **Secrets toevoegen**: Voeg een secret toe aan je applicatie met het volgende commando:

```bash
dotnet user-secrets set "Database:ConnectionString" "Server=(localdb)\\mssqllocaldb;Database=aspnet-WebApplication1-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true"
```

Dit commando voegt een secret met de naam "Database:ConnectionString" toe en de waarde die je hebt verstrekt. Merk op dat de naam van de secret een hiërarchische structuur kan hebben met behulp van de dubbele punt als scheidingsteken.

3. **Secrets gebruiken**: In je code kun je deze secrets gebruiken zoals je elke andere configuratie zou gebruiken:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<MyDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("Database:ConnectionString")));
}
```

In deze code wordt de connection string opgehaald uit de configuratie en gebruikt om de databasecontext te configureren.


Het kan zijn dat je project nog geen UserSecretsId heeft toegewezen gekregen. Deze id is nodig om de geheimen die je hebt opgeslagen via de Secret Manager-tool te koppelen aan je project.

Als je Visual Studio gebruikt, kun je eenvoudig met de rechtermuisknop op het project klikken in Solution Explorer, "Manage User Secrets" selecteren en Visual Studio zal automatisch een UserSecretsId voor je aanmaken en openen een geheimen bestand waarin je je geheimen kunt toevoegen.