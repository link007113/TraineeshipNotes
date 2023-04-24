Het kan nodig zijn een carriage return of regeleinde in te voegen tijdens het werken met stringgegevens. In SQL Server kunnen we de CHAR-functie met ASCII-nummercode gebruiken. We kunnen de volgende ASCII-codes gebruiken in SQL Server:

- Char(10) - Nieuwe regel / regeleinde
- Char(13) - Carriage Return
- Char(9) - Tab

```sql
BEGIN CATCH
		ROLLBACK TRANSACTION
		PRINT CONCAT_WS(' | ', @title, CONVERT(VARCHAR(10), @releaseDate, 120), CONVERT(VARCHAR(8), @length, 8));
		PRINT  CONCAT_WS(CHAR(10),
        'An error occurred:' 
        , Concat('Error number: ', ERROR_NUMBER())
        , Concat('Message: ',ERROR_MESSAGE()));
	END CATCH	
```

Dit levert het volgende resultaat:
```
Movie D | 2019-04-01 | 01:30:00

An error occurred:  
Error number: 2627  
Message: Violation of UNIQUE KEY constraint 'UQ__ReleaseD__F624DD34C70443A7'. Cannot insert duplicate key in object 'SalesLT.ReleaseDates'. The duplicate key value is (2019-04-01).
```