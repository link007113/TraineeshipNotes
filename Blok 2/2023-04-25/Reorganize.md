Reorganize is een term in T-SQL die wordt gebruikt om aan te geven dat de fysieke opslagstructuur van een database geoptimaliseerd moet worden zonder dat gegevens worden verwijderd of verplaatst. Dit is anders dan een "rebuild" die de gegevens in een index volledig opnieuw opbouwt.

Een voorbeeld van een reorganize-query is als volgt:

```sql
ALTER INDEX IX_MijnTabel_MijnKolom ON MijnTabel REORGANIZE;
```

Dit commando optimaliseert de fysieke opslagstructuur van de index "IX_MijnTabel_MijnKolom" in de tabel "MijnTabel". Dit kan bijvoorbeeld handig zijn als de tabel veel updates en deletes ondergaat en de prestaties verminderen.

Use cases voor het gebruik van Reorganize zijn onder meer:

- Het optimaliseren van de prestaties van de query's door de fysieke opslagstructuur van de index te verbeteren.
- Het minimaliseren van de hoeveelheid opslagruimte die wordt gebruikt door de database door de gegevens efficiënter op te slaan.
- Het minimaliseren van de impact van het onderhoud van de database op de beschikbaarheid van de database voor gebruikers.