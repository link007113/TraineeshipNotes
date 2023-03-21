## Inleiding

- CTS staat voor Common Type System 
Dit zorgt ervoor dat je dezelfde types hebt over alle .NET talen heen. 

- Dit zorgt er ook voor dat alle types op Bit niveau hetzelfde zijn. 
```csharp
int a = 3;
System.Int32 a = 3;
```
Is hetzelfde als: 
```vbnet
DIM a AS INTEGER = 3
DIM a AS System.Int32 = 3
```
- CTS deelt types op in twee soorten
- Value Types
- Reference Types

Value types hebben data en kunnen niet null zijn

Reference verwijzen naar objecten 
Kunnen null zijn en kunnen gabrage collected worden. 