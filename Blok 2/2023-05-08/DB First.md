## DB First

Database bestaat al, inclusief tabellen, data, enz. 
Op basis hiervan kan je C# datamodel laten genereren die je kan gebruiken om data uit de database te halen en te muteren.

Het generereren wordt gedaan door middel van Scaffolding (Reverse Engineering)
dit kan door het volgend commando te gebruiken en naar wens aanpassen :

```bash
dotnet ef dbcontext scaffold "Server=localhost;User=SA;Password=********;TrustServerCertificate=true" --output-dir "DAL" Microsoft.EntityFrameworkCore.SqlServer
```
### Eager Loading

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

Voor Lazy loading moet in de context Lazy loading aangezet worden:
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

Mag je niet gebruiken. Tenzij niet anders kan

### Explicit Loading

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

