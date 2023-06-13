REST (Representational State Transfer) is een architectuurstijl die wordt gebruikt voor het ontwerpen van netwerkapplicaties. Een REST API is een manier om interactie met een server mogelijk te maken met behulp van eenvoudige HTTP-verzoeken, zonder gebruik te maken van aanvullende interne logica zoals het bijhouden van sessiestatussen. 

Bij het ontwerpen van een REST API worden HTTP-methoden gebruikt om acties uit te voeren:

- GET: Gegevens ophalen van een resource
- POST: Een nieuwe resource maken
- PUT: Een bestaande resource bijwerken
- DELETE: Een resource verwijderen

In ASP.NET Core, wordt een REST API typisch gemaakt met behulp van een Controller. Hier is een eenvoudig voorbeeld:

```csharp
[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly TodoContext _context;

    public TodoController(TodoContext context)
    {
        _context = context;
    }

    // GET: api/Todo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
    {
        return await _context.Todos.ToListAsync();
    }

    // GET: api/Todo/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> GetTodo(int id)
    {
        var todo = await _context.Todos.FindAsync(id);

        if (todo == null)
        {
            return NotFound();
        }

        return todo;
    }

    // POST: api/Todo
    [HttpPost]
    public async Task<ActionResult<Todo>> PostTodo(Todo todo)
    {
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTodo", new { id = todo.Id }, todo);
    }
    
    // PUT: api/Todo/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodo(int id, Todo todo)
    {
        if (id != todo.Id)
        {
            return BadRequest();
        }

        _context.Entry(todo).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Todo/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Todo>> DeleteTodo(int id)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo == null)
        {
            return NotFound();
        }

        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();

        return todo;
    }
}
```

Dit voorbeeld laat zien hoe je een eenvoudige Todo API kunt maken. Elk Todo item heeft een id en kan worden opgehaald, aangemaakt, bijgewerkt of verwijderd met behulp van de juiste HTTP-methoden.

Zorg er wel voor dat je in je `Program.cs` de volgende regels hebt om Controllers te ondersteunen:

```csharp
builder.Services.AddControllers();
app.MapControllers();
```
