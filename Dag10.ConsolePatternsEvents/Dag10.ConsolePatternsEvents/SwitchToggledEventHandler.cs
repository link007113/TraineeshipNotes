namespace Dag10.ConsolePatternsEvents
{
    public delegate void SwitchToggledEventHandler(object sender, SwitchToggledEventArgs e);

    public class SwitchToggledEventArgs : EventArgs
    {
        public bool State { get; }

        public SwitchToggledEventArgs(bool state)
        {
            State = state;
        }
    }
}