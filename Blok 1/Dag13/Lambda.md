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


### Meer info:
[Lambda expressions and anonymous functions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions)

- [Expression lambda](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions#expression-lambdas) that has an expression as its body:
```c#
(input-parameters) => expression
``` 
- [Statement lambda](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions#statement-lambdas) that has a statement block as its body:
```c#
(input-parameters) => { <sequence-of-statements> }
```
