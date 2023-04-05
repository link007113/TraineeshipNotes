using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok1.BlackJack
{
    public class Dealer : PlayerBase
    {
        public bool IsDealer => true;

        public HandDealer PrimaryHand;

        public Dealer()
        {
            Name = "Dealer";
            PrimaryHand = new HandDealer();
        }

        public override void ClearHands()
        {
            PrimaryHand = new HandDealer();
        }
    }
}