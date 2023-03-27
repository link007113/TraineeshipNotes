using System.Collections;
using System.Collections.Generic;

namespace Dag09.CollectionExcercise.Lib
{
    public class SortedListImpl<T> : IEnumerable
    {
        private T[] _items;
        private int _count;

        public int Length
        {
            get { return _count; }
        }

        public SortedListImpl()
        {
            _items = new T[4];
            _count = 0;
        }

        public SortedListImpl(int size)
        {
            _items = new T[size];
            _count = 0;
        }

        //indexer
        public T this[int index]
        {
            get
            {
                CheckBounds(index);
                return _items[index];
            }
            private set
            {
                CheckBounds(index);
                _items[index] = value;
            }
        }

        private void CheckBounds(int index)
        {
            if (index >= _count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Add(T item)
        {
            // Als er geen ruimte meer is verdubbelen we de ruimte van de array
            if (_count >= _items.Length)
            {
                Resize(ref _items, _items.Length * 2);
            }

            // Array.BinarySearch methode om de juiste positie te vinden om het nieuwe item in de array in te voegen.
            int index = Array.BinarySearch(_items, 0, _count, item);
            if (index < 0)
            {
                index = ~index;
            }

            // Array.Copy gebruik ik om de items te verplaatsen om plaats te maken voor het nieuwe item
            Array.Copy(_items, index, _items, index + 1, _count - index);
            _items[index] = item;
            _count++;
        }

        // Bestaat al op de Array Class, maar voor demo herschreven
        private static void Resize(ref T[] array, int newSize)
        {
            T[] newArray = new T[newSize];

            for (int index = 0; index < array.Length; index++)
            {
                newArray[index] = array[index];
            }
            array = newArray;
        }

        // Nodig voor de ForEach
        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < _count; index++)
            {
                yield return _items[index];
            }
        }
    }
}