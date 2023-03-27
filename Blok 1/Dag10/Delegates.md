Een delegate is een koffer waar een functie in zit. 
```c#
public class Lightbulb
{
    public void Burn(bool on)
    {
        Console.WriteLine($"Lightbulb is {(on ? "ON" : "OFF")}");
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
        
        schakelaar.wire = draadje;
        
        Console.WriteLine("Let's turn on the light");
        schakelaar.SwitchMe();
        Console.WriteLine("Let's turn off the light");
        schakelaar.SwitchMe();
    }
}
```


### Meer info:
[Delegates](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/)