namespace Blok1.BlackJack
{
    public record Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public bool FaceUp { get; private set; }

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
        public string GetAsciiArt()
        {
            if (FaceUp)
            {
                return $@"
┌─────────┐
│ {Rank.ToShortString(),-2}      │
│         │
│    {Suit.ToCharacter(),-2}   │
│         │
│      {Rank.ToShortString(),2} │
└─────────┘";
            }
            else
            {
                return @"
┌─────────┐
│ *       │
│         │
│    *    │
│         │
│      *  │
└─────────┘";
            }
        }

        public virtual void Flip()
        {
            FaceUp = !FaceUp;
        }
    }
}