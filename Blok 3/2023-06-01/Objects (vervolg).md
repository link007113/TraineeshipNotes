In JavaScript kun je getters en setters gebruiken om de toegang tot de eigenschappen van een object te controleren. Dit zijn speciale soorten methoden in een object die worden gebruikt om operaties uit te voeren of berekeningen uit te voeren wanneer een gebruiker probeert de waarde van een eigenschap te verkrijgen of in te stellen.

### Getter:

Een getter wordt gebruikt om de waarde van een specifieke eigenschap op te halen. Het stelt ons in staat om logica toe te voegen voordat de waarde wordt geretourneerd, of zelfs om te berekenen wat de waarde zou moeten zijn. Je definieert een getter met `get`, gevolgd door een functie.

```javascript
class Persoon {
  constructor(naam) {
    this._naam = naam;
  }

  get naam() {
    return this._naam.toUpperCase();
  }
}

let p = new Persoon('Johan');
console.log(p.naam);  // 'JOHAN'
```

In dit voorbeeld, wanneer we de `naam` eigenschap opvragen, retourneert het de naam in hoofdletters, zelfs als we de naam niet in hoofdletters hebben opgegeven.

### Setter:

Een setter wordt gebruikt om de waarde van een specifieke eigenschap in te stellen. Het stelt ons in staat om logica toe te voegen voordat de waarde wordt ingesteld, bijvoorbeeld om de waarde te valideren of te transformeren. Je definieert een setter met `set`, gevolgd door een functie.

```javascript
class Persoon {
  constructor() {
    this._naam = '';
  }

  set naam(naam) {
    if(naam.length > 0) {
      this._naam = naam;
    } else {
      console.log('Naam kan niet leeg zijn');
    }
  }
}

let p = new Persoon();
p.naam = 'Johan';  // Stelt de naam in op 'Johan'
p.naam = '';  // Toont de foutmelding 'Naam kan niet leeg zijn'
```

In dit voorbeeld, wanneer we de `naam` eigenschap instellen, controleert de setter eerst of de naam niet leeg is. Als de naam leeg is, dan wordt een foutmelding getoond en wordt de naam niet ingesteld.
