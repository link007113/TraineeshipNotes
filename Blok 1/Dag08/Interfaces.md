## Inleiding

Interfaces zijn complete abstracte classes.
Ze kunnen geen variable bevatten, maar ze kunnen wel properties bevatten
De namen van interfaces beginnen volgens de conventie met de hoofdletter I

Classes die de interface implementeren zijn verplicht om definities te maken voor de properites en methods die in de interface defineert.

Classes kunnen meerdere interfaces implementeren, dus is niet gelimiteerd tot 1 zoals bij Inheritance. Dit zorgt er voor dat je functionaliteit uit meerdere interfaces kan implementeren in 1 class. 

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