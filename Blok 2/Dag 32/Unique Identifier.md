Een Unique Identifier, ook wel GUID genoemd, is een data type in t-SQL dat wordt gebruikt om een groot nummer te genereren dat gegarandeerd uniek is. Het wordt vaak gebruikt als een primaire sleutel in een database tabel.

GUIDs zijn erg handig voor het waarborgen van de veiligheid van gegevens, omdat ze moeilijk te voorspellen zijn en daardoor moeilijk te raden of te hacken zijn. Een GUID bestaat uit 32 hexadecimale cijfers, gescheiden door streepjes, en kan worden gegenereerd met behulp van de NEWID() functie in t-SQL.

Een voorbeeld van het gebruik van een GUID is bijvoorbeeld wanneer je een tabel hebt met gebruikersgegevens en je wilt voorkomen dat twee gebruikers per ongeluk dezelfde ID hebben. Door een GUID te gebruiken als primaire sleutel, ben je er zeker van dat elke gebruiker een unieke ID heeft.

```sql
CREATE TABLE test (
	ticketnr UNIQUEIDENTIFIER NOT NULL 
    CONSTRAINT DF_TicketNr_NEWID DEFAULT NEWID()
	, plaats NVARCHAR(50) NOT NULL
	)

INSERT INTO test (plaats)
VALUES ('Urk')

SELECT *
FROM test

```
In dit voorbeeld wordt een tabel 'test' aangemaakt met een ticketnr-kolom van het data type UNIQUEIDENTIFIER als primaire sleutel. Bij het toevoegen van een nieuw ticket wordt de NEWID() functie gebruikt om automatisch een unieke GUID te genereren als de ID voor het nieuwe ticket.

Resultaat ziet er als volgt uit:

|ticketnr|plaats|
|---|---|
|5d6fa1f9-efa2-4991-a379-2a72bf5f7901|Urk|



