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