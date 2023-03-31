Bestanden worden vaak gebruikt om gegevens op te slaan en te bewaren, zodat deze later weer gebruikt kunnen worden. Bestanden worden gebruikt om gegevens te lezen, te schrijven, te bewerken en te verwijderen. In C# kunnen bestanden worden bewerkt met behulp van de File-Class.

Hieronder volgt een eenvoudig voorbeeld van hoe de File-Class in C# kan worden gebruikt:
```c#
using System.IO;

var fileName = "myfile.txt";
var text = "This is a test."

File.WriteAllText(fileName, text);

var readText = File.ReadAllText(fileName);
Console.WriteLine(readText);

```
In dit voorbeeld wordt eerst de naam van het bestand en de tekst die naar het bestand geschreven moet worden opgeslagen.  Vervolgens wordt de tekst naar het bestand geschreven met behulp van de WriteAllText-methode van de File-Class. Dit creëert het bestand als het niet bestaat en schrijft de tekst naar het bestand. Daarna wordt de tekst weer uit het bestand gelezen en naar de console geschreven met behulp van de ReadAllText-methode.

In de bovenstaande code wordt het bestand opgeslagen in dezelfde map als de C# toepassing of executable.

Als u echter een andere map wilt opgeven om het bestand op te slaan, kunt u het volledige pad naar het bestand opgeven in de eerste parameter van de File-methoden. 
Bijvoorbeeld:

```c#
var filename = @"C\:myfiles.txt";
File.WriteAllText(filename, text);

```
In dit voorbeeld wordt het bestand opgeslagen in de map "C\:myfiles". Vergeet niet dat de map moet bestaan voordat er een bestand naar toe kan worden geschreven.

Er zijn veel verschillende toepassingen van het werken met bestanden in C#. Zo kunnen bestanden worden gebruikt om configuratiegegevens op te slaan, log-bestanden bij te houden, tijdelijke gegevens op te slaan en nog veel meer. 