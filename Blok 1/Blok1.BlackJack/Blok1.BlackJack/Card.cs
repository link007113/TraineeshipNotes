namespace Blok1.BlackJack
{
    public record Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public bool FaceUp { get; protected set; }

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
            return FaceUp ? $"{Suit.ToCharacter()} {Rank} of {Suit}" : "## Face Down ##";
        }

        public virtual void Flip()
        {
            FaceUp = !FaceUp;
        }
    }
}