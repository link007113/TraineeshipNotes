CSS-klassen zijn een krachtig hulpmiddel in JavaScript voor het manipuleren van het DOM (Document Object Model). Met JavaScript kunt u CSS-klassen toevoegen, verwijderen en wijzigen om de stijl van een element dynamisch te wijzigen.

Hier is hoe je het doet:

1. **Toegang tot klassen van een element:** 
U kunt de `className` eigenschap gebruiken om toegang te krijgen tot de klassen van een element. Het retourneert een string met alle klassen van het element, gescheiden door spaties.

   ```javascript
   let element = document.getElementById('myElement');
   console.log(element.className); // logs the class(es) of the element
   ```

2. **Een klasse toevoegen aan een element:** 
U kunt de `classList.add()` methode gebruiken om een klasse toe te voegen aan een element.

   ```javascript
   element.classList.add('myClass'); // adds the class "myClass" to the element
   ```

3. **Een klasse verwijderen van een element:** 
U kunt de `classList.remove()` methode gebruiken om een klasse te verwijderen van een element.

   ```javascript
   element.classList.remove('myClass'); // removes the class "myClass" from the element
   ```

4. **Controleren of een element een klasse heeft:** 
U kunt de `classList.contains()` methode gebruiken om te controleren of een element een bepaalde klasse heeft. Het retourneert `true` als het element de klasse heeft en `false` anders.

   ```javascript
   let hasClass = element.classList.contains('myClass'); // checks if the element has the class "myClass"
   console.log(hasClass);
   ```

5. **Een klasse schakelen op een element:** 
U kunt de `classList.toggle()` methode gebruiken om een klasse te schakelen op een element. Als het element de klasse heeft, wordt het verwijderd; als het de klasse niet heeft, wordt het toegevoegd.

   ```javascript
   element.classList.toggle('myClass'); // toggles the class "myClass" on the element
   ```

Deze methoden zijn erg handig voor het dynamisch wijzigen van de stijl van elementen op een pagina op basis van gebruikersinteracties of andere gebeurtenissen.