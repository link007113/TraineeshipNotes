De garbage collector beheert de toewijzing en vrijgave van geheugen voor een applicatie. 

Automatisch geheugenbeheer kan veel voorkomende problemen elimineren, zoals het vergeten vrij te maken van een object en het veroorzaken van een SystemOutOfMemoryException.




## IDisposable

IDisposable is een interface in C# die een mechanisme biedt voor het vrijgeven van onbeheerde resources, zoals file handles, databaseverbindingen en netwerkverbindingen. Deze resources worden niet automatisch verzameld door het .NET framework, dus het is belangrijk om ze op de juiste manier op te ruimen wanneer ze niet langer nodig zijn om resource leaks en andere problemen te voorkomen.

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
using (var myObject = new MyClass("myfile.txt"))
{
    myObject.DoSomething();
}

using(FileStream stream = new FileStream("path", FileMode.Open))
{
// doe dingen met filestream
// Klaar!
} // Ruim de unmanaged resources op. 
```





### Meer Info:

[Fundamentals of garbage collection](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals)

