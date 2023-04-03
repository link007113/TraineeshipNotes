Voor de eindoefening moeten we een Console Applicatie maken om Black Jack te spelen.

### Blauwe Piste:

Schrijf code zodat je spel werkt. Voor het basisspel. Alleen Hit of Stand implementatie

### Rode Piste:

Blauwe piste + Unit testen. Volledig spel

### Zwarte Piste:

Code voor volledig spel + unit testen + architectuur

Het spel moet verdeeld worden over 3 projecten

- Console voor de UI Logica
- Lib voor de game logica
- MSTest voor de tests

```
Voorbeeld:

Initial Player saldo = 20(money)

New Round

Player has initial 20 money

Player has 15 money
Place your Bets (1-10): 3

Dealer has 
- Ace of Spades (Face up) 
- 4 Ruiten (Face down)

Player  has
- King of Clubs
- Three of hears
Hand Value is 13
Bet: 3

(H)it or (S)tand or (D)ouble Down or Split (P)airs? H <-- as long as your hand has onkly two cards

Dealer has 
- Ace of Spades (Face up) 
- 4 Ruiten (Face down)

Player  has
- King of Clubs
- Three of hears
- Seven of Diamonds
Hand Value is 20
Bet: 3

(H)it or (S)tand? <- As long as your hand has more than two cards
Dealer has 
- Ace of Spades (Face up) 
- 4 Ruiten (Face down)

Player  has
- King of Clubs
- Three of hears
- Seven of Diamonds
- Jack of Clubs
Hand Value is 30 -> Player has Busted
Player has 12 money

Do you want to keep playing? (Y)es or (N)o?


Suits: Spades, Hearts, Diamonds, Clubs
Ranks: Ace, King, Queen, Jack, Ten, Nine, Eight, Seven, Six, Five, Four, Three, Two

Game contains 52 cards from 6 decks. 
```


![[Pasted image 20230403113353.png]]
