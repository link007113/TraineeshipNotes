## Inleiding

Enum geeft je de mogelijkheid om een keuze lijst te maken. 

```c#
public enum Weather
{
	Sunny = 1,  // Conventie: Beginnend met hoofdletter en daarna kleine letters.
	Cloudy = 2,
	Rainy = 4,
	Snowy = 8,
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

