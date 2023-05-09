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

## Table Constraints

Table constraints in T-SQL zijn regels die worden toegepast op een tabel om de gegevensintegriteit te behouden en te beperken tot alleen geldige gegevens. Ze worden gebruikt om ervoor te zorgen dat de gegevens in een tabel correct en consistent zijn en voldoen aan bepaalde vereisten.

Een voorbeeld van een table constraint kan zijn het beperken van de waarde van een bepaalde kolom onder bepaalde omstandigheden. Bijvoorbeeld, als we de volgende tabel hebben:

```sql
	CREATE TABLE Leveranciers (
		id INT NOT NULL, 
        achternaam NVARCHAR(255) NULL, 
		status SMALLINT NULL, 
        plaats NVARCHAR(255) NULL
		, 
        CONSTRAINT chk_status 
        CHECK (plaats <> 'Veenendaal' OR STATUS = 20)
		)

```

Dan zorgt de CONSTRAINT ervoor dat als de waarde van 'plaats' in een bepaalde rij 'Veenendaal' is, de waarde van 'STATUS' in dezelfde rij altijd 20 moet zijn, anders zal het invoegen of bijwerken van de rij mislukken.

Dit kan handig zijn in een situatie waarin we ervoor willen zorgen dat een bepaalde kolom altijd een bepaalde waarde heeft onder bepaalde omstandigheden. In dit geval willen we bijvoorbeeld dat de status van een leverancier altijd 20 is als de leverancier in Veenendaal is gevestigd.

Andere voorbeelden van table constraints zijn PRIMARY KEY, UNIQUE, FOREIGN KEY en NOT NULL constraints. Deze constraints zorgen ervoor dat er unieke waarden worden ingevoerd in de betreffende kolommen en dat er geen NULL-waarden worden ingevoerd in kolommen die verplicht moeten zijn.



