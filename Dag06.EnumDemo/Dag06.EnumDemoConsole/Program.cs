using Dag06.EnumDemoLibrary;

namespace Dag06.EnumDemoConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Weather w = Weather.Sunny;
            WeatherProcessor(w);
        }

        static void WeatherProcessor(Weather weather)
        {
            Console.WriteLine(weather.WhichJacket());            
        }
    }
}