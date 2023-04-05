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
            Random random = new Random();

            for (int i = Cards.Count; i > 0; i--)
            {
                int randomIndex = random.Next(i);
                int lastCardIndex = i - 1;
                Card shuffledCard = Cards[randomIndex];
                Cards[randomIndex] = Cards[lastCardIndex];
                Cards[lastCardIndex] = shuffledCard;
            }
        }

        private List<Card> GetDeck()
        {
            return (from suit in Enum.GetValues<Suit>()
                    from rank in Enum.GetValues<Rank>()
                    select new Card(suit, rank)).ToList();
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
    }
}