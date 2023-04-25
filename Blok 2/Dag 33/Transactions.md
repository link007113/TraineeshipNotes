Een transactie in T-SQL is een reeks databasebewerkingen die als één enkele eenheid worden uitgevoerd. Het idee hierachter is om de consistentie van de database te waarborgen en ervoor te zorgen dat alle bewerkingen in de transactie volledig worden uitgevoerd of helemaal niet worden uitgevoerd.

Een transactie bestaat uit de volgende stappen, die bekend staan als ACID-eigenschappen:

- Atomicity: de transactie is ondeelbaar, ofwel alle bewerkingen binnen de transactie worden uitgevoerd of geen van de bewerkingen wordt uitgevoerd.
- Consistency: de transactie moet ervoor zorgen dat de database in een geldige toestand blijft. Als er iets fout gaat, worden alle wijzigingen teruggedraaid en blijft de database consistent.
- Isolation: de transactie mag geen invloed hebben op andere transacties die op hetzelfde moment worden uitgevoerd. Elke transactie moet onafhankelijk werken.
- Durability: na het voltooien van de transactie moeten de wijzigingen permanent zijn en niet meer ongedaan kunnen worden gemaakt.

Een eenvoudig voorbeeld van een transactie zou kunnen zijn:
```sql
BEGIN TRANSACTION;

UPDATE Klanten
SET Balans = Balans - 100
WHERE KlantID = 1;

INSERT INTO Transacties (KlantID, Bedrag)
VALUES (1, -100);

COMMIT TRANSACTION;
```
In dit voorbeeld wordt een transactie gestart met de BEGIN TRANSACTION statement. Daarna wordt er een update uitgevoerd op de tabel Klanten en een insert op de tabel Transacties. Beide bewerkingen moeten volledig worden uitgevoerd, anders worden ze allemaal teruggedraaid met behulp van de ROLLBACK TRANSACTION statement. Als alles goed gaat, wordt de transactie bevestigd met de COMMIT TRANSACTION statement.

Transacties zijn vooral handig in situaties waarin meerdere databasebewerkingen als één enkele eenheid moeten worden uitgevoerd. Bijvoorbeeld bij online bankieren waarbij geld van de ene bankrekening naar de andere wordt overgemaakt. Door de transactie te gebruiken, kan het geld alleen worden overgemaakt als er voldoende saldo op de rekening staat, waardoor inconsistenties worden voorkomen.