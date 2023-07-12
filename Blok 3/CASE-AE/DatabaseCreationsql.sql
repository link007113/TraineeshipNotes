SET NOCOUNT ON;
GO

USE master;
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name = 'CourseDB')
BEGIN  
    ALTER DATABASE [CourseDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [CourseDB];
END
GO

CREATE DATABASE Todo;
GO

USE CourseDB;
GO
