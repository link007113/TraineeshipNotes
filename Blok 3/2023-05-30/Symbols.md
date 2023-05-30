Symbols zijn een nieuwe gegevenssoort in JavaScript die unieke waarden vertegenwoordigen. Ze worden gecreëerd door de `Symbol()` functie aan te roepen. Een belangrijk kenmerk van symbols is dat ze uniek zijn, wat betekent dat geen twee symbols ooit gelijk kunnen zijn, zelfs niet als ze op dezelfde manier worden gemaakt.

In JavaScript hebben bepaalde objectmethoden symbolen als hun namen. Twee van deze methoden zijn `toString` en `valueOf`, die worden aangeroepen wanneer het object moet worden omgezet in een string of een primitieve waarde.

Hier is een voorbeeld van hoe je `toString` en `valueOf` zou kunnen vervangen door gebruik te maken van symbols in uit mijn objecten voorbeeld:

```javascript
const auto = {
  merk: "Toyota",
  model: "Corolla",
  kleur: "rood",
  bouwjaar: 2020,
  rijden: function () {
    console.log("De auto rijdt.");
  },
  stoppen: function () {
    console.log("De auto stopt.");
  },
  toeter: function () {
    console.log("De auto toetert.");
  },
  [Symbol.toStringTag]: function () {
    return `De auto is een ${this.merk} ${this.model} uit ${this.bouwjaar} en heeft de kleur ${this.kleur}.`;
  },
  [Symbol.toPrimitive]: function (hint) {
    if (hint == "number") {
      return 2023 - this.bouwjaar;
    }
    else {
      return null;
    }
  },
};

console.log(auto);
console.log(auto.toString());
console.log(auto.valueOf());

auto.rijden();
auto.stoppen();
auto.toeter();
```

In dit voorbeeld gebruik ik het `Symbol.toStringTag` en `Symbol.toPrimitive` symbolen als de namen van de methoden in plaats van `toString` en `valueOf`. Het `Symbol.toStringTag` wordt gebruikt wanneer het object wordt omgezet naar een string en `Symbol.toPrimitive` wordt gebruikt wanneer het object wordt omgezet naar een primitieve waarde. 

Let op: de `Symbol.toPrimitive` functie neemt een 'hint' argument dat aangeeft welk soort primitieve waarde er verwacht wordt.