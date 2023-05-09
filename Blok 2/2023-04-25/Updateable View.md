Een updateable view in t-SQL is een virtuele tabel die wordt gedefinieerd als een query, die het mogelijk maakt om gegevens te wijzigen in de onderliggende tabellen. Het stelt je in staat om een gedeelte van de data van een tabel te presenteren als een aparte entiteit, die je kunt bewerken zonder dat je de onderliggende tabellen hoeft te wijzigen.

Een makkelijk code voorbeeld van een updateable view is als volgt:

```sql
CREATE OR ALTER VIEW OrdersView AS
(
SELECT o.OrderID, c.CustomerName, o.OrderDate
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
WHERE o.ShippedDate IS NULL
)
```

Dit maakt een view aan genaamd "OrdersView", die de order-ID, de naam van de klant en de datum van de order bevat voor alle orders die nog niet zijn verzonden.

Als je nu de view wijzigt, dan worden de wijzigingen ook doorgevoerd in de onderliggende tabellen:

```sql
UPDATE OrdersView
SET OrderDate = '2022-04-25'
WHERE OrderID = 10248;
```

Deze query wijzigt de orderdatum voor de order met ID 10248 in de view. De onderliggende tabel Orders wordt ook bijgewerkt met deze wijziging.

Een use case voor een updateable view is bijvoorbeeld wanneer je een deelverzameling van gegevens uit een grote tabel wilt presenteren aan verschillende gebruikers met verschillende bevoegdheden. Je kunt dan een updateable view creëren die alleen de relevante gegevens bevat en de gebruikers alleen toegang geven tot de view en niet tot de onderliggende tabel. Hierdoor kunnen de gebruikers alleen de gegevens wijzigen die voor hen bedoeld zijn en niet de gehele tabel.