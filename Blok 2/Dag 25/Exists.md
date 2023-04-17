



Stel we hebben de volgende query en die willen we herschrijven naar een self-contained subquery:

```sql
SELECT
    ca.CustomerId
    ,ca.AddressType
FROM
    SalesLT.Customeraddress AS ca
    INNER JOIN SalesLT.address a ON a.addressid = ca.addressid
WHERE a.city = N'London'
```

Dat ziet er alsvolgt uit:

```sql
SELECT
    ca.CustomerId
    ,ca.AddressType
FROM
    SalesLT.Customeraddress AS ca
WHERE ca.addressid IN (
SELECT
    a.addressid
FROM
    SalesLT.address AS a
WHERE a.city = N'London')

```