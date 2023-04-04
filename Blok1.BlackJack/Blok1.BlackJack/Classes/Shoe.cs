using Blok1.BlackJack.Enums;

namespace Blok1.BlackJack.Classes
{
    public class Shoe
    {
        public List<Card> Cards { get; private set; }

        public Shoe()
        {
            Cards = GetDecks();
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

        private List<Card> GetDeck()
        {
            List<Card> deck = new List<Card>();
            foreach (var suit in Enum.GetValues<Suit>())
            {
                foreach (var rank in Enum.GetValues<Rank>())
                {
                    deck.Add(new Card(suit, rank));
                }
            }
            return deck;
        }

        public void Shuffle()
        {
            List<Card> shuffledShoe = new List<Card>();
            Random random = new Random();

            for (int i = Cards.Count; i > 0; i--)
            {
                int randomNumber = random.Next(0, Cards.Count - 1);
                shuffledShoe.Add(Cards[randomNumber]);
                Cards.Remove(Cards[randomNumber]);
            }
            Cards = shuffledShoe;
        }

        public Card DrawCard(bool visible = true)
        {
            Card givenCard = Cards.First();
            Cards.Remove(givenCard);
            givenCard.Visible = visible;
            return givenCard;
        }

        /// <summary>
        /// You Cheater!
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        public Card DrawCard(Rank rank, bool visible = true)
        {
            Card givenCard = Cards.First(c => c.Rank == rank);
            Cards.Remove(givenCard);
            givenCard.Visible = visible;
            return givenCard;
        }
    }
}