namespace Day11.BarExcercise.Lib
{
    [Flags]
    public enum Drinks
    {
        Coffee,
        AuLait,
        Tea,
        Cola,
        Sinas,
        Cassis,
        BeerTap,
        BeerBottle,
        WineRedGlass,
        WineRoseGlass,
        WineRedBottle,
        WineRoseBottle
    }

    public static class DrinkFunctions
    {
        public static decimal GetDrinkPrice(this Drinks drink) => drink switch
        {
            Drinks.Coffee => 1.90m,
            Drinks.AuLait => 2.10m,
            Drinks.Tea => 1.50m,
            Drinks.Cola => 2.50m,
            Drinks.Sinas => 2.50m,
            Drinks.Cassis => 3.00m,
            Drinks.BeerTap => 3.50m,
            Drinks.BeerBottle => 4.00m,
            Drinks.WineRedGlass => 5.00m,
            Drinks.WineRoseGlass => 4.00m,
            Drinks.WineRedBottle => 25.00m,
            Drinks.WineRoseBottle => 20.00m,
            _ => throw new ArgumentException("Invalid drink type")
        };
    }
}