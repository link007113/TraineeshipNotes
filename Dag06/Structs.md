Structs lijken een beetje op classes, in die zin dat ze gegevensstructuren vertegenwoordigen die gegevensleden en functieleden kunnen bevatten. 

In tegenstelling tot classes zijn structs echter Value types en worden deze niet op de heap gezet. 

Een variabele van een struct-type bevat direct de gegevens van de struct, terwijl een variabele van een klassetype een verwijzing naar de gegevens bevat, dit laatste staat bekend als een object.

Bijv:
```c#
        public struct Time
        {
            public int Hours { get; }
            public int Minuts { get; }

            public Time(int hours, int minuts)
            {
                Hours = hours;
                Minuts = minuts;
            }
            
        }


```


Meer info:
[Structs - C# language specification | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/structs)