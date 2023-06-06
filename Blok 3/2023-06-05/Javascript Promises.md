Een `Promise` in JavaScript is een object dat de uiteindelijke voltooiing (of mislukking) van een asynchrone operatie vertegenwoordigt en de daaruit resulterende waarde. Promises werden geïntroduceerd in ES6 (ES2015) om het eenvoudiger te maken om asynchrone acties te beheren.

Een `Promise` is in een van de drie volgende staten:

1. **Pending:** de Promise is nog niet vervuld of afgewezen.
2. **Fulfilled:** de operatie is voltooid en de Promise heeft een resulterende waarde.
3. **Rejected:** de operatie is mislukt en de Promise heeft een reden voor de mislukking.

Eenmaal een Promise is vervuld of afgewezen, is deze onveranderlijk, wat betekent dat de staat niet opnieuw kan veranderen.

Hier is een eenvoudig voorbeeld van het maken en gebruiken van een Promise:

```javascript
let promise = new Promise(function(resolve, reject) {
  // simuleer een asynchrone operatie
  setTimeout(function() {
    // vervul de Promise na 1 seconde
    resolve('De gegevens zijn opgehaald');
  }, 1000);
});

promise.then(function(data) {
  // deze functie wordt aangeroepen wanneer de Promise is vervuld
  console.log(data);  // "De gegevens zijn opgehaald"
}).catch(function(error) {
  // deze functie wordt aangeroepen wanneer de Promise is afgewezen
  console.log(error);
});
```

In dit voorbeeld wordt `resolve` aangeroepen om aan te geven dat de Promise is vervuld, en de waarde die aan `resolve` wordt doorgegeven is de uiteindelijke waarde van de Promise. De `then` methode wordt gebruikt om een functie te specificeren die wordt aangeroepen wanneer de Promise is vervuld, terwijl de `catch` methode wordt gebruikt om een functie te specificeren die wordt aangeroepen wanneer de Promise is afgewezen.

Promises kunnen worden geketend, wat betekent dat je een reeks asynchrone operaties op een sequentiële manier kunt schrijven. Dit maakt de code vaak leesbaarder en makkelijker te onderhouden dan de traditionele callback-stijl.