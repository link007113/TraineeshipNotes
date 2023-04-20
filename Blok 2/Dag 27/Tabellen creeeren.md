


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