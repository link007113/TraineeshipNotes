Een delegate is een koffer waar een functie in zit. 
Het is een type dat verwijzingen voorstelt naar methoden met een bepaalde parameterlijst en een bepaald terugkeertype. Wanneer je een delegate instantieert, kun je zijn instantie associëren met elke methode die dezelfde parameters en Return-type heeft. Je kunt de methode aanroepen via de instantie van de delegate en daarop een Invoke() doen.

Delegates worden gebruikt om methoden als argumenten door te geven aan andere methoden. Event handlers zijn niets anders dan methoden die worden aangeroepen via delegates. Hieronder is te zien hoe je een delegate defineert en gebruikt:

```c#
    public class Lightbulb
    {
        public void Burn(bool on)
        {
            Console.WriteLine($"Lightbulb is {(on ? "ON" : "OFF")}");
        }
    }

    public class TubeLight
    {
        public void Ignite(bool on)
        {
            Console.WriteLine($"TubeLight is {(on ? "ON" : "OFF")}");
        }
    }

    public class Switch
    {
        public Wire wire { get; set; }
        private bool _isOn = false;

        public void SwitchMe()
        {
            _isOn = !_isOn;
            wire.Invoke(_isOn);
        }
    }

    public delegate void Wire(bool b);

    internal class Program
    {
        private static void Main()
        {
            Lightbulb peertje = new Lightbulb();
            Wire draadje = new Wire(peertje.Burn);
            Switch schakelaar = new Switch();
            TubeLight tl = new TubeLight();
            Wire draadjeNaarTL = new Wire(tl.Ignite);
            Lightbulb peertje2 = new Lightbulb();
            Wire draadje2 = new Wire(peertje2.Burn);

            Wire totaalDraad = draadje + draadjeNaarTL + draadje2;

            schakelaar.wire = totaalDraad;

            Console.WriteLine("Let's turn on the light");
            schakelaar.SwitchMe();
            Console.WriteLine("Let's turn off the light");
            schakelaar.SwitchMe();
        }
    }
```
Hierboven zie je dat er in Wire draadje de method peertje.Burn gestopt wordt.
Deze zou je kunnen gebruiken door:
```c#
draadje.Invoke(true);
```
Hierdoor zou eigenlijk Burn van lightbulb met parameter true aangeroepen worden.

Met de method GetInvocationList kan je een array van Delegates opvragen die in een multicast delegate opgeslagen zit.

Met andere woorden, als aan een delegate meerdere methoden zijn toegewezen, zal het aanroepen van GetInvocationList op die delegate een array van delegates opleveren, waarbij elke delegate een van de methoden vertegenwoordigt die zijn toegewezen aan de oorspronkelijke delegate.

Een multicast delegate heeft vooral een voordeel als alle methodes die erin zitten een returntype van void heeft, anders gooit hij de return type weg bij de invoke. 


### Meer info:
[Delegates](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/)