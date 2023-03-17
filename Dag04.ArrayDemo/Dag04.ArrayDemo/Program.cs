namespace Dag04.ArrayDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BlueSlope();
            Console.ReadKey();
            RedSlope();
        }

        static void BlueSlope()
        {
            //blauwe piste
            // afdrukken
            // som
            // max getal

            int[] nummers = { 1, 3, 5, 7, 9, 11, 13, 17 };
            Console.WriteLine($"De volgende nummers zitten in de array:");
            foreach (int nummer in nummers)
            {
                Console.WriteLine(nummer);
            }
            Console.WriteLine();
            Console.WriteLine($"De som van alle nummers in de array is: {nummers.Sum()}");
            Console.WriteLine($"De hoogste cijfer van alle nummers in de array is: {nummers.Max()}");
        }

        static void RedSlope()
        {
            // rode piste
            // maak een array met alle tafel uitkomsten

            int table;
            int multiplication = 1;
            int[,] tables = new int[12, 12];


            for (table = 1; table <= 12; table++)
            {
                tables[table - 1, 0] = table;

                for (multiplication = 1; multiplication <= 12; multiplication++)
                {
                    int total = multiplication * table;
                    tables[table - 1, multiplication - 1] = total;
                    Console.WriteLine($"{multiplication} x {table} = {tables[table - 1, multiplication - 1]}");
                }


            }        
        }
    }
}