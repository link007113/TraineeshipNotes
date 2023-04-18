
Set Operators in t-SQL zijn statements die worden gebruikt om de resultaten van meerdere SELECT-statements te combineren en te filteren op basis van settheorie. Er zijn vier set operators beschikbaar in t-SQL:

-   UNION: combineert de resultaten van twee of meer SELECT-statements en verwijdert duplicaten.
-   UNION ALL: combineert de resultaten van twee of meer SELECT-statements inclusief duplicaten.
-   INTERSECT: retourneert alleen de rijen die in beide SELECT-statements voorkomen.
-   EXCEPT: retourneert alleen de rijen die in het eerste SELECT-statement voorkomen maar niet in het tweede SELECT-statement.

Bijvoorbeeld, als we een tabel "Klanten" hebben met kolommen "Naam" en "Leeftijd", kunnen we de volgende queries uitvoeren met set operators:

-   De volgende query geeft alle unieke namen en leeftijden van klanten terug:

```sql
SELECT Naam, Leeftijd FROM Klanten UNION SELECT Naam, Leeftijd FROM AndereKlanten;
````

-   De volgende query geeft alle namen en leeftijden van klanten terug, inclusief duplicaten:


```sql
SELECT Naam, Leeftijd FROM Klanten UNION ALL SELECT Naam, Leeftijd FROM AndereKlanten;
```

-   De volgende query geeft de namen en leeftijden van klanten terug die voorkomen in beide tabellen:
```sql
SELECT Naam, Leeftijd FROM Klanten INTERSECT SELECT Naam, Leeftijd FROM AndereKlanten;
```

-   De volgende query geeft de namen en leeftijden van klanten terug die voorkomen in de eerste tabel maar niet in de tweede:
```sql
SELECT Naam, Leeftijd FROM Klanten EXCEPT SELECT Naam, Leeftijd FROM AndereKlanten;
```

Kortom, set operators zijn handige hulpmiddelen om gegevens uit meerdere tabellen samen te voegen, te filteren en te manipuleren op basis van settheorie.