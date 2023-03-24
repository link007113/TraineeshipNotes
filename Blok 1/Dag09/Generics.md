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
```

### Meer info:
[Generic classes and methods | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics)
