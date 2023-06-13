In ASP.NET Core is de term "Middleware" gebruikt om te verwijzen naar softwarecomponenten die aanvragen en antwoorden kunnen verwerken als onderdeel van een HTTP-pijplijn. De volgorde waarin deze componenten worden gedefinieerd in de code bepaalt de volgorde waarin ze de aanvraag verwerken en, op de weg terug, het antwoord.

In dit voorbeeld wordt de aanvraag eerst door de middlewarecomponent 1 (MW1) verwerkt, daarna door MW2 en MW3. Vervolgens bereikt het de verwerkingsmethode in de controller. Op de terugweg gaat het antwoord door dezelfde middlewarecomponenten, maar in omgekeerde volgorde. 

Het is belangrijk op te merken dat niet alle middlewarecomponenten zowel een aanvraag als een antwoord hoeven te verwerken. Sommige kunnen enkel voor de aanvraag zorgen, anderen enkel voor het antwoord.

Elke middlewarecomponent heeft de mogelijkheid om de volgende middleware in de pijplijn al dan niet te bellen. Dit betekent dat een component de pijplijn kan "kortsluiten" en het antwoord direct terug kan sturen, zonder dat de rest van de pijplijn wordt uitgevoerd. Dit kan bijvoorbeeld handig zijn in een authenticatiemiddleware, die een ongeautoriseerde aanvraag kan stoppen voordat het verdere verwerkingsbronnen verbruikt.

Voorbeeld van het instellen van middlewarecomponenten in een ASP.NET Core app:

```csharp
public class Startup
{
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
```

In dit voorbeeld worden diverse middleware toegevoegd via de `Use` methoden. De volgorde van deze `Use` aanroepen is belangrijk, want dat bepaalt de volgorde waarin de aanvragen en antwoorden worden verwerkt.