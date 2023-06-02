Een closure in JavaScript is een functie die een toegang heeft tot de parent scope, zelfs nadat de parent functie is afgesloten.

Het is het mechanisme waardoor een functie toegang heeft tot zijn "omsluitende context" of "omsluitende scope" dat de scope van de bovenliggende functie omvat, zelfs na uitvoering ervan. 

Hier is een eenvoudig voorbeeld:

```javascript
function ouderFunctie() {
    let variabele = 'Ik ben van ouderFunctie';
    
    function kindFunctie() {
        console.log(variabele);
    }
    
    return kindFunctie;
}

let nieuweFunctie = ouderFunctie();
nieuweFunctie(); // logs: 'Ik ben van ouderFunctie'
```

In het bovenstaande voorbeeld is `kindFunctie` een closure die wordt gedefinieerd in de scope van `ouderFunctie` en die toegang heeft tot de variabele `variabele` van `ouderFunctie`. Wanneer we `ouderFunctie` aanroepen, retourneert het de `kindFunctie`. We wijzen dit resultaat toe aan `nieuweFunctie`. Hoewel `ouderFunctie` op dit moment is voltooid, kan `nieuweFunctie()` nog steeds toegang krijgen tot de variabele `variabele` in de ouder scope. Dit is een kenmerk van een closure.

Closures zijn een fundamenteel en krachtig aspect van JavaScript, en ze worden gebruikt in veelvoorkomende JavaScript-patronen, zoals module-patronen, functie-fabrieken en objectgegevensprivacy.
