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
        public static int GetValue(this Rank rank, decimal currentTotal = 0)
        {
            if (rank == Rank.Ace)
            {
                return currentTotal + 11 <= 21 ? 11 : 1;
            }

            return rank switch
            {
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
}