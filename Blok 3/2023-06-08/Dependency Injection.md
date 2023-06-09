
Dependency Injection (DI) is een softwareontwerppatroon dat helpt bij het beheren van afhankelijkheden binnen je applicatie. Dit patroon maakt het mogelijk om afhankelijkheden te decoupleren van de klassen die ze gebruiken, waardoor het systeem flexibeler en testbaarder wordt.

In ASP.NET Core is er een ingebouwde ondersteuning voor DI via een IoC (Inversion of Control) container. Deze IoC container kan worden gebruikt om services en hun levenscyclus te beheren. Je kan de levensduur van deze services beheren door gebruik te maken van de methoden `AddScoped`, `AddTransient` en `AddSingleton` die worden aangeboden door de IoC container. Laten we nu eens kijken wat ze doen:

1. `AddScoped`: Wanneer je deze methode gebruikt, zal de IoC container één instantie van de service per HTTP request aanmaken. Dit betekent dat als meerdere objecten in dezelfde request van dezelfde service afhankelijk zijn, ze allemaal dezelfde instantie zullen delen.

2. `AddTransient`: Deze methode vertelt de IoC container om elke keer een nieuwe instantie van de service te maken als deze nodig is. Dit betekent dat als meerdere objecten van dezelfde service afhankelijk zijn, zelfs binnen dezelfde request, ze elk hun eigen instantie zullen hebben.

3. `AddSingleton`: Met deze methode zal de IoC container precies één instantie van de service aanmaken en deze voor de hele levensduur van de applicatie gebruiken. Dit betekent dat alle afhankelijke objecten dezelfde instantie delen, ongeacht de request.

Nu de voor- en nadelen:

- `AddScoped`: Omdat een instantie per request wordt aangemaakt, kunnen deze services enige staat behouden gedurende de levensduur van een enkele request, maar niet tussen verschillende requests. Dit maakt ze nuttig voor zaken als het bijhouden van de databasecontext in Entity Framework, die je per request wilt isoleren.

- `AddTransient`: Aangezien deze services geen staat behouden tussen verschillende gebruikers van de service, zijn ze handig voor stateless services zoals loggers, generatoren, calculators, enz.

- `AddSingleton`: Deze services blijven bestaan voor de hele levensduur van de applicatie en kunnen een staat behouden. Dit kan handig zijn voor zaken als in-memory caches, configuratieservices, enz. Het nadeel is dat je voorzichtig moet zijn met concurrency problemen en memory leaks.

```csharp
builder.Services.AddScoped(); 
builder.Services.AddTransienst(); 
builder.Services.AddSingleton(); 
```