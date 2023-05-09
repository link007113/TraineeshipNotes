Garbage collection is een proces waarbij het .NET framework automatisch geheugen vrijmaakt dat niet langer door een toepassing wordt gebruikt.

Met andere woorden, wanneer er objecten worden gemaakt, nemen ze RAM-geheugen in beslag. Wanneer die objecten niet langer nodig zijn, is het belangrijk om dat geheugen vrij te maken, zodat het kan worden gebruikt door andere delen van de toepassing of door andere toepassingen die op de computer draaien.

Automatisch geheugenbeheer kan veel voorkomende problemen elimineren, zoals het vergeten vrij te maken van een object en het veroorzaken van een SystemOutOfMemoryException.

De Garbage Collector controleert periodiek het geheugen dat door de toepassing wordt gebruikt en identificeert objecten die niet langer worden gebruikt en daarom veilig uit het geheugen kunnen worden verwijderd. Vervolgens wordt het geheugen van die objecten vrijgemaakt, zodat het beschikbaar is voor ander gebruik.


## IDisposable

IDisposable is een interface in C# die een mechanisme biedt voor het vrijgeven van onbeheerde resources, zoals file handles, databaseverbindingen en netwerkverbindingen. 
Deze resources worden niet automatisch opgeruimd door het .NET framework, dus het is belangrijk om ze op de juiste manier op te ruimen wanneer ze niet langer nodig zijn om resource leaks en andere problemen te voorkomen.

Een aantal voorbeelden hiervan zijn:

- FileStream: gebruikt voor het lezen en schrijven van bestanden op de schijf.
- MemoryStream: gebruikt voor het werken met geheugenbuffers als streams.
- SqlConnection, SqlCommand, SqlDataReader: gebruikt voor toegang tot een SQL Server-database.
- StreamReader, StreamWriter: gebruikt voor het lezen en schrijven van tekstbestanden.
- TcpClient, NetworkStream: gebruikt voor netwerkcommunicatie.
- Process: gebruikt voor het starten van externe processen.

## Using

Het using statement is een handige manier om ervoor te zorgen dat IDisposable objecten correct worden verwijderd wanneer ze niet langer nodig zijn. Het using statement roept automatisch de Dispose methode aan op een object dat de IDisposable interface implementeert, zodra het codeblok in het using statement is voltooid:
```c#
class FileParser : IDisposable
{
    private FileStream _fileStream;
    public FileParser(string fileName)
    {
        _fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
    }
    public void ReadLine()
    {
        // Do some work with the file stream
    }
    public void Dispose()
    {
        _fileStream.Dispose();
    }
}

// Example of using IDisposable and using
using (var fileParser = new FileParser("myfile.txt"))
{
    fileParser.DoSomething();// doe dingen met filestream
// Klaar!
}// Ruim de unmanaged resources op. 
```

In dit voorbeeld implementeert de class FileParser de IDisposable interface en heeft een private field genaamd \_fileStream dat een FileStream is. De constructor van FileParser initialiseert het field\_fileStream, en de methode DoSomething voert wat werk uit met de bestandsstroom.

Het using statement wordt gebruikt om een nieuwe instantie van FileParser genaamd fileParser aan te maken, en roept vervolgens de methode DoSomething daarop aan. Wanneer het codeblok in het using statement klaar is met uitvoeren, wordt automatisch de Dispose-methode van fileParser aangeroepen, die op zijn beurt de FileStream verwijdert.

Het gebruik van het using statement zorgt ervoor dat de bestandsstroom correct wordt verwijderd, zelfs als er een uitzondering optreedt binnen het codeblok. Dit helpt om bronlekken en andere problemen te voorkomen die kunnen optreden wanneer onbeheerde bronnen niet goed worden opgeruimd.

### Meer Info:

[Fundamentals of garbage collection](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals)

