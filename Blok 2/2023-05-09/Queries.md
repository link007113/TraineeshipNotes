Queries in Entity Framework zijn een manier om gegevens uit de database te halen met behulp van LINQ (Language-Integrated Query) of SQL. Hieronder leg ik kort uit hoe je queries kunt gebruiken in Entity Framework:

### 1. LINQ-to-Entities

LINQ-to-Entities is een manier om queries uit te voeren op de Entity Framework-objectcontext. Je kunt hiermee queries schrijven in C# of VB.NET en Entity Framework zal deze vertalen naar SQL-queries die naar de database worden gestuurd.

Een voorbeeld:
```csharp
using (var context = new MyDbContext())
{
    var query = from p in context.People
                where p.Age > 18
                orderby p.LastName
                select p;

    var results = query.ToList();
}
```

Dit voorbeeld selecteert alle mensen in de database die ouder zijn dan 18 en sorteert deze op achternaam.

### 2. Raw SQL queries

Je kunt ook gebruik maken van Raw SQL queries om data uit de database te halen. In Entity Framework kun je Raw SQL queries op twee manieren gebruiken: 
- Via de SqlQuery-methode:
```csharp
using (var context = new MyDbContext())
{
    var results = context.People.SqlQuery("SELECT * FROM People WHERE Age > 18").ToList();
}
``` 
- Via de Database-property van het DbContext-object:
```csharp
using (var context = new MyDbContext())
{
    var results = context.Database.SqlQuery<Person>("SELECT * FROM People WHERE Age > 18").ToList();
}
```
In dit voorbeeld wordt hetzelfde query uitgevoerd als in het eerste voorbeeld, maar nu via een Raw SQL-query.

### 3. Stored Procedures

Tot slot kun je Stored Procedures gebruiken om gegevens uit de database te halen in Entity Framework. Dit is vooral handig voor complexe queries die moeilijk in LINQ of Raw SQL queries te schrijven zijn. Je kunt stored procedures op twee manieren gebruiken: 
- Via de Database-property:
```csharp
using (var context = new MyDbContext())
{
    var results = context.Database.SqlQuery<Person>("exec GetPeopleByAge @age", new SqlParameter("@age", 18)).ToList();
}
``` 
- Via de `DbSet<T>.SqlQuery`-methode:
```csharp
using (var context = new MyDbContext())
{
    var results = context.People.SqlQuery("exec GetPeopleByAge @age", new SqlParameter("@age", 18)).ToList();
}
```
Dit voorbeeld roept een stored procedure aan die alle mensen ophaalt die ouder zijn dan een bepaalde leeftijd.

De reden waarom je voor SqlQuery zou kiezen in plaats van ExecuteSql is dat SqlQuery je in staat stelt om het resultaat van de query direct in te lezen in een lijst van objecten, terwijl ExecuteSql alleen een integer teruggeeft die het aantal rijen beïnvloedt.

Dus als je gegevens uit de database wilt halen en deze wilt gebruiken in je code, dan kun je beter SqlQuery gebruiken. Als je daarentegen een bewerking wilt uitvoeren op de database (bijvoorbeeld een INSERT, UPDATE of DELETE) en je bent niet geïnteresseerd in de resultaten, dan kun je ExecuteSql gebruiken.