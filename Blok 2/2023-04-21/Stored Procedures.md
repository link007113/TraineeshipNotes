Stored Procedures zijn stukjes code die je in een database kunt opslaan om later uit te voeren. Het voordeel van het gebruik van Stored Procedures is dat ze al zijn gecompileerd en geoptimaliseerd, wat de uitvoeringstijd kan verkorten. Daarnaast kun je met Stored Procedures ook herhaalde acties uitvoeren zonder dat je de code steeds opnieuw hoeft te schrijven.

Een eenvoudig voorbeeld van een Stored Procedure zou kunnen zijn:

```sql
CREATE PROCEDURE GetCustomerById
    @customerId INT
AS
BEGIN
    SELECT * FROM Customers WHERE Id = @customerId
END
```

In dit voorbeeld wordt een Stored Procedure gemaakt met de naam GetCustomerById. Deze Stored Procedure accepteert een parameter @customerId van het datatype INT. Wanneer de Stored Procedure wordt uitgevoerd, wordt er een SELECT-statement uitgevoerd om alle rijen op te halen uit de tabel Customers waarbij het veld Id gelijk is aan de opgegeven waarde van @customerId. 

Je kunt deze Stored Procedure vervolgens uitvoeren met de volgende code:

```sql
EXEC GetCustomerById @customerId = 1
```

In dit voorbeeld wordt de Stored Procedure uitgevoerd met de parameter @customerId gelijk aan 1. Dit zal resulteren in een SELECT-statement dat alle gegevens ophaalt van de klant met een Id van 1.

## Output

Je kunt ook stored procedures gebruiken met een output parameter.
Een output parameter is een parameter in een stored procedure die een waarde teruggeeft aan de gebruiker of aan de aanroepende procedure.

Hier is een voorbeeld van een stored procedure met een output parameter:
```sql
CREATE PROCEDURE GetTotalSales
    @startdate DATE,
    @enddate DATE,
    @totalSales INT OUTPUT
AS
BEGIN
    SELECT @totalSales = SUM(TotalAmount)
    FROM Sales
    WHERE SaleDate BETWEEN @startdate AND @enddate
END
```
In dit voorbeeld hebben we een stored procedure genaamd GetTotalSales gemaakt. De stored procedure accepteert twee invoerparameters, @startdate en @enddate, die worden gebruikt om de verkoopgegevens op te halen tussen de opgegeven data. Er is ook een uitvoerparameter @totalSales gedefinieerd die de totale verkoopwaarde zal teruggeven.

Binnen de stored procedure wordt de SUM-functie gebruikt om de totale verkoopwaarde tussen de gegeven data te berekenen en wordt deze waarde toegewezen aan de @totalSales-parameter.

Om deze stored procedure uit te voeren en de totale verkoopwaarde terug te krijgen, kan het volgende statement worden gebruikt:
```sql
DECLARE @totalSales INT
EXEC GetTotalSales '2022-01-01', '2022-01-31', @totalSales OUTPUT
SELECT @totalSales
```
In dit voorbeeld wordt de stored procedure uitgevoerd door de EXEC-opdracht en worden de invoerparameters @startdate en @enddate doorgegeven. De uitvoerparameter @totalSales wordt als laatste parameter doorgegeven met de sleutelwoord OUTPUT. Na het uitvoeren van de stored procedure, wordt de waarde van de @totalSales-parameter weergegeven met de SELECT-opdracht.