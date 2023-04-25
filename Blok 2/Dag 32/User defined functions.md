
User Defined Functions (UDFs) zijn aangepaste functies die gebruikers kunnen maken in T-SQL om specifieke taken uit te voeren. Ze zijn geprogrammeerd door de gebruiker en bieden een manier om complexe taken uit te voeren en te hergebruiken in verschillende delen van de database.

Er zijn drie soorten UDF's in T-SQL:

- Scalar functies: deze functies nemen één of meer parameters en retourneren een enkele waarde.
- Table-valued functies: deze functies retourneren een tabel in plaats van een enkele waarde.
- Inline Table-valued functies: deze functies retourneren ook een tabel, maar verschillen van de Table-valued functies omdat ze inline worden uitgevoerd in een query, waardoor ze presteren als een view.

Een voorbeeld van een Scalar UDF kan zijn om de Voornaam, tussen-namen en achternaam met elkaar te concateren. Hieronder staat een voorbeeld van een Scalar UDF die dit doet:

```sql
CREATE OR ALTER FUNCTION dbo.Fullname (
	@firstname AS NVARCHAR(50)
	, @middlenames AS NVARCHAR(100)
	, @lastname AS NVARCHAR(50)
	)
RETURNS NVARCHAR(200)
AS
BEGIN
DECLARE @fullname NVARCHAR(200) = CONCAT_WS(' ', @firstname, @middlenames, @lastname)
RETURN (@fullname)
END
```

UDFs kunnen gebruikt worden voor verschillende doeleinden, zoals het uitvoeren van complexe berekeningen, het uitvoeren van herhaalde taken en het transformeren van gegevens. Ze kunnen worden gebruikt in query's, views en opgeslagen procedures om de functionaliteit van de database uit te breiden. UDFs helpen bij het verminderen van codeherhaling en zorgen voor een betere onderhoudsbaarheid van de code.

Nog een voorbeeld. Deze kan vanuit een url het protocol halen en deze terug geven:


```sql

GO

CREATE OR

ALTER FUNCTION dbo.ProtocolUitURL (@url AS NVARCHAR(1000))
RETURNS NVARCHAR(1000)
AS
BEGIN
	DECLARE @protocol NVARCHAR(1000)

	SET @protocol = IIF(@url LIKE 'http:%', 'http', 
                    IIF(@url LIKE 'https:%', 'https', 
                    IIF(@url LIKE 'ftp:%', 'ftp', NULL)))

	RETURN (@protocol)

	RETURN (@protocol)
END
GO

SELECT dbo.ProtocolUitURL('http://google.nl')
```