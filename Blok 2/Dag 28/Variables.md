Een variabele in T-SQL is een tijdelijke opslagplaats voor gegevens die binnen een script worden gebruikt. Het wordt gebruikt om waarden op te slaan die later in het script kunnen worden gebruikt.

Een voorbeeld van een variabele in T-SQL zou kunnen zijn:

```sql

DECLARE @naam VARCHAR(50)
SET @naam = 'Jan'
SELECT 'Hallo ' + @naam
```



In dit voorbeeld hebben we een variabele genaamd `@naam` gedeclareerd en geïnitialiseerd met de waarde "Jan". Vervolgens gebruiken we deze variabele in een SELECT-statement om de zin "Hallo Jan" te maken. Door het gebruik van variabelen wordt het gemakkelijker om waarden door te geven en te gebruiken in verschillende delen van een script.