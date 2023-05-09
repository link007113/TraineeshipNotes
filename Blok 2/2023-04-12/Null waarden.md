## COALESCE

COALESCE is een SQL-functie die de eerste niet-null waarde in een lijst van expressies retourneert en wordt gebruikt om null-waarden in SQL-query's te behandelen.

Dus, het is een functie die null-waarden in een SQL-query kan behandelen door de eerste niet-null waarde te retourneren uit een lijst van expressies.

```sql
SELECT

    FirstName,
    COALESCE(MiddleName, '') AS MiddleName,
    LastName
FROM

    SalesLT.Customer;
```

Het belangrijkste verschil tussen COALESCE en ISNULL is dat COALESCE meerdere argumenten kan accepteren, terwijl ISNULL slechts twee argumenten kan accepteren.

De functie ISNULL retourneert de tweede parameter als de eerste parameter null is. 

De functie COALESCE kan echter meer dan twee argumenten accepteren en retourneert de eerste niet-null waarde uit de lijst van argumenten. 

Bij gebruik van COALESCE is het dus mogelijk om een ​​reeks waarden te controleren op null-waarden en de eerste niet-null waarde te retourneren. Als alle waarden null zijn, zal COALESCE null retourneren.

Kortom, als je slechts twee argumenten hoeft te controleren op null-waarden, is ISNULL de eenvoudigste optie. Als je echter meerdere waarden moet controleren of meer flexibiliteit nodig hebt bij het werken met null-waarden, is COALESCE de betere keuze.