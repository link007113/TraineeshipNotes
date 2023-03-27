using System.Collections;
using System.Collections.Generic;

namespace Dag09.CollectionExcercise.Lib
{
    public class SortedListImpl<T> : IEnumerable
        where T : IComparable<T>
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

            for (int i = _count; i >= 0; i--)
            {
                if (item.CompareTo(_items[i - 1]) < 0)// item is kleiner dan _items[i]
                {
                    _items[i] = _items[i - 1];
                }
                else
                {
                    _items[i] = item;
                    break;
                }
            }
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