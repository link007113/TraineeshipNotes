Api is te bereiken op https://localhost:7236/
Deze accepteert de volgende endpoints

Get api/cursusinstanties levert alle cursusinstanties op
Get api/cursusinstanties/{year}/{week} levert alle cursusinstanties op voor die week van dat jaar
GET api/cursusinstanties/{id} levert de cursusinstantie met dat id
POST api/cursusinstanties/new voegt alle instanties toe die aangeleverd worden als List<CourseInstance>
POST api/cursusinstanties/date levert alle instanties die in het tijd bestek vallen van het aangeleverde Period object
POST api/cursusinstanties/{id}/newstudent voegt nieuwe cursist toe ,die aangeleverd wordt met een Student object, aan de aangeleverde id 


Website is te bereiken op https://localhost:7200/
Hoofdpagina is Index, hier krijg je wat informatie over de website zelf en uitleg over de twee verschillende tabjes

De pagina Planning geeft overzicht voor de huidige week. De url kan aangevuld worden met Planning/{year}/{week}  om het overzicht van een bepaalde week te krijgen. Deze url wordt ook gebruikt als je met de week en jaar keuze een week selecteert van een bepaald jaar. Op die manier kan je hem toevoegen aan je bookmarks. 

Met de "Meer Info" knop kan je de hele info van de instantie kijken, inclusief de cursisten die deelnemen. Als er minder dan 12 cursisten zijn krijg je een formulier te zien om een nieuwe cursist toe te voegen aan de instantie.


De pagina Import kan gebruikt worden om bestanden aan te leveren om nieuwe instanties in de database te krijgen. De importer heeft nog geen functie om in een bepaalde periode te importeren. Ik was in de war en had de periode gebouwd voor de overzicht pagina. Hierdoor had ik geen tijd meer om de importer om te bouwen. Wel laat te pagina zijn in wat voor een formaat je het bestand moet aanleveren. 

De volgende punten uit de backlog heb ik opgepakt:

