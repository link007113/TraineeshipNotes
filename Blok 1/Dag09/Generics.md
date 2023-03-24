Met Generics maak je classes en methodes type onafhankelijk.


```c#
public class SortedList<T> : IEnumerable
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
}
```

Naast dat classes generics kunnen zijn kunnen methods dat ook:

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

Zoals hierboven beschreven staat zie je bij de PrintSmallest dat er gebruikt wordt van een type constraints. Hieraan kan je meegeven dat de methode alleen geld voor types die de IComparable interface implementeren.

### Meer info:
[Generic classes and methods | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics)
