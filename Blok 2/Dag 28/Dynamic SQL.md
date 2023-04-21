Dynamic SQL in t-SQL is een manier om query's dynamisch samen te stellen en uit te voeren op basis van bepaalde parameters of voorwaarden.

Een eenvoudig voorbeeld van dynamische SQL zou kunnen zijn:

```sql
DECLARE @table NVARCHAR(50) = 'Customers'
DECLARE @query NVARCHAR(MAX) = 'SELECT * FROM ' + @table

EXEC sp_executesql @query
```

In dit voorbeeld wordt een variabele @table gebruikt om de tabelnaam te definiëren en vervolgens wordt een SQL-query dynamisch samengesteld met behulp van de variabele @query. Vervolgens wordt de query uitgevoerd met behulp van de sp_executesql opgeslagen procedure.

Dynamische SQL kan nuttig zijn in situaties waarin de te selecteren tabellen of kolommen dynamisch moeten worden bepaald of als een bepaalde query pas kan worden gegenereerd op basis van gegevens die op het moment van uitvoering nog niet bekend zijn. Enkele voorbeelden van use cases zijn: het opbouwen van zoekopdrachten op basis van gebruikersinvoer, het genereren van rapporten op basis van dynamische filters of het maken van complexe gegevensextracties op basis van gegevens uit meerdere tabellen. Het is belangrijk om te onthouden dat dynamische SQL mogelijk risico's met zich meebrengt, zoals SQL-injectie, en dat het daarom belangrijk is om de juiste beveiligingsmaatregelen te nemen.