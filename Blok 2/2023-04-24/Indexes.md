In t-SQL zijn indexes hulpmiddelen die je kunt gebruiken om zoekopdrachten sneller uit te voeren. Stel je bijvoorbeeld een telefoonboek voor zonder een index: als je op zoek bent naar de contactgegevens van een persoon, moet je het boek doorbladeren tot je de juiste pagina hebt gevonden. Dit kan lang duren als er veel namen in het boek staan.

Met een index kun je de zoekopdracht versnellen door een soort inhoudsopgave toe te voegen aan het telefoonboek. Hiermee kun je snel de juiste pagina vinden waar de persoon die je zoekt zich bevindt. In t-SQL zijn er drie soorten indexes: heap, clustered en non-clustered indexes.

Indexen zijn nuttig wanneer je veel zoekopdrachten uitvoert op grote tabellen. Door het toevoegen van indexen kun je deze zoekopdrachten veel sneller maken en de algehele prestaties van de database verbeteren. Het is echter belangrijk om voorzichtig te zijn met het toevoegen van indexen, omdat deze ook nadelen kunnen hebben, zoals extra opslagruimte en langere invoertijd.

## Heap

Een heap is een tabel zonder index. Hierbij wordt er geen speciale volgorde aangebracht in de manier waarop gegevens in de tabel zijn opgeslagen. Dit kan handig zijn voor kleine tabellen, maar voor grote tabellen kan het langzaam zijn omdat er bij elke zoekopdracht een volledige tabelscan nodig is.

## Clustered index

Een clustered index ordent de gegevens in de tabel op basis van de waarden in een specifieke kolom, meestal de primaire sleutel. Hierdoor kan t-SQL veel sneller gegevens vinden omdat er niet meer door de hele tabel gescand hoeft te worden. Een clustered index heeft een binaire boomstructuur van maximaal 3 niveaus en biedt snel toegang tot de data page die de gezochte data bevat. Standaard wordt er bij een primaire sleutel een clustered index aangemaakt. Kort gezegd is een clustered index een combinatie van binary tree en alle data

## Non-clustered index

Een non-clustered index in t-SQL is een manier om de zoekprestaties van een database te verbeteren door de indexering van specifieke kolommen van een tabel. Het verschil tussen een clustered index en een non-clustered index is dat bij een clustered index de data wordt opgeslagen op basis van de index, terwijl bij een non-clustered index de data gescheiden blijft van de index en deze alleen verwijst naar de fysieke locatie van de data. Kort gezegd is dit een alleen een binary tree 

Een eenvoudig voorbeeld van het maken van een non-clustered index op een kolom in een tabel is als volgt:

```sql
CREATE NONCLUSTERED INDEX IX_Customers_LastName ON Customers (LastName);
```

In dit voorbeeld wordt er een non-clustered index aangemaakt op de kolom LastName in de tabel Customers. Hiermee worden de zoekprestaties verbeterd wanneer er veelvuldig gezocht wordt op de achternaam van een klant.

Enkele use cases voor non-clustered indexes zijn:

-   Zoekopdrachten die vaak worden uitgevoerd op een specifieke kolom.
-   Het verbeteren van de prestaties bij het samenvoegen van meerdere tabellen in één query.
-   Bij tabellen met veel updates of inserts, omdat het bijwerken van een non-clustered index minder belastend is dan het bijwerken van een clustered index.

### Include Index

Een "include index" is een type index in T-SQL waarmee extra kolommen worden toegevoegd aan een non-clustered index. Deze extra kolommen zijn niet opgenomen in de indexboom, maar kunnen wel worden gebruikt om te voorkomen dat SQL Server de bijbehorende gegevenspagina's moet opzoeken wanneer de query wordt uitgevoerd.

Een index met alleen sleutelkolommen kan bijvoorbeeld worden gebruikt om zoekopdrachten uit te voeren, maar wanneer er extra kolommen nodig zijn voor de SELECT, GROUP BY of ORDER BY clausules, moet SQL Server de gegevenspagina's lezen, wat kan leiden tot prestatieproblemen.

Met een include index worden de extra kolommen opgenomen in de index, waardoor SQL Server de informatie niet hoeft op te zoeken in de bijbehorende gegevenspagina's. Dit kan de queryprestaties aanzienlijk verbeteren.

Een eenvoudig voorbeeld van een include index zou kunnen zijn:

```sql
CREATE NONCLUSTERED INDEX IX_SalesOrderDetail_ProductID
ON Sales.SalesOrderDetail (ProductID)
INCLUDE (OrderQty, UnitPrice)
```
In dit voorbeeld is de sleutelkolom 'ProductID' opgenomen in de indexboom en worden de extra kolommen 'OrderQty' en 'UnitPrice' opgenomen als include kolommen. Dit betekent dat SQL Server de extra informatie kan ophalen uit de index zelf, zonder de bijbehorende gegevenspagina's te hoeven lezen.

Een ander voorbeeld van het gebruik van een include index zou kunnen zijn bij een zoekopdracht die een WHERE, ORDER BY en GROUP BY clausule heeft op verschillende kolommen in dezelfde tabel. In dit geval kan een include index op de relevante kolommen helpen om de queryprestaties te verbeteren.