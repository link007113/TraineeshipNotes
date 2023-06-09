Language-Integrated Query (LINQ) is de naam voor een aantal methodes die het mogelijk maakt om een soort van query's te maken rechtstreeks in de C#-taal. LINQ kan je gebruiken op alles wat de interface IEnumerables implementeerd, dat is praktisch alle standaard Reference Types, zoals string, List<>, Array enz. 

De queries zijn ook uit te voeren op databases (LINQ to SQL)  en XML bestanden. 

De meest voorkomende schrijfmanieren zijn de volgende:

```c#
static void Main(string[] args)
{
    List<int> primes = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
    
    
    var q3 = primes.Where(n => n >= 18) // extension method syntax
                   .Select(x => x * x);    
               
    var q4 = from p in primes // comprehension syntax
             where p >= 18
             select p * p;
         
    List<Person> people = new List<Person>
{
    new(){ Name = "Evert 't Reve", Age = 22},
    new(){ Name = "Mats Nevenstam", Age= 44},
    new(){ Name = "Karina van Irak", Age = 33},
};
    var oudste = people.Max(p => p.Age);
    Console.WriteLine(oudste);
}
```

Zoals je kan zien heeft de tweede manier veel weg van SQL, waar de eerste manier veel meer voelt als traditionele c# code.

De LINQ queries worden pas uitgevoerd waarneer er om gevraagd wordt. Dus zodra je bijvoorbeeld q4 wilt gebruiken in een ForEach zal hij de query expressie uitvoeren. Bij de select worden ook echt alleen de objecten opgehaald die voldoen aan de where expressie.

De LINQ queries levert een query object op. 

De lijst van LINQ methodes is erg lang, maar een paar voorbeelden daarvan zijn:

- .Sum()
- .Where()
- .Select()
- .ToList()
- .ToArray()
- .ToDictionary()
- .Max()
- .First()
- .Count()

## Volgorde van LINQ Statements


![Volgorde van LINQ Statements](https://github.com/link007113/TraineeshipNotes/raw/main/Blok%201/Dag13/LinqVolgorde.png)

### Meer info:
[Language Integrated Query (LINQ) (C#)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)