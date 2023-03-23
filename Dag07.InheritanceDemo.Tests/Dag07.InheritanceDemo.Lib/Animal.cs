namespace Dag07.InheritanceDemo.Lib
{
    public abstract class Animal
    {
        public Double Weight;

        public Animal(double weight)
        {
            Weight = weight;
        }

        public abstract string MakeNoise();

        public void Eat(double food)
        {
            Weight += food;
        }

        public string Type()
        {
            return "Animal";
        }
    }
}