using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok1.BlackJack
{
    public class Dealer : PlayerBase
    {
        public DealerHand PrimaryHand;

        public Dealer()
        {
            Name = "Dealer";
            PrimaryHand = new DealerHand();
        }

        public override void ClearHands()
        {
            PrimaryHand = new DealerHand();
        }

        internal void Stand(Shoe shoe)
        {
            PrimaryHand.ShowAllCards();
            while (PrimaryHand.TotalValue < 17)
            {
                PrimaryHand.AddCard(shoe.DrawCard());
            }
        }
    }
}