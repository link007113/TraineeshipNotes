using Blok1.BlackJack.Enums;

namespace Blok1.BlackJack.Classes
{
    public record Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public bool Visible { get; set; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
            Visible = true;
        }

        public Card(Suit suit, Rank rank, bool visible)
        {
            Suit = suit;
            Rank = rank;
            Visible = visible;
        }

        public int Value => Rank.GetValue();

        public override string ToString()
        {
            return Visible ? $"{Rank} of {Suit}" : "Facedown Card";
        }
    }
}