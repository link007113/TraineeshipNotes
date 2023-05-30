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

```

In dit voorbeeld is `auto` een object. De eigenschappen van `auto` zijn `merk`, `model`, `kleur`, en `bouwjaar`, en de functies zijn `rijden`, `stoppen`, en `claxonneren`. 

Je kunt toegang krijgen tot de eigenschappen van een object met de punt-notatie, zoals `auto.merk`, en je kunt de functies van een object oproepen met de punt-notatie gevolgd door haakjes, zoals `auto.rijden()`.
