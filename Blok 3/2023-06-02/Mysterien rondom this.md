De `this` keyword in JavaScript kan inderdaad wat raar zijn, vooral voor beginners zoals mijzelf. Maar als je eenmaal begrijpt hoe het werkt, wordt het een krachtig en nuttig onderdeel van de taal, schijnbaar.

1. **Globale context**: Wanneer `this` buiten een functie wordt gebruikt, verwijst het naar het globale object (`window` in een browser, `global` in Node.js).

```javascript
console.log(this === window); // true in een browser script
```

2. **Function Context**: In een gewone functie (niet een pijl functie of een method in een object) verwijst `this` standaard naar het globale object. Maar als je de functie aanroept met de `new` keyword om een nieuw object te creëren, zal `this` verwijzen naar het nieuw gecreëerde object.

```javascript
function MyFunction() {
  console.log(this === window); // true
}

function MyConstructor() {
  this.value = 'hello';
  console.log(this === window); // false
}

new MyConstructor();
```

3. **Object Method Context**: Wanneer `this` wordt gebruikt binnen een object methode, verwijst het naar het object waar de methode op wordt aangeroepen.

```javascript
const myObject = {
  value: 'Hello, World!',
  print: function() {
    console.log(this.value);
  }
}

myObject.print(); // logs 'Hello, World!'
```

4. **Event Handler Context**: In een event handler, zoals een click event op een DOM element, verwijst `this` naar het element waarop het event plaatsvond.

```javascript
// In de browser
button.addEventListener('click', function() {
  console.log(this === button); // true
});
```

5. **Manueel Context Setten**: Met methoden zoals `call`, `apply` en `bind` kun je de waarde van `this` binnen een functie expliciet instellen.

```javascript
function greet() {
  console.log(this.name);
}

let person = { name: 'John' };
greet.call(person); // logs 'John'
```

Echter, pijlfuncties in ES6 gedragen zich anders - ze hebben geen eigen `this` waarde. In plaats daarvan erven ze `this` van de omliggende (lexicale) context. Dit kan handig zijn, vooral bij het omgaan met callbacks en event handlers.

Het belangrijkste om te onthouden is dat `this` niet gebonden is bij het schrijven van de functie. Het krijgt zijn waarde pas als de functie wordt uitgevoerd en hangt af van hoe en waar de functie wordt aangeroepen.