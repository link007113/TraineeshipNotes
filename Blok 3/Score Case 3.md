# Review Anthony

Score: 7.5 

* Dat installatiescript van je database in je readme... Gewoon `CREATE DATABASE COURSEDB` was prima geweest hoor, lol
* Front- en backend draaien op zelfde poort
  * Waar is je `Properties`-folder met de `launchsettings.json`? Daar staan dit soort dingen in.
    * Oh Marco heeft een `.gitignore` waar deze in staat. [Dat hoort eigenlijk niet](https://stackoverflow.com/questions/47377058/should-i-ignore-the-launchsettings-json-file-from-being-committed-in-git).
* Mooie Git commit messages. Niet op echte projecten doen natuurlijk.

## Backend

### API

* GET `api/cursusinstanties` geeft dit terug:
    ```json
    {
        "cursusInstances": [],
        "containsError": false,
        "errors": [],
        "newCourses": 0,
        "newInstances": 0
    }
    ```
  Waarom geeft een GET informatie terug over nieuwe cursussen/instanties/errors? Ik verwacht gewoon een array van instanties, geen andere properties.
  * `api/cursusinstanties/195` geeft diezelfde JSON terug. Maar die hoort toch echt maar 1 instantie terug te geven. Een array is hier dan ook apart.

### Code

* Je `CursusInstanceController` doet ook cursisten toevoegen
  * En ook een aparte repo voor cursisten graag. `CursusInstanceRepo` zit al tegen de 300 regels aan, cursisten naar een eigen repo lijkt me een prima begin om dat wat terug te schroeven.
* In `CursusInstanceRepo.cs` doe je `using (_context)`, waarbij je die `_context` via DI binnen hebt gekregen. Als die lifetime van die injectable `Scoped`/`Singleton` is, heeft jouw `using` gevolgen voor andere stukken code. In dit scenario is `using` niet nodig, de controller wordt na iedere request opgeruimd en daarmee de injectables ook.
* ```cs
  student.CourseInstances = null; // een klein beetje vage fix, maar nodig anders krijg ik bij het opslaan
  // het probleem dat hij de course en courseinstance wilt inserten.
  // Heb ik met JP naar gekeken, dit is de voorgestelde opplossing.
  ```
  Mooie fix!
* Hoop `private static`s in je repo
* Je repo bevat business logica.
    ```cs
    private string CheckCourseBeforeImport(Course course)
    {
        if (course.DurationInDays > 5)
        {
            return "De duur van de cursus mag niet meer dan 5 dagen bedragen.";
        }

        return null;
    }

    private string CheckInstanceBeforeImport(CourseInstance instance)
    {
        if (!IsWeekdayRange(instance.StartDate, instance.Cursus.DurationInDays))
        {
            return $"De cursus ({instance.Cursus.Code}) moet gepland worden binnen een week (maandag t/m vrijdag).\nDe cursus begint op {ConvertToDutchDayOfWeek(instance.StartDate.DayOfWeek.ToString())} en duurt {instance.Cursus.DurationInDays} dagen.";
        }

        return null;
    }
    ```
    Nu sla je de data op in 1 database, maar stel je wil op een dag het ook graag naar het filesystem of naar Azure wegschrijven. Dan moeten deze validaties ook in die repos worden geïmplementeerd.

    Ook dit soort stukjes code:
    ```cs
    public CourseInstanceOperationResult GetInstancesBySearchPerWeekAndYear(int year, int week)
    {
        DateTime dateFrom = DateCalculator.FirstDateOfWeekISO8601(year, week);
        DateTime dateTo = dateFrom.AddDays(7).AddMinutes(-1);

        return GetInsancesForPeriod(dateFrom, dateTo);
    }
    ```
    Dat converteren naar `DateTime` hoort wmb meer bij "het verwerken van het binnenkomende HTTP-request" en daarmee meer in de controller.
* Vergeet bij je `AddDataMigration` de `Down` ook niet te implementeren om die data weer te verwijderen.


### Tests

* Mooie tests bij de controller. Er zit ook niet veel logica in om te testen, maar ze krijgen allemaal wel even een beetje aandacht. Enkel de `catch` van `AddCursusInstances` wordt niet meegenomen. En netjes gemockt. Prima.
* Repo tests gaan stuk bij init:
    ```sh
    Initialization method CursusCase.BackEnd.Tests.DAL.Repositories.CursusInstanceRepoTests.TestInitialize threw exception. System.IndexOutOfRangeExceptio...

    Initialization method CursusCase.BackEnd.Tests.DAL.Repositories.CursusInstanceRepoTests.TestInitialize threw exception. System.IndexOutOfRangeException: Index was outside the bounds of the array..
        at CursusCase.Shared.Helpers.ImportParser.ValidateImportLine(String[] lines, Int32 index) in C:\repos\belastingdienst\cases-2023\CASE-AE\CursusCase.Shared\Helpers\ImportParser.cs:line 77
        at CursusCase.Shared.Helpers.ImportParser.ValidImportBlock(String[] lines, Int32 index) in C:\repos\belastingdienst\cases-2023\CASE-AE\CursusCase.Shared\Helpers\ImportParser.cs:line 65
        at CursusCase.Shared.Helpers.ImportParser.ParseLinesToCursus(String[] lines) in C:\repos\belastingdienst\cases-2023\CASE-AE\CursusCase.Shared\Helpers\ImportParser.cs:line 31
        at CursusCase.BackEnd.Tests.DAL.Repositories.CursusInstanceRepoTests.TestInitialize() in C:\repos\belastingdienst\cases-2023\CASE-AE\CursusCase.BackEnd.Tests\DAL\Repositories\CursusInstanceRepoTests.cs:line 43
        at InvokeStub_CursusInstanceRepoTests.TestInitialize(Object, Object, IntPtr*)
        at System.Reflection.MethodInvoker.Invoke(Object obj, IntPtr* args, BindingFlags invokeAttr)
    ```

## Frontend

### UI

* Het wordt wat druk bij importeren. Na importeren van goedvoorbeeld1.txt zie ik zowel "Te importeren CursusInstances" als "De volgende foutmeldingen zijn opgetreden" als "De volgende gegevens zijn geïmporteerd".
* Bij meerdere malen toevoegen cursist "Kees Piet" krijg ik een mooie succesmelding:
    >Student Kees Piet is succesvol toegevoegd aan deze instantie!
  
  Maar hij voegt Kees niet meerdere malen toe (wat hoort). De melding klopt dus niet.
* Spaties als voor- en achternaam zorgt voor grote error:
    ```sh
    Call failed with status code 400 (Bad Request): POST https://localhost:7236/api/cursusinstanties/1/newstudent
    ```
  Nou is het netjes dat je foutafhandeling hebt, maar met wat basale validatie had dit voorkomen kunnen worden. Overigens hoort een eindgebruiker dit soort meldingen eigenlijk niet te zien natuurlijk.
* Wat slordigheidjes, "instansie", een accolade onderin de UI, "Toon Lijst" met hoofdletter L, Startdatum/Einddatum zijn beide één woord, verschillende termen met instanties, instancies en CursusInstances.
* Ik kan geen week 53 invullen, maar sommige jaren hebben die wel.
* Het inschrijfformulier voor cursisten wordt misschien verborgen als er 12 cursisten zijn ingeschreven, maar ik kan wel POST-requests blijven sturen om nog meer toe te voegen.

### Code

* Dit kan ook met een linkje:
    ```html
    <form action="/planning">
        <button type="submit">Terug naar planning overzicht</button>
    </form>
    ```
    Met CSS kun je dat linkje er ook als een button uit laten zien. Bijkomend voordeel is dan ook dat ik er bijv. op kan klikken met de rechtermuisknop en "Openen in nieuw tabblad" kan doen (of klikken met de scrollwiel, als je muis fancy genoeg is).
* Stukje authententicatie in je template, maar daar doe je niks mee:
    ```razor
    @if (User.Identity.IsAuthenticated)
    {
        <p>Ingelogd als: @User?.Identity?.Name</p>
    }
    ```
* `BaseModel` gebruikt, leuk!
* Dit:
    ```html
    <p><strong>Titel:</strong> @Model.CourseInstance.Cursus.Title</p>
    <p><strong>Code:</strong> @Model.CourseInstance.Cursus.Code</p>
    <p><strong>Duur in dagen:</strong> @Model.CourseInstance.Cursus.DurationInDays</p>
    ```
  Het zijn duidelijk geen paragrafen aan tekst, dus deze HTML drukt semantisch niet lekker uit wat je hier aan content hebt staan. Een `<dl>` met `<dt>`s en `<dd>`s zou hier gepaster zijn.
* Iets verderop:
    ```html
    <p>@Model.CourseInstance.StartDate.ToString("dd/MM/yyyy")</p>
    ```
  Er is ook een [`<time>`-element](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/time).
* Je hebt nog geen les gehad in asynchroon programmeren, dus deze zie ik door de vingers. Maar, nooit `.Result` gebruiken:
    ```cs
    public CourseInstanceOperationResult AddInstances(List<CourseInstance> instances)
    {
        return AddInstancesImpl(instances).Result;
    }
    ```
    Zie ook [Async Guidance](https://github.com/davidfowl/AspNetCoreDiagnosticScenarios/blob/master/AsyncGuidance.md).
* Meerdere `private` methoden in je repo abstraheren niet genoeg om hun bestaan te verantwoorden. De methode waar je `appendPath` binnenkrijgt, maar ook `ExtractInstancesFromResponse()`.
  * En ze hoeven niet `static` te zijn
* Je repo heeft geen business logica lijkt het, echt puur data-ophaal-logica, mooi!
* Validaties in `OnGet` zijn mooier om te doen met een model:
    ```cs
    if (year == 0)
    {
        year = DateTime.Now.Year;
    }

    if (week == 0)
    {
        week = CurrentWeek;
    }

    if (year < 2000 || year > 2099)
    {
        Errors.Add("Het jaar moet binnen het bereik van 2000 tot en met 2099 liggen");
        return;
    }
    if (week < 1 || week > 53)
    {
        Errors.Add("De week moet binnen het bereik van 1 tot en met 53 liggen");
        return;
    }
    ```
* Pas op voor de [pyramid of doom](https://www.google.com/search?rlz=1C1ONGR_nlNL1026NL1026&q=pyramid+of+doom&tbm=isch&sa=X&ved=2ahUKEwjU2vmYsOj_AhXBu6QKHXnvCXkQ0pQJegQIChAB&biw=1745&bih=845&dpr=1.1) zoals in `OnPostSaveList()` in `Import.cshtml.cs`. In plaats van dit:
    ```cs
    if (_cursusInstances != null)
    {
        CourseInstanceOperationResult result = CursusInstanceRepo.AddInstances(_cursusInstances);

        if (result != null)
        {
            if (!result.ContainsError)
            {
    ```
    kun je bijv. de `if`s omdraaien en meteen returnen::
    ```cs
    if (_cursusInstances == null)
    {
        return;
    }
    
    var result = CursusInstanceRepo.AddInstances(_cursusInstances);

    if (result == null)
    {
        return;
    }
    
    if (!result.ContainsError)
    {
    ```
* Dit via dependency injection graag:
    ```cs
    CursusImporter importer = new CursusImporter();
    ```
* Pas op met de lengte van je bestanden, ze gaan nu al over de 100 regels in en dat voor pagina's waar nog niet eens zo heel veel gebeurt

### Tests

* 3 van je `ImportModelTests` gaan stuk.
* Goeie naamgeving!
* AAA mooi gebruikt
* Hier liever `Assert.AreEqual()` gebruiken. Mocht de test falen op deze assert, dan zie je in de foutmelding wat er fout ging (verwachte waarde vs echte waarde).
    ```cs
    Assert.IsTrue(_model.Errors.Count == 0);
    ```
* Een aantal validatie- en error-scenarios ontbreken nog in de geteste pagina's, maar geen verkeerde opzet zo!
* Importpagina heeft geen tests
* De repo tests, indrukwekkend! Mooi! 100% coverage, goede opzet, sterke naamgeving, AAA, keurig! Ook hier enkel die `Assert.IsTrue()` en `Assert.AreEqual(mockWrapper.GetType(), result.GetType());` kan met `Assert.IsInstanceOfType();` gedaan worden, maar evengoed uitstekend dit.


## Shared

### Tests

* `ImportParserTests` gaan stuk
    ```sh
    Test method CursusCase.Shared.Tests.Helpers.ImportParserTests.Import_ValidInput_ShouldParseCursusInstances threw exception: 
    System.IndexOutOfRangeException: Index was outside the bounds of the array.
        at CursusCase.Shared.Helpers.ImportParser.ValidateImportLine(String[] lines, Int32 index) in C:\repos\belastingdienst\cases-2023\CASE-AE\CursusCase.Shared\Helpers\ImportParser.cs:line 77
    at CursusCase.Shared.Helpers.ImportParser.ValidImportBlock(String[] lines, Int32 index) in C:\repos\belastingdienst\cases-2023\CASE-AE\CursusCase.Shared\Helpers\ImportParser.cs:line 65
    at CursusCase.Shared.Helpers.ImportParser.ParseLinesToCursus(String[] lines) in C:\repos\belastingdienst\cases-2023\CASE-AE\CursusCase.Shared\Helpers\ImportParser.cs:line 31
    at CursusCase.Shared.Tests.Helpers.ImportParserTests.Import_ValidInput_ShouldParseCursusInstances() in C:\repos\belastingdienst\cases-2023\CASE-AE\CursusCase.Shared.Tests\Helpers\ImportParserTests.cs:line 63
    at System.RuntimeMethodHandle.InvokeMethod(Object target, Void** arguments, Signature sig, Boolean isConstructor)
    at System.Reflection.MethodInvoker.Invoke(Object obj, IntPtr* args, BindingFlags invokeAttr)
    ```

## Conclusie

Qua UI: iets meer verplaatsen in "hoe iets op de gebruiker overkomt". Technische meldingen en tegensprekende UI-notificaties zijn vaak niet gewenst.

Qua productiecode: verantwoordelijkheden scheiden tussen classes en methoden mag nog wat verder worden doorgevoerd. Niet één controller hebben die alles doet en niet één repo hebben die alles ophaalt. Geen business logica in een repo opnemen. Let op pyramids of doom en algemene leesbaarheid als grote bestanden en lange methoden.

Qua testen: ook al slagen ze niet allemaal, je hebt wel heel wat tests, er is duidelijk aandacht aan besteed. Je hebt zowel unittests als integratietesten toegepast. Je hebt mocken bij het unittesten toegepast. Voor de volledigheid nog iets meer paden (validaties, exceptions) testen.