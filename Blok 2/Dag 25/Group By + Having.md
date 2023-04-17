### Group By

De GROUP BY-clause in t-SQL wordt gebruikt om rijen in een SELECT-statement te groeperen op basis van de waarden in een of meer kolommen, en aggregatiefuncties zoals SUM, AVG, MAX, enzovoort toe te passen op de gegevens binnen elke groep.
In het volgende voorbeeld zie je alle unieke waardes uit de Color kolom en hoe vaak hij voorkomt
```sql
select color, count(*) from SalesLT.Product
where ProductID > 800
group by Color
```
### Having

De HAVING-clause in t-SQL wordt gebruikt om de resultaten van een GROUP BY-statement te filteren op basis van een of meer voorwaarden die worden toegepast op de resultaten van de aggregatiefuncties in de groepen.

HAVING is een soort van where clause over de group by.
In dit geval laat hij de waardes zien van alle colors die vaker dan 20 keer voorkomt. 

```sql
select ISNULL(color, 'unknown'), count(*) from SalesLT.Product
where ProductID > 800
group by Color
having count(*) > 20
order by Color desc
```
