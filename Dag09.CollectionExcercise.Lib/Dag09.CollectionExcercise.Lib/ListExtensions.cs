using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag09.CollectionExcercise.Lib
{
    public static class ListExtensions
    {
        public static void Print<T>(this SortedListImpl<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}