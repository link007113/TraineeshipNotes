using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag10.ConsolePatternsEvents
{
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
}