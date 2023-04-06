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
            return suit switch
            {
                Suit.Spades => "♠",
                Suit.Hearts => "♥",
                Suit.Diamonds => "♦",
                Suit.Clubs => "♣",
                _ => "Unknown",
            };
        }
    }
}