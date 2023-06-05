ES Modules, of ES6 Modules, zijn een functie geïntroduceerd in ECMAScript 6 (ES6) die een officiële, gestandaardiseerde module syntax in JavaScript bieden. Voor ES6, was JavaScript's gebrek aan ingebouwde module support vaak een kritiekpunt, en ontwikkelaars moesten vertrouwen op "hacky" oplossingen zoals onmiddellijk opgeroepen functie-uitdrukkingen (IIFEs), of bibliotheekoplossingen zoals CommonJS (CJS) en Asynchronous Module Definition (AMD).

Met ES6 modules, kun je functies, objecten, of waarden exporteren van een module, zodat ze kunnen worden geïmporteerd door andere modules. Hier is een eenvoudig voorbeeld:

```javascript
// myModule.js
export const greet = name => `Hello, ${name}!`;
export const goodbye = name => `Goodbye, ${name}!`;
```

In een ander bestand, zou je de `greet` en `goodbye` functies importeren op de volgende manier:

```javascript
// app.js
import { greet, goodbye } from './myModule.js';

console.log(greet('John'));   // Prints: Hello, John!
console.log(goodbye('John')); // Prints: Goodbye, John!
```

Er zijn een paar belangrijke dingen om te weten over ES6 modules:

1. **Statische structuur**: Import en export verklaringen zijn statisch, wat betekent dat ze niet kunnen worden uitgevoerd in een blok (zoals een functie of een if-statement). Dit staat in contrast met CommonJS, waar `require` dynamisch kan worden opgeroepen.

2. **Top-level scope**: Elk module heeft zijn eigen top-level scope. Met andere woorden, variabelen die in een module worden gedefinieerd, zijn niet zichtbaar voor andere modules, tenzij ze expliciet worden geëxporteerd.

3. **Bestandsbasis**: In de browser, wordt elk JavaScript bestand beschouwd als een aparte module. In Node.js, moet je `.mjs` extensie gebruiken of het `type` veld in je `package.json` op `module` zetten om ES6 modules te kunnen gebruiken.

4. **Named en default exports**: Je kunt "named" exports hebben (waarbij je een specifieke naam aan elke export geeft, zoals in het bovenstaande voorbeeld), en/of een "default" export (wat het primaire ding is dat door de module wordt uitgevoerd).



