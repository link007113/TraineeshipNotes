using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag10.ConsolePatternsEvents
{
    public class Lightbulb
    {
        public void Burn(object sender, SwitchToggledEventArgs e)
        {
            bool isOn = e.State;
            Console.WriteLine($"Lightbulb is {(isOn ? "on" : "off")}");
        }
    }
}