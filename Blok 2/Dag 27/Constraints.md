Constraints in t-SQL zijn regels die je kan toevoegen aan een kolom of een tabel. Ze stellen regels op over welke waardes er in deze kolom of tabel mogen staan. Er zijn verschillende soorten constraints, zoals:
- NOT NULL: De waarde in deze kolom mag niet NULL zijn.
- UNIQUE: Elke waarde in deze kolom moet uniek zijn.
- PRIMARY KEY: Deze kolom moet uniek zijn en als een unieke identificatie van een rij fungeren.
- FOREIGN KEY: Deze kolom verwijst naar de PRIMARY KEY van een andere tabel.
- CHECK: Hiermee kan je een voorwaarde opstellen voor welke waardes er in de kolom mogen staan.

Bijvoorbeeld, de volgende tabel maakt gebruik van verschillende constraints:

```sql
CREATE TABLE Logs (
	id  INT IDENTITY 
        CONSTRAINT PK_Log_ID 
        PRIMARY KEY
	, logdatum DATETIME2(0) NOT NULL
    CONSTRAINT default_LogDate DEFAULT SYSDATETIME()
    , message NVARCHAR(2000)
    )	;
GO
```



In dit voorbeeld stelt de PRIMARY KEY constraint in dat de UserID kolom uniek moet zijn en de unieke identificatie van elke rij. De NOT NULL constraint stelt in dat zowel de FirstName als de LastName kolommen verplicht zijn. De UNIQUE constraint op de Email kolom zorgt ervoor dat elke waarde uniek moet zijn. De CHECK constraint op de Age kolom stelt een voorwaarde op waaraan de waarde moet voldoen. En tot slot verwijst de FOREIGN KEY constraint op de CountryCode kolom naar de PRIMARY KEY van een andere tabel.




```sql
Set NOCOUNT ON;
USE master;
Go

DROP DATABASE If EXISTS Huisdieren

Create DATABASE Huisdieren;
GO

Use Huisdieren
GO

DROP TABLE IF EXISTS Logs
GO

CREATE TABLE Logs (
	id  INT IDENTITY 
        CONSTRAINT PK_Log_ID 
        PRIMARY KEY
	, logdatum DATETIME2(0) NOT NULL
    CONSTRAINT default_LogDate DEFAULT SYSDATETIME()
    , message NVARCHAR(2000)
    )	;
GO


INSERT INTO Logs ([message])
VALUES ('Hoi')
	, ('test')
	, ('huh');
GO



select * from Logs

```