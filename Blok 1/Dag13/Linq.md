Language-Integrated Query (LINQ) is de naam voor een aantal methodes die het mogelijk maakt om een soort van query's te maken rechtstreeks in de C#-taal. 

De meest voorkomende schrijf manieren zijn de volgende:

```c#
static void Main(string[] args)

        {

            List<int> primes = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

  

            List<int> squaresOfLargePrimes = primes.FindAll(n => n >= 18)

                                                   .ConvertAll(x => x * x);

            PrintList(squaresOfLargePrimes);

  

            IEnumerable<int> p1 = Enumerable.Where(primes, n => n >= 18);

            PrintList(p1);

            IEnumerable<int> q1 = Enumerable.Select(p1, x => x * x);

            PrintList(q1);

  

            IEnumerable<int> p2 = primes.Where(n => n >= 18);

            PrintList(p2);

            IEnumerable<int> q2 = p2.Select(x => x * x);

            PrintList(q2);

  

            var q3 = primes.Where(n => n >= 18)

                           .Select(x => x * x);

            PrintList(q3);

  

            var q4 = from p in primes

                     from q in primes

                     where p >= 18

                     let x = (from q in primes select p).Max()

                     where p >= 18 

                     group p * p by x into groep

                     where groep.Count() > 1

                     select groep.First();

  

            PrintList(q4);

  

            List<Person> people = new List<Person>

            {

                new(){ Name = "Evert 't Reve", Age = 22},

                new(){ Name = "Mats Nevenstam", Age= 44},

                new(){ Name = "Karina van Irak", Age = 33},

            };

            var oudste = people.Max(p => p.Age);

            Console.WriteLine(oudste);

        }
```

### Meer info:
[Language Integrated Query (LINQ) (C#)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)