Met Generics maak je classes en methodes type onafhankelijk. Hierdoor hoef je dus niet voor elk type een nieuwe class aan te maken, maar kan je je class of methode voor heel veel types gebruiken. 

De types kan je filteren door gebruik te maken van constraints.

Het aanmaken van een generic class doe je doorgaans door NaamClass<\T>\ te gebruiken. 

Hieronder een voorbeeld waarin de lijst met ints van Collection is aangepast naar een generic list.

```c#
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
```

Naast dat classes generics kunnen zijn kunnen methods dat ook.
Hieronder bijv. de methodes PrintFirstItem en PrintSmallest.
```c#
private static void Main(string[] args)
{
    SortedListImpl<int> intList = new SortedListImpl<int>() {1,2,3,4,5,6 };
    SortedListImpl<string> stringList = new SortedListImpl<string>() { "1","2","3"};
    PrintFirstItem(intList);
    PrintFirstItem(stringList);
}
public static void PrintFirstItem<T>(SortedListImpl<T> items)
{
    Console.WriteLine(items[0]);
}

public static void PrintSmallest<T>(SortedListImpl<T> items)
        where T: IComparable<T>
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
```

Zoals hierboven beschreven staat zie je bij de PrintSmallest dat er gebruik gemaakt wordt van een type constraints. Hieraan kan je meegeven dat de methode in dit geval alleen geld voor types die de IComparable interface implementeren. Van die constraints kunnen gecombineerd worden door ze te scheiden met een komma.

Nog meer voorbeelden zijn:

```c#
where T: IComparable<T>, // type constraint
where T: Person, // type constraint
where T : class, // must be reference type
where T: struct, // must be value type
where T: new() // must have a default constructor
```

Ook voor Generics kan je Extension methods maken. Deze kunnen niet in dezelfde generic class, maar moet in een aparte class gezet worden:

```c#
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

private static void Main(string[] args)
{
    SortedListImpl<int> intList = new SortedListImpl<int>() { 1, 2, 3, 4, 5, 6 };
    SortedListImpl<string> stringList = new SortedListImpl<string>() { "1", "2", "3" };
    
    stringList.Print();
    intList.Print();
}
```

### Meer info:
[Generic classes and methods | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics)
