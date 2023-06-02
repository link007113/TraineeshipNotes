In JavaScript is een functie een herbruikbaar stuk code dat een actie uitvoert of een waarde berekent. Functies kunnen argumenten accepteren, wat waarden zijn die je aan de functie kunt geven om het gedrag ervan aan te passen. Een functie kan ook een waarde teruggeven aan de code die het heeft opgeroepen.
Er zijn drie primaire manieren om functies te definiëren in JavaScript: functiedeclaraties, functie-uitdrukkingen 
en pijlfuncties.

## Functiedeclaraties (Function Declarations): 
Dit is de traditionele methode om functies in JavaScript te definiëren. Functiedeclaraties worden gehoist naar de top van de huidige scope, wat betekent dat je de functie kunt aanroepen voordat hij in je code is gedefinieerd.

   Voorbeeld:
   ```javascript
   function greet(name) {
     return `Hello, ${name}!`;
   }
   console.log(greet('John')); // Outputs: Hello, John!
   ```
   
## Functie-uitdrukkingen (Function Expressions): 
Dit zijn functies die worden gedefinieerd als onderdeel van een uitdrukking, meestal toegewezen aan een variabele. Functie-uitdrukkingen worden niet gehoist, wat betekent dat je een functie-uitdrukking niet kunt aanroepen voordat deze is gedefinieerd in je code.

   Voorbeeld:
   ```javascript
   const greet = function(name) {
     return `Hello, ${name}!`;
   };
   console.log(greet('John')); // Outputs: Hello, John!
   ```
   
## Pijlfuncties (Arrow Functions):
Dit is een kortere syntaxis voor functie-uitdrukkingen die is geïntroduceerd in ES6. Pijlfuncties hebben ook een andere context voor `this`. Net als functie-uitdrukkingen, worden pijlfuncties niet gehoist.

   Voorbeeld:
   ```javascript
   const greet = (name) => `Hello, ${name}!`;
   console.log(greet('John')); // Outputs: Hello, John!
   ```

Let op: hoewel pijlfuncties syntactisch handiger kunnen zijn, hebben ze een aantal beperkingen. Ze kunnen bijvoorbeeld niet worden gebruikt als constructorfuncties en ze hebben geen `arguments` object.