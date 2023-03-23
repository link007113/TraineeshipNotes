In c# heb je de mogelijkheid om zelf Exceptions te defineren. Dit kan je op de volgende manier doen:

### Voorbeeld:
```c#
    public class InvalidValutaException : Exception
    {
        public InvalidValutaException() 
        { 
        }

        public InvalidValutaException(string message) : base(message) 
        { 
        }

        public InvalidValutaException(string message, Exception innerException) : base(message, innerException) 
        { 
        }
    }
```

### Meer info:
[How to create user-defined exceptions](https://learn.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions)