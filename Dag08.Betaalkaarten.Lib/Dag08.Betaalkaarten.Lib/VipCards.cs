using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag08.Betaalkaarten.Lib
{
    public class VipCards : BaseCard
    {
        public VipCards(string name, decimal saldo)
        {
            Name = name;
            Saldo = saldo;
            Discount = 10M;
        }

        public VipCards(string name, decimal saldo, decimal discount)
        {
            Name = name;
            Saldo = saldo;
            Discount = discount;
        }

        public override bool Pay(decimal amount)
        {
            if (amount < 0)
            {
                return false;
            }
            else
            {
                amount -= ((amount / 100) * Discount);
                Saldo -= amount;
                return true;
            }
        }
    }
}