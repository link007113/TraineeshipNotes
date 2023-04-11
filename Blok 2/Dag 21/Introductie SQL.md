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

## Conventie

De conventie is alles verdeeld over nieuwe regels.
Voorbeeld hiervan is:

```sql
select 
	Color		as kleur
	, ListPrice as prijs
	, Name		as naam
from SalesLT.Product;

```