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

Hier zijn enkele veelgebruikte window functions in T-SQL: 
1. ROW_NUMBER(): Hiermee kun je een rijnummer toewijzen aan elke rij in het resultaatset, gebaseerd op de volgorde die je definieert met de ORDER BY-clausule. 
2. RANK(): Hiermee kun je een rangorde toewijzen aan elke rij in het resultaatset, gebaseerd op de volgorde die je definieert met de ORDER BY-clausule. Als er meerdere rijen zijn met dezelfde waarden, krijgen ze dezelfde rangorde. 
3. DENSE_RANK(): Dit is vergelijkbaar met RANK(), maar als er meerdere rijen zijn met dezelfde waarden, krijgen ze dezelfde rangorde en wordt de volgende rangorde overgeslagen. 
4. NTILE(): Hiermee kun je het resultaatset opdelen in n gelijke delen en een bucketnummer toewijzen aan elke rij in het resultaatset. Bijvoorbeeld als je NTILE(4) gebruikt, wordt het resultaatset opgedeeld in vier gelijke delen en wordt aan elke rij een bucketnummer toegewezen tussen 1 en 4. 
5. LEAD() en LAG(): Deze functies geven toegang tot de volgende of vorige rij in het resultaatset, gebaseerd op de volgorde die je definieert met de ORDER BY-clausule. LEAD() geeft toegang tot de volgende rij en LAG() geeft toegang tot de vorige rij. 
6. SUM(), AVG(), COUNT() en andere aggregatiefuncties: Deze functies kunnen worden gebruikt in combinatie met de OVER-clausule om aggregatiefuncties te berekenen over een subset van rijen in het resultaatset, in plaats van over het hele resultaatset. Bijvoorbeeld als je SUM(sales) OVER (PARTITION BY year) gebruikt, wordt de totale verkoop berekend per jaar in plaats van voor het hele resultaatset.

In het kort, window functions zijn krachtige hulpmiddelen in t-SQL waarmee we geavanceerde berekeningen kunnen uitvoeren op subsets van rijen binnen een bepaald venster of raam. Ze maken complexe query's veel eenvoudiger en efficiënter.