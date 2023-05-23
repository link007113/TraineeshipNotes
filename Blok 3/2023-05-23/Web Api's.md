## Local en session storage

LocalStorage en SessionStorage zijn JavaScript-API's die webontwikkelaars in staat stellen om gegevens lokaal op te slaan in de browser van de gebruiker. Beide bieden een eenvoudige manier om gegevens op te slaan en op te halen zonder afhankelijk te zijn van een server.

LocalStorage:
- LocalStorage is een permanente opslagplaats voor gegevens die behouden blijven, zelfs nadat de browser is afgesloten.
- De opgeslagen gegevens zijn beschikbaar op alle pagina's binnen hetzelfde domein.
- De gegevens worden opgeslagen als een sleutel-waarde-paar, waarbij zowel de sleutel als de waarde worden opgeslagen als een tekenreeks.
- Je kunt gegevens opslaan in LocalStorage met behulp van de `localStorage.setItem(key, value)`-methode en ophalen met behulp van `localStorage.getItem(key)`.
- Voorbeeld van het opslaan en ophalen van gegevens in LocalStorage:
```javascript
// Gegevens opslaan in LocalStorage
localStorage.setItem('username', 'John Doe');

// Gegevens ophalen uit LocalStorage
const username = localStorage.getItem('username');
console.log(username); // Output: "John Doe"
```

SessionStorage:
- SessionStorage is vergelijkbaar met LocalStorage, maar de opgeslagen gegevens zijn alleen beschikbaar tijdens de sessie van de gebruiker en worden verwijderd zodra de sessie eindigt (bijvoorbeeld wanneer de browser wordt gesloten).
- De opgeslagen gegevens zijn beperkt tot de huidige tabblad of het huidige venster.
- Net als LocalStorage worden de gegevens opgeslagen als een sleutel-waarde-paar en kunnen ze worden ingesteld met `sessionStorage.setItem(key, value)` en opgehaald met `sessionStorage.getItem(key)`.
- Voorbeeld van het opslaan en ophalen van gegevens in SessionStorage:
```javascript
// Gegevens opslaan in SessionStorage
sessionStorage.setItem('language', 'JavaScript');

// Gegevens ophalen uit SessionStorage
const language = sessionStorage.getItem('language');
console.log(language); // Output: "JavaScript"
```

Zowel LocalStorage als SessionStorage bieden een eenvoudige manier om gegevens op te slaan en op te halen in de browser van de gebruiker. Ze kunnen handig zijn voor het opslaan van gebruikersvoorkeuren, tijdelijke gegevens of andere informatie die lokaal moet worden bewaard. Het is belangrijk op te merken dat hoewel ze nuttig zijn voor het opslaan van kleine hoeveelheden gegevens, ze niet moeten worden gebruikt voor het opslaan van gevoelige informatie, zoals wachtwoorden of vertrouwelijke gegevens, vanwege beveiligingsrisico's.

## JSON stringify() en parse()




## Fetch API
De Fetch API is een ingebouwde JavaScript-interface die een eenvoudige manier biedt om HTTP-verzoeken te maken en te behandelen, zoals het ophalen van bronnen van een server. Het vervangt grotendeels het oudere XMLHttpRequest-object dat eerder werd gebruikt voor het uitvoeren van vergelijkbare taken.

Met de Fetch API kun je HTTP-verzoeken maken naar een bepaalde URL en de ontvangen respons verwerken. Het biedt een asynchrone en promise-gebaseerde benadering, wat betekent dat je een promise-object ontvangt dat wordt opgelost wanneer de respons beschikbaar is.

Hier is een voorbeeld van het gebruik van de Fetch API om gegevens op te halen van een externe server:

```javascript
fetch('https://randomuser.me/api')
  .then(response => {
    // Controleer de status van de respons
    if (!response.ok) {
      throw new Error('Er is een fout opgetreden bij het ophalen van de gegevens.');
    }
    // Parseer de respons als JSON
    return response.json();
  })
  .then(data => {
    // Verwerk de ontvangen gegevens
    console.log(data);
  })
  .catch(error => {
    // Behandel eventuele fouten
    console.error(error);
  });
```

In dit voorbeeld maken we een GET-verzoek naar de URL https://randomuser.me/api
De `fetch()`-functie retourneert een promise die we vervolgens kunnen afhandelen met de `.then()`-methode. In de eerste `.then()`-blok controleren we de status van de respons met `response.ok` en gooien we een fout als de status niet in het bereik 200-299 ligt. Vervolgens gebruiken we de `.json()`-methode om de ontvangen respons te parsen als JSON en ontvangen we een nieuwe promise die de geparseerde gegevens bevat. In de tweede `.then()`-blok verwerken we de gegevens en loggen we ze in de console. Als er zich ergens in de keten een fout voordoet, wordt deze afgehandeld in het `.catch()`-blok.

Met de Fetch API kun je ook andere soorten HTTP-verzoeken maken, zoals POST, PUT, DELETE, enz. Je kunt de Fetch API ook gebruiken om bestanden te verzenden, aangepaste headers in te stellen en andere configuraties uit te voeren. Het is een flexibele en krachtige API voor het werken met HTTP-verzoeken in JavaScript.
