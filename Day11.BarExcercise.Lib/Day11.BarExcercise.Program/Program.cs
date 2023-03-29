using Day11.BarExcercise.Lib;

namespace Day11.BarExcercise.Program
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Order1();
            Order2();
        }

        private static void Order1()
        {
            Bar bar = new Bar();
            string waiterName = "John";
            int table = 1;

            bar.OpenTable(table);
            bar.TakeOrder(table, waiterName, Drinks.Cola);
            Console.WriteLine(bar.AskBill(table));
            bar.PayBill(table, 25m);
            Console.WriteLine(bar.GetWaiterTipSummary(waiterName));
        }

        private static void Order2()
        {
            Bar bar = new Bar();
            string waiterName1 = "John";
            string waiterName2 = "Barry";

            int table = 1;

            bar.OpenTable(table);
            bar.TakeOrder(table, waiterName1, Drinks.Cola);

            List<Drinks> drinks = new List<Drinks>();
            drinks.Add(Drinks.Cola);
            drinks.Add(Drinks.WineRedGlass);

            bar.TakeOrder(table, waiterName2, drinks);

            bar.TakeOrder(table, waiterName1, Drinks.WineRoseBottle);

            Console.WriteLine(bar.AskBill(table));
            bar.PayBill(table, 50m);
            Console.WriteLine(bar.GetWaiterTipSummary(waiterName1));
            Console.WriteLine(bar.GetWaiterTipSummary(waiterName2));
        }
    }
}