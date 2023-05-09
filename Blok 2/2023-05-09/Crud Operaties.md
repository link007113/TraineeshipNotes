In de wereld van databases en softwareontwikkeling is CRUD een acroniem dat staat voor Create, Read, Update en Delete. Deze vier operaties zijn essentieel om gegevens in een database te kunnen beheren.

Entity Framework is een ORM (Object-Relational Mapping) framework voor .NET dat het mogelijk maakt om gegevens op een objectgerichte manier te benaderen in plaats van op een relationele manier. Dit betekent dat je met Entity Framework kunt werken met klassen en objecten in plaats van met SQL-tabellen en -rijen.

Om CRUD-operaties uit te voeren met Entity Framework, moet je een aantal stappen volgen: 

- **Create** (aanmaken): om een nieuwe record toe te voegen aan de database, moet je een nieuw object van de juiste klasse aanmaken en dit object toevoegen aan de DbSet-collectie van de DbContext. Bijvoorbeeld:
```csharp
var newCustomer = new Customer { Name = "John Doe", Email = "john.doe@example.com" };
dbContext.Customers.Add(newCustomer);
dbContext.SaveChanges();
```
- **Read** (lezen): om gegevens uit de database te lezen, kun je LINQ gebruiken om een query te bouwen die de gegevens ophaalt die je nodig hebt.  Bijvoorbeeld:
```csharp
var customers = dbContext.Customers.AsNoTracking().Where(c => c.Name.Contains("Doe")).ToList();
``` 
In Entity Framework houdt de Change Tracker bij welke entiteiten gewijzigd zijn sinds ze uit de database zijn geladen. Dit kan handig zijn voor bijvoorbeeld het bijhouden van wijzigingen en het beheren van de levenscyclus van objecten.

Met AsNoTracking() geef je aan dat Entity Framework geen Change Tracker moet bijhouden voor de gegevens die je opvraagt. Dit kan nuttig zijn wanneer je bijvoorbeeld alleen gegevens wilt lezen en niet wilt wijzigen of opslaan, omdat het de prestaties van je applicatie kan verbeteren. Het kan ook nuttig zijn bij het opvragen van grote aantallen gegevens waarvoor het bijhouden van wijzigingen niet nodig is.

In het voorbeeld hierboven worden klanten opgevraagd waarvan de naam "Doe" bevat. Door AsNoTracking() te gebruiken, wordt voorkomen dat de Change Tracker de gewijzigde entiteiten bijhoudt, waardoor het geheugenverbruik van de applicatie mogelijk wordt verminderd en de prestaties worden verbeterd.

- **Update** (bijwerken): om een bestaande record bij te werken, moet je het object ophalen uit de database en de gewenste wijzigingen aanbrengen. Entity Framework houdt automatisch bij welke eigenschappen zijn gewijzigd en past de wijzigingen toe wanneer SaveChanges() wordt aangeroepen. Bijvoorbeeld:
```csharp
var customer = dbContext.Customers.FirstOrDefault(c => c.Id == 1);
if (customer != null)
{
    customer.Name = "Jane Doe";
    dbContext.SaveChanges();
}
``` 
- **Delete** (verwijderen): om een record te verwijderen, moet je het object ophalen uit de database en vervolgens het object verwijderen uit de DbSet-collectie van de DbContext. Bijvoorbeeld:
```csharp
var customer = dbContext.Customers.FirstOrDefault(c => c.Id == 1);
if (customer != null)
{
    dbContext.Customers.Remove(customer);
    dbContext.SaveChanges();
}
```


