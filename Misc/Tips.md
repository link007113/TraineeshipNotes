## Naamgeving
``` c#
// Dit heet een function-arrow
public decimal TotalPricePerRow =>  Price * Count; 
```
### Meer info:
[# C#-coderingsconventies](https://learn.microsoft.com/nl-nl/dotnet/csharp/fundamentals/coding-style/coding-conventions)

## Internals zichtbaar maken voor een bepaalde assemlby
Je internals kan je zichtbaar maken voor een project kan je het volgende gebruiken:

1. Voeg een AssemblyInfo toe aan je project, vanuit waar je je internals wilt laten zien
2. Voeg volgende code toe waar de text tussen de quotes de naam van het project staat waar je het zichtbaar voor wilt maken.
```c#
[assembly: InternalsVisibleTo("Dag07.InheritanceDemo.Tests")]
```