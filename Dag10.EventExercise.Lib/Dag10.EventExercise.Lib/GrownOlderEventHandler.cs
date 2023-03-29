namespace Dag10.EventExercise.Lib
{
    public delegate void GrownOlderEventHandler(object sender, GrownOlderEventArgs e);

    public class GrownOlderEventArgs : EventArgs
    {
        public string Name { get; set; }
        public int OldAge { get; set; }
        public int NewAge { get; set; }

        public GrownOlderEventArgs(string name, int oldAge, int newAge)
        {
            Name = name;
            OldAge = oldAge;
            NewAge = newAge;
        }
    }
}