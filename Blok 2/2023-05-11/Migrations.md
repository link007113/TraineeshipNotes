- Microsoft.EntityFrameworkCore.Design
- DBContext heeft een default constructor nodig die boven aan staat
- OnConfiguring:
  ```c#
          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { 
            // migrationConnection
            }
        }
``` 

Dan kan je in de map waar de csproj file staat het volgende commando runnen:

```bash
dotnet ef migrations add "InitialCreate"
```
```bash
dotnet ef database update
```
