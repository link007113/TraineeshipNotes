Is een library van Microsoft en die is bedoeld als abstractie laag zodat je als developer eigenlijk niet veel kennis nodig hebt van SQL zelf. 

Vanuit C# kan je LINQ gebruiken om via de EF data uit een SQL database te halen. EF vertaald LINQ naar SQL query's en vertaald het resultaat weer terug naar een C# object:

```mermaid
flowchart LR

    A(C#) -->|LINQ| B[Entity Framework]

    B -->|SQL| C(Database)

    C --> |Data| B

    B --> |Objecten| A
```
