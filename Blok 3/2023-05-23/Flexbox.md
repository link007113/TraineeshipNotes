Flexbox, of de Flexible Box Layout, is een CSS3 lay-outmodel dat efficiënter omgaat met ruimteverdeling en uitlijning van items in een container, zelfs als hun grootte onbekend is of dynamisch wordt gewijzigd.

In mijn voorbeeld, heb ik een flex-container (de element met de class `.container`) en drie flex-items (de elementen met de class `.item`).

```css
.container {
  display: flex;
  flex-wrap: wrap;
}
```
In de bovenstaande CSS-regels stel ik de `display` eigenschap van `.container` in op `flex`, wat het een flex-container maakt. Daarna stel ik de `flex-wrap` eigenschap in op `wrap`, wat betekent dat de flex-items naar de volgende regel zullen gaan als ze niet passen op de huidige regel.

```css
.item {
  flex: 1;
  padding: 20px;
  background-color: #7aff7e;
  margin: 10px;
}
```
Voor de flex-items, met de `flex: 1` regel, geef ik aan dat elk item de beschikbare ruimte in de container gelijk moet verdelen. `Padding` is de ruimte binnen elk item, `background-color` geeft de kleur van de item en `margin` is de ruimte buiten elk item.

Het belangrijkste voordeel van het gebruik van Flexbox is dat ik de grootte, volgorde en uitlijning van elementen in een container kunt manipuleren zonder dat ik floats of posities hoeft te gebruiken, wat in het verleden nogal een uitdaging kon zijn.

Voor meer details en visuele gidsen over Flexbox, raad ik aan de [Flexbox gids](https://css-tricks.com/snippets/css/a-guide-to-flexbox/) van CSS-Tricks te bezoeken, een zeer nuttige bron voor het leren en begrijpen van Flexbox.

```html
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Flexbox</title>
  <style>
    .container {
      display: flex;
      flex-wrap: wrap; -- default to nowrap
    }

    .item {
      flex: 1;
      padding: 20px;
      background-color: #7aff7e;
      margin: 10px;
    }
  </style>
</head>
<body>
  <div class="container">
    <div class="item">Item 1</div>
    <div class="item">Item 2</div>
    <div class="item">Item 3</div>
  </div>
</body>
</html>
```