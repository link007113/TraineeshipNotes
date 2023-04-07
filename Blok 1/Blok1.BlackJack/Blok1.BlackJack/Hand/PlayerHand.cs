using System.Linq;
using System.Text;

namespace Blok1.BlackJack
{
    public class PlayerHand : HandBase
    {
        public decimal Bet { get; private set; }

        public bool CanDoubleDown => Cards.Count() == 2;

        public bool CanSplit => Cards.Count() == 2 && Cards.First().Value == Cards.Skip(1).First().Value;
        public bool IsCharlie => Cards.Count() == 5 && !IsBust;
        public bool Stands { get; set; } = false;

        public PlayerHand(decimal bet = 0)
        {
            Bet = bet;
        }

        public PlayerHand(bool isSplit) : this()
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