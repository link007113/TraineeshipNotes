namespace Blok1.BlackJack
{
    public record Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public bool FaceUp { get; internal set; }

        public Card(Suit suit, Rank rank) : this(suit, rank, true)
        {
        }

        public Card(Suit suit, Rank rank, bool faceUp)
        {
            Suit = suit;
            Rank = rank;
            FaceUp = faceUp;
        }

        public int Value => Rank.GetValue();

        public override string ToString()
        {
            return FaceUp ? $"{Rank} of {Suit}" : "## Face Down ##";
        }
    }
}