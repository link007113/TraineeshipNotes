Voor de introductie maken we gebruik van de [adventureworks] database. De volgende 6 onderdelen zijn de basis onderdelen van SQL query's:

## Onderdelen query

### Select 

Beginnend met Select. Hiermee kan je data selecteren. In dit voorbeeld selecteer je het cijfer 1
```sql
select 1
```
### From

Vervolgens From. Met het volgende statement haal je alle data op uit de Address tabel uit het schema SalesLT:
```sql
select *  from SalesLT.Product
```
Met \* kan je alle data van alle tabellen ophalen.
In plaats daarvan kan je ook de naam gebruiken van kolom. Dit is sneller dan alle data ophalen. 

### Where
```sql
select *  from SalesLT.Product
where ProductID > 800
```

### Order By

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
### Group By

In het volgende voorbeeld zie je alle unieke waardes uit de Color kolom en hoe vaak hij voorkomt
```sql
select color, count(*) from SalesLT.Product
where ProductID > 800
group by Color
```

count(\*) is een aggregate function.

### Having

Having is een soort van where clause over de group by.
In dit geval laat hij de waardes zien van alle colors die vaker dan 20 keer voorkomt. 

```sql
select ISNULL(color, 'unknown'), count(*) from SalesLT.Product
where ProductID > 800
group by Color
having count(*) > 20
order by Color desc
```
ISNULL() is een scalar function. 

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
Met deze eerste regel van de query specificeer je de kolommen die je wilt selecteren uit de SalesLT.Customer-tabel. In dit geval selecteren we de kolommen "FirstName", "LastName" en "EmailAddress". De AS-clausule wordt gebruikt om een alias te geven aan elke kolom, zodat de resultaten gemakkelijker te begrijpen zijn. Bijvoorbeeld, de kolom "FirstName" wordt in de resultaten weergegeven als "Voornaam".
```sql
FROM SalesLT.Customer As C -- Tabel Allias
```
Deze regel specificeert de tabel waaruit de query gegevens selecteert, in dit geval de "SalesLT.Customer"-tabel. Het "As C"-deel geeft een alias aan de tabel, zodat deze later in de query kan worden gebruikt.
```sql
WHERE C.FirstName like 'A%' and C.LastName like 'E%'
```
Deze regel voegt voorwaarden toe aan de query om te bepalen welke rijen moeten worden opgenomen in de resultaten. In dit geval zorgt de "where"-clausule ervoor dat alleen rijen worden opgenomen waarvan de waarde in de kolom "FirstName" begint met de letter "A" en de waarde in de kolom "LastName" begint met de letter "E". Het "%" symbool betekent dat er ook andere tekens kunnen voorkomen na de A en de E.
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