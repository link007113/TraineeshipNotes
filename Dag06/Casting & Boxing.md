## Casting

==Casting== is het omzetten van het ene data type naar de andere.
Bijv:
```c#
int i = 3;
long l = i;
```
Casting kan je afdwingen door (datatype) te gebruiken
```c#
long nummer = 4;
i = (int)nummer;
```
Als je een waarde groter dan de max waarde in een int probeert te stoppen, treed er een overflow op.

Hierdoor gaat hij van het grootste positieve getal naar het laagste negatieve getal.


Meer info:
[Casting and type conversions - C# Programming Guide | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/casting-and-type-conversions)

## Boxing

Boxing is het omzetten van een waardetype naar het type object of naar een interfacetype dat door dit waardetype wordt geïmplementeerd.

Unboxing haalt het waardetype uit het object. Boxing is impliciet; unboxing is expliciet.

```c#
int i = 123;
object o = i;
```

### Object Class

Ondersteunt alle Classes in de .NET Class hiërarchie en levert low-level diensten aan afgeleide Classes. Dit is de ultieme basis Class van alle .NET Classes

Meer info:
[Boxing and Unboxing - C# Programming Guide | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing)

