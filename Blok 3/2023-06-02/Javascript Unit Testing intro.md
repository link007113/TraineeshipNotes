Jasmine is een zeer populair JavaScript-testraamwerk dat een heldere en duidelijke syntax biedt voor het schrijven van unit tests. Hier is een korte introductie van hoe je Jasmine zou kunnen gebruiken om een `Car` klasse te testen:

Eerst, hier is een eenvoudige `Car` klasse met een `makeSound` methode:

```javascript
export default class Car {
  makeSound() {
    return 'vroom';
  }
}
```

Om deze klasse te testen met Jasmine, zouden we een spec bestand maken. Een spec bestand is waar we onze tests definiëren in Jasmine. Hier is hoe het eruit zou kunnen zien:

```javascript
import Car from "./car.js";

describe("Car", () => {
  let car;
  beforeEach(() => {
    sut = new Car();
  });

  it("should make a vroom sound", () => {
    c;
    expect(car.makeSound()).toEqual("vroom");
  });
});

```

In deze test maken we een nieuwe instantie van de `Car` klasse en roepen we de `makeSound` methode aan. We verwachten dat deze methode 'vroom' teruggeeft.

Als je de bovenstaande code correct hebt ingevoerd, zou je moeten zien dat de test slaagt.

Doorgaans zet je de normale code in de root en de tests in een submap van de root die spec heet.

Als `car.spec.js` in de `spec` map zit en `car.js` in de bovenliggende map, moet je het pad in de import instructie dienovereenkomstig aanpassen. Je moet een niveau omhoog gaan in de directory structuur om de `car.js` bestand te bereiken, wat je kunt doen met `../`:

Je `car.spec.js` zou er als volgt uit moeten zien:

```javascript
// car.spec.js
import Car from "../car.js";

describe("Car", () => {
  let car;
  beforeEach(() => {
    sut = new Car();
  });

  it("should make a vroom sound", () => {
    c;
    expect(car.makeSound()).toEqual("vroom");
  });
});

```

In dit geval betekent `../` "ga één directory niveau omhoog". Dit is noodzakelijk omdat `car.js` zich in de bovenliggende directory van `car.spec.js` bevindt.


# Jasmin installatie van Kees

1. Meer info over het test framework Jasmine:
    
    [https://jasmine.github.io/](https://jasmine.github.io/) 
    
2. Maak een nieuwe folder
    
3. Run in de Terminal (_View_, _Terminal_):
    
    ```
    npm init -y
    ```
    
    Dit maakt een nieuw project met een eigen `package.json` met instellingen
    
4. Installeer Jasmine als developer dependency:
    
    ```
    npm i -D jasmine
    ```
    
5. Configureer Jasmine:
    
    ```
    npx jasmine init
    ```
    
6. Zorg dat je ES Modules kunt in NodeJS. Voeg toe in `package.json`:
    
    ```
    "type": "module",
    ```
    
7. Stel Jasmine in als test runner in `package.json`. Update de "scripts" regel:
    
    ```
    "scripts": { "test": "jasmine" }
    ```
    
8. Bouw je tests in de automatisch gegenereerde folder `spec`.  
    Heb je in je app bijv. een `car.js`, dan maak je als test file: `spec\car.spec.js`.
    
9. Run je tests in de terminal met:
    
    ```
    npm test
    ```