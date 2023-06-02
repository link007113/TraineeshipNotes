Unit Testing is een niveau van softwaretesten waarbij afzonderlijke eenheden/components van een software worden getest. Het doel is om te valideren dat elke unit van de software correct werkt. In JavaScript zijn er meerdere tools en bibliotheken om unit testing te vergemakkelijken. Hier zijn enkele van de belangrijkste concepten:

**1. Test Frameworks (Test Runners)**: Dit zijn tools die het uitvoeren van je tests automatiseren. Ze zorgen voor het instellen van je testomgeving, en bieden functies om te controleren of de tests geslaagd of mislukt zijn. Voorbeelden zijn Mocha, Jest, en Jasmine.

**2. Assertion Library**: Dit zijn bibliotheken die een set van functies bieden om te controleren of bepaalde condities waar zijn. Ze worden gebruikt in combinatie met een testrunner om tests te schrijven. Voorbeelden zijn Chai, en de ingebouwde assertie bibliotheek in Jest en Jasmine.

**3. Mocking**: Dit is een techniek waarbij echte objecten worden vervangen door valse objecten (mocks) die je zelf controleert. Mocking wordt gebruikt om het gedrag van complexe objecten te simuleren en te controleren hoe functies interageren met deze objecten. Jest heeft ingebouwde mocking functionaliteiten.

**4. Code Coverage**: Dit is een metriek die meet in welke mate je broncode wordt getest door je tests. Tools zoals Istanbul kunnen worden gebruikt om code coverage rapporten te genereren.

Een eenvoudig voorbeeld van een unit test met Jest zou er zo uit kunnen zien:

```javascript
// De functie die je wilt testen
function sum(a, b) {
  return a + b;
}

// De test
test('sum adds numbers correctly', () => {
  expect(sum(1, 2)).toBe(3);
  expect(sum(-1, 2)).toBe(1);
});
```

In dit voorbeeld wordt de `test` functie geleverd door Jest om een nieuwe test te definiëren, en `expect` en `toBe` zijn Jest functies die worden gebruikt om de uitkomst van de test te controleren. 

Het uitvoeren van je tests kan zo eenvoudig zijn als het draaien van een commando in je terminal, zoals `npm test` als je Jest hebt geconfigureerd als je testrunner.