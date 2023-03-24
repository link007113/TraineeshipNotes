

Om Collections te begrijpen hebben we de implementatie van List nagemaakt.

## Eigen implementatie van List'\<T\> Class

```c#
    public class IntList : IEnumerable
    {
        private int[] _items;
        private int _count;

        public int Length
        {
            get { return _count; }
        }

        public IntList()
        {
            _items = new int[4];
            _count = 0;
        }

        //indexer
        public int this[int index]
        {
            get
            {
                CheckBounds(index);
                return _items[index];
            }
            set
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

        public void Add(int x)
        {
            if (_count >= _items.Length)
            {
                Resize(ref _items, _items.Length * 2);
            }

            _items[_count] = x;
            _count++;
        }

        // Bestaat al op de Array Class, maar voor demo herschreven
        private static void Resize(ref int[] array, int newSize)
        {
            int[] newArray = new int[newSize];

            for (int index = 0; index < array.Length; index++)
            {
                newArray[index] = array[index];
            }
            array = newArray;
        }

        // Nodig voor de ForEach
        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        // Implementatie van de ForEach
        private class MyEnumerator : IEnumerator
        {
            private IntList _parent;
            private int _index;

            public MyEnumerator(IntList parent)
            {
                _parent = parent;
                _index = -1;
            }

            public object Current => _parent._items[_index];

            public bool MoveNext()
            {
                _index++;
                return _index != _parent._count;
            }

            public void Reset()
            {
                _index = 0;
            }
        }
    }
```
Bovenstaande manier is de MyEnumerator class te maken is wat ingewikkeld. Gelukkig is daar een makkelijkere manier voor.

## Indexer

Indexers maken het mogelijk instanties van een class of struct te indexeren, net als arrays. De geïndexeerde waarde kan worden ingesteld of opgehaald zonder expliciet een type of instantie-lid te specificeren. Indexers lijken op "properties".

### Meer info:
[Indexers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/)
## IEnumerable


## Yield


### Meer info:
[Collections (C#) | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections)
