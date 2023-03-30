Het verschil tussen Delegates en Events is het icoontje
Ipv, een baksteen is het een bliksemschicht. 

Maar serieus, event is een speciaal soort Delegate.
Buiten de class kan je alleen maar toevoegen en verwijderen en binnen de class kan je hem gebruiken als een normale delegate.

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
    public event Wire wire;
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
        Switch schakelaar = new Switch();
        Lightbulb peertje = new Lightbulb();
        schakelaar.wire += peertje.Burn;
        TubeLight tl = new TubeLight();
        schakelaar.wire += tl.Ignite;
        Lightbulb peertje2 = new Lightbulb();
        schakelaar.wire += peertje2.Burn;
        Console.WriteLine("Let's turn on the light");
        schakelaar.SwitchMe();
        Console.WriteLine("Let's turn off the light");
        schakelaar.SwitchMe();
        schakelaar.wire -= peertje2.Burn;
    }
}
```

Events worden standaard gebruikt door Gui based applicaties, bijv. de classes Button, TextBox, ListBox

## Event handlers

- Publisher - Zegt dat er een event gebeurt is: Hierboven is dat de Switch
- Subriber - Moet het event afhandelen: Hierboven is dat de Lightbulb

### Meer info:
[Events](https://learn.microsoft.com/en-us/dotnet/standard/events/#events)
## Design patterns

```c#
    public class Switch
    {   // Naamgeving Delegate is naam van Event + EventHandler
        // Naamgeving Event = Actie in verleden tijd
        public event SwitchToggledEventHandler SwitchToggled;

        private bool _IsOn = false;

        public void SwitchMe()
        {
            _IsOn = !_IsOn;
            OnSwitchToggled(new SwitchToggledEventArgs(_IsOn));
        }

        // On+Naam van Event
        protected virtual void OnSwitchToggled(SwitchToggledEventArgs e)
        {
            if (SwitchToggled != null)
            {
                SwitchToggledEventHandler temp = SwitchToggled;
                temp.Invoke(this, e);
            }
        }
    }
    
    public delegate void SwitchToggledEventHandler(object sender, SwitchToggledEventArgs e);

    public class SwitchToggledEventArgs : EventArgs
    {
        public bool State { get; }

        public SwitchToggledEventArgs(bool state)
        {
            State = state;
        }
    }
    public class Lightbulb
    {
        public void Burn(object sender, SwitchToggledEventArgs e)
        {
            bool isOn = e.State;
            Console.WriteLine($"Lightbulb is {(isOn ? "on" : "off")}");
        }
    }
	private static void Main(string[] args)
	{
	    Switch sw = new Switch();
	    Lightbulb lightbulb = new Lightbulb();
	    sw.SwitchToggled += lightbulb.Burn;
	    sw.SwitchMe();
	}  
```
### Meer info:
[Standard .NET event patterns](https://learn.microsoft.com/en-us/dotnet/csharp/event-pattern)


