using Dag10.EventExercise.Lib;

namespace Dag10.EventExercise.Program
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Person person = new Person("Anthony", 30);
            person.GrownOlder += person.GrowOlder;
            person.AgeUp(1);
        }
    }
}