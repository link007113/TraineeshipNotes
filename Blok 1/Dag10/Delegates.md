Een delegate is een koffer waar een functie in zit. 

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


### Meer info:
[Delegates](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/)