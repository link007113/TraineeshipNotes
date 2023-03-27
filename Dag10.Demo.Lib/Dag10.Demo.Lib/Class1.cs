namespace Dag10.Demo.Lib
{
    public class Lightbulb
    {
        public void Burn()
        {
            Console.WriteLine("Lightbulb is ON");
        }
    }

    internal class Program
    {
        private static void Main()
        {
            Lightbulb peertje = new Lightbulb();
            peertje.Burn();
        }
    }
}