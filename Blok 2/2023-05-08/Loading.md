### Eager Loading

Eager Loading is een methode die ervoor zorgt dat de gerelateerde entiteiten al worden opgehaald op het moment dat de query wordt uitgevoerd. Het is vooral handig wanneer je zeker weet dat je de gerelateerde gegevens nodig hebt in je programma. Bij Eager Loading kun je de gerelateerde entiteiten als het ware meenemen door middel van de Include() methode in de query. In de codevoorbeelden wordt dit gedemonstreerd met de Players en Countries tabellen in de WorldCup2018Context.

```c#
// Eager Loading
using (WorldCup2018Context context = new WorldCup2018Context())
{
    context.Database.EnsureCreated();
    var query = from player in context.Players.Include(p => p.Country)
                where player.FamilyName.StartsWith("R")
                select player;
    foreach (var person in query)
    {
        Console.WriteLine($"{person.FirstName} {person.FamilyName} {person.Country.CountryName}");
    }
}
```
Dit wordt de query
```sql
SELECT [p].[PlayerId], [p].[BirthDate], [p].[CountryId], [p].[FamilyName], [p].[FirstName], [c].[CountryId], [c].[CountryName], [c].[Qualified]
FROM [Persons].[Players] AS [p]
INNER JOIN [Other].[Countries] AS [c] ON [p].[CountryId] = [c].[CountryId]
WHERE [p].[FamilyName] LIKE N'R%'
go

```

### Precise Loading

Precise Loading is een methode die ervoor zorgt dat je alleen de benodigde gegevens ophaalt. Het kan efficiënter zijn dan Eager Loading, omdat je alleen de data ophaalt die je nodig hebt in plaats van alle gerelateerde gegevens. Dit wordt gedaan door middel van een nieuwe klasse te maken met de benodigde gegevens.
```c#
// Precise Loading
        public record PersonData { public Player Player; public string CountryName; }
        private static void DbFirstDemo()
        {
            using (WorldCup2018Context context = new WorldCup2018Context())
            {
                context.Database.EnsureCreated();

                var query = from player in context.Players
                            where player.FamilyName.StartsWith("R")
                            select new PersonData { Player = player, CountryName = player.Country.CountryName };

                foreach (var person in query)
                {
                    Console.WriteLine($"{person.Player.FirstName} {person.Player.FamilyName} {person.CountryName}");
                }
            }
        }
```
Dit wordt de query 

```sql
SELECT [p].[PlayerId], [p].[BirthDate], [p].[CountryId], [p].[FamilyName], [p].[FirstName], [c].[CountryName]
FROM [Persons].[Players] AS [p]
INNER JOIN [Other].[Countries] AS [c] ON [p].[CountryId] = [c].[CountryId]
WHERE [p].[FamilyName] LIKE N'R%'
go

```

### Lazy Loading

Lazy Loading is een methode die ervoor zorgt dat de gerelateerde entiteiten pas worden opgehaald op het moment dat ze nodig zijn. Dit kan handig zijn als je niet zeker weet welke gerelateerde gegevens je nodig hebt of als je een groot aantal gerelateerde gegevens hebt. Voor Lazy Loading moet de LazyLoadingProxies package worden geïnstalleerd en ingesteld in de context van de applicatie.

Microsoft.EntityFrameworkCore.Proxies
```c#
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    string connectionString = @"Server=localhost;User=SA;Password=*****;Database=MagazijnDB;TrustServerCertificate=true;MultipleActiveResultSets=true";
    optionsBuilder
        .UseLazyLoadingProxies()
        .UseSqlServer(connectionString);
}
```
Daarna kan het alsvolgt gebruikt worden:

```c#
using (WorldCup2018Context context = new WorldCup2018Context())
{
    context.Database.EnsureCreated();
    var query = from player in context.Players
                where player.FamilyName.StartsWith("R")
                select player;
    foreach (var person in query)
    {
        Console.WriteLine($"{person.FirstName} {person.FamilyName} {person.Country?.CountryName}");
    }
}
```
Dit wordt de query 

```sql
SELECT [p].[PlayerId], [p].[BirthDate], [p].[CountryId], [p].[FamilyName], [p].[FirstName], [c].[CountryName]
FROM [Persons].[Players] AS [p]
INNER JOIN [Other].[Countries] AS [c] ON [p].[CountryId] = [c].[CountryId]
WHERE [p].[FamilyName] LIKE N'R%'
go

```

Let op dat Lazy Loading vaak tot prestatieproblemen kan leiden, omdat het een extra query kan uitvoeren voor elke gerelateerde entiteit die wordt opgehaald. Het wordt aanbevolen om Eager Loading of Explicit Loading te gebruiken wanneer mogelijk.

### Explicit Loading

Explicit Loading is een methode die vergelijkbaar is met Lazy Loading, maar dan expliciet wordt opgeroepen wanneer de gerelateerde gegevens nodig zijn. Het is handig wanneer je een bepaalde subset van gerelateerde gegevens nodig hebt in plaats van alle gerelateerde gegevens. Dit wordt gedaan door middel van de Load() methode op de Entry() van de Entity in kwestie.
```c#
// Explicit Loading
using (WorldCup2018Context context = new WorldCup2018Context())
{
    context.Database.EnsureCreated();
    var query = from player in context.Players
                where player.FamilyName.StartsWith("R")
                select player;
    foreach (var person in query)
    {
    context.Entry(person).Reference(p => p.Country).Load();
        Console.WriteLine($"{person.FirstName} {person.FamilyName} {person.Country.CountryName}");
    }
}
```
Dit wordt de query
```sql
SELECT [p].[PlayerId], [p].[BirthDate], [p].[CountryId], [p].[FamilyName], [p].[FirstName], [c].[CountryId], [c].[CountryName], [c].[Qualified]
FROM [Persons].[Players] AS [p]
INNER JOIN [Other].[Countries] AS [c] ON [p].[CountryId] = [c].[CountryId]
WHERE [p].[FamilyName] LIKE N'R%'

```
