Is een class die alle logica bevat voor het werken met de database.
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
