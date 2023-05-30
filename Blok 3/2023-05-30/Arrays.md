Een array in JavaScript is als een speciale doos waarin je meerdere items kunt stoppen. Deze items kunnen van alles zijn - getallen, strings (tekst), andere arrays, objecten, enzovoort. Het mooie van een array is dat je één naam kunt geven aan de hele doos en de items die je erin stopt toch individueel kunt bereiken.

Hier is een voorbeeld van hoe een array eruit ziet in JavaScript:
```javascript
const mijnDieren = ["hond", "kat", "vogel"];
```
In dit voorbeeld is `mijnDieren` de naam van de array, en "hond", "kat" en "vogel" zijn de items in de array.

Om bij een specifiek item in de array te komen, gebruik je het nummer van dat item in de array. Dit nummer heet de 'index'. Het eerste item in de array heeft index 0, het tweede item heeft index 1, enzovoort. 

Dus als je bijvoorbeeld het woord "kat" uit de array `mijnDieren` wilt halen, doe je dat zo:
```javascript
const mijnKat = mijnDieren[1];
```
Na deze code is de waarde van `mijnKat` "kat".

Een array kan ook veranderd worden. Je kan een item toevoegen, verwijderen of veranderen. Hier is een voorbeeld hoe je een item toevoegt aan de array:
```javascript
mijnDieren.push("hamster");
```
Nu is de array `mijnDieren` ["hond", "kat", "vogel", "hamster"].

Arrays zijn type loos, dus je kan verschillende types in een array stoppen. In typescript kan dit weer niet, dus lijkt me ook niet handig om daadwerkelijk te doen. 


## Methods
Hieronder staan de top 10 meest gebruikte methods en een korte uitleg erbij:

1. **push()**: Voegt nieuwe elementen toe aan het einde van een array en retourneert de nieuwe lengte van de array.
```javascript
const arr = [1, 2, 3];
arr.push(4);
console.log(arr); // Output: [1, 2, 3, 4]
```

2. **pop()**: Verwijdert het laatste element van een array en retourneert dat element.
```javascript
const arr = [1, 2, 3, 4];
const last = arr.pop();
console.log(last); // Output: 4
console.log(arr); // Output: [1, 2, 3]
```

3. **shift()**: Verwijdert het eerste element van een array en retourneert dat element.
```javascript
const arr = [1, 2, 3, 4];
const first = arr.shift();
console.log(first); // Output: 1
console.log(arr); // Output: [2, 3, 4]
```

4. **unshift()**: Voegt nieuwe elementen toe aan het begin van een array en retourneert de nieuwe lengte van de array.
```javascript
const arr = [1, 2, 3, 4];
arr.unshift(0);
console.log(arr); // Output: [0, 1, 2, 3, 4]
```

5. **slice()**: Retourneert een nieuw array-object met een kopie van een deel van een array. De originele array wordt niet gewijzigd.
```javascript
const arr = [1, 2, 3, 4, 5];
const sliced = arr.slice(1, 4);
console.log(sliced); // Output: [2, 3, 4]
```

6. **splice()**: Verandert de inhoud van een array door bestaande elementen te verwijderen en/of nieuwe elementen toe te voegen.
```javascript
const arr = [1, 2, 4, 5];
arr.splice(2, 0, 3); // Voeg 3 toe op index 2
console.log(arr); // Output: [1, 2, 3, 4, 5]
```

7. **forEach()**: Voert een opgegeven functie uit voor elk element in een array.
```javascript
const array = ["aap", "noot", "mies"];
array.forEach((element) => console.log(element));
```

8. **map()**: Creëert een nieuwe array met de resultaten van een functie die wordt uitgevoerd voor elk array-element.
```javascript
const arr = [1, 2, 3, 4, 5];
const squared = arr.map(function(item){
    return item*item;
});
console.log(squared); // Output: [1, 4, 9, 16, 25]
```

9. **filter()**: Creëert een nieuwe array met alle elementen die de test van een opgegeven functie doorstaan.
```javascript
const arr = [1, 2, 3, 4, 5];
const evens = arr.filter(function(item){
    return item%2 === 0;
});
console.log(evens); //

 Output: [2, 4]
```

10. **reduce()**: Past een functie toe op elk element in de array (van links naar rechts) om het te reduceren tot één enkele waarde.
```javascript
const arr = [1, 2, 3, 4, 5];
const sum = arr.reduce(function(total, item){
    return total + item;
}, 0);
console.log(sum); // Output: 15
```
