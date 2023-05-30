
 In JavaScript, zijn er twee soorten van data conversies: impliciet en expliciet.

## Impliciete conversie: 

Dit gebeurt wanneer JavaScript automatisch een datatype verandert naar een ander datatype zonder dat je er iets voor hoeft te doen. Bijvoorbeeld:

```javascript
let waarde = '5' + 2; 
console.log(waarde); // Output: '52'
```

In dit voorbeeld proberen we een string ('5') en een nummer (2) op te tellen. JavaScript verandert automatisch het nummer in een string en voegt ze samen, wat resulteert in de string '52'.

## Expliciete conversie:
- Dit is wanneer je JavaScript specifiek vertelt om een datatype te veranderen naar een ander datatype. Je kunt dit doen met behulp van verschillende methodes, zoals `Number()`, `String()`, en `Boolean()`. Bijvoorbeeld:
```javascript
let nummer = Number('5'); 
console.log(nummer); // Output: 5
```

In dit voorbeeld gebruiken we de `Number()` functie om de string '5' expliciet om te zetten naar het nummer 5.

Hier zijn nog enkele voorbeelden van expliciete conversies:
```javascript
let waarde = String(5);
console.log(waarde); // Output: '5'

waarde = Boolean(1);
console.log(waarde); // Output: true

waarde = Boolean(0);
console.log(waarde); // Output: false
```

In de bovenstaande voorbeelden, wordt de `String()` functie gebruikt om het nummer 5 om te zetten naar een string '5', en de `Boolean()` functie wordt gebruikt om de nummers 1 en 0 om te zetten naar respectievelijk `true` en `false`. 
