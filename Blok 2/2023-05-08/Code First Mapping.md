## Code First

 In Code-First Mapping worden de entiteiten eerst gedefinieerd in de code, waarna Entity Framework de database-schema's genereert op basis van de code. In deze benadering wordt gebruik gemaakt van conventies en attributen om de mapping te definiëren. 

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
