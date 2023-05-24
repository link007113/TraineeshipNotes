
## Two's Complement System:

   Het Two's Complement-systeem is een methode voor het voorstellen van negatieve getallen in binaire vorm. Het systeem gebruikt het meest significante bit (het linkerbit) om het teken van een getal aan te geven. Een 0 betekent positief en een 1 betekent negatief. De overige bits geven de magnitude van het getal aan. Het Two's Complement-systeem maakt het mogelijk om optel- en aftrekoperaties uit te voeren met behulp van dezelfde binaire logica, ongeacht het teken van de getallen.

## Bitwise Operator:

   Bitwise-operatoren zijn operatoren die worden toegepast op individuele bits van numerieke waarden. Ze werken op bitniveau en voeren specifieke bewerkingen uit, zoals logische AND, OR, XOR en verschuivingen (links- en rechtsverschuivingen). Bitwise-operatoren worden vaak gebruikt bij taken zoals het manipuleren van vlaggen, het comprimeren van gegevens en het werken met binaire getallen.

   Voorbeeld:
   ```javascript
   let a = 5;       // binaire: 0101
   let b = 3;       // binaire: 0011

   console.log(a & b);   // Bitwise AND: 0001 (1)
   console.log(a | b);   // Bitwise OR: 0111 (7)
   console.log(a ^ b);   // Bitwise XOR: 0110 (6)
   console.log(~a);      // Bitwise NOT: 1010 (-6)
   console.log(a << 1);  // Left Shift: 1010 (10)
   console.log(a >> 1);  // Right Shift: 0010 (2)
   ```

## + Operand prefereert string:

   In JavaScript heeft de + operator een dubbele functie: het optellen van getallen en het samenvoegen van strings (concatenatie). Als een van de operanden een string is, zal de + operator automatisch de andere operand ook als een string behandelen en de concatenatie uitvoeren, zelfs als de andere operand een getal is.

   Voorbeeld:
   ```javascript
   let num = 5;
   let str = "10";

   console.log(num + str);   // "510" (concatenatie)
   ```

## Truthy en Falsy waardes:

   In JavaScript worden waarden geëvalueerd als "truthy" of "falsy" in logische contexten zoals condities in if-statements. Falsy waarden zijn waarden die als onwaar worden beschouwd, terwijl truthy waarden als waar worden beschouwd.

   Enkele voorbeelden van Falsy waarden:
   - false
   - 0
   - ""
   - null
   - undefined
   - NaN

   Voorbeelden van Truthy waarden:
   - true
   - 1
   - "Hello"
   - []
   - {}

## Verschil tussen == en `===`:

   In JavaScript zijn == (gelijkheid) en === (strikte gelijkheid) beide vergelijkingsoperatoren, maar ze gedragen zich op verschillende manieren.

   - De == operator vergelijkt waarden met typecoercie (automatische typeconversie). Dit betekent dat de waarden eerst worden omgezet naar een gemeenschappelijk type voordat de vergelijking wordt uitgevoerd. Bijvoorbeeld, de string "5" wordt als gelijk beschouwd aan het getal 5 omdat ze worden geconverteerd naar hetzelfde numerieke type.

   - De === operator voert een strikte vergelijking uit zonder typecoercie. Het vergelijkt de waarden en hun typen. Beide waarden moeten van hetzelfde type zijn en dezelfde waarde hebben om als gelijk te worden beschouwd.

   Voorbeeld:
   ```javascript
   console.log(5 == "5");   // true (typecoercie)
   console.log(5 === "5");  // false (strikte gelijkheid)
   ```