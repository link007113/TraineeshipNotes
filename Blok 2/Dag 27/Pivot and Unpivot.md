PIVOT en UNPIVOT zijn twee T-SQL-operaties die worden gebruikt om gegevens in rijen en kolommen om te zetten of omgekeerd.
## PIVOT

PIVOT wordt gebruikt om gegevens in rijen om te zetten naar kolommen op basis van een aggregatiefunctie.

Bijvoorbeeld, laten we zeggen dat we een tabel hebben met verkoopgegevens per maand:MaandVerkoopJanuari100Februari200Maart150

We willen de verkoopgegevens per kwartaal weergeven met behulp van PIVOT:

```sql

SELECT *
FROM (
    SELECT Maand, Verkoop, 'Kwartaal ' + CAST((DATEPART(q, DATEADD(m, MONTH, 0)) - 1) AS VARCHAR(10)) AS Kwartaal
    FROM Sales
) AS src
PIVOT (
    SUM(Verkoop)
    FOR Kwartaal IN ([Kwartaal 1], [Kwartaal 2], [Kwartaal 3], [Kwartaal 4])
) AS pvt;
```



In dit voorbeeld wordt de maandwaarde omgezet naar een kwartaalwaarde met behulp van de `DATEPART`-functie en vervolgens samengevoegd met de verkoopgegevens. De `PIVOT`-clausule voert de omzetting uit door de waarden van de kolom 'Kwartaal' te gebruiken als kolomkoppen en de bijbehorende verkoopwaarden op te tellen.
## UNPIVOT

UNPIVOT wordt gebruikt om gegevens in kolommen om te zetten naar rijen.

Bijvoorbeeld, laten we zeggen dat we een tabel hebben met verkoopgegevens per kwartaal:KwartaalVerkoopKwartaal 1100Kwartaal 2200Kwartaal 3150Kwartaal 4300

We willen de verkoopgegevens per maand weergeven met behulp van UNPIVOT:

```css

SELECT Maand, Verkoop
FROM (
    SELECT [Kwartaal 1], [Kwartaal 2], [Kwartaal 3], [Kwartaal 4]
    FROM Sales
) AS pvt
UNPIVOT (
    Verkoop
    FOR Maand IN ([Januari], [Februari], [Maart])
) AS unpvt;
```



In dit voorbeeld wordt de kwartaalwaarde omgezet naar een maandwaarde met behulp van de `UNPIVOT`-clausule. De waarden van de kolommen 'Kwartaal 1' tot 'Kwartaal 4' worden omgezet naar rijen met behulp van de `FOR`-clausule en de bijbehorende maandwaarden worden geëxtraheerd uit de kolomkoppen.

Kortom, PIVOT en UNPIVOT zijn handige tools voor het transformeren van gegevens tussen rijen en kolommen en kunnen worden gebruikt om complexe query's te vereenvoud