Functies in JavaScript zijn een beetje als recepten. Een recept kan je vertellen hoe je een taart moet bakken, welke ingrediënten je nodig hebt en welke stappen je moet volgen. Op dezelfde manier vertelt een JavaScript-functie aan de computer welke stappen hij moet uitvoeren om een bepaalde taak uit te voeren.

Je kunt een functie in JavaScript op deze manier definiëren:

```javascript
function maakTaart() {
  console.log("Mix de ingrediënten");
  console.log("Bak de taart");
  console.log("Serveer de taart");
}
```

In dit voorbeeld is `maakTaart` de naam van onze functie (of ons 'recept'). Deze functie heeft drie stappen die worden uitgevoerd wanneer we de functie 'oproepen' of 'gebruiken'.

Om de functie te 'roepen', schrijf je gewoon de naam van de functie gevolgd door haakjes:

```javascript
maakTaart(); // roept de functie op
```

Als je dit in je code uitvoert, zal de console de volgende uitvoer weergeven:

```
Mix de ingrediënten
Bak de taart
Serveer de taart
```

Functies kunnen ook 'parameters' hebben. Deze zijn vergelijkbaar met de ingrediënten in ons taartrecept. Bijvoorbeeld:

```javascript
function groet(naam) {
  console.log("Hallo, " + naam + "!");
}
```

In dit voorbeeld is `naam` de parameter van de `groet` functie. Je kunt deze parameter vullen door een waarde tussen de haakjes te plaatsen wanneer je de functie aanroept:

```javascript
groet("Jan"); // roept de functie op met "Jan" als parameter
```

Dit zal de volgende uitvoer geven:

```
Hallo, Jan!
```
