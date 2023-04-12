## COALESCE

COALESCE is een SQL-functie die de eerste niet-null waarde in een lijst van expressies retourneert en wordt gebruikt om null-waarden in SQL-query's te behandelen.

Dus, het is een functie die null-waarden in een SQL-query kan behandelen door de eerste niet-null waarde te retourneren uit een lijst van expressies.

```sql
SELECT

    FirstName,
    COALESCE(MiddleName, '') AS MiddleName,
    LastName
FROM

    SalesLT.Customer;
```
