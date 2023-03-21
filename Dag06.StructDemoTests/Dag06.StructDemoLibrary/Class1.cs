using System.Diagnostics.CodeAnalysis;

namespace Dag06.StructDemoLibrary
{
    public readonly struct Time
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
            Time newTime = new(Hours, Minutes + minutes);
            return newTime;

        }
        public static Time operator +(Time a, Time b)
        {

            return new Time(a.Hours + b.Hours, a.Minutes + b.Minutes);
        }
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
        public static explicit operator Time(double timeValue)
        {
            int hours = (int)timeValue;
            int minutes = (int)((timeValue - hours) * 100);
            return new Time(hours, minutes);
        }

        public override string ToString()
        {
            return $"H:{this.Hours} M:{this.Minutes} uur";
        }


    }
}