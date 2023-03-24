Met Generics maak je classes en methodes type onafhankelijk. Hierdoor hoef je dus niet voor elk type een nieuwe class aan te maken, maar kan je je class of methode voor heel veel types gebruiken. 

De types kan je filteren door gebruik te maken van constraints.

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

Zoals hierboven beschreven staat zie je bij de PrintSmallest dat er gebruikt wordt van een type constraints. Hieraan kan je meegeven dat de methode alleen geld voor types die de IComparable interface implementeren. Van die constraints kunnen gecombineerd worden door ze te scheiden met een komma.

Nog meer voorbeelden zijn:

```c#
where T: IComparable<T>, // type constraint
where T: Person, // type constraint
where T : class, // must be reference type
where T: struct, // must be value type
where T: new() // must have a default constructor
```

Ook voor Generics kan je Extension methods maken:

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
