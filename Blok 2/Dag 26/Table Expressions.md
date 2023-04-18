Table Expressions zijn logische tabellen die worden gedefinieerd binnen een t-SQL statement. Ze stellen gebruikers in staat om gegevens te manipuleren en te analyseren zonder de noodzaak van een fysieke tabel. Hieronder volgen enkele voorbeelden van Table Expressions:

## View

Een View is een virtuele tabel die is gebaseerd op een SELECT-statement. Het definieert een set kolommen en rijen die kunnen worden gebruikt als een normale tabel. Een voorbeeld van het maken van een View zou zijn:

```sql
CREATE VIEW view_name
AS
SELECT column1
	, column2
FROM table_name
WHERE condition;

```
Zet om de view twee GO statements om de error `Incorrect syntax: 'CREATE VIEW' must be the only statement in the batch.` op te lossen. 


## Table Valued Function

Een Table Valued Function (TVF) is een functie die een tabel retourneert als resultaat. Het kan worden gebruikt als een parameter in een ander t-SQL statement. Een voorbeeld van het maken van een TVF zou zijn:

```sql
CREATE FUNCTION function_name (@param1 INT)
RETURNS TABLE
AS
RETURN

SELECT column1
	, column2
FROM table_name
WHERE column3 = @param1;

```

## Derived Table

Een Derived Table is een logische tabel die wordt gemaakt als een subquery binnen een ander t-SQL statement. Het kan worden gebruikt om de resultaten van een subquery te manipuleren en te analyseren. Een voorbeeld van een Derived Table zou zijn:

```sql
SELECT column1
	, AVG(column2)
FROM (
	SELECT column1
		, column2
	FROM table_name
	WHERE condition
	) AS derived_table
GROUP BY column1;

```

## CTE

Een CTE (Common Table Expression) is een benaming voor een afgeleide tabel die wordt gedefinieerd in de context van een enkel SELECT-statement. Het wordt gebruikt om complexe query's te vereenvoudigen en leesbaarder te maken. Een voorbeeld van een CTE zou zijn:

```sql
WITH cte_name (
	column1
	, column2
	)
AS (
	SELECT column1
		, column2
	FROM table_name
	WHERE condition
	)
SELECT column1
	, AVG(column2)
FROM cte_name
GROUP BY column1;
```

Kortom, Table Expressions zijn krachtige hulpmiddelen in t-SQL waarmee gebruikers gegevens kunnen manipuleren en analyseren zonder fysieke tabellen te hoeven maken. Ze stellen gebruikers in staat om complexe query's te vereenvoudigen en leesbaarder te maken, en om gegevens op een flexibele manier te benaderen en te analyseren.