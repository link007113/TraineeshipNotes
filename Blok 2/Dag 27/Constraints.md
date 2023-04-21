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

Dit SQL-query maakt een nieuwe tabel genaamd 'Logs' met drie kolommen: 'id', 'logdatum' en 'message'.

De eerste kolom 'id' is een identiteitskolom, wat betekent dat SQL Server automatisch een unieke waarde toewijst aan deze kolom wanneer een nieuwe rij wordt ingevoegd. De CONSTRAINT PK_Log_ID maakt de 'id' kolom de primaire sleutel van de tabel, zodat elke rij een unieke identificatie heeft.

De tweede kolom 'logdatum' kan niet leeg zijn en wordt standaard ingesteld op de huidige datum en tijd met de DEFAULT SYSDATETIME() constraint.

De derde kolom 'message' is een gewone NVARCHAR-kolom waarin tekst kan worden opgeslagen.

Samengevat zorgt deze SQL-query voor het creëren van een nieuwe tabel voor het opslaan van logs, waarbij elke rij uniek geïdentificeerd kan worden door een automatisch gegenereerde ID, terwijl de datum van de log automatisch wordt toegevoegd en het logbericht kan worden opgeslagen in de 'message' kolom.

