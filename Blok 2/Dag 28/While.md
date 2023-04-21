De `WHILE`-loop in t-SQL is een manier om een bepaalde set van instructies te herhalen totdat een bepaalde voorwaarde niet meer geldt. Het werkt op een vergelijkbare manier als een `IF`-statement, maar in plaats van alleen maar een keer de code uit te voeren, blijft de `WHILE`-loop de code uitvoeren totdat de opgegeven voorwaarde niet meer waar is.

Een voorbeeld van een `WHILE`-loop kan zijn om de waarden van een bepaalde kolom in een tabel op te tellen totdat een bepaalde waarde wordt bereikt. Dit kan bijvoorbeeld handig zijn als je wilt weten hoeveel items er in een tabel staan, maar je wilt het niet handmatig doen.

Hier is een voorbeeld van hoe je een `WHILE`-loop in t-SQL kunt gebruiken:

```sql
DECLARE @counter as INT = 0

WHILE @counter <= 10
BEGIN
PRINT @counter;
set @counter += 1;

END
```

In dit voorbeeld begint de variabele `@counter` met de waarde 0. De `WHILE`-loop blijft de code binnen de `BEGIN` en `END`-blokken uitvoeren totdat `@counter` 10 bereikt. Bij elke iteratie van de loop wordt de `@counter` bijgewerkt. 

Een veel voorkomend gebruik van `WHILE`-loops is bij het uitvoeren van bewerkingen op rijen van een tabel waarbij je niet meteen weet hoeveel rijen er verwerkt moeten worden. Bijvoorbeeld, als je een bewerking op elke rij van een tabel wilt uitvoeren waarbij de bewerking afhankelijk is van de waarde van een bepaalde kolom, maar de tabel duizenden of zelfs miljoenen rijen kan hebben, kun je een `WHILE`-loop gebruiken om de bewerkingen iteratief uit te voeren totdat alle rijen zijn verwerkt.

