namespace Blok1.BlackJack
{
    public enum Suit
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }

    public static class SuitFunctions
    {
        public static string ToCharacter(this Suit suit)
        {
            switch (suit)
            {
                case Suit.Spades:
                    return "♠";

                case Suit.Hearts:
                    return "♥";

                case Suit.Diamonds:
                    return "♦";

                case Suit.Clubs:
                    return "♣";

                default:
                    return "Unknown";
            }
        }
    }
}