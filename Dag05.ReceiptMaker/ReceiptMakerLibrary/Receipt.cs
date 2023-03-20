using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptMakerLibrary
{
    public class Receipt
    {
        private List<Row> _rows;

        public Receipt()
        {
            _rows = new List<Row>();
        }

        public decimal TotalPrice
        {
            get { return _rows.Sum(r => r.TotalPricePerRow); }

        }

        public void Scan(string articleName, decimal price)
        {
            foreach (Row row in _rows)
            {
                if (row.Name == articleName)
                {
                    row.Count++;
                    return;
                }
            }

            if (_rows.Count < 10)
            {
                Row newRow = new Row(articleName, price);
                _rows.Add(newRow);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(_rows.Count), "Receipt doesn't have space for more items.");
            }




        }

        public string Print()
        {
            string receiptPrint = string.Empty;

            foreach (Row row in _rows)
            {
                receiptPrint += $"Aantal:{row.Count}|\tNaam: {row.Name}\tPrijs:{row.Price}\t|{row.TotalPricePerRow}\n";
            }
            receiptPrint += "_____________________________\n";
            receiptPrint += $"\t\t\tTotaal:{TotalPrice}\n";

            return receiptPrint;
        }


    }
}
