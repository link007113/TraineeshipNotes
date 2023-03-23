## Inleiding
Structs lijken een beetje op classes, in die zin dat ze gegevensstructuren vertegenwoordigen die gegevensleden en functieleden kunnen bevatten. 

In tegenstelling tot classes zijn structs echter Value types en worden deze niet op de heap gezet. 

Een variabele van een struct-type bevat direct de gegevens van de struct, terwijl een variabele van een klassetype een verwijzing naar de gegevens bevat, dit laatste staat bekend als een object.

Bijv:
```c#
    public struct Time
    {
        public int Hours { get; }
        public int Minutes { get; }
        public Time(int hours, int minutes)
        {      
            Hours = hours + minutes / 60;
            Minutes = minutes % 60;
        }
        public Time AddMinutes(int minutes)
        {
            Time newTime = new Time(Hours, Minutes + minutes);
            return newTime;
        
        }
    }
        public void Main()
        {
            Time time = new Time(3,15);
            Console.WriteLine($"H:{time.Hours} M:{time.Minutes} uur");

            Time time1 = time.AddMinutes(50);
            Console.WriteLine($"H:{time1.Hours} M:{time1.Minutes} uur");

        }
```


### Meer info:
[Structs - C# language specification | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/structs)