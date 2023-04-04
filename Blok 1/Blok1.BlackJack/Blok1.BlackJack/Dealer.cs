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

        public HandDealer PrimaryHand => Hands.First() as HandDealer;

        public Dealer()
        {
            Name = "Dealer";
            Hands = new List<HandBase>
            {
                new HandDealer()
            };
        }

        public void ClearHands()
        {
            Hands = new List<HandBase>
            {
                new HandDealer()
            };
        }
    }
}