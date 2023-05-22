SET NOCOUNT ON;
GO

-- Database Creatie
USE master;
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name = 'WegUitHamelen')
BEGIN  
    ALTER DATABASE [WegUitHamelen] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [WegUitHamelen];
END
GO

CREATE DATABASE WegUitHamelen;
GO

USE WegUitHamelen;
GO

-- Schema Creatie
CREATE SCHEMA Burgers;
GO
CREATE SCHEMA Gemeente;
GO
CREATE SCHEMA Documenten;
GO

-- Table Creatie
CREATE TABLE Burgers.Personen
(
    PersoonID            INT            IDENTITY(1,1) PRIMARY KEY NONCLUSTERED
    ,Voornaam            VARCHAR(54)    NOT NULL
    ,Achternaam          VARCHAR(54)    NOT NULL
    ,Tussenvoegsel       VARCHAR(10)    NULL
    ,BSN                 VARCHAR(9)     NOT NULL UNIQUE CLUSTERED
    ,Adres               VARCHAR(100)   NOT NULL
    ,Postcode            VARCHAR(7)     NOT NULL
    ,Woonplaats          VARCHAR(50)    NOT NULL
    ,OorspronkelijkeNaam NVARCHAR(128)  NOT NULL
    ,Geboorteplaats      VARCHAR(50)    NOT NULL DEFAULT 'Hamelen'
    ,Geboorteland        VARCHAR(2)     NOT NULL DEFAULT 'NL'
);
GO

CREATE UNIQUE INDEX UIX_Personen_Naam_BSN
ON Burgers.Personen (Voornaam, Tussenvoegsel, Achternaam, BSN);
GO

CREATE TABLE Gemeente.Afdelingen
(
    AfdelingID  INT             IDENTITY(1,1) PRIMARY KEY NONCLUSTERED
    ,Naam       VARCHAR(50)     UNIQUE CLUSTERED
 
);
GO

CREATE TABLE Gemeente.Medewerkers
(
    MedewerkerID    INT         IDENTITY(1,1) PRIMARY KEY
    ,PersoonID      INT         NOT NULL
    ,AfdelingID     INT         NOT NULL
    ,ManagerID      INT         NULL
    ,FOREIGN KEY (PersoonID)    REFERENCES Burgers.Personen(PersoonID)
    ,FOREIGN KEY (ManagerID)    REFERENCES Gemeente.Medewerkers(MedewerkerID)
    ,FOREIGN KEY (AfdelingID)   REFERENCES Gemeente.Afdelingen(AfdelingID)
);
GO

CREATE TABLE Documenten.DocumentType
(
    DocumentTypeID           INT          PRIMARY KEY NONCLUSTERED IDENTITY(1,1) 
    ,DocumentTypeNaam        NVARCHAR(20) NOT NULL UNIQUE CLUSTERED
    ,Prijs                   DECIMAL(5,2) NOT NULL
    ,GeldigheidsduurInDagen  INT          NOT NULL
)
GO

CREATE TABLE Documenten.DocumentStatus
(
    DocumentStatusID    INT           PRIMARY KEY NONCLUSTERED IDENTITY(1,1) 
    ,DocumentStatusNaam NVARCHAR(20)  NOT NULL UNIQUE CLUSTERED
)
GO

CREATE FUNCTION Documenten.BerekenVerloopdatum (@documentTypeId INT, @afgifteDatum DATETIME2(0))
RETURNS DATETIME2(0)
AS
BEGIN
    DECLARE @geldigheidsduurInDagen INT
    SELECT @geldigheidsduurInDagen = GeldigheidsduurInDagen
    FROM Documenten.DocumentType
    WHERE DocumentTypeID = @documentTypeId

    RETURN DATEADD(DAY, @geldigheidsduurInDagen, @afgifteDatum)
END
GO

