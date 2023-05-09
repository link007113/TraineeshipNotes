Code-First Mapping is een methode van het maken van databases met behulp van Entity Framework, waarbij de entiteiten eerst gedefinieerd worden in de code en Entity Framework op basis van die code de database-schema's genereert. Deze benadering maakt gebruik van conventies en attributen om de mapping te definiëren.

In tegenstelling tot Database-First Mapping, waarbij de database eerst wordt gemaakt en vervolgens het datamodel wordt gegenereerd, maakt Code-First Mapping het mogelijk om een database te genereren op basis van de gedefinieerde code. Dit is de prefered way, omdat het gemakkelijker is om Test-Driven development toe te passen en omdat er geen bestaande database nodig is.

Om dit te doen, moet je eerst een datamodel maken in de code. Dit kan gedaan worden met behulp van classes zoals de `Voorraad` class in de gegeven code:
```c#

public class Voorraad
{
    public long Id { get; set; }
    public string Artikel { get; set; }
    public int Aantal { get; set; }
}
```
Vervolgens moet je een DbContext class maken, zoals de MagazijnDbContext class in de gegeven code. Dit definieert de entiteiten die in de database moeten worden opgenomen:
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
Ten slotte kun je de database maken en de inhoud ervan vullen door de DbContext class te gebruiken:
```c#

using (MagazijnDbContext magazijnDbContext = new MagazijnDbContext())
{
    magazijnDbContext.Database.EnsureCreated();
}

Voorraad voorraad1 = new Voorraad { Artikel = "Muis", Aantal = 5 };
Voorraad voorraad2 = new Voorraad { Artikel = "Computer", Aantal = 9 };

using (MagazijnDbContext magazijnDbContext = new MagazijnDbContext())
{
    magazijnDbContext.Voorraad.Add(voorraad1);
    magazijnDbContext.Voorraad.Add(voorraad2);
    magazijnDbContext.SaveChanges();
}
```



In de bovenstaande code wordt de database MagazijnDB aangemaakt met de tabel Voorraad en de inhoud van de tabel wordt gevuld met twee records. De DbContext class wordt gebruikt om de database te maken en te communiceren met de database. Door de EnsureCreated() methode te gebruiken, kan je de database creëren als deze nog niet bestaat.

Kortom, Code-First Mapping is een krachtige manier om databases te maken en te onderhouden met behulp van Entity Framework. Het maakt het gemakkelijker om Test-Driven te werken en maakt het mogelijk om een database te maken zonder dat er al een bestaande database nodig is.