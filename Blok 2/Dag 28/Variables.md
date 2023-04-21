 Er zijn drie manieren om variabelen te definiëren en te gebruiken in t-SQL: 
 
 - DECLARE statement: hiermee kunt u een variabele declareren en een waarde toewijzen.

Voorbeeld:
```sql
DECLARE @myVariable INT;
SET @myVariable = 10;
```

Dit declareert een variabele genaamd @myVariable van het type INT en wijst de waarde 10 toe. 
 - SET statement: hiermee kunt u een waarde toewijzen aan een bestaande variabele.
 
Voorbeeld:
```sql
DECLARE @myVariable INT;
SET @myVariable = 10;
SET @myVariable = @myVariable + 5;
```

Dit declareert een variabele genaamd @myVariable van het type INT, wijst de waarde 10 toe en voegt vervolgens 5 toe aan de bestaande waarde van @myVariable. 

 - SELECT statement: hiermee kunt u een query uitvoeren en het resultaat toewijzen aan een variabele. Dit wordt meestal gebruikt wanneer u een enkelvoudig resultaat verwacht.
 
Voorbeeld:

```sql
DECLARE @myVariable INT;
SELECT @myVariable = COUNT(*) FROM myTable;
```

Dit declareert een variabele genaamd @myVariable van het type INT en wijst het aantal rijen in myTable toe aan@myVariable.

Het gebruik van variabelen maakt het gemakkelijker om waarden op te slaan en te gebruiken in verschillende delen van uw query.