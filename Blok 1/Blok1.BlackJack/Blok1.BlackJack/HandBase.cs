using System.Text;

namespace Blok1.BlackJack
{
    public abstract class HandBase
    {
        public virtual bool CanDoubleDown => false;

        public virtual bool CanSplit => false;

        public List<Card> Cards { get; }
        public string GameResult { get; private set; }
        public bool IsBlackJack => Cards.Count == 2 && TotalValue == 21 && !IsSplit;
        public bool IsBust => TotalValue > 21;
        public bool IsSplit { get; set; }

        public int TotalValue
        {
            get
            {
                int currentTotal = Cards.Sum(c => c.Rank.GetValue());

                if (currentTotal > 21 && Cards.Any(c => c.Rank == Rank.Ace))
                {
                    currentTotal -= 10;
                }

                return currentTotal;
            }
        }

        public HandBase()
        {
            Cards = new List<Card>();
            GameResult = string.Empty;
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public void SetGameResult(string result)
        {
            GameResult = result;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            // TODO: Cards next to each other
            string cards = string.Empty;
            sb.AppendLine("Cards:");
            cards = string.Join(' ', Cards.Select(c => c.GetAsciiArt()));
            sb.AppendLine(cards);
            if (!string.IsNullOrEmpty(GameResult))
            {
                sb.AppendLine($"{GameResult}");
            }
            if (Cards.All(c => c.FaceUp))
            {
                sb.AppendLine($"Total value: {TotalValue}");
            }
            return sb.ToString();
        }

        protected HandBase(bool isSplit) : this()
        {
            IsSplit = isSplit;
        }
    }
}