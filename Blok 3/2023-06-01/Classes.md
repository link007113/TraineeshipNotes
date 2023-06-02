Classes in JavaScript zijn een manier om objecten te creëren die specifieke eigenschappen en methoden delen. Voordat classes in JavaScript werden geïntroduceerd, werd dit meestal gedaan met functies en het prototype van een object. Een prototype in JavaScript is een interne eigenschap van een object, dat verwijst naar een ander object waaruit het eigenschappen en methoden kan erven.

Een JavaScript class wordt gedefinieerd met het keyword `class`, gevolgd door de naam van de class. De class is in wezen een functie, en het gedraagt zich als een functie in JavaScript.

In een class kunnen we de `constructor` methode definiëren, die wordt aangeroepen wanneer een nieuw object wordt gemaakt met deze class. De constructor methode kan parameters accepteren die kunnen worden gebruikt om de eigenschappen van het object te initialiseren.

```javascript
class Persoon {
  constructor(naam, stad) {
    this.naam = naam;
    this.stad = stad;
  }
}
```

In een class kunnen we ook andere methoden definiëren die beschikbaar zijn voor objecten van deze class.

```javascript
class Persoon {
  constructor(naam, stad) {
    this.naam = naam;
    this.stad = stad;
  }
  groet() {
    console.log(`Hallo, ik ben ${this.naam} uit ${this.stad}.`);
  }
}
```

**Inheritance** (overerving) is een concept waarbij we een nieuwe class kunnen definiëren die de eigenschappen en methoden van een bestaande class erft. Dit wordt gedaan met het `extends` keyword.

```javascript
class Werknemer extends Persoon {
  constructor(naam, stad, positie) {
    super(naam, stad);
    this.positie = positie;
  }
  groet() {
    super.groet();
    console.log(`Ik werk als een ${this.positie}.`);
  }
}
```

De `super` keyword roept de constructor van de parent class (in dit geval Persoon) aan.

JavaScript ondersteunt geen **abstracte klassen** direct, maar we kunnen het simuleren door een fout te gooien in de constructor van de class als deze direct wordt aangeroepen.

```javascript
class Persoon {
  constructor(naam, stad) {
    if (new.target === Persoon) {
      throw new Error("Kan geen instantie van Abstract Class maken");
    }
    this.naam = naam;
    this.stad = stad;
  }
}
```

Vanaf ES2022 kunnen we ook **member variables** direct in de class declareren buiten de constructor.

```javascript
class Persoon {
  naam = "Joep";
  stad = "";
}
```

En tot slot, met de introductie van ES2020, kunnen we nu **private properties** in classes maken door het voorvoegsel `#` te gebruiken. Deze eigenschappen zijn alleen toegankelijk binnen de class.

```javascript
class Persoon {
  #geheimeId;
  constructor(id) {
    this.#geheimeId = id;
  }
}
```
In dit geval is `#geheimeId` een private property van de `Persoon` class en kan het niet buiten de class worden geopend.