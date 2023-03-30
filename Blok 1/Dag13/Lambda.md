
Een lambda is eigenlijk een functie gewrapped in een delegate.

Als basis om lambda uit te leggen hebben we de volgende code:

```c#
    internal class Program
    {
        private static void Main()
        {
            MyMath math = new MyMath();
            Func<int, int> kwadraat = new Func<int, int>(math.Square);

            int result = kwadraat(5);
            Console.WriteLine(result);
        }
    }

    public class MyMath
    {
        public int Square(int n)
        {
            return n * n;
        }
    }
```

Je zou Func<int, int> kwadraat = new Func<int, int>(math.Square); kunnen vervangen door 1 van de volgende voorbeelden:

```c#
Func<int, int> kwadraat2 = x => x * x;
int result2 = kwadraat2(5);
Console.WriteLine(result2);

var kwadraat3 = (int x) => x * x;
int result3 = kwadraat3(5);
Console.WriteLine(result3);
```
We kunnen de method Square herschrijven, dat ziet er alsvolgt uit:
```c#
public int Square(int n) => n * n;
```
Overigens heet dit geen lambda, maar een arrow function.

Een method kan je een inner method (soms nested method genoemd) gebruiken. Dit wordt onder water vertaald naar een lambda expressie. 
```c#
private static void Main()
{

    Console.WriteLine(Kwadraatje(3));
    int Kwadraatje(int n) // inner method // nested method
    {
        return n * n;
    }
}
```

### Meer info:
[Lambda expression => operator defines a lambda expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator)
[Lambda expressions and anonymous functions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions)

- [Expression lambda](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions#expression-lambdas) that has an expression as its body:
```c#
(input-parameters) => expression
``` 
- [Statement lambda](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions#statement-lambdas) that has a statement block as its body:
```c#
(input-parameters) => { <sequence-of-statements> }
```
