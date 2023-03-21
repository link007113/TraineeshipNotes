using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptMakerLibrary
{
    public class Receipt
    {
        public long ReceiptNr;

        private static long _receiptNr ;
        private List<Row> _rows;

        public Receipt()
        {
            _rows = new List<Row>();
            _receiptNr = _receiptNr + 1;
            ReceiptNr = _receiptNr;
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

        public override string ToString()
        {
            string receiptPrint = string.Empty;

            foreach (Row row in _rows)
            {
                receiptPrint += $"Aantal:{row.Count}|\tNaam: {row.Name}\tPrijs:{row.Price}\t|{row.TotalPricePerRow}\n";
            }
            receiptPrint += "___________________________________________\n";
            receiptPrint += $"\t\t\tTotaal:{TotalPrice}\n";
            receiptPrint += $"Bonnummer:{ReceiptNr}\t\t\t\n";

            return receiptPrint;
        }        

    }
}
