namespace Day14.LinqAndFileExcercise.Program
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var calorieCount = Elf.GetMaxAmountOfCalories(Elf.GetAllElves());

            Console.WriteLine($"De elf met de meeste callorienwaarde heeft {calorieCount} calorieen bij zich.");
        }
    }
}