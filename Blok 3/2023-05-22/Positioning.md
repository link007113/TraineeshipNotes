## Absolute en relative

Positionering in CSS verwijst naar het bepalen van de positie en het gedrag van HTML-elementen op een webpagina. Er zijn verschillende positioneringsmethoden beschikbaar, waaronder absolute, relative en floating.

1. Absolute positionering:
   - Absolute positionering plaatst een element op een specifieke positie ten opzichte van het dichtstbijzijnde gepositioneerde ouder-element (als het ouder-element een positionele eigenschap heeft, zoals `position: relative`).
   - De positie van het element wordt bepaald door de eigenschappen `top`, `bottom`, `left` en `right`. Deze eigenschappen geven de afstand aan tussen het gepositioneerde element en de randen van het ouder-element.
   - Een absoluut gepositioneerd element wordt uit de normale documentstroom gehaald, wat betekent dat het andere elementen niet beïnvloedt en andere elementen eroverheen kunnen worden geplaatst.

2. Relative positionering:
   - Relative positionering plaatst een element op een positie die relatief is ten opzichte van zijn oorspronkelijke positie in de documentstroom.
   - De positie van het element kan worden aangepast met behulp van de eigenschappen `top`, `bottom`, `left` en `right`, die de afstand aangeven ten opzichte van de oorspronkelijke positie.
   - Een relatief gepositioneerd element neemt nog steeds ruimte in binnen de normale documentstroom, dus andere elementen worden niet verplaatst om er rekening mee te houden.
## Floating Elements

   - Floating is een oudere positioneringstechniek die werd gebruikt om elementen uit de normale documentstroom te halen en ze naast elkaar te plaatsen.
   - Met de `float`-eigenschap kunnen elementen naar links of naar rechts zweven binnen hun container.
   - Floating-elementen kunnen naast elkaar worden geplaatst, waarbij ze in de documentstroom naar links of rechts worden geduwd en de resterende ruimte opvullen.
   - Echter, floating-elementen kunnen complexiteit en onvoorspelbaarheid veroorzaken, vooral wanneer het gaat om de positionering van andere elementen en het creëren van consistente lay-outs. Daarom is de flexbox-layoutmodule geïntroduceerd als een modernere en krachtigere oplossing voor het creëren van flexibele en responsieve lay-outs.

Flexbox heeft een meer gestructureerde en flexibele aanpak dan floating. Het maakt het gemakkelijker om elementen naast elkaar te plaatsen, de volgorde te wijzigen, de uitlijning en verdeling van ruimte te regelen, en het biedt betere ondersteuning voor responsieve ontwerpen. Met flexbox kunnen complexe lay-outs worden gemaakt met minder CSS-code en minder problemen met overlappingen of onverwachte effecten. Daarom wordt flexbox vaak gebruikt als een modernere en krachtigere vervanging voor floating.