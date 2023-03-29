using Day11.BarExcercise.Lib;

namespace Day11.BarExcercise.Program
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Order1();
        }

        private static void Order1()
        {
            Bar bar = new Bar();
            int tableNumber1 = 1;

            string waiterName1 = "John";
            string waiterName2 = "Barry";
            string waiterName3 = "Dave";

            List<Drinks> drinks1 = new List<Drinks>();
            drinks1.Add(Drinks.Cola);
            drinks1.Add(Drinks.BeerBottle);
            drinks1.Add(Drinks.BeerBottle);

            List<Drinks> drinks2 = new List<Drinks>();
            drinks2.Add(Drinks.WineRedBottle);
            drinks2.Add(Drinks.WineRoseBottle);

            List<Drinks> drinks3 = new List<Drinks>();
            drinks3.Add(Drinks.Cassis);
            drinks3.Add(Drinks.Sinas);

            decimal amountPaid1 = 150m;

            bar.TakeOrder(tableNumber1, waiterName1, drinks1);
            bar.TakeOrder(tableNumber1, waiterName2, drinks2);
            bar.TakeOrder(tableNumber1, waiterName3, drinks3);
            bar.TakeOrder(tableNumber1, waiterName1, drinks3);

            Console.WriteLine(bar.AskBill(tableNumber1));

            bar.PayBill(tableNumber1, amountPaid1);

            Console.WriteLine();
            Console.WriteLine($"Amount paid:{amountPaid1}");
            Console.WriteLine(bar.GetWaiterTipSummary(waiterName1));
            Console.WriteLine(bar.GetWaiterTipSummary(waiterName2));
            Console.WriteLine(bar.GetWaiterTipSummary(waiterName3));
        }
    }
}