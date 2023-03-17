using System.Collections;

namespace Dag04.ArrayDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BlueSlope();
            Console.ReadKey();
            RedSlope();
            Console.ReadKey();
            BlackSlope();
        }

        static void BlueSlope()
        {
            Console.WriteLine("Blauwe piste"); 
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
            Console.WriteLine("Rode piste");
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

        private static void BlackSlope()
        {
            Console.WriteLine("Zwarte piste");
            int[][] arraysWithNumbers = new int[][]{
            new int[] {1, 2, 3},
            new int[] {4, 5},
            new int[] {6, 7, 8, 9},
            new int[] {10}
            };

            int maxLength = 0;
            foreach (int[] innerArray in arraysWithNumbers)
            {
                if (innerArray.Length > maxLength)
                {
                    maxLength = innerArray.Length;
                }
            }

            int[] flatArray = new int[arraysWithNumbers.Length * maxLength];
            int index = 0;
            for (int valueIndex = 0; valueIndex < maxLength; valueIndex++)
            {
                for (int innerArrayIndex = 0; innerArrayIndex < arraysWithNumbers.Length; innerArrayIndex++)
                {
                    if (valueIndex < arraysWithNumbers[innerArrayIndex].Length)
                    {
                        flatArray[index] = arraysWithNumbers[innerArrayIndex][valueIndex];
                        index++;
                    }
                }
            }

            Array.Sort(flatArray);

            Console.WriteLine(string.Join(", ", flatArray));


            flatArray = new int[arraysWithNumbers.Length * maxLength];


            int[] flatArrayWithLinq = arraysWithNumbers.SelectMany(subArr => subArr).ToArray();

            Console.WriteLine(string.Join(", ", flatArrayWithLinq));
        }

    }

}
