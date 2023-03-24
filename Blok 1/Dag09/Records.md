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

        public double CalculateVolume() => Height * Width * Length;

        public double CalculateSurface()
        {
            double surfaceLongWalls = (Height * Width) * 2;
            double surfaceShortWalls = (Height * Length) * 2;
            return surfaceLongWalls + surfaceShortWalls;
        }
    }
```
De ToString van een record laat standaard de naam van het record zien en de waardes van de properties en velden.

De constructor voor een struct kan je korter opschrijven dan die van een class:

```c#

```



### Meer info:

[Records](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record)