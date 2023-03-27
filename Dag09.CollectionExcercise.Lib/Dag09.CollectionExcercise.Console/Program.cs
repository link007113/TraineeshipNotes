using System;
using Dag09.CollectionExcercise.Lib;

namespace Dag09.CollectionExcercise.ConsoleProgram
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SortedListImpl<int> intList = new SortedListImpl<int>() { 1, 2, 3, 4, 5, 6 };
            SortedListImpl<string> stringList = new SortedListImpl<string>() { "1", "2", "3" };

            PrintFirstItem(intList);
            PrintFirstItem(stringList);

            stringList.Print();
        }

        public static void PrintFirstItem<T>(SortedListImpl<T> items)
        {
            Console.WriteLine(items[0]);
        }

        public static void PrintSmallest<T>(SortedListImpl<T> items)
        where T : IComparable<T> // type constraint
        {
            T first = items[0];
            T second = items[1];

            int result = first.CompareTo(second);
            if (result <= 0)
            {
                Console.WriteLine(first);
            }
            else
            {
                Console.WriteLine(second);
            }
        }
    }
}