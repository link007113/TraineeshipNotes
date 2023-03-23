using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag08.Betaalkaarten.Lib
{
    public abstract class BaseCard
    {
        public string Name { get; set; } = String.Empty;
        public decimal Saldo { get; protected set; }
        public decimal Discount { get; protected set; } = 0M;

        public abstract bool Pay(decimal amount);
    }
}