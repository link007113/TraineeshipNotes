GUID
Is een data type
Groot nummer, gegarandeerd uniek
Security omdat het nauwelijks voorspelbaar is

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

|ticketnr|plaats|
|---|---|
|5d6fa1f9-efa2-4991-a379-2a72bf5f7901|Urk|



