using System.Linq;

namespace Blok1.BlackJack
{
    public class Shoe
    {
        public List<Card> Cards { get; }

        public Shoe()
        {
            Cards = GetDecks();
        }

        public Card DrawCard(bool facedown = false)
        {
            Card givenCard = Cards.First();
            Cards.Remove(givenCard);

            if (facedown)
            {
                givenCard.Flip();
            }

            return givenCard;
        }

        public void Shuffle()
        {
            Random random = new();

            for (int i = Cards.Count; i > 0; i--)
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
            Card shuffledCard = Cards[randomIndex];
            Cards[randomIndex] = Cards[lastCardIndex];
            Cards[lastCardIndex] = shuffledCard;
        }
    }
}