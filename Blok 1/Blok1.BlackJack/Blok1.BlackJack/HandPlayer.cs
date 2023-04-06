using System.Linq;
using System.Text;

namespace Blok1.BlackJack
{
    public class HandPlayer : HandBase
    {
        public decimal Bet { get; private set; }

        public override bool CanDoubleDown => Cards.Count == 2;

        public override bool CanSplit => Cards.Count == 2 && Cards[0].Value == Cards[1].Value;
        public bool IsCharlie => Cards.Count == 5 && !IsBust;

        public HandPlayer(decimal bet = 0)
        {
            Bet = bet;
        }

        public HandPlayer(bool isSplit) : this()
        {
            IsSplit = isSplit;
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