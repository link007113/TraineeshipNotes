Een record is een combinatie van een struct en een class.
Een record is een reference type net als een class, maar ook wordt het voor waardes gebruikt zoals structs.

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
Na het aanmaken van een instantie van een record op deze manier kan je de waarde alleen maar zetten bij het instantieeren. Dus je kan het niet meer later aanpassen. Als je dat wel wilt moet je het alsvolgt opschrijven:

```c#
public record Bar(double height, double width, double length)
    {
        public string Color { get; set; }
    }
```




### Meer info:

[Records](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record)