## Fixed vs responsive

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

## Flex Box