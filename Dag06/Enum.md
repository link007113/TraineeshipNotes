## Inleiding

Enum geeft je de mogelijkheid om een keuze lijst te maken. 

```c#
public enum Weather
{
	Sunny,  // Conventie: Beginnend met hoofdletter en daarna kleine letters.
	Cloudy,
	Rainy,
}

namespace Dag06.EnumDemoConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static void WheaterProcessor(Weather weather)
        {
            Console.WriteLine(weather);
            int weatherNumber = (int)weather;
        }
    }
}
```

