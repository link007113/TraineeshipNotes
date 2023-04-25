```sql
CREATE OR ALTER FUNCTION dbo.Fullname (
	@firstname AS NVARCHAR(50)
	, @middlenames AS NVARCHAR(100)
	, @lastname AS NVARCHAR(50)
	)
RETURNS NVARCHAR(200)
AS
BEGIN
DECLARE @fullname NVARCHAR(200) = CONCAT_WS(' ', @firstname, @middlenames, @lastname)
RETURN (@fullname)
END
```