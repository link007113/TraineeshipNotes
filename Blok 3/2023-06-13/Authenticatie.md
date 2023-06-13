Authenticatie is een proces dat bevestigt dat gebruikers zijn wie ze zeggen dat ze zijn. Als je authenticatie wilt toevoegen aan je Razor Pages-website in ASP.NET Core, moet je enkele stappen volgen.

Hier zijn de stappen om authenticatie in te stellen met behulp van Identity Framework:

1. Voeg eerst de Identity Framework-services toe aan je `Program.cs`-bestand. 

```csharp
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TodoContext>();
```


