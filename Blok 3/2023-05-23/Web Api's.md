- local en session storage
- JSON stringify() en parse()


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
