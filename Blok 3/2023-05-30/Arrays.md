Een array in JavaScript is als een speciale doos waarin je meerdere items kunt stoppen. Deze items kunnen van alles zijn - getallen, strings (tekst), andere arrays, objecten, enzovoort. Het mooie van een array is dat je één naam kunt geven aan de hele doos en de items die je erin stopt toch individueel kunt bereiken.

Hier is een voorbeeld van hoe een array eruit ziet in JavaScript:
```javascript
let mijnDieren = ["hond", "kat", "vogel"];
```
In dit voorbeeld is `mijnDieren` de naam van de array, en "hond", "kat" en "vogel" zijn de items in de array.

Om bij een specifiek item in de array te komen, gebruik je het nummer van dat item in de array. Dit nummer heet de 'index'. Het eerste item in de array heeft index 0, het tweede item heeft index 1, enzovoort. 

Dus als je bijvoorbeeld het woord "kat" uit de array `mijnDieren` wilt halen, doe je dat zo:
```javascript
let mijnKat = mijnDieren[1];
```
Na deze code is de waarde van `mijnKat` "kat".

Een array kan ook veranderd worden. Je kan een item toevoegen, verwijderen of veranderen. Hier is een voorbeeld hoe je een item toevoegt aan de array:
```javascript
mijnDieren.push("hamster");
```
Nu is de array `mijnDieren` ["hond", "kat", "vogel", "hamster"].
