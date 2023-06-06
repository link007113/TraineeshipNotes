HTML-templates zijn een zeer krachtige functie in moderne webontwikkeling. Ze maken het mogelijk om herbruikbare markup te creëren, wat erg handig is voor herhaalde of dynamische inhoud.

Een HTML-template kan worden gedefinieerd met behulp van het `<template>` element. De inhoud van dit element wordt niet weergegeven in de uiteindelijke pagina, maar kan worden gekloond en ingevoegd waar nodig met behulp van JavaScript.

Hier is een voorbeeld van een HTML-template:

```html
<template id="my-template">
  <div class="card">
    <h2 class="card-title"></h2>
    <p class="card-content"></p>
  </div>
</template>
```

In dit voorbeeld hebben we een sjabloon voor een kaartelement gedefinieerd. We kunnen dit sjabloon nu vullen en het nieuwe element toevoegen aan onze pagina met behulp van JavaScript.

```javascript
// Selecteer het template element
let template = document.getElementById('my-template');

// Maak een "diepe" kopie van de inhoud van het template
let clone = template.content.cloneNode(true);

// Vul de gegevens in
clone.querySelector('.card-title').innerText = 'Dit is de titel van mijn kaart';
clone.querySelector('.card-content').innerText = 'Dit is de inhoud van mijn kaart';

// Voeg het nieuwe element toe aan de pagina
document.body.appendChild(clone);
```

In dit voorbeeld selecteren we eerst het template-element met behulp van zijn ID. Daarna maken we een kloon van de inhoud van het template met `template.content.cloneNode(true)`. Deze methode maakt een kopie van de template-inhoud, inclusief alle kind-elementen (dat is waar het `true` argument voor is).

Vervolgens vullen we de gegevens in door de `.innerText` eigenschap van de titel- en inhoudselementen te wijzigen.

Tenslotte voegen we de nieuwe kaart toe aan de pagina met `document.body.appendChild(clone)`. Dit voegt de nieuwe kaart toe aan het einde van het `<body>` element.