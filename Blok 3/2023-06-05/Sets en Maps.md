Zowel Sets als Maps zijn ingebouwde collectietypen in JavaScript die werden geïntroduceerd met ES6 (ES2015).

### Sets

Een `Set` in JavaScript is een verzameling unieke waarden; elk element kan maar één keer in een set voorkomen. Je kunt waarden aan een set toevoegen met de `add` methode, en je kunt controleren of een waarde in een set voorkomt met de `has` methode.

Voorbeeld:

```javascript
let mySet = new Set();

mySet.add(1); // voegt het getal 1 toe aan de set
mySet.add(2); // voegt het getal 2 toe aan de set
mySet.add(1); // probeert 1 toe te voegen aan de set, maar doet niets omdat 1 al in de set zit

console.log(mySet.has(1)); // geeft "true" omdat 1 in de set zit
console.log(mySet.has(3)); // geeft "false" omdat 3 niet in de set zit
```

### Maps

Een `Map` in JavaScript is een verzameling van sleutel-waarde paren. In tegenstelling tot gewone objecten, die alleen strings en symbolen als sleutels toestaan, laat een Map je elk type van waarde (objecten en primitieve waarden) als sleutel of waarde gebruiken.

Voorbeeld:

```javascript
let myMap = new Map();

myMap.set('name', 'John'); // voegt een sleutel "name" met de waarde "John" toe aan de map
myMap.set('age', 30); // voegt een sleutel "age" met de waarde 30 toe aan de map

console.log(myMap.get('name')); // geeft "John"
console.log(myMap.get('age')); // geeft 30
```

Zowel Sets als Maps hebben nuttige methoden en eigenschappen, zoals `size` voor het krijgen van het aantal elementen, en `delete` voor het verwijderen van een element. Beide ondersteunen ook het `forEach`-patroon voor het doorlopen van de elementen in de collectie.