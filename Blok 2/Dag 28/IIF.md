De iif-functie in T-SQL staat voor "If-Then-Else" en is een afkorting voor "Immediate If". Het werkt als een korte vorm van de CASE-expressie en stelt je in staat om in één regelcode een logische voorwaarde te evalueren en te bepalen welke waarde moet worden geretourneerd, afhankelijk van of de voorwaarde waar is of niet.

Het is vergelijkbaar met de Ternary-statement in programmeertalen zoals C# of Java, maar het werkt binnen een T-SQL query of opgeslagen procedure.

Een voorbeeld van het gebruik van de iif-functie is als volgt:

``` sql
SELECT ProductName, 
       UnitsInStock, 
       IIF(UnitsInStock > 0, 'In Stock', 'Out of Stock') AS StockStatus
FROM Products;
```

Dit zal een resultaatset teruggeven met de namen van producten, de hoeveelheid van de producten in voorraad en de status van de voorraad (in voorraad of niet in voorraad). De iif-functie wordt hier gebruikt om de voorraadstatus te bepalen op basis van het aantal eenheden in voorraad. 

Als het aantal eenheden in voorraad groter is dan nul, wordt de tekst 'In Stock' geretourneerd, anders wordt de tekst 'Out of Stock' geretourneerd.