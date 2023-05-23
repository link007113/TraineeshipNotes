Er zijn drie manieren om CSS aan een HTML-pagina te koppelen:

1. Inline-stijl: Bij deze methode wordt CSS direct in het HTML-element zelf toegevoegd met behulp van het style-attribuut. Hiermee kan specifieke stijlinstructies worden toegepast op individuele elementen. Bijvoorbeeld:
   ```html
   <h1 style="color: blue;">Dit is een blauwe kop</h1>
   ```
   Deze aanpak is handig wanneer je specifieke stijlen wilt toepassen op een specifiek element, maar het kan de HTML-markup rommelig maken en het is moeilijker om consistentie te behouden in de hele pagina.

2. Interne stijl: Bij deze methode wordt CSS-code binnen de style-tags geplaatst in het head-gedeelte van het HTML-document. Hiermee kunnen stijlinstructies worden toegepast op meerdere elementen op dezelfde pagina. Bijvoorbeeld:
   ```html
   <head>
     <style>
       h1 {
         color: blue;
       }
     </style>
   </head>
   <body>
     <h1>Dit is een blauwe kop</h1>
   </body>
   ```
   Deze aanpak is handig wanneer je specifieke stijlen wilt toepassen op een hele pagina, maar het kan problematisch worden wanneer je dezelfde stijl op meerdere pagina's wilt toepassen. Het kan ook moeilijk zijn om de CSS-code te onderhouden als deze groter wordt.

3. Externe stijl: Bij deze methode wordt CSS-code in een extern CSS-bestand geplaatst en wordt dit bestand gekoppeld aan het HTML-document met behulp van het link-element. Het externe CSS-bestand bevat alle stijlinstructies en kan worden gebruikt voor meerdere HTML-pagina's. Bijvoorbeeld:
   ```html
   <head>
     <link rel="stylesheet" type="text/css" href="styles.css">
   </head>
   <body>
     <h1>Dit is een blauwe kop</h1>
   </body>
   ```
   In dit voorbeeld wordt een extern CSS-bestand met de naam "styles.css" gekoppeld aan de HTML-pagina. Het externe CSS-bestand bevat de stijlinstructies voor de pagina.

De externe stijlmethode is de meest gebruikelijke en aanbevolen manier om CSS aan een HTML-pagina te koppelen, omdat het zorgt voor een betere scheiding van inhoud en presentatie, maakt hergebruik van stijlen mogelijk en vergemakkelijkt het onderhoud van de CSS-code.


Reset CSS