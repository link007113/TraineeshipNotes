namespace Dag10.Demo.Program
{
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

            Wire totaalDraad = draadje + draadjeNaarTL;

            schakelaar.wire = totaalDraad;

            Lightbulb peertje2 = new Lightbulb();

            schakelaar.wire += peertje2.Burn;

            foreach (var del in schakelaar.wire.GetInvocationList())
            {
            }

            Console.WriteLine("Let's turn on the light");
            schakelaar.SwitchMe();
            Console.WriteLine("Let's turn off the light");
            schakelaar.SwitchMe();
        }
    }
}