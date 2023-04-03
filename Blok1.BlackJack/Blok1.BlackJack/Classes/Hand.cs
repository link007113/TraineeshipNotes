using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok1.BlackJack.Classes
{
    public class Hand
    {
        public Hand()
        {
            Cards = new List<Card>();
        }

        public Hand(decimal bet) : this()
        {
            Bet = bet;
        }

        public decimal Bet { get; private set; }
        public List<Card> Cards { get; }

        public bool IsBlackJack
        {
            get
            {
                return Cards.Count == 2 && TotalValue == 21;
            }
        }

        public bool IsBust
        {
            get
            {
                return TotalValue > 21;
            }
        }

        public bool CanSplit
        {
            get
            {
                return Cards.Count == 2 && Cards[0].Rank == Cards[1].Rank;
            }
        }

        public int TotalValue
        {
            get
            {
                return Cards.Sum(c => c.Value);
            }
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public void PlaceBet(decimal bet)
        {
            Bet = bet;
        }

        public void ShowAllCards() => Cards.Where(c => !c.Visible).Select(c => c.Visible = true);

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Bet: {Bet}");
            sb.AppendLine($"Total value: {TotalValue}");
            sb.AppendLine($"Is BlackJack: {IsBlackJack}");
            sb.AppendLine($"Is Bust: {IsBust}");
            sb.AppendLine($"Can Split: {CanSplit}");
            sb.AppendLine("Cards:");
            foreach (var card in Cards)
            {
                sb.AppendLine(card.ToString());
            }
            return sb.ToString();
        }
    }
}