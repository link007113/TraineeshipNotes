## Naamgeving
``` c#
// Dit heet een function-arrow
public decimal TotalPricePerRow =>  Price * Count; 
```
### Meer info:
[# C#-coderingsconventies](https://learn.microsoft.com/nl-nl/dotnet/csharp/fundamentals/coding-style/coding-conventions)
## Meerdere testen tegelijk uitvoeren

Deze manier werkt alleen met primitive types:
-   [Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean?view=net-8.0)
-   [Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte?view=net-8.0)
-   [SByte](https://learn.microsoft.com/en-us/dotnet/api/system.sbyte?view=net-8.0)
-   [Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16?view=net-8.0)
-   [UInt16](https://learn.microsoft.com/en-us/dotnet/api/system.uint16?view=net-8.0)
-   [Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32?view=net-8.0)
-   [UInt32](https://learn.microsoft.com/en-us/dotnet/api/system.uint32?view=net-8.0)
-   [Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64?view=net-8.0)
-   [UInt64](https://learn.microsoft.com/en-us/dotnet/api/system.uint64?view=net-8.0)
-   [Char](https://learn.microsoft.com/en-us/dotnet/api/system.char?view=net-8.0)
-   [Double](https://learn.microsoft.com/en-us/dotnet/api/system.double?view=net-8.0)
-   [Single](https://learn.microsoft.com/en-us/dotnet/api/system.single?view=net-8.0)
```c#
[DataTestMethod]
[DataRow(ValutaEnum.Florijn,DisplayName = "Florijn is invalid")]
[DataRow( ValutaEnum.Dukaat, DisplayName = "Dukaat is invalid")]
[DataRow(ValutaEnum.Gulden, DisplayName = "Gulden is invalid")]
public void Given_ValutaOther_Then_ValutaIsInvalid(ValutaEnum valuta)
{          
    bool output = ValutaExtensions.IsValutaValidInTheNetherlands(valuta);
    Assert.AreEqual(false, output);
}
```

## Test Setup maken

Om 1 variable te hergebruiken kan je net als in normale Classes velden gebruiken over meerdere testen. De TestInitialize wordt uitgevoerd voor elke test.

```c#
    [TestClass]
    public class BirdTest
    {
        private Bird _sut;
        [TestInitialize]
        public void TestIntialize()
        {
            _sut = new Bird(0.2);
        }

        [TestMethod]
        public void Bird_Has_Initial_Weight()
        {
            Assert.IsTrue(_sut.Weight == 0.2);
        }

        [TestMethod]
        public void Eat_BirdWithWeight02_GainsWeight()
        {
            _sut.Eat(0.6);
            Assert.IsTrue(_sut.Weight == 0.8);
        }
    }
```

## Internals zichtbaar maken voor een bepaalde assemlby
Je internals kan je zichtbaar maken voor een project kan je het volgende gebruiken:

1. Voeg een AssemblyInfo toe aan je project, vanuit waar je je internals wilt laten zien
2. Voeg volgende code toe waar de text tussen de quotes de naam van het project staat waar je het zichtbaar voor wilt maken.
```c#
[assembly: InternalsVisibleTo("Dag07.InheritanceDemo.Tests")]
```