DateTime en DateTime2 zijn datatypes in Transact-SQL (t-SQL) die worden gebruikt om datum- en tijdwaarden op te slaan in Microsoft SQL Server.

DateTime is het oudere datatype en kan waarden opslaan vanaf het jaar 1753 tot en met het jaar 9999 met een precisie van ongeveer 3 milliseconden. Een voorbeeld van het gebruik van DateTime zou zijn:

```sql
DECLARE @date datetime = '2023-04-12 14:30:00'
SELECT @date
```

Dit zou de waarde '2023-04-12 14:30:00.000' retourneren.'

DateTime2 is een nieuwer datatype dat werd geïntroduceerd in SQL Server 2008 en kan waarden opslaan vanaf het jaar 0001 tot en met het jaar 9999 met een precisie tot 100 nanoseconden. DateTime2 is hierdoor nauwkeuriger dan DateTime. Een voorbeeld van het gebruik van DateTime2 zou zijn:

```sql
DECLARE @date datetime2 = '2023-04-12 14:30:00.1234567'
SELECT @date
```
Dit zou de waarde '2023-04-12 14:30:00.1234567' retourneren.

Kortom, het belangrijkste verschil tussen DateTime en DateTime2 is dat DateTime een lagere precisie heeft dan DateTime2 en geen ondersteuning biedt voor jaartallen vóór 1753. Daarom wordt DateTime2 vaak aanbevolen voor nieuwe toepassingen waarbij hoge precisie en ondersteuning voor bredere jaartallen vereist zijn.


Zie onderstaande link, of bijgevoegd PDF bestand voor meer uitleg.


https://learn.microsoft.com/en-us/sql/t-sql/functions/date-and-time-data-types-and-functions-transact-sql?view=sql-server-ver16