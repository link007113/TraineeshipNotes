
In Database-First Mapping wordt eerst de database gedefinieerd en maakt Entity Framework de entiteiten op basis van de database-schema's. In deze benadering wordt gebruik gemaakt van een ontwerpmodel waarin de mapping wordt gedefinieerd.

Het generereren wordt gedaan door middel van Scaffolding (Reverse Engineering)
dit kan door het volgend commando te gebruiken en naar wens aanpassen :

```bash
dotnet ef dbcontext scaffold "Server=localhost;User=SA;Password=********;TrustServerCertificate=true" --output-dir "DAL" Microsoft.EntityFrameworkCore.SqlServer
```

