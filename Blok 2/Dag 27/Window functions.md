Window functions in t-SQL zijn functies die worden gebruikt om berekeningen uit te voeren op een subset van rijen binnen een bepaald venster of raam.

Een voorbeeld van een window function is ROW_NUMBER, die rijnummers toekent aan elke rij in het venster op basis van een bepaalde sortering. Bijvoorbeeld:

```sql

SELECT ROW_NUMBER() OVER (ORDER BY SalesAmount DESC) as 'Rank', 
       FirstName, 
       LastName, 
       SalesAmount 
FROM SalesTable;
```
In dit voorbeeld wordt ROW_NUMBER gebruikt om de verkoopbedragen in SalesTable te rangschikken van hoog naar laag en elke rij een rangnummer te geven in de kolom 'Rank'. De OVER-clausule geeft aan welke kolommen moeten worden gebruikt om het venster te definiëren.

Andere voorbeelden van window functions zijn onder andere SUM, AVG en COUNT, die berekeningen uitvoeren op basis van het venster in plaats van op basis van de gehele tabel. Dit stelt ons in staat om complexe berekeningen uit te voeren op subsets van rijen zonder gebruik te maken van subqueries of joins.

In het kort, window functions zijn krachtige hulpmiddelen in t-SQL waarmee we geavanceerde berekeningen kunnen uitvoeren op subsets van rijen binnen een bepaald venster of raam. Ze maken complexe query's veel eenvoudiger en efficiënter.