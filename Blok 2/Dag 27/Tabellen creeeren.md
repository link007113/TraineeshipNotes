


```sql
use tempdb;
GO

DROP TABLE if EXISTS Huisdieren

CREATE TABLE Huisdieren
(
    id  int IDENTITY PRIMARY KEY
    , naam NVARCHAR(50) NOT NULL    
);
GO

INSERT INTO Huisdieren
(naam)
VALUES

     ('Bello'),
     ('Kazan'),
     ('Ibbeltje'),
    ('Mies')
;
GO

select * from Huisdieren
```