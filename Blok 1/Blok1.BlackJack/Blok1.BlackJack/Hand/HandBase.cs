using System.Text;

namespace Blok1.BlackJack
{
    public abstract class HandBase
    {
        private readonly List<Card> _cards;

        public IEnumerable<Card> Cards => _cards;
        public GameResult GameResult { get; private set; } = GameResult.None;
        public bool IsBlackJack => Cards.Count() == 2 && TotalValue == 21 && !IsSplit;
        public bool IsBust => TotalValue > 21;
        public bool IsSplit { get; set; }

        public int TotalValue
        {
            get
            {
                int currentTotal = Cards.Sum(c => c.Rank.GetValue());
                int countOfAces = Cards.Count(c => c.Rank == Rank.Ace);

                for (int loop = countOfAces; loop > 0 && currentTotal > 21; loop--)
                {
                    currentTotal -= 10;
                }

                return currentTotal;
            }
        }

        public HandBase()
        {
            _cards = new List<Card>();
            GameResult = GameResult.None;
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public void RemoveCard(Card card)
        {
            _cards.Remove(card);
        }

        public void SetGameResult(GameResult result)
        {
            GameResult = result;
        }

        protected HandBase(bool isSplit) : this()
        {
            IsSplit = isSplit;
        }
    }
}