Een self join in t-SQL is het koppelen van een tabel aan zichzelf om zo gegevens te combineren en te analyseren. Dit kan bijvoorbeeld handig zijn als je een tabel hebt met informatie over medewerkers en je wilt de manager van elke medewerker vinden.

Hier is een simpel voorbeeld:

We hebben een tabel "Employees" met de volgende kolommen:

-   EmployeeID (de unieke identificatie van een medewerker)
-   EmployeeName (de naam van de medewerker)
-   ManagerID (de EmployeeID van de manager van de medewerker)


Om de manager van elke medewerker te vinden, kunnen we een self join gebruiken. We koppelen de tabel "Employees" aan zichzelf met behulp van de ManagerID-kolom. We selecteren de naam van de medewerker en de naam van zijn/haar manager.

Dit kan als volgt worden geschreven:
```sql
SELECT e.EmployeeName, m.EmployeeName AS ManagerName FROM Employees e LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID
```

Zoals je kunt zien, toont deze query de namen van alle medewerkers en hun managers, inclusief de naam van de hoogste manager. 