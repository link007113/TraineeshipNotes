Use strict is een letterlijke uitdrukking in JavaScript die kan worden gebruikt om te zorgen dat je code op een "striktere" manier wordt geïnterpreteerd en uitgevoerd. Dit betekent dat bepaalde acties die normaal gesproken door JavaScript zouden worden toegestaan, worden voorkomen. Bovendien zal het script foutmeldingen geven voor bepaalde praktijken die anders zouden worden genegeerd.

Hier zijn enkele regels die "use strict" in werking stelt:

1. Variabelen moeten worden gedeclareerd met `var`, `let` of `const`. Als je probeert een variabele te gebruiken zonder deze eerst te declareren, zal JavaScript een fout geven.

```javascript
"use strict";
x = 3.14; // Dit zal een fout geven omdat x niet is gedeclareerd
```

2. Het toewijzen van een waarde aan een niet-schrijfbare globale variabele resulteert in een fout.

```javascript
"use strict";
NaN = 3.14; // Dit zal een fout geven
```

3. Het proberen om een waarde toe te wijzen aan een niet-schrijfbare eigenschap resulteert ook in een fout.

```javascript
"use strict";
var obj = {};
Object.defineProperty(obj, "x", {value: 0, writable: false});
obj.x = 3.14; // Dit zal een fout geven
```

4. Het verwijderen van een variabele, functie of functieparameter leidt tot een fout.

```javascript
"use strict";
var x;
delete x; // Dit zal een fout geven
```

5. Dubbele parameterwaarden zijn niet toegestaan in functies.

```javascript
"use strict";
function x(p1, p1) {}; // Dit zal een fout geven
```

De "use strict" directive helpt bij het schrijven van betere code door het introduceren van extra controles en het verminderen van potentieel problematische JavaScript-praktijken. Het is een goede gewoonte om "use strict" bovenaan je JavaScript-bestanden of -functies te plaatsen om te profiteren van deze extra controle.