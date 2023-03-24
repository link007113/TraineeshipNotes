C# heeft heel veel standaard collections.
Een aantal zijn:

- List
	- Vertegenwoordigt een lijst van objecten die per index kunnen worden benaderd. Biedt methoden om lijsten te doorzoeken, sorteren en wijzigen.
- Dictionary
	- Vertegenwoordigt een verzameling van key/value die zijn georganiseerd op basis van de key.
- Stack
	- Vertegenwoordigt een last in, first out (LIFO) verzameling van objecten.
- Queue
	- Vertegenwoordigt een first in, first out (FIFO) verzameling van objecten.
- IEnumerable
	- Geeft de enumerator weer, die een eenvoudige iteratie over een verzameling van een gespecificeerd type ondersteunt.


Om Collections te begrijpen hebben we de implementatie van List nagemaakt.
Let wel de Add methode is aangepast zodat deze een gesorteerde lijst maakt.

## Eigen implementatie van List'\<int\> Class

```c#
public class SortedIntList : IEnumerable
{
    private int[] _items;
    private int _count;
    public int Length
    {
        get { return _count; }
    }
    public SortedIntList()
    {
        _items = new int[4];
        _count = 0;
    }
    public SortedIntList(int size)
    {
        _items = new int[size];
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
    public void Add(int item)
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
        else if (index < _items.Length && _items[index] == item)
        {
            // Zoek eerste positie van dubble item
            int duplicateIndex = index;
            while (duplicateIndex < _count && _items[duplicateIndex] == item)
            {
                duplicateIndex++;
            }
            index = duplicateIndex;
        }
        // Array.Copy gebruik ik om de items te verplaatsen om plaats te maken voor het nieuwe item
        Array.Copy(_items, index, _items, index + 1, _count - index);
        _items[index] = item;
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
![uitleg](https://github.com/link007113/TraineeshipNotes/blob/main/Blok%201/Dag09/YieldUitleg.png?raw=true)

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

In het voorbeeld van de List heb ik een indexer gedefineerd:
```c#
public int this[int index]
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
```
Hierin wordt eerst gekeken of de index wel aangevraagd mag worden, door te bepalen of deze niet groter is dan de huidige grootte van de array en of die niet negatief is. Als dat beide niet het geval is wordt de waarde van de gevraagde positie terug gegeven. 

### Meer info:
[Indexers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/)

## Hash Codes

In C# is GetHashCode een methode die een unieke gehele waarde voor een object teruggeeft. Deze waarde wordt vaak gebruikt in hashtabellen, dat zijn gegevensstructuren waarmee je objecten snel kunt opzoeken aan de hand van hun hashcode.

Bij het gebruik van generieken in C# kunt je je eigen methode GetHashCode implementeren om een aangepaste berekening van de hashcode voor objecten van een specifiek type te bieden. Dit kan handig zijn als je je eigen manier van de operator + wilt definiëren voor objecten van dat type.

Bijvoorbeeld dat je een Person-Class hebt die een Name en een Age hebben. Je zou een aangepaste GetHashCode methode kunnen implementeren voor deze Class die de hashcode berekent op basis van zowel de Name als de Age properties. Dit zou ervoor zorgen dat twee Persoon objecten met dezelfde Naam en Leeftijd waarden dezelfde hash code hebben, en efficiënt kunnen worden opgezocht in een hash tabel.

Bijv:
```c#
public override int GetHashCode()
{
    int hash = 17;
    hash = hash * 23 + Name.GetHashCode();
    hash = hash * 23 + Age.GetHashCode();
    return hash;
}

```

### Meer info:
[Collections (C#) | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections)
