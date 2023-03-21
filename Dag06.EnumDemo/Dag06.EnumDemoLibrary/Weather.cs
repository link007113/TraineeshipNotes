namespace Dag06.EnumDemoLibrary
{
    [Flags]
    public enum Weather
    {
        Sunny,
        Cloudy,
        Rainy,
    }

    public static class WeatherFunctions
    {
        // Extension Method
        // Static method in een static class
        // De eerste parameter heeft het 'this'-keyword
        public static string WhichJacket(this Weather weather) => weather switch
        {
            Weather.Sunny => "Geen jas",
            Weather.Cloudy => "jas",
            Weather.Rainy => "Regen Jas",
            _ => ""
        };

    }
}