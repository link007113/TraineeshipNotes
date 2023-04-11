using System.Linq;

namespace Blok1.BlackJack
{
    public class Shoe
    {
        private readonly List<Card> _cards;

        public IEnumerable<Card> Cards
        {
            get
            {
                for (int i = 0; i < _cards.Count; i++)
                {
                    yield return _cards[i];
                }
            }
        }

        public bool MarkerReached => _cards.Count <= (312 / 4);

        public Shoe()
        {
            _cards = GetDecks();
        }

        public Card DrawCard(bool facedown = false)
        {
            Card givenCard = Cards.First();
            _cards.Remove(givenCard);

            if (facedown)
            {
                givenCard.Flip();
            }

            return givenCard;
        }

        public void Shuffle()
        {
            Random random = new();

            for (int i = _cards.Count; i > 0; i--)
            {
                int randomIndex = random.Next(i);
                int lastCardIndex = i - 1;
                SwitchCardPlaces(randomIndex, lastCardIndex);
            }
        }

        private List<Card> GetDeck()
        {
            var list = new List<Card>();
            foreach (var suit in Enum.GetValues<Suit>())
            {
                list.AddRange(Enum.GetValues<Rank>().Select(rank => new Card(suit, rank)));
            }

            return list;
        }

        private List<Card> GetDecks(int countOfDecks = 6)
        {
            List<Card> fullShoe = new();

            for (int passes = 1; passes <= countOfDecks; passes++)
            {
                fullShoe.AddRange(GetDeck());
            }
            return fullShoe;
        }

        private void SwitchCardPlaces(int randomIndex, int lastCardIndex)
        {
            Card shuffledCard = _cards[randomIndex];
            _cards[randomIndex] = _cards[lastCardIndex];
            _cards[lastCardIndex] = shuffledCard;
        }
    }
}