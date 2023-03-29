namespace Dag10.EventExercise.Lib
{
    public class Person
    {
        private string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public event GrownOlderEventHandler GrownOlder;

        public virtual void AgeUp(int years)
        {
            int oldAge = Age;
            Age += years;
            OnGrowOlder(new GrownOlderEventArgs(Name, oldAge, Age));
        }

        public void GrowOlder(object sender, GrownOlderEventArgs e)
        {
            Console.WriteLine($"“Gefeliciteerd, {e.Name}, je bent nu al {e.NewAge}, ik weet het nog goed dat je {e.OldAge} was.”");
        }

        protected virtual void OnGrowOlder(GrownOlderEventArgs e)
        {
            if (GrownOlder != null)
            {
                GrownOlderEventHandler temp = GrownOlder;
                temp.Invoke(this, e);
            }
        }
    }
}