Jasmine is een populair gedragsgestuurd framework voor het testen van JavaScript-code. Het heeft geen afhankelijkheden van andere JavaScript-frameworks en kan in combinatie met elke server- of clientside-technologie worden gebruikt.

Het doel van unit testing is om geïsoleerde stukken code te testen om te controleren of ze correct werken onder verschillende omstandigheden. In het geval van Jasmine, zijn dit de basisonderdelen:

- **Suites**: Een testsuite begint met een oproep aan de globale Jasmine-functie `describe` met twee parameters: een string en een functie. De string is een naam of titel voor een suite van specs (tests) en de functie is een blok code die de specs definieert.
  
- **Specs**: Specs worden gedefinieerd door een oproep aan de globale Jasmine-functie `it`, die evenals `describe` twee parameters accepteert: een string en een functie. De string is de titel van de spec en de functie is de spec zelf, of de test. Een spec kan meerdere verwachtingen bevatten die de test definiëren.

- **Expectations**: Expectations worden gedefinieerd met de functie `expect` die een waarde accepteert, bekend als de 'actual'. Het wordt gekoppeld aan een Matcher-functie, die het verwachte resultaat definieert.

Een eenvoudig Jasmine test zou er als volgt kunnen uitzien:

```javascript
describe("Een suite", function() {
  it("bevat een spec met een verwachting", function() {
    expect(true).toBe(true);
  });
});
```

In dit voorbeeld is "Een suite" de naam van onze testsuite en "bevat een spec met een verwachting" is onze spec. De verwachting in deze test is dat de waarde true gelijk is aan true.

Om Jasmine te gebruiken voor unit testing in uw JavaScript-code, moet u eerst de Jasmine-bibliotheek installeren en correct configureren in uw project. De officiële Jasmine-documentatie bevat gedetailleerde instructies en gidsen om je op weg te helpen: https://jasmine.github.io/index.html