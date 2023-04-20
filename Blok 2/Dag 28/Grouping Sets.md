Grouping Sets in t-SQL is een feature waarmee je groepering kunt toepassen op een query resultaatset op basis van meerdere kolommen. Hiermee kun je een resultaatset genereren met subtotalen en totalen voor elke kolom of combinatie van kolommen.

Bijvoorbeeld, laten we zeggen dat we een tabel hebben met verkoopgegevens van producten in verschillende regio's en jaren. We willen subtotalen en totalen genereren voor elke combinatie van regio's en jaren:

```sql

SELECT Region, Year, SUM(Sales) as TotalSales
FROM SalesData
GROUP BY GROUPING SETS ((Region, Year), (Region), ())
ORDER BY Region, Year;
```



In dit voorbeeld gebruiken we de `GROUP BY`-clausule met de `GROUPING SETS`-optie om subtotalen en totalen te genereren voor elke combinatie van regio's en jaren. De eerste groeperingsset bevat beide kolommen, waardoor subtotalen worden gegenereerd voor elke combinatie van regio's en jaren. De tweede groeperingsset bevat alleen de regio-kolom, waardoor subtotalen worden gegenereerd voor elke regio. De derde groeperingsset bevat geen kolommen, waardoor het totaal voor alle verkoopgegevens wordt berekend.

Kortom, Grouping Sets in t-SQL is een handige feature om snel subtotalen en totalen te genereren voor meerdere kolommen in een resultaatset, en kan worden gebruikt om complexe queries te vereenvoudigen en te verduidelijken.