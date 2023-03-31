De garbage collector beheert de toewijzing en vrijgave van geheugen voor een applicatie. 

Automatisch geheugenbeheer kan veel voorkomende problemen elimineren, zoals het vergeten vrij te maken van een object en het veroorzaken van een SystemOutOfMemoryException.




## IDisposable

Alles wat een IDisposable implementeert heeft een Dispose methode. Hiermee geef je aan dat de unmanaged resource opgeruimt moet worden. 

## Using

Using kan je gebruiken op alles wat IDisposable implementeerd. Dit zorgt er namelijk voor dat nadat alles in de body van de using gedaan is hij de unmanaged resources opgeruimd worden:

```c#

using(FileStream stream = new FileStream("path", FileMode.Open))
{
// doe dingen met filestream
// Klaar!
} // Ruim de unmanaged resources op. 
```






### Meer Info:

[Fundamentals of garbage collection](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals)

