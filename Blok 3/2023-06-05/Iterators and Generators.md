Iterators en generators zijn geavanceerde concepten in JavaScript die worden gebruikt om aangepaste iteratiegedrag te creëren.

## Iterators

Een Iterator is een object dat een `next()` methode definieert om elementen één voor één te doorlopen. Elke oproep aan `next()` geeft een resultaatobject terug met twee eigenschappen: `value`, dat het huidige element vertegenwoordigt, en `done`, dat `true` is als er geen meer elementen zijn om door te lopen, en `false` anders.

Hier is een eenvoudig voorbeeld van een Iterator:

```javascript
const myArray = ['apple', 'banana', 'cherry'];
const arrayIterator = myArray[Symbol.iterator]();

let arrayElement;

while ((arrayElement = arrayIterator.next()) && !arrayElement.done) {
  console.log(arrayElement.value);  // prints 'apple', 'banana', 'cherry'
}
```

## Generators

Een Generator is een speciaal type functie in JavaScript dat kan worden gepauzeerd en hervat, en produceert een reeks waarden op aanvraag. Generators worden gedefinieerd met behulp van de functiesyntaxis `function*` en gebruiken het `yield` keyword om waarden te produceren.

Hier is een eenvoudig voorbeeld van een Generator:

```javascript
function* fruitGenerator() {
  yield 'apple';
  yield 'banana';
  yield 'cherry';
}

const gen = fruitGenerator();

console.log(gen.next().value);  // 'apple'
console.log(gen.next().value);  // 'banana'
console.log(gen.next().value);  // 'cherry'
```

## For...of loop

De `for...of` loop in JavaScript is een nieuw type loop dat specifiek is ontworpen om te werken met iterable objecten, zoals arrays en generatoren.

Hier is een voorbeeld dat een `for...of` loop gebruikt met zowel een array als een generator:

```javascript
const myArray = ['apple', 'banana', 'cherry'];

for (const fruit of myArray) {
  console.log(fruit);  // prints 'apple', 'banana', 'cherry'
}

function* fruitGenerator() {
  yield 'apple';
  yield 'banana';
  yield 'cherry';
}

for (const fruit of fruitGenerator()) {
  console.log(fruit);  // prints 'apple', 'banana', 'cherry'
}
```

Zoals je kunt zien, is `for...of` een krachtige en expressieve manier om door iterable objecten in JavaScript te lopen. Het werkt met ingebouwde iterables zoals arrays en strings, evenals met aangepaste iterables die je zelf kunt definiëren.