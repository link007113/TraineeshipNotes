namespace Blok1.BlackJack.Enums
{
    public enum Rank
    {
        Ace,
        King,
        Queen,
        Jack,
        Ten,
        Nine,
        Eight,
        Seven,
        Six,
        Five,
        Four,
        Three,
        Two
    }

    public static class RankFunctions
    {
        //Gets the value of the card, Ace can be 1 or 11 depending on the situation
        public static int GetValue(this Rank rank) => rank switch
        {
            Rank.Ace => 11,
            Rank.King => 10,
            Rank.Queen => 10,
            Rank.Jack => 10,
            Rank.Ten => 10,
            Rank.Nine => 9,
            Rank.Eight => 8,
            Rank.Seven => 7,
            Rank.Six => 6,
            Rank.Five => 5,
            Rank.Four => 4,
            Rank.Three => 3,
            Rank.Two => 2,
            _ => 0,
        };
    }
}