Rebuild is een SQL Server-opdracht die wordt gebruikt om een index volledig opnieuw te bouwen. Het laat de index fysiek opnieuw opbouwen, in tegenstelling tot de Reorganize-opdracht, die alleen de index defragmenteert.

Een eenvoudig voorbeeld van het gebruik van de Rebuild-opdracht zou zijn:

```sql
ALTER INDEX IX_MijnTabel_MijnIndex ON MijnTabel REBUILD;
```

Dit voorbeeld herbouwt de index "MijnIndex" op de tabel "MijnTabel".

Rebuild wordt meestal gebruikt wanneer de index sterk gefragmenteerd is en de prestaties van de database beïnvloedt. Het kan ook worden gebruikt om andere problemen met de index op te lossen, zoals fouten of beschadiging. Het wordt over het algemeen aanbevolen om rebuild alleen te gebruiken wanneer dat nodig is, omdat het een intensief proces kan zijn dat veel bronnen van de server gebruikt.