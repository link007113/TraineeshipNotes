### Hoisting:

Hoisting is een gedrag van JavaScript waarbij variabelen en functiedeclaraties naar boven worden verplaatst, of "gehoist", naar de bovenkant van hun omringende scope tijdens de compilatiefase.

- **Function Declaration**: In JavaScript wordt een function declaration volledig gehoist. Dit betekent dat je een functie kunt aanroepen voordat je deze hebt gedefinieerd:

    ```javascript
    hoistedFunction();  // "Ik ben gehoist!"

    function hoistedFunction() {
      console.log("Ik ben gehoist!");
    }
    ```

- **Function Expression**: Een function expression, aan de andere kant, wordt niet gehoist. Als je probeert een function expression aan te roepen voordat het is gedefinieerd, krijg je een `TypeError`.

    ```javascript
    notHoistedFunction();  // TypeError: notHoistedFunction is not a function

    var notHoistedFunction = function() {
      console.log("Ik ben niet gehoist!");
    }
    ```

### Rest Parameter:

Een rest parameter is een manier om een willekeurig aantal argumenten als een array te accepteren in een functie. Het wordt weergegeven als drie punten (`...`) voor de naam van de parameter in de functiedefinitie.

```javascript
function som(...getallen) {
  let totaal = 0;
  for (let getal of getallen) {
    totaal += getal;
  }
  return totaal;
}

console.log(som(1, 2, 3, 4));  // 10
```

### Function Parameter Checks:

Het is een goede praktijk om te controleren of de juiste argumenten zijn doorgegeven aan een functie voordat deze wordt uitgevoerd. Dit kan helpen om fouten en onverwacht gedrag te voorkomen.

```javascript
function verdeel(a, b) {
  if (typeof a !== 'number' || typeof b !== 'number') {
    throw new Error('Beide argumenten moeten getallen zijn');
  }
  if (b === 0) {
    throw new Error('Je kunt niet delen door nul');
  }
  return a / b;
}

console.log(verdeel(10, 2));  // 5
console.log(verdeel(10, 0));  // Error: Je kunt niet delen door nul
console.log(verdeel('tien', 2));  // Error: Beide argumenten moeten getallen zijn
```

In dit voorbeeld, als een van de argumenten geen getal is, of als het tweede argument 0 is, gooit de functie een fout voordat de deling wordt geprobeerd.