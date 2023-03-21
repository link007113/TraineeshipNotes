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

