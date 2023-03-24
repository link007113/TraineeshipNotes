## Inleiding

Enum geeft je de mogelijkheid om een keuze lijst te maken. 

Je hebt de mogelijkheid om op een Extension Method te maken.
Dat is een Static method in een static class en heeft als de eerste parameter heeft het 'this'-keyword.

### Voorbeeld:
```c#
namespace Dag06.EnumDemoLibrary
{
    [Flags]
    public enum Weather
    {
        Sunny,
        Cloudy,
        Rainy,
    }
    public static class WeatherFunctions
    {
        public static string WhichJacket(this Weather weather) => weather switch
        {
            Weather.Sunny => "Geen jas",
            Weather.Cloudy => "jas",
            Weather.Rainy => "Regen Jas",
            _ => ""
        };

    }
}

namespace Dag06.EnumDemoConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Weather w = Weather.Sunny;
            WeatherProcessor(w);
        }

        static void WheaterProcessor(Weather weather)
        {
            Console.WriteLine(weather.WhichJacket());           
        }
    }
}
```

### Meer info:
[Enumeration types - C# reference | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum)