## API

Api is te bereiken op https://localhost:7236/ tijdens debuggen, http://localhost:5233 na deployment

Deze accepteert de volgende endpoints:

### GETs
GET `api/cursusinstanties` levert alle cursusinstanties op

GET `api/cursusinstanties/{year}/{week}` levert alle cursusinstanties op voor die week van dat jaar

GET `api/cursusinstanties/{id}` levert de cursusinstantie met dat id

### POSTs
POST `api/cursusinstanties/new` voegt alle instanties toe die aangeleverd worden als `List<CourseInstance>

POST `api/cursusinstanties/date` levert alle instanties die in het tijd bestek vallen van het aangeleverde Period object

POST `api/cursusinstanties/{id}/newstudent` voegt nieuwe cursist toe ,die aangeleverd wordt met een Student object, aan de aangeleverde id 

## FrontEnd

Website is te bereiken op https://localhost:7200/ tijdens debuggen, http://localhost:5024 na deployment

Hoofdpagina is Index, hier krijg je wat informatie over de website zelf en uitleg over de twee verschillende tabjes

De pagina Planning geeft overzicht voor de gekozen week. Standaard is dit de huidige week. Als op de pagina op de huidige week geklikt wordt zal de week en jaar kiezer hier opgezet worden.

De week en jaar kiezer kan gebruikt worden om naar de vorige en volgende week en jaar te navigeren. 

De url kan aangevuld worden met `Planning/{year}/{week}`  om het overzicht van een bepaalde week te krijgen. Deze url wordt ook gebruikt als je met de week en jaar keuze een week selecteert van een bepaald jaar. Op die manier kan je hem toevoegen aan je bookmarks. 

Met de `"Meer Info"` knop kan je de hele info van de instantie kijken, inclusief de cursisten die deelnemen. Als er minder dan 12 cursisten zijn krijg je een formulier te zien om een nieuwe cursist toe te voegen aan de instantie.

De knop navigeert naar `instantie/{id}` zodat ook deze gebookmarkt kan worden. 

De pagina Import kan gebruikt worden om bestanden aan te leveren om nieuwe instanties in de database te krijgen. De pagina laat zien in wat voor een formaat je het bestand moet aanleveren. Het form controleert of het bestand de juiste bestandsextensie heeft. 

Er wordt standaard data geimporteerd uit  `goedvoorbeeld1.txt` zodat er altijd data is om te zien hoe de pagina eruit ziet. Dit wordt toegevoegd door de migratie AddData

Dit is te vinden onder https://localhost:7200/Planning/2018/41


## Database

De backend maakt gebruik van de Secret Safe van ASP.NET. Dus het kan zijn dat er nog een aanpassing in appsettings.json oid nodig is om het nu op een andere machine te laten draaien. 

Dit is de setting die ik ervoor heb gemaakt. 
```json
  "ConnectionStrings": {
    "SQL": "Server=localhost;User=SA;Password=Geheim101!;Database=CourseDB;TrustServerCertificate=true;MultipleActiveResultSets=True"
  }
```

Voor het maken van de database heb ik het volgende script gebruikt:

```sql
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

CREATE DATABASE CourseDB;
GO

USE CourseDB;
GO

```

## Database Diagram vanuit Azure Data Studio
![[Pasted image 20230623134711.png]]
## Backlog-Items

De volgende punten uit de backlog heb ik naar beste kunnen opgepakt:
 
| Slice                                                                                                   | Task                                                   |
| ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------ |
| 1 - Basis-functionaliteit om cursussen te importeren en te tonen (Walking Skeleton)                     | Ingeplande cursusinstanties bekijken                   |
| 1 - Basis-functionaliteit om cursussen te importeren en te tonen (Walking Skeleton)                     | tekstbestand selecteren                                |
| 1 - Basis-functionaliteit om cursussen te importeren en te tonen (Walking Skeleton)                     | cursusplanning importeren                              |
| 1 - Basis-functionaliteit om cursussen te importeren en te tonen (Walking Skeleton)                     | Resultaat bekijken                                     |
| 2 - Bruikbare functionaliteit om cursussen te importeren EN de geimporteerde lijst gesorteerd weergeven | Gesorteerde lijst bekijken                             |
| 2 - Bruikbare functionaliteit om cursussen te importeren EN de geimporteerde lijst gesorteerd weergeven | geen bestaande of dubbele cursus-instanties importeren |
| 2 - Bruikbare functionaliteit om cursussen te importeren EN de geimporteerde lijst gesorteerd weergeven | Melden hoveel duplicaten er zijn tegengekomen          |
| 2 - Bruikbare functionaliteit om cursussen te importeren EN de geimporteerde lijst gesorteerd weergeven | geen cursusplanning "in incorrect formaat" importeren  |
| 2 - Bruikbare functionaliteit om cursussen te importeren EN de geimporteerde lijst gesorteerd weergeven | Foutmelding bekijken                                   |
| 3 - geimporteerde lijst gesorteerd per week weergeven                                                   | Huidige week tonen                                     |
| 3 - geimporteerde lijst gesorteerd per week weergeven                                                   | Weeknummer (en jaar) kiezen                            |
| 3 - geimporteerde lijst gesorteerd per week weergeven                                                   | lijst in gekozen week tonen                            |
| 3 - geimporteerde lijst gesorteerd per week weergeven                                                   | weekoverzicht in favorieten                            |
| 4 - Alleen cursusinstanties binnen periode importeren EN navigeren naar volgende en vorige week         | Navigeren naar volgende en vorige week                 |
| 4 - Alleen cursusinstanties binnen periode importeren EN navigeren naar volgende en vorige week         | begin- en einddatum opgeven                            |
| 4 - Alleen cursusinstanties binnen periode importeren EN navigeren naar volgende en vorige week         | alleen cursusinstanties binnen periode importeren      |
| 5 - Basis functionaliteit voor inschrijven van cursisten voor cursus                                    | Cursusinstantie kiezen                                 |
| 5 - Basis functionaliteit voor inschrijven van cursisten voor cursus                                    | Voor- en achternaam cursist invullen                   |
| 5 - Basis functionaliteit voor inschrijven van cursisten voor cursus                                    | Melding krijgen dat inschrijving gelukt is             |


## Meer info

Alleen het importeren met tijd periode heb ik niet kunnen unit testen doordat mijn tijd er een beetje op zat 😅


De model classes hebben de volgende structuur:
![[Pasted image 20230623134725.png]]

Ik heb gekozen om een scheiding aan te brengen in de fouten die kunnen onstaan bij het importeren van bestanden. De BackEnd die kijkt per instantie of de duur niet te lang is, of dat hij wel binnen een week valt. Dit heb ik hier gelaten omdat, als deze instantie niet klopt de andere uit het bestand misschien wel.

De importer die kijkt vooral naar of de volgorde en het formaat van het bestand goed zijn. Mocht daar iets fout in gaan, importeert hij het hele bestand niet. 