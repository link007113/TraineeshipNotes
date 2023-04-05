namespace Blok1.BlackJack
{
    public class Player : PlayerBase
    {
        public decimal Balance { get; set; }
        public List<HandPlayer> Hands { get; set; } = new List<HandPlayer>();
        public HandPlayer PrimaryHand => Hands.First();

        public Player(string name, decimal balance = 20M, HandPlayer hand = null)
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

        public override void ClearHands()
        {
            Hands = new List<HandPlayer>
            {
                new HandPlayer()
            };
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