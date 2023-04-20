Primary Key


```sql
Set NOCOUNT ON;
USE master;
Go

DROP DATABASE If EXISTS Huisdieren

Create DATABASE Huisdieren;
GO

Use Huisdieren
GO

DROP TABLE IF EXISTS Logs
GO

CREATE TABLE Logs (
	id  INT IDENTITY 
        CONSTRAINT PK_Log_ID 
        PRIMARY KEY
	, logdatum DATETIME2(0) NOT NULL
    CONSTRAINT default_LogDate DEFAULT SYSDATETIME()
    , message NVARCHAR(2000)
    )	;
GO


INSERT INTO Logs ([message])
VALUES ('Hoi')
	, ('test')
	, ('huh');
GO



select * from Logs

```