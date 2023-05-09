## Inleiding

Interfaces zijn complete abstracte classes, met 1 groot verschil:

- Classes kunnen meerdere interfaces implementeren, dus is niet gelimiteerd tot 1 zoals bij Inheritance (of beter gezegd compleet abstracte classes). Dit zorgt er voor dat je functionaliteit uit meerdere interfaces kan implementeren in 1 class. 

Ze kunnen geen variable bevatten, maar ze kunnen wel properties bevatten.
Een Interface is dus een soortblauwdruk van een class waarin methodes zijn beschreven maar niet gedefineerd.

Classes die de interface implementeren zijn verplicht om definities te maken voor de properites en methods die in de interface defineert.

De namen van interfaces beginnen volgens de conventie met de hoofdletter I

### Voorbeeld:

```c#
    public interface IShape
    {
        int A { get; set; }
        double CalculateSurface();

        double CalculateVolume();
    }
```



### Meer info:
[Interfaces](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces)