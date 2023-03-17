namespace Project_2;
class Program
{
    static void Main(string[] args)
    {
        PaintCalculation();
    }
    static void PaintCalculation()
    {
        double height = ParseInputToDouble("Wat is de hoogte van de kamer? Bijv. 2");
        double width = ParseInputToDouble("Wat is de breedte van de kamer? Bijv. 4");
        double length = ParseInputToDouble("Wat is de lengte van de kamer? Bijv. 6");

        double totalSurface = CalculateSurface(height, width, length);

        Console.WriteLine($"De totale oppervlakte van de 4 muren is: {totalSurface}");

        int doorCount = 1;
        int windowCount = 2;

        totalSurface = CalculateSurface(height, width, length, windowCount, doorCount);

        Console.WriteLine($"De totale oppervlakte van de 4 muren en {doorCount} deur(en) en {windowCount} raamen is: {totalSurface}");

        double minPaintUsage = 7.0;
        double maxPaintUsage = 10.0;

        Console.WriteLine($"Bij normaal gebruik zou je maximaal {CalculatePaintUsage(totalSurface, minPaintUsage)} blikken nodig hebben en minimaal {CalculatePaintUsage(totalSurface, maxPaintUsage)}");
    }
    static double CalculateSurface(double height, double width, double length)
    {
        double surfaceLongWalls = (height * width) * 2;
        double surfaceShortWalls = (height * length) * 2;
        return surfaceLongWalls + surfaceShortWalls;
    }
    static double CalculateSurface(double height, double width, double length, int windowCount = 0, int doorCount = 0)
    {
        double totalSurface = CalculateSurface(height, width, length);
        double doorSurface = doorCount * (0.80 * 2.0);
        double windowSurface = windowCount * (1.0 * 1.5);

        return totalSurface - (doorSurface + windowSurface);
    }
    static double CalculatePaintUsage(double surface, double paintUsage)
    {
        return Math.Ceiling(surface / paintUsage);
    }
    #region Helpers
    private static double ParseInputToDouble(string message)
    {
        double result = 0;
        Console.WriteLine(message);
        string input = Console.ReadLine();

        while (!double.TryParse(input, out result))
        {
            Console.WriteLine($"That's not a valid input. {message}");
            input = Console.ReadLine();
        }
        return result;
    }
    #endregion
}
