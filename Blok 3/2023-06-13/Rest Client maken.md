Het maken van een REST API-client in .NET kan eenvoudig gedaan worden met behulp van de `HttpClient` klasse. Laten we eens kijken hoe we dit kunnen doen met betrekking tot onze Todo API. 

Allereerst, als we een nieuwe Todo willen aanmaken, zouden we een POST-verzoek sturen naar de endpoint `https://jouwwebsite.com/api/Todo`. Dit zou er in code ongeveer zo uit zien:

```csharp
var todo = new Todo
{
    Description = "My first Todo",
    Creator = "User1",
    DateDue = DateTime.Now.AddDays(7)
};

string todoAsJson = JsonSerializer.Serialize(todo);
var httpContent = new StringContent(todoAsJson, Encoding.UTF8, "application/json");

using (var httpClient = new HttpClient())
{
    var response = await httpClient.PostAsync("https://jouwwebsite.com/api/Todo", httpContent);

    if(response.IsSuccessStatusCode)
    {
        Console.WriteLine("Todo successfully created.");
    }
    else
    {
        Console.WriteLine("Unable to create Todo.");
    }
}
```

Vervolgens, als we een lijst van al onze Todos willen ontvangen, zouden we een GET-verzoek sturen naar dezelfde endpoint:

```csharp
using (var httpClient = new HttpClient())
{
    var response = await httpClient.GetAsync("https://jouwwebsite.com/api/Todo");

    if(response.IsSuccessStatusCode)
    {
        var todosAsJson = await response.Content.ReadAsStringAsync();
        var todos = JsonSerializer.Deserialize<List<Todo>>(todosAsJson);

        foreach(var todo in todos)
        {
            Console.WriteLine($"Todo: {todo.Description}, Created by: {todo.Creator}, Due date: {todo.DateDue}");
        }
    }
    else
    {
        Console.WriteLine("Unable to retrieve Todos.");
    }
}
```

Tot slot, zouden we een DELETE-verzoek sturen naar de endpoint `https://jouwwebsite.com/api/Todo/{id}` om een Todo te verwijderen:

```csharp
int todoId = 1; // Het ID van de Todo die je wilt verwijderen.

using (var httpClient = new HttpClient())
{
    var response = await httpClient.DeleteAsync($"https://jouwwebsite.com/api/Todo/{todoId}");

    if(response.IsSuccessStatusCode)
    {
        Console.WriteLine("Todo successfully deleted.");
    }
    else
    {
        Console.WriteLine("Unable to delete Todo.");
    }
}
```

Deze voorbeelden maken gebruik van de `HttpClient` klasse om HTTP-verzoeken te sturen, en de `JsonSerializer` klasse om objecten te converteren naar JSON-formaat en vice versa. Let op, het is aan te raden om een enkele instantie van `HttpClient` voor de gehele levensduur van de applicatie te gebruiken in plaats van een nieuwe instantie aan te maken voor elk verzoek, om de efficiëntie van het verbinden met de server te verbeteren. Dit kan bijvoorbeeld door middel van `HttpClientFactory` of door het injecteren van `HttpClient` via dependency injection.