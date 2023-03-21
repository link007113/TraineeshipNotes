## Inleiding

In c# kan je functionalitiet van de operators overschrijven.
Dit kan je bijvoorbeeld gebruiken voor je eigen classes



```c#
public static Time operator+ (Time a, Time b)
{

return new Time(a.Hours + b.Hours, a.Minutes + b.Minutes)
}

```