
## Primary Key

Een primaire sleutel (Primary key) is een unieke identificator die wordt toegewezen aan een kolom of groep van kolommen in een relationele database tabel. Het garandeert dat elke rij in de tabel uniek is geïdentificeerd en dat er geen duplicaten zijn. Het wordt gebruikt om te verwijzen naar specifieke rijen in de tabel en om de rijen in de tabel te ordenen. Een primaire sleutel kan worden gedefinieerd bij het maken van een tabel met behulp van de "PRIMARY KEY" constraint, die wordt toegepast op een of meer kolommen in de tabel.

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

## Foreign Key

Een foreign key in t-SQL is een manier om de relaties tussen tabellen vast te leggen. Het is een kolom in een tabel die overeenkomt met de primaire sleutel van een andere tabel. Dit wordt gebruikt om de integriteit van de gegevens te waarborgen door ervoor te zorgen dat er alleen waarden worden ingevoegd in de foreign key kolom die overeenkomen met de primaire sleutel van de bijbehorende tabel. Met andere woorden, het zorgt ervoor dat er geen inconsistente gegevens kunnen worden ingevoerd in de database en dat de gegevens altijd coherent blijven.

```sql
Set NOCOUNT ON;

USE tempdb;
GO

DROP TABLE IF EXISTS Medewerkers
GO
DROP TABLE IF EXISTS Afdelingen
GO

CREATE TABLE Afdelingen (
	id  INT IDENTITY 
        CONSTRAINT PK_Afdeling_ID 
        PRIMARY KEY
	, naam NVARCHAR(50) NOT NULL
	);
GO

-- NO ACTION = doe niks = standaard = foutmelding
-- CASCADE  = doe hetzelfde in de andere tabel
-- SET NULL = zet in de andere tabel NULL
-- SET DEFAULT = Zet in andere tabel default waarde


CREATE TABLE Medewerkers (
	id  INT IDENTITY 
        CONSTRAINT PK_Medewerker_ID
        PRIMARY KEY 
	, naam NVARCHAR(50) NOT NULL
    , afdeling_id INT 
                  CONSTRAINT FK_medewe_afdid_afdelingenid
                  FOREIGN KEY REFERENCES Afdelingen(id) 
                  ON DELETE NO ACTION
                  On UPDATE NO ACTION
	);
GO

INSERT INTO Afdelingen (naam)
VALUES ('HR')
	, ('Aangefites')
	, ('IV');
GO

INSERT INTO Medewerkers (naam, afdeling_id)
VALUES ('Ad',1)
	, ('Bo',2)
	, ('Cas',2)
    , ('Anna',3);
GO

SELECT *
FROM Afdelingen where id = 2

SELECT *
FROM Medewerkers where afdeling_id = 2

```
## Composite Key
Een composite key in t-SQL is een combinatie van twee of meer kolommen die samen fungeren als de primaire sleutel voor een tabel. Dit betekent dat de combinatie van waarden in de geselecteerde kolommen uniek moet zijn voor elke rij in de tabel. Om een composite key te maken in t-SQL, voeg je de gewenste kolommen toe aan de PRIMARY KEY-constraint, gescheiden door een komma.

Een voorbeeld:

```sql
CREATE TABLE Orders (
    OrderID int,
    CustomerID int,
    OrderDate date,
    PRIMARY KEY (OrderID, CustomerID)
);
```
In dit voorbeeld vormen de kolommen OrderID en CustomerID samen de composite key voor de Orders-tabel. Elke combinatie van OrderID en CustomerID moet uniek zijn in de tabel.