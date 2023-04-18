Table Expressions zijn logische tabellen die worden gedefinieerd binnen een t-SQL statement. Ze stellen gebruikers in staat om gegevens te manipuleren en te analyseren zonder de noodzaak van een fysieke tabel. Hieronder volgen enkele voorbeelden van Table Expressions:

## View

Een View is een virtuele tabel die is gebaseerd op een SELECT-statement. Het definieert een set kolommen en rijen die kunnen worden gebruikt als een normale tabel. Een voorbeeld van het maken van een View zou zijn:

```sql
GO
CREATE VIEW SalesLT.StateProvincesEnAantallen
AS
SELECT StateProvince
	, count(*) AS aantal
FROM SalesLT.Address AS a
GROUP BY StateProvince
GO

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


## Cross Apply

CROSS APPLY in t-SQL is een operator die wordt gebruikt om een tabel-uitdrukking toe te passen op elke rij van een andere tabel-uitdrukking. Het kan handig zijn wanneer u een berekening wilt uitvoeren op basis van de resultaten van een andere query.

Bijvoorbeeld, laten we zeggen dat we twee tabellen hebben: TabelA en TabelB. TabelA bevat een kolom genaamd "ID" en TabelB bevat een kolom genaamd "Value". We willen de som berekenen van alle waarden in TabelB voor elke rij in TabelA:

```sql

SELECT A.ID, Total.ValueSum
FROM TabelA AS A
CROSS APPLY (
    SELECT SUM(B.Value) AS ValueSum
    FROM TabelB AS B
    WHERE B.ID = A.ID
) AS Total;
```

In dit voorbeeld fungeert "A" als de linker tabel en "Total" als de rechter tabel. De CROSS APPLY operator past de subquery toe op elke rij van TabelA en retourneert de som van alle overeenkomende waarden uit TabelB.

Kortom, CROSS APPLY kan handig zijn om berekeningen uit te voeren op basis van de resultaten van een andere query. Het kan worden gebruikt om gecorreleerde subqueries uit te voeren, waardoor het mogelijk is om berekeningen uit te voeren op basis van de relaties tussen tabellen.

Zo kan je ook bijvoorbeeld Cross Apply gebruiken op functies.
Stel je hebt deze TVF geschreven:

```sql
CREATE
	OR
ALTER FUNCTION SalesLT.Top5MarkupPerCat (@category NVARCHAR(50))
RETURNS TABLE
AS
RETURN (
		SELECT TOP 5
		-- WITH ties 
		P.ProductID
			, P.Name
		FROM SalesLT.Product AS p
		INNER JOIN SalesLT.ProductCategory AS pc
			ON p.ProductCategoryID = pc.ProductCategoryID
		INNER JOIN SalesLT.SalesOrderDetail AS sod
			ON p.ProductID = sod.ProductID
		WHERE pc.Name LIKE '%' + @category + '%'
		ORDER BY (ListPrice - p.StandardCost) - p.StandardCost
		);
GO
```
Dan kan je die alsvogt gebruiken in een query:

```sql
SELECT pc.Name
	, Top5MarkupPerCat.*
FROM SalesLT.ProductCategory AS pc
CROSS APPLY (
	SELECT *
	FROM SalesLT.Top5MarkupPerCat(pc.Name)
	) AS Top5MarkupPerCat;
```

In dit voorbeeld wordt voor elke categorie uit ProductCategory de functie Top5MarkupPerCat  uitgevoerd.