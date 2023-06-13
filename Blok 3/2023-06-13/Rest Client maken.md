Om een REST API-client te maken als console-applicatie met behulp van Flurl, volg je de volgende stappen:

1. Maak een nieuwe console-applicatie in Visual Studio of een andere code-editor.
2. Voeg de Flurl.Http NuGet-pakketreferentie toe aan je project.
3. Maak een nieuwe klasse aan die verantwoordelijk is voor het maken van API-verzoeken.

   ```csharp
using Flurl;
using Flurl.Http;
using DemoProject.Models;

namespace DemoProject.RestClient
{
    public class ApiClient
    {
        private readonly string baseUrl;

        public ApiClient(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public async Task<IEnumerable<Todo>> GetTodos()
        {
            try
            {
                var response = await baseUrl.AppendPathSegment("todos").GetJsonListAsync();
                List<Todo> todoList = new List<Todo>();

                foreach (var todo in response)
                {
                    Todo newTodo = new Todo
                    {
                        Id = (int)todo.id,
                        Description = todo.description,
                        DateDue = todo.dateDue,
                        Creator = todo.creator,
                        Category = (TodoCategory)todo.category,
                        Done = todo.done
                    };

                    todoList.Add(newTodo);
                }

                return todoList;
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
   ```

4. In de `Main`-methode van je console-applicatie, maak een instantie van `ApiClient` aan en roep de gewenste API-methoden aan.

   ```csharp
namespace DemoProject.RestClient
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var apiClient = new ApiClient("https://localhost:7216/api");
            var todos = await apiClient.GetTodos();
            foreach (var todo in todos)
            {
                Console.WriteLine($"{todo.Description} verloopt op {todo.DateDue.ToShortDateString()}");
            }

            Console.ReadLine();
        }
    }
}
   ```

Op deze manier kun je een REST API-client maken met behulp van Flurl in een console-applicatie. Vergeet niet om de juiste URL's en HTTP-methoden te gebruiken voor de specifieke API waar je mee werkt.