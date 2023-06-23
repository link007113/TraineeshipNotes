## API

Api is te bereiken op https://localhost:7236/
Deze accepteert de volgende endpoints

GET `api/cursusinstanties` levert alle cursusinstanties op
GET `api/cursusinstanties/{year}/{week}` levert alle cursusinstanties op voor die week van dat jaar
GET `api/cursusinstanties/{id}` levert de cursusinstantie met dat id
POST `api/cursusinstanties/new` voegt alle instanties toe die aangeleverd worden als `List<CourseInstance>
POST `api/cursusinstanties/date` levert alle instanties die in het tijd bestek vallen van het aangeleverde Period object
POST `api/cursusinstanties/{id}/newstudent` voegt nieuwe cursist toe ,die aangeleverd wordt met een Student object, aan de aangeleverde id 

## FrontEnd

Website is te bereiken op https://localhost:7200/
Hoofdpagina is Index, hier krijg je wat informatie over de website zelf en uitleg over de twee verschillende tabjes

De pagina Planning geeft overzicht voor de huidige week. De url kan aangevuld worden met `Planning/{year}/{week}`  om het overzicht van een bepaalde week te krijgen. Deze url wordt ook gebruikt als je met de week en jaar keuze een week selecteert van een bepaald jaar. Op die manier kan je hem toevoegen aan je bookmarks. 

Met de `"Meer Info"` knop kan je de hele info van de instantie kijken, inclusief de cursisten die deelnemen. Als er minder dan 12 cursisten zijn krijg je een formulier te zien om een nieuwe cursist toe te voegen aan de instantie.


De pagina Import kan gebruikt worden om bestanden aan te leveren om nieuwe instanties in de database te krijgen. De pagina laat zien in wat voor een formaat je het bestand moet aanleveren. Het form controleert of het bestand de juiste bestandsextensie heeft. 

## Backlog-Items

De volgende punten uit de backlog heb ik opgepakt:

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
| 5 - Basis functionaliteit voor inschrijven van cursisten voor cursus                                    | Cursusinstantie kiezen                                 |
| 5 - Basis functionaliteit voor inschrijven van cursisten voor cursus                                    | Voor- en achternaam cursist invullen                   |
| 5 - Basis functionaliteit voor inschrijven van cursisten voor cursus                                    | Melding krijgen dat inschrijving gelukt is             |



## Meer info

Ik was dus bezig met de periode selectie. Alleen omdat ik een foutje had gemaakt met lezen dacht ik dat het de bedoeling was om het alleen in een bepaalde periode te laten zien. De importer heeft dus nog geen functie om in een bepaalde periode te importeren. Ik was in de war en had de periode gebouwd voor de overzicht pagina. Hierdoor had ik geen tijd meer om de importer om te bouwen. Het gaat om de twee tussenliggende tasks:


| 4 - Alleen cursusinstanties binnen periode importeren EN navigeren naar volgende en vorige week | 10 | 2 | Cursussen invoeren | filter aangeven | begin- en einddatum opgeven                       | zodat ik er voor kan kiezen dat alleen cursussen uit een bepaalde periode worden     |
| ----------------------------------------------------------------------------------------------- | -- | - | ------------------ | --------------- | ------------------------------------------------- | ------------------------------------------------------------------------------------ |
| 4 - Alleen cursusinstanties binnen periode importeren EN navigeren naar volgende en vorige week | 10 | 2 | Cursussen invoeren | importeren      | alleen cursusinstanties binnen periode importeren | cursussen die eindigen op of na een startdatum, en beginnen op of voor een einddatum |


