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


## Merge

Merge in t-SQL is een statement dat wordt gebruikt om gegevens van één of meer bronnen samen te voegen met een doeltabel op basis van een overeenkomstige sleutelkolom.

Bijvoorbeeld, laten we zeggen dat we twee tabellen hebben: TabelA en TabelB. Beide tabellen bevatten een kolom genaamd "ID". We willen gegevens uit TabelB samenvoegen met TabelA op basis van de overeenkomende ID-waarden:

```sql
MERGE TabelA AS target
USING TabelB AS source
ON (target.ID = source.ID)
WHEN MATCHED THEN
    UPDATE SET target.Column1 = source.Column1,
               target.Column2 = source.Column2
WHEN NOT MATCHED THEN
    INSERT (ID, Column1, Column2)
    VALUES (source.ID, source.Column1, source.Column2);
```

In dit voorbeeld fungeert "target" als de doeltabel en "source" als de bron. De ON-clausule geeft aan op welke kolommen de overeenkomstige records moeten worden gevonden. De WHEN MATCHED THEN-clausule beschrijft welke actie moet worden ondernomen wanneer er een match is tussen de bron en de doeltabel. In dit geval worden de waarden van Column1 en Column2 in de doeltabel bijgewerkt met de waarden uit de bron. De WHEN NOT MATCHED THEN-clausule beschrijft wat er moet gebeuren als er geen overeenkomende record is gevonden. In dit geval wordt er een nieuw record toegevoegd aan de doeltabel met de waarden uit de bron.

Kortom, het verschil tussen Merge en andere statements zoals Insert en Update is dat Merge beide acties kan uitvoeren op basis van de overeenkomstige records. Dit maakt het een handig hulpmiddel voor het synchroniseren van gegevens tussen verschillende tabellen en het beheren van incrementele wijzigingen.