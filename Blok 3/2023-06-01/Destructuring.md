Destructuring is een functie in JavaScript waarmee we waarden uit arrays of eigenschappen uit objecten kunnen halen en die in afzonderlijke variabelen kunnen opslaan. Dit maakt de code vaak veel schoner en gemakkelijker te lezen. 

1. **Array destructuring:**

    ```javascript
    const dieren = ["ezel", "ara", "slang"];
    const [dier1, , dier2] = dieren;
    console.log(dier1, dier2);
    ```
    In dit voorbeeld haalt destructuring de waarden uit de array `dieren` en slaat ze op in de variabelen `dier1` en `dier2`. Merk op dat we een komma gebruiken om de tweede waarde in de array over te slaan.

2. **Object destructuring:**

    ```javascript
    let course1 = {
      belasting: "medium",
      naam: "Angular",
      aantalDagen: 4,
    };

    const { naam, belasting } = course1;
    const { naam, belasting: moeilijkheid } = course1;
    ```

    Hier halen we de waarden van de eigenschappen `naam` en `belasting` uit het `course1` object en slaan we ze op in variabelen met dezelfde naam. Als we een andere naam willen gebruiken voor de variabele (bijvoorbeeld `moeilijkheid` in plaats van `belasting`), kunnen we een alias specificeren met behulp van de syntax `eigenschap: alias`.

3. **Array destructuring uit een object:**

    ```javascript
    let course1 = {
      belasting: "medium",
      naam: "Angular",
      aantalDagen: 4,
      trainers: ['Kees', 'JP'],
    };

    const [, trainer2] = course1.trainers;
    console.log(trainer2)

    const{trainers: [, trainer3]} = course1
    console.log(trainer3)
    ```

    In dit voorbeeld gebruiken we destructuring om de tweede waarde uit de `trainers` array van het `course1` object te halen. We slaan deze waarde op in de `trainer2` variabele. De tweede destructuring regel doet hetzelfde, maar doet dit in één stap door eerst de `trainers` eigenschap uit het object te halen en vervolgens de tweede waarde uit de resulterende array te halen.