Zeker, het toevoegen van een formulier met invoer validatie in een Razor pagina is een veelvoorkomende taak bij het ontwikkelen van webtoepassingen. Hier is een eenvoudig voorbeeld van hoe je dit zou kunnen doen.

Stel dat we een formulier hebben waar gebruikers een nieuwe student kunnen toevoegen. We hebben een `Student` modelklasse nodig zoals eerder gedefinieerd:

```csharp
public class Student
{
    [Required]
    [Display(Name = "StudentNummer")]
    public int StudentNummer { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Naam")]
    public string Naam { get; set; }
}
```

Merk op dat we nu attributen zoals `Required` en `StringLength` gebruiken. Dit zijn validatieattributen die ervoor zorgen dat een studentnummer en naam altijd worden ingevoerd, en dat de naam niet langer is dan 50 karakters.

Vervolgens hebben we een `PageModel` klasse nodig die het `Student` model en de `OnPost` methode bevat om het formulier te verwerken:

```csharp
public class NieuweStudentModel : PageModel
{
    [BindProperty]
    public Student NieuweStudent { get; set; }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Code om de nieuwe student op te slaan gaat hier

        return RedirectToPage("./Index");
    }
}
```

Hier gebruiken we de `BindProperty` attribuut om automatisch de formuliervelden aan ons `Student` object te binden. De `OnPost` methode wordt aangeroepen wanneer het formulier wordt ingediend. We controleren of het model geldig is, en als dat niet het geval is, sturen we de gebruiker terug naar de pagina om de fouten te corrigeren.

Nu kunnen we onze Razor-pagina maken met het formulier:

```html
@page
@model NieuweStudentModel

<h2>Nieuwe student toevoegen</h2>

<form method="post">
    <div>
        <label asp-for="NieuweStudent.StudentNummer"></label>
        <input asp-for="NieuweStudent.StudentNummer" />
        <span asp-validation-for="NieuweStudent.StudentNummer" class="text-danger"></span>
    </div>

    <div>
        <label asp-for="NieuweStudent.Naam"></label>
        <input asp-for="NieuweStudent.Naam" />
        <span asp-validation-for="NieuweStudent.Naam" class="text-danger"></span>
    </div>

    <button type="submit">Toevoegen</button>
</form>
```

Hier hebben we een formulier met twee velden, één voor het studentnummer en één voor de naam. We gebruiken de `asp-for` tag helper om de labels en invoervelden te binden aan de eigenschappen van ons `Student` object. We gebruiken ook de `asp-validation-for` tag helper om validatiefoutberichten voor elk veld weer te geven.

Wanneer de gebruiker het formulier indient, zal de `OnPost` methode in onze `PageModel` klasse worden aangeroepen. Als er validatiefouten zijn, worden deze weergegeven naast de relevante form

Voor validatie in Razor pagina's, kunnen we een combinatie van data-annotaties en tag helpers gebruiken. We kunnen data-annotaties gebruiken om validatieregels te definiëren voor de eigenschappen van onze modellen, en we kunnen tag helpers gebruiken om onze formulieren in de Razor-pagina te renderen en de validatieregels toe te passen.

## FluentValidation

Om FluentValidation te gebruiken, moet je een aparte validator klasse maken die de validatieregels bevat. Dit is hoe je het zou doen:

Eerst, installeer de FluentValidation NuGet package door de volgende commando in je package manager console te draaien:

```bash
Install-Package FluentValidation
```

Vervolgens, maak een nieuwe validator klasse voor je `TodoList` model:

```csharp
using FluentValidation;
using DemoProject.Models;

public class TodoListValidator : AbstractValidator<TodoList>
{
    public TodoListValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Vul AUB in")
            .Length(0, 100);

        RuleFor(x => x.DateDue)
            .NotEmpty().WithMessage("Kies een datum");

        RuleFor(x => x.Creator)
            .NotEmpty().WithMessage("Vul AUB in")
            .Length(0, 50);
    }
}
```

De `RuleFor` methode wordt gebruikt om validatieregels te definiëren voor specifieke eigenschappen. De `NotEmpty` methode controleert of de eigenschap niet leeg is, en de `WithMessage` methode stelt een aangepast foutbericht in. De `Length` methode controleert de lengte van de string.

De `TodoList` klasse ziet er nu als volgt uit:

```csharp
using System;

namespace DemoProject.Models
{
    public class TodoList
    {
        public string Description { get; set; }
        public DateTime DateDue { get; set; }
        public bool Done { get; set; }
        public string Creator { get; set; } = "Anthony";
    }
}
```

Ten slotte, om de validatie toe te passen in je Razor pagina, voeg het volgende toe aan de `OnPostAddTodo` methode:

```csharp
public IActionResult OnPostAddTodo()
{
    var validator = new TodoListValidator();
    var result = validator.Validate(new TodoList
    {
        Description = NewDescription,
        DateDue = NewDateDue,
        Creator = NewCreator,
    });

    if (!result.IsValid)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }

        return Page();
    }

    // ... bestaande code om een nieuw TodoList object aan de lijst toe te voegen ...

    return RedirectToPage();
}
```

Dit zal de FluentValidation validator gebruiken om de gegevens te valideren voordat ze worden toegevoegd aan de lijst. Als de validatie faalt, worden de fouten toegevoegd aan de ModelState zodat ze kunnen worden weergegeven in de pagina.