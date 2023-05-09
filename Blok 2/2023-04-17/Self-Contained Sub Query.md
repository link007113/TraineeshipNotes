
Een self-contained sub query in t-SQL is een query die in zichzelf compleet is en die kan worden gebruikt in de SELECT-, WHERE- of HAVING-clausule van een query. Het resultaat van de subquery wordt gebruikt om de resultaten van de hoofdquery te beperken of te verfijnen.

In het voorbeeld hieronder wil je alle info hebben van het product met de hoogste listprice.

```sql
SELECT     *
FROM     SalesLT.Product
WHERE listprice = (
		    SELECT     max(p.listprice)
			FROM     SalesLT.Product AS p
		)

-- Doet hetzelfde alleen gebruikt top 1 en order by ipv. inner query
SELECT     TOP 1
WITH TIES     *
FROM     SalesLT.Product
ORDER BY listprice DESC

```
Dit is een singled valued sub query. Dat betekent dat hij een enkele waarde terug geeft.
hier kan je in principe alle operators gebruiken. 

Als je meerdere waardes terug krijgt heet het een multi valued sub query.
Hierop kan je alleen IN en NOT IN operators gebruiken.

## Correlated Sub Query

Een correlated sub query in t-SQL is een subquery die afhankelijk is van de resultaten van de hoofdquery. Het resultaat van de subquery is gebaseerd op de huidige rij van de hoofdquery.

Bijvoorbeeld, laten we zeggen dat we een tabel hebben genaamd "Orders" met kolommen "OrderID", "ProductID" en "OrderQuantity". We willen de producten retourneren waarvan de bestelhoeveelheid hoger is dan het gemiddelde van alle bestellingen per product:

```sql
SELECT ProductID, OrderQuantity FROM Orders o WHERE OrderQuantity > (SELECT AVG(OrderQuantity) FROM Orders WHERE ProductID = o.ProductID)
```

In dit voorbeeld is de subquery (SELECT AVG(OrderQuantity) FROM Orders WHERE ProductID = o.ProductID) een correlated sub query omdat het afhankelijk is van de huidige rij van de hoofdquery. Het resultaat van de subquery is gebaseerd op het product ID van de huidige rij van de hoofdquery.