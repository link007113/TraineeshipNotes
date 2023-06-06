Zeker! Razor is een markup syntax voor het embedden van server-based code in webpagina's. De Razor syntax wordt gebruikt met C# in ASP.NET Core applicaties. Hier is een eenvoudig voorbeeld van een Razor-pagina die een tabel van data toont. 

Eerst moeten we een model maken voor de data die we willen weergeven. Laten we zeggen dat we een lijst van studenten willen tonen. Elk student heeft een naam en een studentnummer. We maken een eenvoudige klasse in C# voor onze Student:

```csharp
public class Student
{
    public int StudentNummer { get; set; }
    public string Naam { get; set; }
}
```

Vervolgens moeten we een lijst van studenten maken om te tonen op onze Razor-pagina. We doen dit in de `OnGet` methode van onze Razor-pagina:

```csharp
public class IndexModel : PageModel
{
    public List<Student> Studenten { get; private set; }

    public void OnGet()
    {
        Studenten = new List<Student>
        {
            new Student { StudentNummer = 1, Naam = "Jan" },
            new Student { StudentNummer = 2, Naam = "Peter" },
            new Student { StudentNummer = 3, Naam = "Klaas" },
            // Voeg meer studenten toe zoals nodig
        };
    }
}
```

Nu kunnen we onze Razor-pagina maken die de lijst van studenten toont. We maken een HTML-tabel en gebruiken de Razor syntax om door elke student in de lijst te loopen en een rij in de tabel te maken voor elke student:

```html
@page
@model IndexModel

<h2>Studentenlijst</h2>

<table>
    <thead>
        <tr>
            <th>StudentNummer</th>
            <th>Naam</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var student in Model.Studenten)
        {
            <tr>
                <td>@student.StudentNummer</td>
                <td>@student.Naam</td>
            </tr>
        }
    </tbody>
</table>
```

In dit voorbeeld wordt de `@foreach` loop gebruikt om door elke student in de `Studenten` lijst te itereren. Voor elke student wordt een nieuwe tabelrij (`<tr>`) gemaakt met twee cellen (`<td>`), een voor het studentnummer en een voor de naam. De `@` in `@student.StudentNummer` en `@student.Naam` wordt gebruikt om C# code in de HTML in te voegen.
