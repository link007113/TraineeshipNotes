Use WegUitHamelen;
GO
-- Select Queries

-- Blauwe piste
SELECT * FROM Burgers.Personen AS p 
LEFT OUTER JOIN Documenten.Reisdocumenten as r on r.PersoonID = p.PersoonID;

SELECT * FROM Burgers.Personen AS p 
RIGHT OUTER JOIN Gemeente.Medewerkers as m on m.PersoonID = p.PersoonID
WHERE NOT EXISTS 
(
SELECT
    1
FROM
   Documenten.Reisdocumenten as r
WHERE m.MedewerkerID = r.AanvraagMedewerkerID
);

SELECT 
T.DocumentTypeNaam AS [Type document]
, COUNT(R.DocumentID) AS Aantal
FROM Documenten.Reisdocumenten AS r 
INNER JOIN Documenten.DocumentType AS t ON R.DocumentTypeID = T.DocumentTypeID
WHERE MONTH(AanvraagDatumTijd) = MONTH(SYSDATETIME()) - 1
GROUP BY T.DocumentTypeNaam;

SELECT * FROM Burgers.Personen WHERE Woonplaats = 'Hamelen';

-- Rode Piste

SELECT 
MONTH(AanvraagDatumTijd) AS [Aanvraag Maand]
, YEAR(AanvraagDatumTijd) AS [Aanvraag Jaar]
, SUM(T.Prijs) AS [Totaal Prijs]
FROM Documenten.Reisdocumenten AS r 
INNER JOIN Documenten.DocumentType AS t ON R.DocumentTypeID = T.DocumentTypeID
GROUP BY MONTH(AanvraagDatumTijd) 
, YEAR(AanvraagDatumTijd);

SELECT * FROM Documenten.Reisdocumenten 
WHERE 
VerloopDatum < SYSDATETIME() OR 
VerloopDatum BETWEEN SYSDATETIME() AND DATEADD(MONTH, 2, SYSDATETIME());

SELECT 
T.DocumentTypeNaam AS [Type document]
, s.DocumentStatusNaam AS [Status]
, COUNT(R.DocumentID) AS Aantal
FROM Documenten.Reisdocumenten AS r 
INNER JOIN Documenten.DocumentType AS t ON R.DocumentTypeID = T.DocumentTypeID
INNER JOIN Documenten.DocumentStatus AS s ON S.DocumentStatusID = R.DocumentStatusId
GROUP BY T.DocumentTypeNaam 
, s.DocumentStatusNaam ;

SELECT 
T.DocumentTypeNaam AS [Type document]
, s.DocumentStatusNaam AS [Status]
, COUNT(R.DocumentID) AS Aantal
FROM Documenten.Reisdocumenten AS r 
INNER JOIN Documenten.DocumentType AS t ON R.DocumentTypeID = T.DocumentTypeID
INNER JOIN Documenten.DocumentStatus AS s ON S.DocumentStatusID = R.DocumentStatusId
GROUP BY T.DocumentTypeNaam 
, s.DocumentStatusNaam ;

SELECT *
FROM Gemeente.Medewerkers AS m 
LEFT JOIN Gemeente.Medewerkers AS mm  ON m.ManagerID = m.MedewerkerID
INNER JOIN Burgers.Personen AS p ON m.PersoonID = p.PersoonID;

SELECT 
CONCAT_WS(' ', pm.Voornaam, pm.Tussenvoegsel, pm.Achternaam) AS MedewerkerNaam, 
COALESCE(pm.BSN, '') AS MedewerkerBSN, 
CONCAT_WS(', ', pm.Adres, pm.Postcode, pm.Woonplaats) AS MedewerkerAdres, 
CONCAT_WS(' ', pmm.Voornaam, pmm.Tussenvoegsel, pmm.Achternaam) AS ManagerNaam, 
COALESCE(pmm.BSN, '') AS ManagerBSN, 
CONCAT_WS(', ', pmm.Adres, pmm.Postcode, pmm.Woonplaats) AS ManagerAdres
FROM Gemeente.Medewerkers m
LEFT JOIN Gemeente.Medewerkers mm ON m.ManagerID = mm.MedewerkerID
INNER JOIN Burgers.Personen pm ON m.PersoonID = pm.PersoonID
LEFT JOIN Burgers.Personen pmm ON mm.PersoonID = pmm.PersoonID;

-- Zwarte Piste

-- Per jaar per documenttype het totaalbedrag dat werkelijk betaald is (de prijs van toen) en het totaalbedrag op basis van de huidige prijs (een fictief totaal)
SELECT 
    YEAR(r.AfgifteDatum) AS Jaar,
    dt.DocumentTypeNaam AS DocumentTypeNaam,
    SUM(r.BetaaldePrijs) AS TotaalBetaald,
    SUM(dt.Prijs) AS FictiefTotaalBetaald
FROM 
    Documenten.Reisdocumenten AS r
    INNER JOIN Documenten.DocumentType AS dt ON r.DocumentTypeID = dt.DocumentTypeID
GROUP BY 
    YEAR(r.AfgifteDatum), dt.DocumentTypeNaam;

-- Per maand de procentuele toe- of afname van opgehaalde reisdocumenten.
SELECT
    DATEFROMPARTS(YEAR(r.AfgifteDatum), MONTH(r.AfgifteDatum), 1) AS Maand
    
    ,100 * (COUNT(*) - LAG(COUNT(*), 1, 0) OVER (ORDER BY MONTH(AfgifteDatum), 
             MONTH(AfgifteDatum))) / LAG(COUNT(*), 1, 1) OVER (ORDER BY MONTH(AfgifteDatum), 
             MONTH(AfgifteDatum)) AS ToeOfAfname
FROM
    Documenten.Reisdocumenten AS r
WHERE DocumentStatusID = 2
GROUP BY YEAR(AfgifteDatum), MONTH(AfgifteDatum);

-- Tel het aantal documenten van de huidige maand.
-- Trek het aantal documenten van de vorige maand af van het huidige aantal auto's. Als er geen gegevens zijn voor de vorige maand, neem dan 0.
-- Deel het verschil door het aantal documenten van de vorige maand. Als er geen gegevens zijn voor de vorige maand, neem dan 1.
-- Vermenigvuldig het resultaat met 100 om de verandering als een percentage te krijgen.


-- Challenge: Per week de eerste 3 opgehaalde reisdocumenten
SELECT Jaar, [Week], DocumentNr from (
    SELECT 
    YEAR(AfgifteDatum) AS Jaar,
    DATEPART(WEEK, AfgifteDatum) AS Week,
    DocumentNr,
    ROW_NUMBER() OVER (PARTITION BY YEAR(AfgifteDatum), DATEPART(WEEK, AfgifteDatum) ORDER BY AfgifteDatum) AS RowNumber
FROM Documenten.Reisdocumenten
WHERE DocumentStatusID = 2
    ) Reisdocumenten WHERE RowNumber <= 3;

-- Groepeer de documenten op basis van het jaar en de week van de uitgifte.
-- Wijs een rijnummer toe aan elk document binnen elke groep, waarbij de documenten worden geordend op basis van de uitgifte datum.
-- Selecteer alleen de documenten waarvan het rijnummer kleiner is dan of gelijk is aan 3, dit zijn de eerste drie documenten van elke week.


select * from Documenten.Reisdocumenten where PersoonID = 10