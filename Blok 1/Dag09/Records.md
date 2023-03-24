Een record is een combinatie van een struct en een class.
Een record is een reference type net als een class, maar ook wordt het voor waardes gebruikt zoals structs.

Kort gezegd, een record is een data bak.

```c#
public record Bar
{
    public double Height { get; }
    public double Width { get; }
    public double Length { get; }
    public Bar(double height, double width, double length)
    {
        Height = height;
        Width = width;
        Length = length;
    }

```
De ToString()-Method van een record laat standaard de naam van het record zien en de waardes van de properties en velden.

Het declareren van een record kan je korter opschrijven dan die van een class:
```c#
public record Bar(double Height, double Width, double Length);
```
Na het aanmaken van een instantie van een record op deze manier kan je de waarde alleen maar zetten bij het instantiëren. Dus je kan het niet meer later aanpassen. Als je dat wel wilt moet je het als volgt opschrijven:

```c#
public record Bar(double height, double width, double length)
    {
        public string Color { get; set; }
    }
```
Zoals bij classes kan je inheritance gebruiken, maar anders dan bij classes kan je pattern matching gebruiken om in een abstract record logica te verwerken die slaan op de derived records:

```c#
public abstract record Shape
{
    public double Diameter() => this switch
    {
        Cube(double z) => Math.Sqrt(z),
        Bar(double x, double y, double z) => Math.Sqrt(x * x + y * y + z * z),
        Sphere(double r) => 2 * r,
    };
}
public record Bar(double height, double width, double length) : Shape;
public record Sphere(double Straal) : Shape;
public record Cube(double Edge) : Bar(Edge, Edge, Edge);

```


### Meer info:

[Records](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record)