CREATE TABLE Documenten.Reisdocumenten
(
    DocumentID              INT             PRIMARY KEY IDENTITY(1,1)
    ,PersoonID              INT             NOT NULL
    ,DocumentNr             VARCHAR(20)     NOT NULL
    ,DocumentTypeID         INT             NOT NULL
    ,AanvraagMedewerkerID   INT             NOT NULL
    ,AanvraagDatumTijd      DATETIME2(0)    NOT NULL DEFAULT SYSDATETIME()
    ,AfgiftePlaats          VARCHAR(50)     NOT NULL DEFAULT 'Hamelen'
    ,AfgifteDatum           DATETIME2(0)    NOT NULL
    ,VerloopDatum           DATETIME2(0)    NOT NULL
    ,BetaaldePrijs          DECIMAL(5,2)    NOT NULL
    ,DocumentStatusId       INT DEFAULT 1
    ,CONSTRAINT FK_Reisdocumenten_Mederwerkers FOREIGN KEY (AanvraagMedewerkerID) REFERENCES Gemeente.Medewerkers(MedewerkerID)
    ,CONSTRAINT FK_Reisdocumenten_Personen FOREIGN KEY (PersoonID) REFERENCES Burgers.Personen(PersoonID)
    ,CONSTRAINT FK_Reisdocumenten_DocumentType FOREIGN KEY (DocumentTypeID) REFERENCES Documenten.DocumentType(DocumentTypeID)
    ,CONSTRAINT FK_Reisdocumenten_DocumentStatus FOREIGN KEY (DocumentStatusID) REFERENCES Documenten.DocumentStatus(DocumentStatusID)
)
GO
CREATE UNIQUE INDEX UIX_Reisdocumenten_DocumentType_DocumentStatus_PersoonID
ON Documenten.Reisdocumenten (DocumentTypeID, DocumentStatusID, PersoonID);
GO


CREATE FUNCTION Gemeente.fn_IsValidBSN (@BSN VARCHAR(9))
RETURNS BIT
AS
BEGIN
    DECLARE @result BIT;
    SET @result = 0;
    IF @bsn LIKE '%[0-9]%' AND (
        (9 * CAST(SUBSTRING(@bsn, 1, 1) AS INTEGER)) +
        (8 * CAST(SUBSTRING(@bsn, 2, 1) AS INTEGER)) +
        (7 * CAST(SUBSTRING(@bsn, 3, 1) AS INTEGER)) +
        (6 * CAST(SUBSTRING(@bsn, 4, 1) AS INTEGER)) +
        (5 * CAST(SUBSTRING(@bsn, 5, 1) AS INTEGER)) +
        (4 * CAST(SUBSTRING(@bsn, 6, 1) AS INTEGER)) +
        (3 * CAST(SUBSTRING(@bsn, 7, 1) AS INTEGER)) +
        (2 * CAST(SUBSTRING(@bsn, 8, 1) AS INTEGER)) -
        (1 * CAST(SUBSTRING(@bsn, 9, 1) AS INTEGER))
    ) % 11 = 0
        SET @result = 1;
    RETURN @result;
END;
GO

ALTER TABLE Burgers.Personen
ADD CONSTRAINT CK_ValidBSN CHECK (Gemeente.fn_IsValidBSN(BSN) = 1);

-- Insert of data
INSERT INTO Documenten.DocumentType
    (DocumentTypeNaam, Prijs, GeldigheidsduurInDagen)
VALUES
    ('Paspoort' ,58.85 ,3652)
    ,('ID-kaart' ,70.35 ,1826)
    ,('Visum' ,80.00 ,182)
GO

INSERT INTO Documenten.DocumentStatus
    (DocumentStatusNaam)
VALUES
    ('Aangevraagd')
    ,('Opgehaald' )
    ,('Afgekeurd')
    ,('Verlopen')
GO

