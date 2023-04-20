
in de volgende tabel maken we een tabel met een primary key die zelf optelt:

```sql
USE tempdb;
GO

DROP TABLE IF EXISTS Huisdieren


CREATE TABLE Huisdieren (
	id  INT IDENTITY -- Zorgt voor een oplopend nummer. Begint bij 1 en telt bij elke iteratie 1 op
        CONSTRAINT PK_Huisdier_ID -- Naamgeving aan de constraint
        PRIMARY KEY --  Zorgt ervoor dat je altijd een unieke waarde krijgt
	, naam NVARCHAR(50) NOT NULL
	);
GO

INSERT INTO Huisdieren (naam)
VALUES ('Bello')
	, ('Kazan')
	, ('Ibbeltje')
	, ('Mies');
GO

SELECT *
FROM Huisdieren

```

In het volgende voorbeeld maken we een Foreign key aan

```sql
USE tempdb;
GO

DROP TABLE IF EXISTS Afdelingen
CREATE TABLE Afdelingen (
	id  INT IDENTITY 
        CONSTRAINT PK_Afdeling_ID 
        PRIMARY KEY
	, naam NVARCHAR(50) NOT NULL
	);
GO

DROP TABLE IF EXISTS Medewerkers
CREATE TABLE Medewerkers (
	id  INT IDENTITY 
        CONSTRAINT PK_Medewerker_ID
        PRIMARY KEY 
	, naam NVARCHAR(50) NOT NULL
    , afdeling_id INT 
                  CONSTRAINT FK_medewe_afdid_afdelingenid
                  FOREIGN KEY REFERENCES Afdelingen(id)
	);
GO

INSERT INTO Afdelingen (naam)
VALUES ('HR')
	, ('Aangefites')
	, ('IV');
GO

SELECT *
FROM Afdelingen

SELECT *
FROM Medewerkers
```
