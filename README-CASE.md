Api is te bereiken op https://localhost:7236/
Deze accepteert de volgende endpoints

Get api/cursusinstanties levert alle cursusinstanties op
Get api/cursusinstanties/{year}/{week} levert alle cursusinstanties op voor die week van dat jaar
GET api/cursusinstanties/{id} levert de cursusinstantie met dat id
POST api/cursusinstanties/new voegt alle instanties toe die aangeleverd worden als List<CourseInstance>
POST api/cursusinstanties/date levert alle instanties die in het tijd bestek vallen van het aangeleverde Period object
POST api/cursusinstanties/{id}/newstudent voegt nieuwe cursist toe ,die aangeleverd wordt met een Student object, aan de aangeleverde id 


Website 