## Naamgeving
``` c#
// Dit heet een function-arrow
public decimal TotalPricePerRow =>  Price * Count; 
```

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
