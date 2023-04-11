using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok1.BlackJack
{
    public class DealerHand : HandBase
    {
        public void ShowAllCards()
        {
            foreach (var card in Cards.Where(c => !c.FaceUp))
            {
                card.Flip();
            }
        }
    }
}