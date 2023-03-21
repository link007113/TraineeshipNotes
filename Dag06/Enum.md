## Inleiding

Enum geeft je de mogelijkheid om een keuze lijst te maken. 

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
        public static string WhichJacket(Weather weather) => weather switch
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
            Console.WriteLine(weather);
            int weatherNumber = (int)weather;
        }
    }
}
```

