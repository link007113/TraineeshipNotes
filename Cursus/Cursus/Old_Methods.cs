using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursus
{
    internal class Old_Methods
    {
        static void TablesAndPyramid()
        {
            int table;
            int multiplication = 1;

            for (table = 2; multiplication <= 10; multiplication++)
            {
                int total = multiplication * table;
                Console.WriteLine($"{multiplication} x {table} = {total}");
            }

            Console.ReadKey();

            for (table = 1; table <= 10; table++)
            {
                for (multiplication = 1; multiplication <= 10; multiplication++)
                {
                    int total = multiplication * table;
                    Console.WriteLine($"{multiplication} x {table} = {total}");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("What height of the pyramid do you want?");
            if (int.TryParse(Console.ReadLine(), out int height))
            {
                for (int layer = 1; layer <= height; layer++)
                {
                    for (int spacePos = 1; spacePos <= height - layer; spacePos++)
                    {
                        Console.Write(" ");
                    }
                    for (int blockPos = 1; blockPos <= 2 * layer - 1; blockPos++)
                    {
                        Console.Write("#");
                    }
                    Console.WriteLine();
                }
            }
        }

    }
}
