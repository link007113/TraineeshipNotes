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
In dit voorbeeld creëren we een container met de class "container" en drie items met de class "item". Door de "display" eigenschap van de container in te stellen op "flex", worden de items automatisch in een flexibele rij geplaatst.
De eigenschap "flex: 1" op de items zorgt ervoor dat ze gelijkmatig worden verdeeld over de beschikbare ruimte in de container. Dit betekent dat elk item een gelijk deel van de beschikbare ruimte inneemt.
We hebben ook enkele visuele stijlen toegepast op de items om ze te onderscheiden, zoals een achtergrondkleur en wat padding.
Wanneer je dit voorbeeld in een webbrowser opent, zul je zien dat de drie items naast elkaar worden weergegeven en de beschikbare ruimte in de container gelijkmatig verdelen.
Dit is slechts een basisvoorbeeld van hoe Flexbox kan worden gebruikt. Flexbox biedt veel meer mogelijkheden, zoals het beheren van de richting, uitlijning en volgorde van elementen binnen een container.

https://css-tricks.com/snippets/css/a-guide-to-flexbox/