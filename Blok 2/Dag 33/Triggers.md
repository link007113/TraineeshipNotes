Triggers in t-SQL zijn database-objecten die worden gebruikt om automatisch acties uit te voeren wanneer er gegevens in een tabel worden gewijzigd. Een trigger wordt geactiveerd door een specifieke gebeurtenis, zoals een INSERT-, UPDATE- of DELETE-operatie op een tabel, en kan vervolgens een reeks acties uitvoeren, zoals het bijwerken van een andere tabel of het uitvoeren van een opgeslagen procedure.

Een eenvoudig voorbeeld van een trigger in t-SQL zou kunnen zijn een trigger die automatisch de voorraad van een bepaald product bijwerkt wanneer er een verkoop plaatsvindt. De trigger zou worden geactiveerd door een INSERT- of UPDATE-operatie op de verkoopstabel, en zou vervolgens de voorraadtabel bijwerken door het aantal verkochte producten af te trekken van de totale voorraad.

Hier is een voorbeeldcode van zo'n trigger:

```sql
CREATE TRIGGER tr_UpdateStock
ON Sales
AFTER INSERT, UPDATE
AS
BEGIN
  UPDATE Stock
  SET Quantity = Quantity - i.Quantity
  FROM Stock s
  JOIN inserted i ON s.ProductID = i.ProductID
END
```

Dit is een AFTER-trigger die wordt geactiveerd na een INSERT- of UPDATE-operatie op de Sales-tabel. De trigger voert vervolgens een UPDATE-query uit op de voorraadtabel, waarbij het aantal verkochte producten wordt afgetrokken van de totale voorraad.

Use cases voor triggers zijn bijvoorbeeld het bijwerken van gerelateerde tabellen wanneer er een wijziging plaatsvindt, het uitvoeren van complexe berekeningen op gegevens voordat deze in de database worden opgeslagen, of het afdwingen van bepaalde bedrijfsregels en beperkingen. Triggers kunnen ook worden gebruikt om audit trails te maken, zodat er een logboek wordt bijgehouden van wijzigingen in de database.