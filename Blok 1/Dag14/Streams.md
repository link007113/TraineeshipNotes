Een Stream in C# is een manier om gegevens in te lezen of uit te schrijven naar een bron of bestemming. Dit kan bijvoorbeeld een bestand op de harde schijf zijn, een netwerkverbinding of de console.

Met Streams kun je gegevens op een efficiënte manier lezen of schrijven, omdat ze de gegevens in kleine stukjes (buffers) verwerken. Dit betekent dat Streams slechts een klein deel van de gegevens in het geheugen hoeven te houden, waardoor Streams geschikt zijn voor het werken met grote hoeveelheden gegevens.

Streams zijn ook erg flexibel omdat ze in verschillende formaten kunnen worden gebruikt. In C# zijn er bijvoorbeeld FileStreams voor het lezen en schrijven van bestanden, MemoryStreams voor het lezen en schrijven van gegevens in het geheugen en NetworkStreams voor het lezen en schrijven van gegevens via netwerkverbindingen.

```c#
// Example of reading and writing a file using a FileStream
using (var stream = new FileStream("myfile.txt", FileMode.OpenOrCreate))
{
    // Write a string to the file
    var text = "This is a test."
    var buffer = Encoding.UTF8.GetBytes(text);
    stream.Write(buffer, 0, buffer.Length);

    // Read the file and write it to the console
    buffer = new byte[stream.Length];
    stream.Seek(0, SeekOrigin.Begin);
    stream.Read(buffer, 0, buffer.Length);
    text = Encoding.UTF8.GetString(buffer);
    Console.WriteLine(text);
}
```

In dit voorbeeld wordt een FileStream gebruikt om een bestand te lezen en schrijven. Eerst wordt een FileStream-object aangemaakt en geopend met de using-statement. Vervolgens wordt een string naar het bestand geschreven met behulp van de Write-methode en gelezen en naar de console geschreven met behulp van de Read-methode. Tot slot wordt het FileStream-object automatisch gesloten en vrijgegeven door de using-statement.



### Meer info:
[Stream Class](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-7.0)