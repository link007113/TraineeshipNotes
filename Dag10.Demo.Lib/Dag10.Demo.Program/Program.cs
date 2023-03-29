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
}