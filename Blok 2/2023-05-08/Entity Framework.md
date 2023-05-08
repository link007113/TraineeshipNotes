Is een library van Microsoft en die is bedoeld als abstractie laag zodat je als developer eigenlijk niet veel kennis nodig hebt van SQL zelf. 

Vanuit C# kan je LINQ gebruiken om via de EF data uit een SQL database te halen. EF vertaald LINQ naar SQL query's en vertaald het resultaat weer terug naar een C# object:

```mermaid
flowchart LR

    A(C#) -->|LINQ| B[Entity Framework]

    B -->|SQL| C(Database)

    C --> |Data| B

    B --> |Objecten| A
```

Het is vergelijkbaar met de ORM Framework uit JAVA. Omdat JAVA hier veel eerder mee was, moest Microssoft om klanten te behouden ook een eigen versie van hebben.

C# gebruikt LINQ statements om aan de DBContext aan te geven welke data er opgehaald moet worden. De provider in de DBContext bepaald wat voor een query er gemaakt moet worden en voert deze uit op de database. Er bestaan voor bijna alle populaire Databases een provider bijv.:

- MSSQL
- MySQL
- MongoDB

Deze providers leveren de data aan als C# Object. Meestal vraag je data als Class op. De relatie zou je kunnen zien als de naam van de class is de naam van de tabel en de namen van de verschillende kollommen zijn de namen van de properties.

Hier moet er dus wel rekening gehouden worden van de Relationele wereld van SQL en de Object Georienteerde wereld van C#.

De nuget libs die we gebruiken is Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Design, Microsoft.EntityFrameworkCore.SqlServer

```xml
  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="7.0.5" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="7.0.5">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.5" />
  </ItemGroup>
```

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
            string connectionString = @"Server=localhost;User=SA;Password=3Erfoom1992!;Database=MagazijnDB;TrustServerCertificate=true";
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
        }

```
Daarna kan het alsvolgt gebruikt worden:

```c#
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=localhost;User=SA;Password=3Erfoom1992!;Database=MagazijnDB;TrustServerCertificate=true";
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
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





## Code First

Applicatie maken inclusief datamodel.
Entity Framework kan hiermee een database generenen inclusief tabellen 
Dit is de prefered way.
Dit omdat het ook Test-Driven gedaan kan worden. 
Kan alleen als er nog geen bestaande database is.

```c#
	private static void Main(string[] args)
        {
            using (MagazijnDbContext magazijnDbContext = new MagazijnDbContext())
            {
                magazijnDbContext.Database.EnsureCreated();
            }
            Console.WriteLine("Your database has been created!");
            Voorraad voorraad1 = new Voorraad { Artikel = "Muis", Aantal = 5 };
            Voorraad voorraad2 = new Voorraad { Artikel = "Computer", Aantal = 9 };

            using (MagazijnDbContext magazijnDbContext = new MagazijnDbContext())
            {
                magazijnDbContext.Voorraad.Add(voorraad1);
                magazijnDbContext.Voorraad.Add(voorraad2);
                magazijnDbContext.SaveChanges();
            }
        }
```
```c#
    public class Voorraad
    {
        public long Id { get; set; }
        public string Artikel { get; set; }
        public int Aantal { get; set; }
    }
```
```c#
    public class MagazijnDbContext : DbContext
    {
        public DbSet<Voorraad> Voorraad { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=localhost;User=SA;Password=**********;Database=MagazijnDB;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
```
Deze code maakt de database MagazijnDB aan met de tabel Voorraad en de inhoud ervan.

BBOM

### Meer info:

[Getting Started with EF Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli)