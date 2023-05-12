Het Repository Pattern is een software ontwerp patroon dat wordt gebruikt om de complexiteit van het werken met databases te verminderen. Het patroon scheidt de logica voor het werken met de database van de rest van de applicatie. Dit maakt het gemakkelijker om wijzigingen aan te brengen in de manier waarop gegevens worden opgeslagen en opgehaald zonder dat dit invloed heeft op de rest van de applicatie.


Voorbeeld van BlackJack Database met SpelerRepository. Applicatie implementeert ISpelerRepository. In de database bewaren we de spelers met hun score per ronde en saldo.

Dit komt in de Model  map in de solution:
Speler class heeft een ID, Naam, Saldo, Tafel
Tafel Class heeft een ID, Nummer, Naam, Naam Dealer, List<Speler> Spelers
Op Tafel wordt nooit direct gequeried. 

In de DAL map in de solution komen:

De SpelerRepository

Datamapper VS Repository

```c#
```
