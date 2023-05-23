## Fixed vs responsive

Fixed en responsive zijn twee benaderingen binnen webdesign om de lay-out en het ontwerp van een website aan te passen aan verschillende schermformaten en apparaten.

1. Fixed lay-out: Een fixed lay-out is ontworpen met een specifieke vaste breedte, meestal in pixels. Ongeacht het schermformaat of apparaat behoudt de website dezelfde breedte en blijven de elementen op dezelfde positie staan. Dit betekent dat de inhoud van de website niet meeschaalt met de schermgrootte. Bij een fixed lay-out kan het zijn dat de inhoud buiten het zichtbare schermgebied valt of dat horizontaal scrollen nodig is op kleinere schermen.

2. Responsive  lay-out: Een responsive lay-out is ontworpen om zich aan te passen aan verschillende schermformaten en apparaten. De website past automatisch de lay-out en het ontwerp aan op basis van de beschikbare schermruimte. Dit wordt bereikt door het gebruik van flexibele eenheden zoals percentages en het toepassen van CSS-mediaqueries. Met een responsive lay-out schaalt de inhoud proportioneel mee en worden elementen herschikt om de leesbaarheid en bruikbaarheid te verbeteren op verschillende apparaten.

In vergelijking met een fixed lay-out biedt een responsive lay-out voordelen zoals:

-   Verbeterde gebruikerservaring op verschillende schermformaten en apparaten.
-   Geen horizontaal scrollen of inhoud die buiten het scherm valt.
-   Betere toegankelijkheid voor gebruikers met verschillende apparaten, zoals mobiele telefoons en tablets.
-   Mogelijkheid om één enkele website te ontwerpen en onderhouden die geschikt is voor verschillende apparaten.

Over het algemeen wordt het gebruik van responsive design sterk aanbevolen, omdat het zorgt voor een betere gebruikerservaring en de website toegankelijk maakt voor een breder publiek. Het past zich aan aan de diversiteit van schermformaten en apparaten die tegenwoordig worden gebruikt.

## Media queries
Media queries in CSS stellen ons in staat om stijlen toe te passen op basis van verschillende kenmerken van het apparaat waarop de webpagina wordt weergegeven, zoals schermgrootte, resolutie en oriëntatie. In je code heb je al een eenvoudig voorbeeld van een media query:

```html
<style>
  body {
    color: red;
    background-color: blue;
  }

  @media all and (min-width: 768px) {
    body {
      color: blue;
      background-color: red;
    }
  }
</style>
```

In deze code wordt de initiële stijl van de `body` ingesteld op rode tekst op een blauwe achtergrond. Echter, binnen de media query wordt een andere stijl gedefinieerd voor het geval het scherm een minimum breedte heeft van 768 pixels. In dat geval wordt de tekstkleur ingesteld op blauw en de achtergrondkleur op rood.

Met andere woorden, wanneer de schermgrootte groter is dan of gelijk is aan 768 pixels, worden de stijlen binnen de media query toegepast. Anders blijven de initiële stijlen behouden.

Dit stelt ons in staat om responsieve ontwerpen te maken waarbij de lay-out en stijlen van een webpagina worden aangepast op basis van de schermgrootte. Hierdoor kunnen we een betere gebruikerservaring bieden op verschillende apparaten, zoals desktops, tablets en smartphones.
