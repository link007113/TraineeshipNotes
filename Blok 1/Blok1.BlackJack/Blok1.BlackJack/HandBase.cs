using System.Text;

namespace Blok1.BlackJack
{
    public class HandBase
    {
        public virtual bool CanDoubleDown
        {
            get
            {
                return false;
            }
        }

        public virtual bool CanSplit
        {
            get
            {
                return false;
            }
        }

        public List<Card> Cards { get; }

        public string GameResult { get; set; }

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

        public int TotalValue
        {
            get
            {
                int currentTotal = Cards.Sum(c => c.Rank.GetValue());

                if (currentTotal > 21 && Cards.Any(c => c.Rank == Rank.Ace))
                {
                    currentTotal -= 11;
                    currentTotal++;
                    return currentTotal;
                }

                return currentTotal;
            }
        }

        public HandBase()
        {
            Cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (!Cards.Any(c => !c.FaceUp))
            {
                sb.AppendLine($"Total value: {TotalValue}");
            }
            sb.AppendLine("Cards:");
            foreach (var card in Cards)
            {
                sb.AppendLine($"\t{card.ToString()}");
            }
            if (!string.IsNullOrEmpty(GameResult))
            {
                sb.AppendLine($"\t{GameResult}");
            }
            return sb.ToString();
        }
    }
}