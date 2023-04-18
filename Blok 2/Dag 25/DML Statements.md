DML statements (Data Manipulation Language) in t-SQL worden gebruikt om gegevens in een database te manipuleren. 

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

Er zijn vier soorten DML statements met simpele voorbeelden:

## Insert

Met een insert kan je nieuwe gegevens toevoegen aan je database. 

```sql
INSERT into RaceAutos
(Naam, maxSnelHeid)
VALUES
('RB18', 340),
('AEG12',670)
```

Dit statement zal een nieuwe rij in de tabel "RaceAutos" invoegen met de opgegeven waarden voor Naam en maxSnelHeid.

Je kan ook data overhevelen naar een andere tabel:
```sql
INSERT into RaceAutos
(Naam, maxSnelHeid)
select top 10 left(FirstName, 15), 100 + CustomerID from SalesLT.Customer
```

## Update
Update kan je gebruiken om data te manipuleren. Wordt dus gebruikt om bestaande gegevens in een database bij te werken.
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

Let op: Dit zijn hele korte en eenvoudige voorbeelden van de DML statements, in werkelijkheid kunnen deze statements veel complexer zijn en kunnen ze ook gecombineerd worden met andere SQL statements om uitgebreide gegevensmanipulaties uit te voeren.