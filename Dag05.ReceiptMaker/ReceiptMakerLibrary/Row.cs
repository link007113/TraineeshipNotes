namespace ReceiptMakerLibrary
{
    public class Row
    {
        public int Count;
        public string Name;
        public decimal Price;
        private decimal _totalRowPrice;

        public Row(string name, decimal price) : this(1, name, price)
        { 
        }
        public Row(int count, string name, decimal price)
        {
            Count = count;
            Name = name;
            Price = price;            
        }

        public decimal TotalPricePerRow =>  Price * Count; 

        }

    }
}