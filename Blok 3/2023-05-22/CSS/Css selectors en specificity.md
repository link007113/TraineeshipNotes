

CSS-selectoren zijn notaties die worden gebruikt om specifieke HTML-elementen te targeten en stijlregels toe te passen. Selectoren kunnen gebaseerd zijn op elementnamen, klassen, ID's en andere attributen. De specificiteit van een selector bepaalt welke stijlregels van toepassing zijn wanneer er meerdere regels zijn die dezelfde elementen targeten.

In je notities heb je al een aantal CSS-selectoren en hun betekenissen genoteerd. Hier is een uitleg van elk:

- UL: Deze selector target alle ul-elementen op de pagina. Omdat dit een selector is die alleen op elementnaam is gebaseerd, heeft deze een lagere specificiteit.

- DIV > P: Deze selector target alle p-elementen die direct binnen een div>-element staan. Dit betekent dat alleen p-elementen die direct kinderen zijn van div>-elementen worden geselecteerd.

- DIV P: Deze selector target alle p-elementen die ergens binnen een div>-element staan. Dit betekent dat alle p-elementen die zich binnen een div bevinden, ongeacht hun positie, worden geselecteerd.

- DIV, P: Deze selector target zowel alle div-elementen als alle p>-elementen op de pagina. Het is een zogenaamde groepselector die meerdere elementen combineert.

- DIV.kleuren: Deze selector target alle div-elementen met de class "kleuren". Het element moet zowel een div-element zijn als de class "kleuren" hebben om te worden geselecteerd. Deze selector heeft een hogere specificiteit vanwege het gebruik van een class.

- DIV#ToonMelding: Deze selector target het element met de ID "ToonMelding" dat een div-element is. De ID-selector heeft de hoogste specificiteit omdat ID's uniek moeten zijn op een pagina.

Wanneer er meerdere stijlregels zijn die dezelfde elementen targeten, bepaalt de specificiteit welke regels worden toegepast. Hoe hoger de specificiteit, hoe groter de invloed op de stijl van het element. Als er meerdere regels met dezelfde specificiteit zijn, wordt de regel toegepast die het laatst wordt gedefinieerd in het CSS-bestand.

Het begrijpen van selectoren en specificiteit is belangrijk om de volgorde en prioriteit van stijlregels in CSS te begrijpen en ervoor te zorgen dat de gewenste stijlen correct worden toegepast op de geselecteerde elementen.


```css
UL  = alle <UL> elementen <--- belangrijk
DIV>P = alle <P> direct binnen een <DIV>
DIV P = alle <P> binnen een <DIV>
DIV, P = alle <DIV> en alle <P>
DIV.kleuren alle <DIV class="kleuren"> <--- belangrijk
DIV#ToonMelding het element <DIV id="ToonMelding"> <--- belangrijk
``` 