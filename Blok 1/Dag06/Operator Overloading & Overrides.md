## Inleiding

In c# kan je functionaliteit van de operators overschrijven.
Hiermee kan je dus bepalen wat er gebeurt als je bijvoorbeeld een object wil samen voegen of wilt vergelijken met elkaar. 
Dit kan je bijvoorbeeld gebruiken voor je eigen classes.
De voorbeelden gebruiken de struct van [[Structs]]
```c#
// Overschrijft Time + Time
public static Time operator+ (Time a, Time b)
{
	return new Time(a.Hours + b.Hours, a.Minutes + b.Minutes)
}
```
```c#
// Overschrijft Time == Time & Time != Time
#region equality
public static bool operator ==(Time a, Time b)
{
    return a.Hours == b.Hours && a.Minutes == b.Minutes;
}
public static bool operator !=(Time a, Time b)
{
    return !(a ==b);
}
public override bool Equals(object? obj)
{
    return obj != null &&
        obj.GetType() == typeof(Time) &&
        this == (Time)obj;
    //  return obj is Time &&
    //  this == (Time)obj;
    //  return (obj is Time that) && this == that;
}
public override int GetHashCode()
{
    return Hours * 60 + Minutes;
}
#endregion
```

Zo kan je ook de wijze waarop een type gecast wordt overschrijven
Bijv.:
```c#
public static explicit operator Time(double timeValue)
{
	int hours = (int)timeValue;
	int minutes = (int)((timeValue - hours) * 100);
	return new Time(hours, minutes);        
}
// Te gebruiken door:
Time time2 = (Time)3.5;
```


Je kan ook de standaard ToString method overschrijven:
```c#
public override string ToString()
{
    return $"H:{this.Hours} M:{this.Minutes} uur";
}
```

