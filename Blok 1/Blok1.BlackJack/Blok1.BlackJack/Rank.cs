namespace Blok1.BlackJack
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
        public static int GetValue(this Rank rank)
        {
            return rank switch
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

        public static string ToShortString(this Rank rank) => rank switch
        {
            Rank.Ace => "A",
            Rank.Two => "2",
            Rank.Three => "3",
            Rank.Four => "4",
            Rank.Five => "5",
            Rank.Six => "6",
            Rank.Seven => "7",
            Rank.Eight => "8",
            Rank.Nine => "9",
            Rank.Ten => "10",
            Rank.Jack => "J",
            Rank.Queen => "Q",
            Rank.King => "K",
            _ => ""
        };
    }
}