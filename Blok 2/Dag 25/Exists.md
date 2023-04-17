Exists kan je gebruiken om veel performance winst te krijgen tegen over inner-joins
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

Om hem naar een query met exists te herschrijven ziet hij er alsvolgt uit:
```sql
SELECT
    1 -- gebruik 1 omdat je daarmee een compacte dataset terug krijg. * kan ook, T-SQL maakt hiervan een 1
FROM
    SalesLT.Customeraddress AS ca
WHERE EXISTS 
(
SELECT
    *
FROM
    SalesLT.address AS a
WHERE a.city = N'London'
    AND a.addressid = ca.addressid
)
```