INSERT INTO Burgers.Personen (Voornaam, Achternaam, Tussenvoegsel, BSN, Adres, Postcode, Woonplaats, OorspronkelijkeNaam, Geboorteplaats, Geboorteland)
VALUES ('Els', 'Jansen', NULL, '668093924', 'Kerkstraat 1', '1234 AB', 'Hamelen', 'Els Jansen', 'Hamelen', 'NL'),
       ('Mo', 'Ahmed', NULL, '661979295', 'Marktplein 2', '1234 CD', 'Hamelen', 'Mo Ahmed', 'Hamelen', 'NL'),
       ('Arend', 'Pietersen', NULL, '860503756', 'Kerkstraat 3', '1234 EF', 'Hamelen', 'Arend Pietersen', 'Hamelen', 'NL'),
       ('Mieke', 'Vermeer', NULL, '513830935', 'Marktplein 4', '1234 GH', 'Hamelen', '媛引ク', 'Hamelen', 'NL'),
       ('Boris', 'Jansen', NULL, '847696947', 'Kerkstraat 5', '1234 IJ', 'Hamelen', 'Boris Jansen', 'Hamelen', 'NL'),
       ('Angela', 'De Vries', NULL, '817149594', 'Marktplein 6', '1234 KL', 'Hamelen', 'Angela De Vries', 'Hamelen', 'NL'),
       ('Evert', 'Revert', '''t', '659871105', 'Dorpsstraat 1', '5678 AB', 'Hamelen', 'Evert Bakker', 'Hamelen', 'NL'),
       ('Anna', 'Janssen', NULL, '206950779', 'Raadhuisstraat 2', '5678 CD', 'Hamelen', 'Anna Janssen', 'Hamelen', 'NL'),
       ('Hannah', 'Smit', NULL, '933600793', 'Dorpsstraat 3', '5678 EF', 'Hamelen', 'Hannah Smit', 'Hamelen', 'NL'),
       ('Anthony', 'Ellenbroek', NULL, '209175175', 'Van Ostadelaan 37', '7312 NE', 'Apeldoorn', 'Anthony Ellenbroek', 'Apeldoorn', 'NL'),
       ('Max', 'Vogel', NULL, '540675568', 'Kerkplein 5', '5678 CD', 'Hamelen', 'Max Vogel', 'Hamelen', 'NL'),
       ('Lisa', 'Jacobs', NULL, '961923556', 'Marktstraat 15', '9012 EF', 'Hamelen', 'Lisa Jacobs', 'Hamelen', 'NL'),
       ('Finn', 'Mulder', NULL, '771489304', 'Dorpshof 3', '3456 GH', 'Hamelen', 'Finn Mulder', 'Hamelen', 'NL'),
       ('Sophie', 'Bakker', NULL, '937676688', 'Kerkweg 20', '6789 IJ', 'Hamelen', 'Sophie Bakker', 'Hamelen', 'NL'),
       ('Lucas', 'Meijer', NULL, '143496736', 'Raadhuisplein 8', '8901 KL', 'Hamelen', 'Lucas Meijer', 'Hamelen', 'NL'),
       ('Julia', 'De Boer', NULL, '458668941', 'Schoolstraat 12', '9012 MN', 'Hamelen', 'Julia De Boer', 'Hamelen', 'NL'),
       ('Milan', 'Scholten', NULL, '377053867', 'Vondellaan 3', '2345 OP', 'Hamelen', 'Milan Scholten', 'Hamelen', 'NL'),
       ('Luna', 'Bos', NULL, '390314328', 'Burgemeesterplein 6', '5678 QR', 'Hamelen', 'Luna Bos', 'Hamelen', 'NL'),
       ('Thomas', 'Kok', NULL, '871443600', 'Dorpsstraat 5', '8901 ST', 'Hamelen', 'Thomas Kok', 'Hamelen', 'NL');

DECLARE @ElsID INT, @MoID INT, @ArendID INT, @MiekeID INT, @BorisID INT, @AngelaID INT, @EvertID INT, @AnnaID INT, @HannahID INT, @AnthonyID INT
      , @MaxID INT, @LisaID INT, @FinnID INT, @SophieID INT, @LucasID INT, @JuliaID INT, @MilanID INT, @LunaID INT, @ThomasID INT

SET @ElsID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Els');
SET @MoID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Mo');
SET @ArendID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Arend');
SET @MiekeID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Mieke');
SET @BorisID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Boris');
SET @AngelaID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Angela');
SET @EvertID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Evert');
SET @AnnaID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Anna');
SET @HannahID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Hannah');
SET @AnthonyID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Anthony');
SET @MaxID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Max');
SET @LisaID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Lisa');
SET @FinnID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Finn');
SET @SophieID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Sophie');
SET @LucasID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Lucas');
SET @JuliaID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Julia');
SET @MilanID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Milan');
SET @LunaID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Luna');
SET @ThomasID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Thomas');

INSERT INTO Gemeente.Afdelingen (Naam)
VALUES ('Reisdocumenten'), ('Algemeen'), ('Informatievoorziening')

INSERT INTO Gemeente.Medewerkers (PersoonID, AfdelingID)
VALUES    
    (@ElsID, 1),
    (@MoID, 1),      
    (@ArendID, 2),
    (@MiekeID, 2),
    (@BorisID, 2),     
    (@AngelaID, 3)

UPDATE Gemeente.Medewerkers
SET ManagerID = (SELECT MedewerkerID FROM Gemeente.Medewerkers WHERE PersoonID = @MiekeID)
WHERE PersoonID = @ArendID
;


UPDATE Gemeente.Medewerkers
SET ManagerID = (SELECT MedewerkerID FROM Gemeente.Medewerkers WHERE PersoonID = (SELECT PersoonID FROM Burgers.Personen WHERE Voornaam = 'Arend'))
WHERE PersoonID IN (
    @ElsID,
    @MoID,
    @BorisID,
    @AngelaID
);



INSERT INTO Documenten.Reisdocumenten (PersoonID, DocumentNr, DocumentTypeID, AanvraagMedewerkerID, AanvraagDatumTijd, AfgiftePlaats, AfgifteDatum, VerloopDatum, BetaaldePrijs, DocumentStatusId)
VALUES
(@EvertID, 'EVR-123', 1, @ElsID, DATEADD(DAY, -10, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 4, SYSDATETIME()), Documenten.BerekenVerloopdatum(1, DATEADD(DAY, 4, SYSDATETIME())), 58.85, 1),
(@EvertID, 'EVR-54321', 3, @ElsID, DATEADD(DAY, -10, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 4, SYSDATETIME()), Documenten.BerekenVerloopdatum(3, DATEADD(DAY, 4, SYSDATETIME())), 58.85, 1),
(@AnnaID, 'ASM-234', 1, @MoID, DATEADD(DAY, -35, SYSDATETIME()), 'Hamelen', DATEADD(DAY, -21, SYSDATETIME()), Documenten.BerekenVerloopdatum(1, DATEADD(DAY, -21, SYSDATETIME())), 58.85,  2),
(@HannahID, 'HSM-345', 2, @AngelaID, DATEADD(DAY, -186, SYSDATETIME()), 'Hamelen', DATEADD(DAY, -172, SYSDATETIME()), Documenten.BerekenVerloopdatum(2, DATEADD(DAY, -172, SYSDATETIME())), 70.35, 2),
(@AnthonyID, 'AEL-456', 3, @ElsID, DATEADD(DAY, -365, SYSDATETIME()), 'Apeldoorn', DATEADD(DAY, -351, SYSDATETIME()),Documenten.BerekenVerloopdatum(3, DATEADD(DAY, -351, SYSDATETIME())), 75.00, 2),
(@AnthonyID, 'AEL-458', 2, @ElsID, DATEADD(DAY, -30, SYSDATETIME()), 'Apeldoorn', DATEADD(DAY, -15, SYSDATETIME()),Documenten.BerekenVerloopdatum(2, DATEADD(DAY, -15, SYSDATETIME())), 58.85, 1),
(@AnnaID, 'ASM-298', 2, @ElsID, DATEADD(DAY, -1826, SYSDATETIME()), 'Hamelen', DATEADD(DAY, -1812, SYSDATETIME()),Documenten.BerekenVerloopdatum(2, DATEADD(DAY, -1812, SYSDATETIME())), 65.35,  2),
(@MaxID, 'MVO-512', 1, @ElsID, DATEADD(DAY, -17, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 7, SYSDATETIME()), Documenten.BerekenVerloopdatum(1, DATEADD(DAY, 7, SYSDATETIME())), 58.85, 1),
(@MaxID, 'MVO-724', 2, @MoID, DATEADD(DAY, -14, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 0, SYSDATETIME()), Documenten.BerekenVerloopdatum(2, DATEADD(DAY, 0, SYSDATETIME())), 75.50, 1),
(@LisaID, 'LJA-658', 1, @ElsID, DATEADD(DAY, -5, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 9, SYSDATETIME()), Documenten.BerekenVerloopdatum(1, DATEADD(DAY, 9, SYSDATETIME())), 58.85, 1),
(@LisaID, 'LJA-923', 2, @AngelaID, DATEADD(DAY, -12, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 2, SYSDATETIME()), Documenten.BerekenVerloopdatum(2, DATEADD(DAY, 2, SYSDATETIME())), 75.50, 1),
(@FinnID, 'FMU-162', 1, @ElsID, DATEADD(DAY, -3, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 11, SYSDATETIME()), Documenten.BerekenVerloopdatum(1, DATEADD(DAY, 11, SYSDATETIME())), 58.85, 1),
(@FinnID, 'FMU-023', 2, @ElsID, DATEADD(DAY, -10, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 4, SYSDATETIME()), Documenten.BerekenVerloopdatum(2, DATEADD(DAY, 4, SYSDATETIME())), 75.50, 1),
(@SophieID, 'SBA-034', 1, @AngelaID, DATEADD(DAY, -9, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 5, SYSDATETIME()), Documenten.BerekenVerloopdatum(1, DATEADD(DAY, 5, SYSDATETIME())), 58.85, 1),
(@SophieID, 'SBA-456', 2, @ElsID, DATEADD(DAY, -16, SYSDATETIME()), 'Hamelen', DATEADD(DAY, -2, SYSDATETIME()), Documenten.BerekenVerloopdatum(2, DATEADD(DAY, -2, SYSDATETIME())), 75.50, 2),
(@LucasID, 'LME-243', 1, @ElsID, DATEADD(DAY, -2, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 12, SYSDATETIME()), Documenten.BerekenVerloopdatum(1, DATEADD(DAY, 12, SYSDATETIME())), 58.85, 1),
(@LucasID, 'LME-983', 2, @ElsID, DATEADD(DAY, -9, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 5, SYSDATETIME()), Documenten.BerekenVerloopdatum(2, DATEADD(DAY, 5, SYSDATETIME())), 75.50, 1),
(@JuliaID, 'JBO-539', 1, @MoID, DATEADD(DAY, -11, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 3, SYSDATETIME()), Documenten.BerekenVerloopdatum(1, DATEADD(DAY, 3, SYSDATETIME())), 58.85, 1),
(@JuliaID, 'JBO-823', 2, @ElsID, DATEADD(DAY, -18, SYSDATETIME()), 'Hamelen', DATEADD(DAY, -4, SYSDATETIME()), Documenten.BerekenVerloopdatum(2, DATEADD(DAY, -4, SYSDATETIME())), 75.50, 2),
(@MilanID, 'MSC-923', 1, @AngelaID, DATEADD(DAY, -6, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 8, SYSDATETIME()), Documenten.BerekenVerloopdatum(1, DATEADD(DAY, 8, SYSDATETIME())), 58.85, 1),
(@MilanID, 'MSC-223', 2, @ElsID, DATEADD(DAY, -13, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 1, SYSDATETIME()), Documenten.BerekenVerloopdatum(2, DATEADD(DAY, 1, SYSDATETIME())), 75.50, 1),
(@LunaID, 'LBO-143', 1, @MoID, DATEADD(DAY, -4, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 10, SYSDATETIME()), Documenten.BerekenVerloopdatum(1, DATEADD(DAY, 10, SYSDATETIME())), 58.85, 1),
(@LunaID, 'LBO-126', 2, @ElsID, DATEADD(DAY, -11, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 3, SYSDATETIME()), Documenten.BerekenVerloopdatum(2, DATEADD(DAY, 3, SYSDATETIME())), 75.50, 1),
(@ThomasID, 'TKO-223', 1, @MoID, DATEADD(DAY, -8, SYSDATETIME()), 'Hamelen', DATEADD(DAY, 6, SYSDATETIME()), Documenten.BerekenVerloopdatum(1, DATEADD(DAY, 6, SYSDATETIME())), 58.85, 1),
(@ThomasID, 'TKO-232', 2, @ElsID, DATEADD(DAY, -15, SYSDATETIME()), 'Hamelen', DATEADD(DAY, -1, SYSDATETIME()), Documenten.BerekenVerloopdatum(2, DATEADD(DAY, -1, SYSDATETIME())), 75.50, 2);

Update Documenten.Reisdocumenten set DocumentStatusId = 4 where SYSDATETIME() > VerloopDatum   and DocumentStatusId in (2)