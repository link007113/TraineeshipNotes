Voor de introductie maken we gebruik van de [adventureworks] database. Het doel van de eerste 5 dagen is aan het eind de zes onderdelen van een query kennen


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

### Where
```sql
select *  from SalesLT.Product
where ProductID > 800
```

### OrderBy


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

###


###