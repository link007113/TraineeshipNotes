Transacties in t-SQL stellen ons in staat om meerdere SQL-instructies als één enkele, geatomiseerde eenheid uit te voeren, waarbij alle instructies tegelijkertijd of helemaal niet worden uitgevoerd. Dit betekent dat als er een probleem optreedt bij het uitvoeren van een van de instructies in de transactie, alle wijzigingen die zijn aangebracht door de andere instructies in de transactie worden teruggedraaid, waardoor de database in de oorspronkelijke staat wordt hersteld.

Hieronder volgt een eenvoudig voorbeeld:
```sql
BEGIN TRANSACTION;

UPDATE Customers
SET FirstName = 'John'
WHERE LastName = 'Doe';

INSERT INTO Orders (CustomerID, OrderDate)
VALUES (1, '2023-04-21');

COMMIT TRANSACTION;
```
In dit voorbeeld bevatten de instructies UPDATE en INSERT een transactie die wordt gestart met de opdracht `BEGIN TRANSACTION` en eindigt met de opdracht `COMMIT TRANSACTION`. Als er tijdens het uitvoeren van deze transactie een fout optreedt, bijvoorbeeld als er een probleem is met het invoegen van de bestelling, worden alle wijzigingen die zijn aangebracht in de transactie teruggedraaid en wordt de database in de oorspronkelijke staat hersteld. Dit helpt om de consistentie van de database te behouden en eventuele fouten te voorkomen die kunnen optreden bij het uitvoeren van complexe bewerkingen.