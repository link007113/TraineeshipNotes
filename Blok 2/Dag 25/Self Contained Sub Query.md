
Een self contained sub query of beter bekent als inner query.
Een inner query kan je los van de outer query draaien. 

In het voorbeeld hieronder wil je alle info hebben van het product met de hoogste listprice
```sql
SELECT
    *
FROM
    SalesLT.Product
WHERE listprice =
(
    SELECT
    max(p.listprice)
FROM
    SalesLT.Product AS p
)
-- Doet hetzelfde alleen gebruikt top 1 en order by ipv. inner query

SELECT
    TOP 1 WITH TIES
    *
FROM
    SalesLT.Product
ORDER BY listprice DESC
```