
## Test Driven Development
Stappen plan voor test driven development

1. Schrijf <span style="color:red">1 test</span>  (Red)
2. Zie dat de test <span style="color:red">faalt</span> (Red)
3. Schrijft de <span style="color:lightgreen">minimale</span> code om de test te laten slagen (Green)
4. Zie dat de test <span style="color:lightgreen">slaagt</span>  (Green)
5. <span style="color:lightblue">Refactor:</span> maak de code mooier, overzichtelijker, en beter leesbaar (Blue)
6. Zie dat <span style="color:lightblue">alle testen slagen</span> (Blue)
7. Ga naar stap 1

Dit noemen we de "Red-Green-Refactor cycle"

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