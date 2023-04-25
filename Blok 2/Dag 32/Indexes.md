In t-SQL zijn indexes hulpmiddelen die je kunt gebruiken om zoekopdrachten sneller uit te voeren. Stel je bijvoorbeeld een telefoonboek voor zonder een index: als je op zoek bent naar de contactgegevens van een persoon, moet je het boek doorbladeren tot je de juiste pagina hebt gevonden. Dit kan lang duren als er veel namen in het boek staan.

Met een index kun je de zoekopdracht versnellen door een soort inhoudsopgave toe te voegen aan het telefoonboek. Hiermee kun je snel de juiste pagina vinden waar de persoon die je zoekt zich bevindt. In t-SQL zijn er drie soorten indexes: heap, clustered en non-clustered indexes.

Indexen zijn nuttig wanneer je veel zoekopdrachten uitvoert op grote tabellen. Door het toevoegen van indexen kun je deze zoekopdrachten veel sneller maken en de algehele prestaties van de database verbeteren. Het is echter belangrijk om voorzichtig te zijn met het toevoegen van indexen, omdat deze ook nadelen kunnen hebben, zoals extra opslagruimte en langere invoertijd.

## Heap

Een heap is een tabel zonder index. Hierbij wordt er geen speciale volgorde aangebracht in de manier waarop gegevens in de tabel zijn opgeslagen. Dit kan handig zijn voor kleine tabellen, maar voor grote tabellen kan het langzaam zijn omdat er bij elke zoekopdracht een volledige tabelscan nodig is.

## Clustered index

Een clustered index ordent de gegevens in de tabel op basis van de waarden in een specifieke kolom, meestal de primaire sleutel. Hierdoor kan t-SQL veel sneller gegevens vinden omdat er niet meer door de hele tabel gescand hoeft te worden. Een clustered index heeft een binaire boomstructuur van maximaal 3 niveaus en biedt snel toegang tot de data page die de gezochte data bevat. Standaard wordt er bij een primaire sleutel een clustered index aangemaakt.

## Non-clustered index

Een non-clustered index in t-SQL is een manier om de zoekprestaties van een database te verbeteren door de indexering van specifieke kolommen van een tabel. Het verschil tussen een clustered index en een non-clustered index is dat bij een clustered index de data wordt opgeslagen op basis van de index, terwijl bij een non-clustered index de data gescheiden blijft van de index en deze alleen verwijst naar de fysieke locatie van de data.

Een eenvoudig voorbeeld van het maken van een non-clustered index op een kolom in een tabel is als volgt:

```sql
CREATE NONCLUSTERED INDEX IX_Customers_LastName ON Customers (LastName);
```

In dit voorbeeld wordt er een non-clustered index aangemaakt op de kolom LastName in de tabel Customers. Hiermee worden de zoekprestaties verbeterd wanneer er veelvuldig gezocht wordt op de achternaam van een klant.

Enkele use cases voor non-clustered indexes zijn:

-   Zoekopdrachten die vaak worden uitgevoerd op een specifieke kolom.
-   Het verbeteren van de prestaties bij het samenvoegen van meerdere tabellen in één query.
-   Bij tabellen met veel updates of inserts, omdat het bijwerken van een non-clustered index minder belastend is dan het bijwerken van een clustered index.