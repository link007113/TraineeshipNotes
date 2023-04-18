

```sql
use adventureworks
go

DROP TABLE If EXISTS RaceAutos

CREATE TABLE RaceAutos
(
id int IDENTITY PRIMARY KEY,
Naam NVARCHAR(15) NULL,
maxSnelHeid DECIMAL(5,2) NULL
)
GO

```
## Insert

Met een insert kan je data toevoegen aan je tabellen. 

```sql
INSERT into RaceAutos
(Naam, maxSnelHeid)
VALUES
('RB18', 340),
('AEG12',670)
```

Je kan ook data overhevelen naar een andere tabel:
```sql
INSERT into RaceAutos
(Naam, maxSnelHeid)
select top 10 left(FirstName, 15), 100 + CustomerID from SalesLT.Customer
```

## Update
Update kan je gebruiken om data te manipuleren
```sql
UPDATE RaceAutos set naam = CONCAT(naam, '!')
WHERE id BETWEEN 1 and 447
```

## Delete
Delete gebruik je om data te verwijderen. 
```sql
DELETE FROM RaceAutos
WHERE id BETWEEN 1 AND 447
```