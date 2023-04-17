Voor de introductie maken we gebruik van de adventureworks database. De volgende 6 onderdelen zijn de basis onderdelen van SQL query's:

## Onderdelen query

### SELECT 

Beginnend met SELECT. Hiermee kan je data selecteren. In dit voorbeeld selecteer je het cijfer 1
```sql
select 1
```
Met een SELECT-statement in t-SQL kun je gegevens uit één of meer tabellen selecteren en deze gegevens in de resultaatset teruggeven.

### FROM

Vervolgens FROM. De FROM-clause in t-SQL wordt gebruikt om aan te geven uit welke tabel of tabellen je gegevens wilt selecteren in een query.
 Met het volgende statement haal je alle data op uit de Address tabel uit het schema SalesLT:
```sql
select *  from SalesLT.Product
```
Met \* kan je alle data van alle tabellen ophalen.
In plaats daarvan kan je ook de naam gebruiken van kolom. Dit is sneller dan alle data ophalen. 


### WHERE

De WHERE-clause in t-SQL wordt gebruikt om rijen te filteren op basis van een of meer voorwaarden in een SELECT-statement.
```sql
select *  from SalesLT.Product
where ProductID > 800
```

In de Where-clause kan je verschillende operators gebruiken:

* = (Gelijk aan)
* != of <> (Niet gelijk aan)
* >= (Groter of gelijk aan)
* <=  (Kleiner of gelijk aan)
* >  (Groter dan)
* < (Kleiner dan )
* IS NULL (NULL als waarde)
* IS NOT NULL (Alles waar niet NULL als waarde)
* IN (lijst van waardes vervangt x = 'A' OR x = 'B' )
* NOT IN (alles behalve lijst met waardes)
* BETWEEN (waardes tussen twee waardes)
* LIKE

```sql
SELECT 
*
FROM SalesLT.Customer AS C
WHERE Title not in ('Ms.', 'Sra.')
```
Dit levert dus alle mannelijke customers op.

### Order By

De ORDER BY-clause in t-SQL wordt gebruikt om de resultaten van een SELECT-statement te sorteren op basis van een of meer kolommen in oplopende of aflopende volgorde.
Dit werkt van laag naar hoog 
```sql
select *  from SalesLT.Product
where ProductID > 800
order by ListPrice asc
```
ASC is de default. Zonder het expliciet aan te geven 

Dit werkt van hoog naar laag:
```sql
select *  from SalesLT.Product
where ProductID > 800
order by ListPrice desc
```

### Join

Een JOIN in t-SQL wordt gebruikt om rijen uit twee of meer tabellen te combineren op basis van gemeenschappelijke kolommen, en om een resultaatset te creëren die gegevens uit beide tabellen bevat.
Hierin zijn verschillende varianten:

* Inner Join
* Left Outer Join
* Right Outer Join

### Case

Een CASE-statement in t-SQL is een expressie die wordt gebruikt om een resultaat terug te geven op basis van een of meer voorwaarden die worden geëvalueerd. Het werkt als een "if-then-else" constructie, waarbij de voorwaarden worden gecontroleerd en het resultaat wordt teruggegeven op basis van de eerste overeenkomende voorwaarde. Er zijn twee soorten CASE-statements: "simple" en "searched".

Simple case
```sql
SELECT
    CONCAT_WS(
        ' ',
        CASE -- kolom achter Case Keyword
            c.Title
            WHEN 'Ms.' THEN 'Mevrouw'
			WHEN 'Sra.'THEN 'Mevrouw'
			WHEN 'Mr.' THEN 'De heer'
			WHEN 'Sr.' THEN 'De heer'
            ELSE c.Title
        END,
        c.FirstName,
        c.MiddleName,
        c.LastName
    ) AS Full_Name,
    a.AddressLine1,
    a.City
FROM
    SalesLT.Customer AS c
    LEFT OUTER JOIN SalesLT.CustomerAddress AS ca ON c.CustomerID = ca.CustomerID
    INNER JOIN SalesLT.Address AS a ON ca.AddressID = a.AddressID where City in ('Burnaby', 'Seattle')
```
Searched case
```sql
SELECT
    CONCAT_WS(
        ' ',
        CASE -- niks achter Case Keyword
            WHEN c.Title IN('Ms.', 'Sra.') THEN 'Mevrouw'
            WHEN c.Title IN('Mr.', 'Sr.') THEN 'De heer'
            ELSE c.Title
        END,
        c.FirstName,
        c.MiddleName,
        c.LastName
    ) AS Full_Name,
    a.AddressLine1,
    a.City
FROM
    SalesLT.Customer AS c
    LEFT OUTER JOIN SalesLT.CustomerAddress AS ca ON c.CustomerID = ca.CustomerID
    INNER JOIN SalesLT.Address AS a ON ca.AddressID = a.AddressID where City in ('Burnaby', 'Seattle')
```

