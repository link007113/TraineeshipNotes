

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


## Yield

De functie geeft een object terug dat de interface IEnumerable<> implementeert. Als een aanroepende functie over dit object gaat foreach-ing, wordt de functie opnieuw aangeroepen totdat deze "yields".
```c#
public void Consumer()
{
    foreach(int i in Integers())
    {
        Console.WriteLine(i.ToString());
    }
}

public IEnumerable<int> Integers()
{
    yield return 1;
    yield return 2;
    yield return 4;
    yield return 8;
    yield return 16;
    yield return 16777216;
}
```

Het volgende plaatje laat zien hoe yield werkt.
![[Pasted image 20230324124204.png]]

Dus in het voorbeeld bij het voorbeeld van List de methode GetEnumerator vervangen voor het volgende:

```c#
public IEnumerator GetEnumerator()
{
    for (int index = 0; index < _count; index++)
    {
        yield return _items[index];
    }
}
```
## Indexer

Indexers maken het mogelijk instanties van een class of struct te indexeren, net als arrays. De geïndexeerde waarde kan worden ingesteld of opgehaald zonder expliciet een type of instantie-lid te specificeren. Indexers lijken op "properties".

### Meer info:
[Indexers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/)
## IEnumerable



### Meer info:
[Collections (C#) | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections)
