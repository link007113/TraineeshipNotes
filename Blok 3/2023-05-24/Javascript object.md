JavaScript-objecten zijn een belangrijk onderdeel van de programmeertaal en bieden een manier om gegevens te organiseren en functionaliteit te structureren.

## JavaScript Collection:

   JavaScript-objecten fungeren als een verzameling van sleutel-waarde-paren. Je kunt een object maken door middel van objectliteralen ({}) of door het gebruik van een constructorfunctie of de classsyntaxis. Een object kan eigenschappen bevatten die worden gedefinieerd met sleutels en waarden, waarbij de sleutels uniek zijn binnen het object. Hier is een voorbeeld van een object met eigenschappen:

   ```javascript
   const person = {
     name: 'John',
     age: 30,
     city: 'New York'
   };

   console.log(person.name); // Output: John
   console.log(person.age); // Output: 30
   console.log(person.city); // Output: New York
   ```

   In dit voorbeeld wordt een object `person` gemaakt met de eigenschappen `name`, `age` en `city`, die kunnen worden benaderd met behulp van de punt-notatie.

## JavaScript Functions:

   JavaScript-objecten kunnen ook functies bevatten, die methoden worden genoemd. Een methode is een functie die is gedefinieerd als een eigenschap van een object. Hier is een voorbeeld van het toevoegen van een methode aan een object:

   ```javascript
   const person = {
     name: 'John',
     age: 30,
     city: 'New York',
     sayHello: function() {
       console.log(`Hello, my name is ${this.name}`);
     }
   };

   person.sayHello(); // Output: Hello, my name is John
   ```

   In dit voorbeeld wordt de methode `sayHello` toegevoegd aan het object `person`, die een begroeting met de naam van de persoon logt.

## JavaScript Classes:

   JavaScript ondersteunt ook het gebruik van klassen om objecten te maken met behulp van de classsyntaxis. Een klasse definieert een blauwdruk voor het maken van objecten met gemeenschappelijke eigenschappen en methoden. Hier is een voorbeeld van het maken van een klasse en het instantiëren van een object:

   ```javascript
   class Person {
     constructor(name, age, city) {
       this.name = name;
       this.age = age;
       this.city = city;
     }

     sayHello() {
       console.log(`Hello, my name is ${this.name}`);
     }
   }

   const person = new Person('John', 30, 'New York');
   person.sayHello(); // Output: Hello, my name is John
   ```

   In dit voorbeeld wordt de klasse `Person` gedefinieerd met een constructor voor het instellen van de eigenschappen en een methode `sayHello`. Een object `person` wordt gemaakt met behulp van de `new`-operator en de klasse wordt geïnstantieerd.

## JavaScript Operations:

   JavaScript-objecten bieden verschillende operaties om eigenschappen te benaderen, te wijzigen en te verwijderen. Enkele veelgebruikte operatoren zijn:
   - Eigenschapstoegang: Gebruik de punt-notatie (bijv. `object.property`) of de vierkante-haak-notatie (bijv. `object['property']`) om een eigenschap te benaderen.
   - Eigenschapstoewijzing: Gebruik de toekenningsoperator (`=`) om een waarde aan een eigenschap toe te wijzen.
   - Eigenschap verwijderen: Gebruik het `delete`-keyword om een eigenschap uit een object te verwijderen.

   Hier is een voorbeeld van het uitvoeren van deze operaties:

   ```javascript
   const person = {
     name: 'John',
     age: 30,
     city: 'New York'
   };

   console.log(person.name); // Eigenschapstoegang: Output: John

   person.age = 35; // Eigenschapstoewijzing
   console.log(person.age); // Output: 35

   delete person.city; // Eigenschap verwijderen
   console.log(person.city); // Output: undefined
   ```

   In dit voorbeeld worden verschillende operaties uitgevoerd op het object `person`, zoals het benaderen van een eigenschap, het toewijzen van een nieuwe waarde en het verwijderen van een eigenschap.