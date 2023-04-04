namespace Blok1.BlackJack
{
    public class Player : PlayerBase
    {
        public decimal Balance { get; set; }
        public HandPlayer PrimaryHand => Hands.First() as HandPlayer;

        public Player(string name, decimal balance = 20M, HandBase hand = null)
        {
            if (hand == null)
            {
                hand = new HandPlayer();
            }
            Name = name;
            Balance = balance;
            Hands.Add(hand);
        }

        public void AddWinnings() => AddWinnings(PrimaryHand);

        public void AddWinnings(HandPlayer hand)
        {
            Balance += hand.Bet * 2;
        }

        public void AddWinningsBlackJack() => AddWinningsBlackJack(PrimaryHand);

        public void AddWinningsBlackJack(HandPlayer hand)
        {
            Balance += hand.Bet * 2.5M;
        }

        public void AddWinningsPush(HandPlayer hand)
        {
            Balance += hand.Bet;
        }

        public void PlaceBet(decimal bet) => PlaceBet(bet, PrimaryHand);

        public void PlaceBet(decimal bet, HandPlayer hand)
        {
            if (bet > Balance)
            {
                throw new ArgumentOutOfRangeException("Not enough money");
            }
            Balance -= bet;
            hand.PlaceBet(bet);
        }

        public void ReturnBet() => AddWinningsPush(PrimaryHand);

        public void SplitPair() => SplitPair(PrimaryHand);

        public void SplitPair(HandPlayer hand)
        {
            if (hand.CanSplit)
            {
                var secondHand = new HandPlayer();
                PlaceBet(hand.Bet, secondHand);
                secondHand.Cards.Add(hand.Cards[1]);
                hand.Cards.Remove(hand.Cards[1]);
                Hands.Add(secondHand);
            }
        }
    }
}