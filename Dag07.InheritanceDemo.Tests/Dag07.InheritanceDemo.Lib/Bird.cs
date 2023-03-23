namespace Dag07.InheritanceDemo.Lib
{
    public class Bird : Animal
    {
        public Bird(double weight) : base(weight)
        {
        }

        public override string MakeNoise()
        {
            return "Tjilp";
        }

        public string Type()
        {
            return "Bird";
        }
    }
}