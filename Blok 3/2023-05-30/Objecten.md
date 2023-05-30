Objecten in JavaScript zijn net als echte leven objecten. Ze hebben eigenschappen en ze kunnen dingen doen.

Stel je voor dat je een auto hebt. Deze auto heeft verschillende eigenschappen zoals merk, model, kleur, en bouwjaar. De auto kan ook dingen doen, zoals rijden, stoppen, en claxonneren. 

In JavaScript kun je een object maken dat deze eigenschappen en functies vertegenwoordigt. Hier is een voorbeeld:

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
  toString: function () {
    return `De auto is een ${this.merk} ${this.model} uit ${this.bouwjaar} en heeft de kleur ${this.kleur}.`;
  },
  valueOf: function () {
    return 2023 - this.bouwjaar;
  },
};

console.log(auto);
console.log(auto.toString());
console.log(auto.valueOf());


auto.rijden();
auto.stoppen();
auto.toeter();



const passpoort = {
    id: 1,
    bsn: 123456789,
    afgifteplaats: 'Apeldoorn',
    toString: function () {
        return `BSN: ${this.bsn}, Afgifteplaats: ${this.afgifteplaats}`;
    },
    valueOf: function () {
        return this.bsn;
    }
};
const mijnafgifteplaats = passpoort?.afgifteplaats ?? "onbekend";

```

In dit voorbeeld is `auto` een object. De eigenschappen van `auto` zijn `merk`, `model`, `kleur`, en `bouwjaar`, en de functies zijn `rijden`, `stoppen`, en `claxonneren`. 

Je kunt toegang krijgen tot de eigenschappen van een object met de punt-notatie, zoals `auto.merk`, en je kunt de functies van een object oproepen met de punt-notatie gevolgd door haakjes, zoals `auto.rijden()`.


## Method Chaining in JavaScript

Method chaining is een veelgebruikte techniek in JavaScript, waarmee meerdere methoden in één regel kunnen worden aangeroepen. Het belangrijkste is dat elke methode een object moet retourneren, zodat de volgende methode daaraan kan worden gekoppeld.

Hier is een eenvoudig voorbeeld:

```javascript
let naam = '    Hallo Wereld    ';

// Verwijder witruimte aan beide uiteinden en maak het geheel in hoofdletters
let resultaat = naam.trim().toUpperCase();
console.log(resultaat); // Output: "HALLO WERELD"
```
In dit voorbeeld hebben we de `trim()` methode gebruikt om de witruimte aan beide uiteinden te verwijderen en daarna de `toUpperCase()` methode om alles in hoofdletters te zetten. Omdat elke methode een string retourneert, kunnen we ze aan elkaar koppelen in één regel.



