
Een formulier in HTML wordt gebruikt om gegevens van gebruikers te verzamelen. Hier zijn enkele veelgebruikte inputvelden die je kunt gebruiken:

- Text (Tekst): Dit is een standaardtekstinvoerveld waar gebruikers tekst kunnen typen. Bijvoorbeeld:
   ```html
   <input type="text" name="naam" placeholder="Voer je naam in">
   ```
- Password (Wachtwoord): Dit veld maskeert de ingevoerde tekens, zodat het niet zichtbaar is. Dit wordt vaak gebruikt voor wachtwoordinvoer:
   ```html
   <input type="password" name="wachtwoord" placeholder="Voer je wachtwoord in">
   ```
- Submit (Verzenden): Dit is een knop waarmee gebruikers het formulier kunnen verzenden. Bijvoorbeeld:
   ```html
   <input type="submit" value="Verzenden">
   ```
- Checkbox (Selectievakje): Dit stelt gebruikers in staat om één of meerdere opties te selecteren. Elke checkbox heeft een unieke naam en waarde:
   ```html
   <input type="checkbox" name="hobby" value="voetbal"> Voetbal
   <input type="checkbox" name="hobby" value="tennis"> Tennis
   ```
- Radio: Dit stelt gebruikers in staat om één optie te selecteren uit een lijst met keuzes. Elk radio-element heeft een unieke naam en waarde:
   ```html
   <input type="radio" name="geslacht" value="man"> Man
   <input type="radio" name="geslacht" value="vrouw"> Vrouw
   ```
- Select (Keuzelijst): Dit biedt een vervolgkeuzelijst waaruit gebruikers één optie kunnen selecteren:
   ```html
   <select name="land">
     <option value="nederland">Nederland</option>
     <option value="belgie">België</option>
     <option value="duitsland">Duitsland</option>
   </select>
   ```
- Email: Dit is een invoerveld dat is geoptimaliseerd voor het invoeren van e-mailadressen:
   ```html
   <input type="email" name="email" placeholder="Voer je e-mailadres in">
   ```
- Telephone (Telefoonnummer): Dit veld is bedoeld voor het invoeren van telefoonnummers:
   ```html
   <input type="tel" name="telefoon" placeholder="Voer je telefoonnummer in">
   ```
- Range (Bereik): Dit stelt gebruikers in staat om een waarde te selecteren binnen een bepaald bereik, bijvoorbeeld een schuifregelaar:
   ```html
   <input type="range" name="leeftijd" min="0" max="100">
   ```
- URL: Dit is een invoerveld dat is geoptimaliseerd voor het invoeren van URL's (webadressen):
    ```html
    <input type="url" name="website" placeholder="Voer de URL in">
    ```
- Number (Getal): Dit is een invoerveld dat is geoptimaliseerd voor het invoeren van numerieke waarden:
    ```html
    <input type="number" name="aantal" placeholder="Voer een getal in">
    ```

Dit zijn maar een voorbeelden van de verschillende inputvelden die je kunt gebruiken in HTML-formulieren. Elke input heeft zijn eigen specifieke doel en kan worden aangepast met behulp van verschillende attributen om de functionaliteit en weergave ervan aan te passen.

Form voorbeeld
```html
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Aanmeldformulier</title>
    <style>
      body {
        margin: 50px 550px 50px 50px ;
        font-family: "Verdana";  
        background-color: whitesmoke;
   
      }
      h1 {
        font-weight: bold;
        font-size: x-large;
        text-align: left;
        margin: 0 0 5px 0;
        color: gray;
      }
      strong{ color: gray;}
      label{color: gray;}
      #bio {
        height: 200px;
        width: 200px;
        font-size: 14pt;
      }
      div>input
      {display: table;}  
      fieldset>input{display: inline;}
    </style>
  </head>
  <body>
    <form method="GET">
      <h1>Aanmelden</h1>
      <div>
        <strong><label for="gebruikersnaam">Gebruikersnaam:</label></strong>
        <input
          id="gebruikersnaam"
          name="gebruikersnaam"
          type="text"
          maxlength="75"
        />
      </div>
      <div>
        <strong><label for="wachtwoord">Wachtwoord:</label></strong>
        <input
          id="wachtwoord"
          name="wachtwoord"
          type="password"
          maxlength="256"
        />
      </div>
      <fieldset>
        <legend >Geslacht:</legend>
        
        <input id="man" name="gender" type="radio" />
        <label for="man">Man</label>
        
        <input id="vrouw" name="gender" type="radio" />
        <label for="vrouw">Vrouw</label>
        
        <input id="anders" name="gender" type="radio" />
        <label for="anders">Anders</label>
      </fieldset>
      </div>
      <div>
        <strong><label for="beroepsgroep">Beroepsgroep:</label></strong>
        <select name="beroepsgroep" id="beroepsgroep">
          <option value="ict">ICT</option>
          <option value="zorg">Zorg</option>
          <option value="logistiek">Logistiek</option>
        </select>
      </div>
      
        <input id="geschenk" name="geschenk" type="checkbox" />
        <label for="geschenk">Ja, ik wil een welkomsgesprek</label>
   
      <div>
        <strong><label for="bio">Biografie:</label></strong>
        <hr />
        <input id="bio" name="bio" type="text" />
      </div>
      <button id="verstuur">Verstuur</button>
    </form>
  </body>
</html>
