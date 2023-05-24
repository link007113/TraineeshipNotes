Om JavaScript-code aan een HTML-document te koppelen, kan je de `<script>`-tag gebruiken. Door de `src`-attribuutwaarde in te stellen op de locatie van het JavaScript-bestand, kan je het externe scriptbestand aanroepen. Het toevoegen van het `defer`-attribuut zorgt ervoor dat het script wordt uitgesteld in de uitvoering totdat de HTML-parsing is voltooid.

```html
<script defer src="script.js"></script>
```



## querySelector():
`querySelector()` is een methode van het `Document`-object in JavaScript waarmee je een element in de DOM (Document Object Model) kunt selecteren op basis van een CSS-selector. Het retourneert het eerste element dat overeenkomt met de opgegeven selector.

Voorbeeld:
```javascript
const element = document.querySelector('.my-element');
```

## innerText, innerHTML, value:
Dit zijn eigenschappen van een DOM-element waarmee je de inhoud van een element kunt manipuleren.

- `innerText`: Het `innerText`-attribuut stelt of retourneert de tekstinhoud van een element, inclusief de tekstinhoud van alle onderliggende elementen. Het behandelt de tekst als platte tekst en interpreteert geen HTML-tags.

- `innerHTML`: Het `innerHTML`-attribuut stelt of retourneert de HTML-markup en tekstinhoud van een element. Het behandelt de inhoud als HTML en kan HTML-tags interpreteren.

- `value`: Het `value`-attribuut is specifiek voor invoerelementen zoals `<input>` en `<textarea>`. Het stelt of retourneert de waarde van het invoerveld.

Voorbeeld:
```javascript
const element = document.querySelector('.my-element');

// Het instellen van de tekstinhoud
element.innerText = 'Hello, world!';

// Het instellen van de HTML-inhoud
element.innerHTML = '<strong>Hello, world!</strong>';

// Het ophalen van de waarde van een invoerveld
const input = document.querySelector('input');
const value = input.value;
```

## CSS-class plaatsen:
Om een CSS-klasse toe te voegen aan een element via JavaScript, kan je de `classList`-eigenschap gebruiken. De `classList`-eigenschap biedt methoden zoals `add()`, `remove()` en `toggle()` om klassen toe te voegen, te verwijderen of te schakelen.

Voorbeeld:
```javascript
const element = document.querySelector('.my-element');

// Een klasse toevoegen
element.classList.add('new-class');

// Een klasse verwijderen
element.classList.remove('old-class');

// Een klasse in- of uitschakelen (als het aanwezig is, wordt het verwijderd; anders wordt het toegevoegd)
element.classList.toggle('active');
```

## Events:
Events zijn acties of gebeurtenissen die plaatsvinden in een webpagina, zoals een muisklik, toetsaanslag, formulierinzending, enz. In JavaScript kan je events aan elementen koppelen met behulp van eventlisteners.

Voorbeeld:
```javascript
const button = document.querySelector('button');

// Een eventlistener toevoegen voor een klikgebeurtenis
button.addEventListener('click', function(event) {
  // Event-handler code
  console.log('Button clicked!');
});
```

Met behulp van eventlisteners kan je reageren op verschillende gebeurtenissen en de gewenste acties uitvoeren wanneer het event optreedt.