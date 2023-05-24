
In JavaScript kan je gebruik maken van objects.  Een object is een verzameling van eigenschappen (ook wel bekend als sleutel-waardeparen) die betrekking hebben op een bepaalde entiteit. Elk object kan methoden en eigenschappen bevatten, waarmee je functionaliteit kunt definiëren en gegevens kunt opslaan.

## JavaScript Arrays

JavaScript-arrays zijn objecten die een geordende verzameling van waarden bevatten. Ze kunnen worden gebruikt om meerdere waarden in één enkele variabele op te slaan. Hier is een voorbeeld van het maken en gebruiken van een array:

```javascript
// Array-initialisatie
const fruits = ['apple', 'banana', 'orange'];

// Toegang tot array-elementen
console.log(fruits[0]); // Output: 'apple'

// Array-lengte
console.log(fruits.length); // Output: 3

// Itereren over een array
fruits.forEach((fruit) => {
  console.log(fruit);
});
```

In dit voorbeeld wordt een array `fruits` gemaakt en worden enkele basisbewerkingen uitgevoerd, zoals het toegang krijgen tot een element via de index en het itereren over de array met behulp van de `forEach`-methode.

## JavaScript Functions

JavaScript-functies stellen je in staat om een blok code te definiëren dat kan worden opgeroepen en hergebruikt. Functies kunnen parameters accepteren en waarden retourneren. Hier is een voorbeeld van het definiëren en aanroepen van een functie:

```javascript
// Functiedefinitie
function greet(name) {
  return `Hello, ${name}!`;
}

// Functieaanroep
const greeting = greet('John');
console.log(greeting); // Output: 'Hello, John!'
```

In dit voorbeeld wordt een functie `greet` gedefinieerd die een naamparameter accepteert en een begroetingsbericht retourneert. De functie wordt vervolgens opgeroepen met een argument 'John', en het resultaat wordt in de variabele `greeting` opgeslagen en afgedrukt.

## JavaScript Classes

JavaScript biedt ondersteuning voor klassen en objectgeoriënteerd programmeren. Een klasse is een blauwdruk voor het maken van objecten met gemeenschappelijke eigenschappen en methoden. Hier is een voorbeeld van een eenvoudige klasse in JavaScript:

```javascript
// Klasse-definitie
class Rectangle {
  constructor(width, height) {
    this.width = width;
    this.height = height;
  }

  getArea() {
    return this.width * this.height;
  }
}

// Objectinstantiatie
const rectangle = new Rectangle(10, 5);

// Methodeaanroep
console.log(rectangle.getArea()); // Output: 50
```

In dit voorbeeld wordt een klasse `Rectangle` gedefinieerd met een constructor en een methode `getArea()`. Een object `rectangle` wordt geïnstantieerd op basis van deze klasse, en vervolgens wordt de `getArea()`-methode aangeroepen om het oppervlakte van het rechthoekige object te berekenen en af te drukken.

## JavaScript Operators

JavaScript bevat verschillende soorten operators waarmee je verschillende bewerkingen kunt uitvoeren op waarden. Hier zijn enkele veelvoorkomende operators in JavaScript:

- **Arithmetic operators**: worden gebruikt voor wiskundige berekeningen, zoals optellen (`+`), aftrekken (`-`), vermenigvuldigen (`*`), delen (`/`), modulo (`%`), enz.
- **Assignment operators**: worden gebruikt om waarden aan variabelen toe te wijzen, zoals toekenning (`=`), toevoeging (`+=`), aftrekking (`-=`), enz.
- **Comparison operators**: worden gebruikt om waarden te vergelijken, zoals gelijkheid (`==`, `===`), ongelijkheid (`!=`, `!==`), groter dan (`>`), kleiner dan (`<`), enz.
- **Logical operators**: worden gebruikt voor logische bewerkingen, zoals logische AND (`&&`), logische OR (`||`), logische NOT (`!`), enz.
- **Unary operators**: worden gebruikt voor een enkele operand, zoals increment (`++`), decrement (`--`), negation (`-`), enz.

Hier is een voorbeeld van het gebruik van verschillende operators:

```javascript
let a = 5;
let b = 10;

// Arithmetic operators
console.log(a + b); // Output: 15
console.log(a * b); // Output: 50

// Assignment operators
a += 3;
console.log(a); // Output: 8

// Comparison operators
console.log(a > b); // Output: false

// Logical operators
console.log(a > 0 && b > 0); // Output: true

// Unary operators
console.log(++a); // Output: 9
```