## Volgorde van uitvoer

SQL zal een query in de volgende volgorde uitvoeren:

From > Where > Group By > Having >  Select > Order by

Om deze reden kan je een veld alias pas gebruiken bij de Order By

## Aliassen

Er zijn twee verschillende soorten aliassen
* Veld Allias
* Tabel Allias

```sql
SELECT 
C.FirstName			AS Voornaam  -- Veld Allias
, C.LastName		AS Achternaam
, c.EmailAddress	AS Mail_adres
FROM SalesLT.Customer As C -- Tabel Allias
WHERE	C.FirstName like 'A%'
		and C.LastName like 'E%'
ORDER BY 
	FirstName
	, LastName;
```

### Uitleg query
```sql

SELECT C.FirstName AS Voornaam -- Veld Allias , C.LastName AS Achternaam , c.EmailAddress AS Mail_adres
```
Met deze eerste regel van de query specificeer je de kolommen die je wilt selecteren uit de SalesLT.Customer-tabel. In dit geval selecteren we de kolommen "FirstName", "LastName" en "EmailAddress". De AS-clause wordt gebruikt om een alias te geven aan elke kolom, zodat de resultaten gemakkelijker te begrijpen zijn. Bijvoorbeeld, de kolom "FirstName" wordt in de resultaten weergegeven als "Voornaam".
```sql
FROM SalesLT.Customer As C -- Tabel Allias
```
Deze regel specificeert de tabel waaruit de query gegevens selecteert, in dit geval de "SalesLT.Customer"-tabel. Het "As C"-deel geeft een alias aan de tabel, zodat deze later in de query kan worden gebruikt.
```sql
WHERE C.FirstName like 'A%' and C.LastName like 'E%'
```
Deze regel voegt voorwaarden toe aan de query om te bepalen welke rijen moeten worden opgenomen in de resultaten. In dit geval zorgt de "where"-clause ervoor dat alleen rijen worden opgenomen waarvan de waarde in de kolom "FirstName" begint met de letter "A" en de waarde in de kolom "LastName" begint met de letter "E". Het "%" symbool betekent dat er ook andere tekens kunnen voorkomen na de A en de E.
```sql
ORDER BY FirstName , LastName;
```
Met deze regel wordt de volgorde gespecificeerd waarin de resultaten worden geretourneerd. In dit geval worden de resultaten gesorteerd op voornaam en vervolgens op achternaam. Het "Order by" keyword is hier gebruikt om deze sortering te specificeren.

## Conventie

De conventie is alles verdeeld over nieuwe regels.
Gebruik As in plaats van het weg laten bij een alias
Voorbeeld hiervan is:

```sql
select 
	Color		as kleur
	, ListPrice as prijs
	, Name		as naam
from SalesLT.Product;

```
```sql
SELECT
    CONCAT_WS(
        ' ',
        c.FirstName,
        c.MiddleName,
        c.LastName
    ) AS Full_Name,
    a.AddressLine1,
    a.City
FROM
    SalesLT.Customer AS c
    LEFT OUTER JOIN SalesLT.CustomerAddress AS ca ON c.CustomerID = ca.CustomerID
    INNER JOIN SalesLT.Address AS a ON ca.AddressID = a.AddressID
	where City in ('Burnaby', 'Seattle')
```