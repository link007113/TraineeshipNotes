De term "asynchroon" in JavaScript verwijst naar de mogelijkheid om operaties uit te voeren zonder te wachten tot voorgaande operaties zijn voltooid. Dit is bijzonder nuttig voor tijd consumerende operaties zoals netwerkaanvragen, toegang tot een database, of in dit geval, het lezen van bestanden van het bestandssysteem.

Node.js heeft de module `fs` (File System) die het mogelijk maakt om te interageren met het bestandssysteem op je computer. Veel van de functies van de `fs` module hebben zowel synchrone als asynchrone versies.

Hier is een voorbeeld van asynchrone bestandslezing in Node.js:

```javascript
const fs = require('fs');

fs.readFile('example.txt', 'utf8', function(err, data) {
    if (err) {
        console.error("Er is een fout opgetreden tijdens het lezen van het bestand!", err);
        return;
    }
    console.log(data);
});

console.log("Dit bericht wordt eerst weergegeven, ook al staat het na de readFile functie in de code.");
```

In dit voorbeeld wordt `fs.readFile()` gebruikt om een bestand asynchroon te lezen. Het neemt drie argumenten: het pad naar het bestand, de codering van het bestand, en een callback functie die wordt uitgevoerd wanneer het lezen van het bestand is voltooid.

De callback functie wordt pas uitgevoerd nadat het bestand volledig is gelezen. Als er tijdens het lezen een fout optreedt, wordt deze als eerste argument doorgegeven aan de callback functie.

Het belangrijkste punt om hier op te merken is dat, ondanks dat de oproep aan `fs.readFile()` eerder in de code staat dan de `console.log()`, de leesbewerking asynchroon is. Dat betekent dat de JavaScript-runtime niet wacht tot `fs.readFile()` klaar is met uitvoeren voordat het doorgaat naar de volgende regel. Daarom wordt "Dit bericht wordt eerst weergegeven, ook al staat het na de readFile functie in de code." eerst afgedrukt, zelfs als het lezen van het bestand nog niet is voltooid.
