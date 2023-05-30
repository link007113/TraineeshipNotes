In JavaScript heb je een aantal controlestructuren die je helpen bij het sturen van de stroom van je code. Ze zijn vergelijkbaar met de instructies die je geeft bij het spelen van een bordspel. Laten we de belangrijkste doorlopen:

## If-statement

De `if`-statement is als een vraag. Als het antwoord op de vraag "ja" (of "waar" / "true") is, voer je een bepaalde actie uit. Zo niet, dan gebeurt er niets.

Voorbeeld:
```javascript
let appels = 5;
if (appels > 0) {
    console.log("We hebben appels!");
}
```
In dit geval zal de console "We hebben appels!" printen, omdat we meer dan 0 appels hebben.

## If-else-statement

Het `if-else`-statement lijkt op de `if`-statement, maar met een extra optie. Als het antwoord op de vraag "ja" is, doe je iets. Zo niet, dan doe je iets anders.

Voorbeeld:
```javascript
let appels = 0;
if (appels > 0) {
    console.log("We hebben appels!");
} else {
    console.log("We hebben geen appels.");
}
```
Omdat we geen appels hebben, zal de console "We hebben geen appels." printen.

## For-loop

De `for`-loop is als het herhaaldelijk uitvoeren van een taak. Je voert een actie uit voor een bepaald aantal keer.

Voorbeeld:
```javascript
for (let i = 0; i < 5; i++) {
    console.log("Dit is loop nummer " + i);
}
```
Dit zal 5 keer een bericht printen, elke keer met een ander nummer, van 0 tot 4.

## While-loop

De `while`-loop is een ander soort herhaling, maar deze keer blijf je de taak herhalen zolang een bepaalde voorwaarde waar is.

Voorbeeld:
```javascript
let appels = 5;
while (appels > 0) {
    console.log("Er zijn nog " + appels + " appels over.");
    appels--;
}
```
Dit zal een bericht printen voor elke appel, tot er geen appels meer over zijn.

## Switch-statement

De `switch`-statement is als een reeks `if-else`-statements. Je controleert een waarde en afhankelijk van die waarde voer je een specifieke actie uit.

Voorbeeld:
```javascript
let kleur = "rood";
switch (kleur) {
    case "rood":
        console.log("De kleur is rood.");
        break;
    case "blauw":
        console.log("De kleur is blauw.");
        break;
    default:
        console.log("Ik ken deze kleur niet.");
}
```
Dit zal "De kleur is rood." printen omdat de variabele `kleur` de waarde "rood" heeft.
