using System.Globalization;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Day11.BarExcercise.Lib
{
    public class Bar
    {
        private Dictionary<int, List<Order>> tables;
        private Dictionary<string, decimal> tipJar;

        public Bar()
        {
            tables = new Dictionary<int, List<Order>>();
            tipJar = new Dictionary<string, decimal>();
        }

        #region NeemBestellingOp

        public void TakeOrder(int tableNumber, string waiterName, Drinks drink)
        {
            List<Drinks> drinks = new List<Drinks>
            {
                drink
            };
            TakeOrder(tableNumber, waiterName, drinks);
        }

        public void TakeOrder(int tableNumber, string waiterName, List<Drinks> drinks)
        {
            try
            {
                CheckIfTableExists(tableNumber);
            }
            catch
            {
                OpenTable(tableNumber);
            }

            tipJar.TryAdd(waiterName, 0);

            Order order = new Order
            {
                WaiterName = waiterName,
                Drinks = drinks
            };
            tables[tableNumber].Add(order);
        }

        private void OpenTable(int tableNumber)
        {
            tables[tableNumber] = new List<Order>();
        }

        #endregion NeemBestellingOp

        #region VraagRekening

        public string AskBill(int tableNumber)
        {
            CheckIfTableExists(tableNumber);
            Dictionary<Drinks, int> bill = GetCountPerDrink(tableNumber);
            decimal totalAmount = bill.Sum(drink => drink.Key.GetDrinkPrice() * drink.Value);

            return ReceiptBuilder(tableNumber, bill, totalAmount);
        }

        private static string ReceiptBuilder(int tableNumber, Dictionary<Drinks, int> bill, decimal totalAmount)
        {
            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine($"Bill for table {tableNumber}\n");

            foreach (KeyValuePair<Drinks, int> item in bill)
            {
                string itemPrice = ConvertDecimalToCurrencyString(item.Key.GetDrinkPrice() * item.Value);
                receipt.AppendLine($"{item.Value} - {item.Key}: {itemPrice}");
            }

            int maxLength = receipt.ToString().Split('\n').Max(line => line.Length);
            receipt.AppendLine(new string('-', maxLength));
            receipt.AppendLine($"Total amount: {ConvertDecimalToCurrencyString(totalAmount)}");

            return receipt.ToString();
        }

        private Dictionary<Drinks, int> GetCountPerDrink(int tableNumber)
        {
            Dictionary<Drinks, int> countPerDrink = new Dictionary<Drinks, int>();

            foreach (List<Drinks> drinksPerOrder in GetDrinksForTableNumber(tableNumber))
            {
                foreach (Drinks drink in drinksPerOrder)
                {
                    if (countPerDrink.ContainsKey(drink))
                    {
                        countPerDrink[drink]++;
                    }
                    else
                    {
                        countPerDrink[drink] = 1;
                    }
                }
            }

            return countPerDrink;
        }

        #endregion VraagRekening

        #region BetaalRekening

        public void PayBill(int tableNumber, decimal amount)
        {
            CheckIfTableExists(tableNumber);

            decimal totalAmount = 0;

            foreach (List<Drinks> drinksPerOrder in GetDrinksForTableNumber(tableNumber))
            {
                foreach (Drinks drink in drinksPerOrder)
                {
                    totalAmount += drink.GetDrinkPrice();
                }
            }

            if (amount < totalAmount) throw new PaymentInsufficientException();

            CalculateTip(tableNumber, amount, totalAmount);

            tables.Remove(tableNumber);
        }

        private void CalculateTip(int tableNumber, decimal amount, decimal totalAmount)
        {
            decimal tip = amount - totalAmount;
            List<string> checkedWaiters = new List<string>();

            foreach (Order waiterOrder in tables[tableNumber])
            {
                if (!checkedWaiters.Contains(waiterOrder.WaiterName))
                {
                    int count = tables[tableNumber].Count(o => o.WaiterName == waiterOrder.WaiterName);
                    decimal waiterTip = tip * (count / (decimal)tables[tableNumber].Count);

                    if (tipJar.TryGetValue(waiterOrder.WaiterName, out decimal currentTip))
                    {
                        tipJar[waiterOrder.WaiterName] = currentTip + waiterTip;
                    }
                    else
                    {
                        tipJar.Add(waiterOrder.WaiterName, waiterTip);
                    }

                    checkedWaiters.Add(waiterOrder.WaiterName);
                }
            }
        }

        #endregion BetaalRekening

        #region Helpers

        public string GetWaiterTipSummary(string waiterName)
        {
            if (!tipJar.ContainsKey(waiterName) || tipJar[waiterName] == 0)
            {
                return $"Waiter {waiterName} has not earned any tips.";
            }

            decimal tipAmount = tipJar[waiterName];

            return $"Waiter {waiterName} earned {ConvertDecimalToCurrencyString(tipAmount)} in tip.";
        }

        private static string ConvertDecimalToCurrencyString(decimal amount) => amount.ToString("C", new CultureInfo("fr-FR"));

        private void CheckIfTableExists(int tableNumber)
        {
            if (!tables.ContainsKey(tableNumber))
            {
                throw new ArgumentOutOfRangeException("Table does not exist");
            }
        }

        private IEnumerable<List<Drinks>> GetDrinksForTableNumber(int tableNumber)
        {
            foreach (Order order in tables[tableNumber])
            {
                yield return order.Drinks;
            }
        }

        #endregion Helpers
    }
}