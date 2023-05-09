## Inleiding

De abstract modifier kan worden gebruikt voor classes, methoden, eigenschappen, indexers en gebeurtenissen. Een abstracte class wordt gebruikt om aan te geven dat een Class alleen bedoeld is om een base te dienen voor andere classes, niet om zelf te instantiëren. Sterker nog, abstracte classes kan je niet instantiëren. Leden gemarkeerd als abstract moeten geïmplementeerd worden door niet-abstracte classes die afgeleid zijn van de abstracte class.

In een abstracte class zet je alle informatie die gedeeld worden over de classes die ervan afgeleid. 

In een abstracte class kan je de methode abstract maken. Hierdoor is er niet gedefinieerd in de base wat er gedaan moet worden, maar alle classes die je van de base afleid moeten dan een implementatie van die class maken. 

Je kan wel nog normale methods gebruiken in abstracte classes, in tegenoverstelling van interfaces.

```c#
    public abstract class Animal
    {
        public Double Weight;

        public Animal(double weight)
        {
            Weight = weight;
        }

        public abstract string MakeNoise();

        public void Eat(double food)
        {
            Weight += food;
        }

        public string Type()
        {
            return "Animal";
        }
    }
```

Bij voorkeur alle classes die niet daadwerkelijk gebruikt worden abstract maken. 
Dus bijv.:

- Animal - Abstract
- Bird - Abstract
- Chicken - Niet abstract

### Meer info:
[Abstract Classes](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract)