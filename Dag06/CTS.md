## Inleiding

CTS staat voor Common Type System 
Dit zorgt ervoor dat je dezelfde types hebt over alle .NET talen heen. 

Dit zorgt er ook voor dat alle types op Bit niveau hetzelfde zijn. 
```csharp
int a = 3;
System.Int32 a = 3;
```
Is hetzelfde als: 
```vbnet
DIM a AS INTEGER = 3
DIM a AS System.Int32 = 3
```

## Soorten types
CTS deelt types op in twee soorten
- Value Types
- Reference Types

==Value types== hebben data en kunnen niet null zijn
- Enum
- Struct
- Tuple

Voorbeelden zijn
- int
- bool
- double
- decimal
- long
- byte
- char
- short
- int?

Vaak op de Stack
Assignment by Value
Operations on one cannot affect others

Werk je met koppien van waardes.

==Reference types== verwijzen naar objecten 
Kunnen null zijn en kunnen gabrage collected worden. 
- Class
- Record
- Interface
- Delegate

Voorbeelden zijn
- String
- Array
- List
- string?

Altijd op heap
Assignment by reference
Operations on one may affect others

Werk je met pointers. Hierdoor kan hij dus aangepast worden door verschillende manieren.

### Kleine omschrijving tussen de verschillen van Stack en Heap

- Stack is een lineaire gegevensstructuur, terwijl Heap een hiërarchische gegevensstructuur is. Stackgeheugen zal nooit gefragmenteerd raken, terwijl Heap-geheugen gefragmenteerd kan raken doordat geheugenblokken eerst worden toegewezen en vervolgens worden vrijgegeven. Stack heeft alleen toegang tot lokale variabelen, terwijl Heap u toegang geeft tot variabelen wereldwijd.


