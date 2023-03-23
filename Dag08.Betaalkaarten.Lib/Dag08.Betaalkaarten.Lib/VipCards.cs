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
            amount -= ((amount / 100) * Discount);
            if (amount < 0)
            {
                throw new SaldoTooLowException($"“Uw saldo van {Math.Round(Saldo, 2, MidpointRounding.AwayFromZero)} Euro is ontoereikend om een bedrag van {Math.Round(Saldo, 2, MidpointRounding.AwayFromZero)} mee te betalen”");
            }
            else
            {
                Saldo -= amount;
                return true;
            }
        }
    }
}