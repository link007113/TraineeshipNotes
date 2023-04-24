

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

Persisted is een keyword die ervoor zorgt dat de data wordt opgeslagen als de data de eerste keer wordt opgevraagd.
Zorgt voor een snelle select maar een langzame update.

Zonder heb je een langzamere select en een snellere update.