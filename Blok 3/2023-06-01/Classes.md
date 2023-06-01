Class is een nieuw iets. Eerder was het een function die gebruikt werd als een soort class.
Als je functions wou gebruiken in je class function, maar niet meerdere instanties van die function moest je hem toevoegen aan het prototype

Tegenwoordig kan je een class maken

```javascript
class Person {
  constructor(name, city) {
    this.name = name;
    this.city = city;
  }
  toon() {
    console.log(`${this.name} ${this.city}`);
  }
  static create(name, city) {
    return new Person(name, city);
  }
}

const p1 = Person.create("Anthony", "Apoldro");
p1.toon();

```