namespace Dag10.ConsolePatternsEvents
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Switch sw = new Switch();
            Lightbulb lightbulb = new Lightbulb();

            sw.SwitchToggled += lightbulb.Burn;
            sw.SwitchMe();
        }
    }
}