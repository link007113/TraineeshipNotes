In SQL Server bevat elke tabel een verzameling statistieken die informatie bieden over de distributie van gegevens in de kolommen van die tabel. Dit staat bekend als tabelstatistieken of kolomstatistieken. Het doel van statistieken is om de query optimizer te helpen bij het bepalen van de meest efficiënte queryplannen.

Tabelstatistieken bevatten informatie zoals de unieke waarden, de frequentie van deze waarden en de verdeling van de waarden in een kolom. Wanneer een query wordt uitgevoerd, gebruikt de query optimizer deze statistieken om te beslissen welke queryplan de beste is.

Er zijn twee soorten statistieken: automatische statistieken en handmatige statistieken. Automatische statistieken worden automatisch gegenereerd door SQL Server op basis van de gegevens in de tabel. Handmatige statistieken kunnen door de gebruiker worden gemaakt en onderhouden.

Een voorbeeld van het maken van handmatige statistieken op de kolom "leeftijd" van de tabel "gebruikers" zou er als volgt uitzien:

```sql
CREATE STATISTICS stats_leeftijd ON gebruikers(leeftijd);
```

In dit voorbeeld wordt de statistiek "stats_leeftijd" gemaakt op de kolom "leeftijd" van de tabel "gebruikers". Deze statistiek bevat informatie over de unieke waarden, frequentie en verdeling van de leeftijden van de gebruikers in de tabel.

Use cases voor het gebruik van statistieken zijn onder meer:

- Verbetering van queryprestaties: het gebruik van statistieken kan helpen bij het identificeren van de meest efficiënte queryplannen, waardoor de prestaties van de query's worden verbeterd.

- Identificatie van gegevensproblemen: door de statistieken van een tabel te analyseren, kunnen gegevensproblemen zoals ontbrekende waarden, te veel null-waarden of inconsistente gegevens worden geïdentificeerd.

- Optimalisatie van gegevensopslag: door de statistieken te analyseren, kan de optimale manier worden bepaald om de gegevens in een tabel op te slaan, zoals het gebruik van indexen of partities.