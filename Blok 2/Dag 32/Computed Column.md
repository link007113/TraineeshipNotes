
Een computed column in t-SQL is een kolom die automatisch wordt berekend op basis van andere kolommen in dezelfde tabel. Dit kan handig zijn als je bijvoorbeeld altijd een bepaalde berekening wilt uitvoeren op een set data.

```sql
Drop table if EXISTS Engineers

CREATE TABLE Engineers (
	id int IDENTITY NOT NULL 
	, naam NVARCHAR(50) NOT NULL
    , salaris DECIMAL(8,2)
    , indienst DATE not NULL
    , overwinst DECIMAL(8,2)
    , jaarsalaris as salaris + overwinst // computed Column
	)

INSERT INTO Engineers (naam, salaris, indienst, overwinst)
VALUES ('Anthony', 2400., '20230301', 1200.)

SELECT *
FROM Engineers

```

Een computed column kan ook worden opgeslagen in de database door gebruik te maken van het keyword "Persisted". Dit zorgt ervoor dat de berekende waarde wordt opgeslagen in de database, waardoor het sneller is om de data op te halen. Het nadeel is wel dat het updaten van de data langzamer kan worden omdat de waarde opnieuw moet worden berekend.

Als je geen "Persisted" gebruikt, dan wordt de berekende kolom niet opgeslagen in de database en wordt het elke keer opnieuw berekend wanneer het wordt opgevraagd. Dit kan leiden tot een langzamere select, maar wel een snellere update.

Computed columns kunnen nuttig zijn bij het vereenvoudigen van complexe berekeningen, het verminderen van redundante data en het verbeteren van queryprestaties.
