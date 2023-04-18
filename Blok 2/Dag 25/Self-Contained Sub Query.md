
Een self-contained sub query.
Een inner query kan je los van de outer query draaien. 

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

