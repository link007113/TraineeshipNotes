namespace Day11.BarExcercise.Lib
{
    public class Bar
    {
        private Dictionary<int, Dictionary<string, List<Drinks>>> tables;
        private Dictionary<string, decimal> tipJar;

        public Bar()
        {
            tables = new Dictionary<int, Dictionary<string, List<Drinks>>>();
            tipJar = new Dictionary<string, decimal>();
        }

        public void OpenTable(int tableNumber)
        {
            tables[tableNumber] = new Dictionary<string, List<Drinks>>();
        }

        public void TakeOrder(int tableNumber, string waiterName, Drinks drink)
        {
            CheckIfTableExists(tableNumber);

            tipJar.TryAdd(waiterName, 0);

            tables.TryAdd(tableNumber, new Dictionary<string, List<Drinks>>());
            tables[tableNumber].TryAdd(waiterName, new List<Drinks>());
            tables[tableNumber][waiterName].Add(drink);
        }

        public void TakeOrder(int tableNumber, string waiterName, List<Drinks> drinks)
        {
            drinks.ForEach(drink => TakeOrder(tableNumber, waiterName, drink));
        }

        public string AskBill(int tableNumber)
        {
            CheckIfTableExists(tableNumber);

            var bill = tables[tableNumber].Values
                .SelectMany(waiterOrders => waiterOrders)
                .GroupBy(drink => drink)
                .ToDictionary(group => group.Key, group => group.Count());

            decimal totalAmount = bill.Sum(item => item.Key.GetDrinkPrice() * item.Value);

            var billString = $"Bill for table {tableNumber}\n\n";
            billString += string.Join("\n", bill.Select(item => $"{item.Key}: {item.Value}")) + "\n";
            billString += $"Total amount: {totalAmount:C2}";

            return billString;
        }

        public void PayBill(int tableNumber, decimal amount)
        {
            CheckIfTableExists(tableNumber);

            decimal totalAmount = tables[tableNumber].Values
                .SelectMany(waiterOrders => waiterOrders)
                .Sum(drink => drink.GetDrinkPrice());

            if (amount < totalAmount)
            {
                throw new PaymentInsufficientException();
            }

            decimal tip = amount - totalAmount;
            foreach (var waiterOrders in tables[tableNumber])
            {
                decimal waiterTip = tip * (waiterOrders.Value.Count / (decimal)tables[tableNumber].Count);
                string waiterName = waiterOrders.Key;
                tipJar[waiterName] += waiterTip;
            }

            tables.Remove(tableNumber);
        }

        public string GetWaiterTipSummary(string waiterName)
        {
            if (!tipJar.ContainsKey(waiterName))
            {
                return $"Waiter {waiterName} has not earned any tips.";
            }

            decimal tipAmount = tipJar[waiterName];

            return $"Waiter {waiterName} earned {tipAmount:C2} in tip.";
        }

        private void CheckIfTableExists(int tableNumber)
        {
            if (!tables.ContainsKey(tableNumber))
            {
                throw new ArgumentException("Table does not exist");
            }
        }
    }
}