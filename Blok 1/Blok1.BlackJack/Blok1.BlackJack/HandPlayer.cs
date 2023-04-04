using System.Linq;
using System.Text;

namespace Blok1.BlackJack
{
    public class HandPlayer : HandBase
    {
        public decimal Bet { get; private set; }

        public override bool CanDoubleDown
        {
            get
            {
                if (Cards.Count == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override bool CanSplit
        {
            get
            {
                return Cards.Count == 2 && Cards[0].Value == Cards[1].Value;
            }
        }

        public HandPlayer(decimal bet = 0) : base()
        {
            Bet = bet;
        }

        public void PlaceBet(decimal bet)
        {
            Bet += bet;
        }

        public override string ToString()
        {
            string toString = String.Empty;
            if (Bet > 0)
            {
                toString += $"Bet: {Bet}\n";
            }

            return toString + base.ToString();
        }
    }
}