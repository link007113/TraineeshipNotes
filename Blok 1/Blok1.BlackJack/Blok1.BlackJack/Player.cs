using System.Reflection.Metadata;

namespace Blok1.BlackJack
{
    public class Player : PlayerBase
    {
        public decimal Balance { get; internal set; }

        public List<HandPlayer> Hands { get; private set; } = new List<HandPlayer>();

        public HandPlayer PrimaryHand => Hands.First();

        public Player(string name, decimal balance = 20M)
        {
            Name = name;
            Balance = balance;
            Hands.Add(new());
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

        public bool GetCanDoubleDown(HandPlayer hand)
        {
            return hand.CanDoubleDown && Balance > hand.Bet;
        }

        public bool GetCanSplit(HandPlayer hand)
        {
            return hand.CanSplit && Balance > hand.Bet;
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

        public void SplitPair() => SplitPair(PrimaryHand);

        public void SplitPair(HandPlayer hand)
        {
            if (hand.CanSplit)
            {
                var secondHand = new HandPlayer(true);
                hand.IsSplit = true;
                PlaceBet(hand.Bet, secondHand);
                secondHand.Cards.Add(hand.Cards[1]);
                hand.Cards.Remove(hand.Cards[1]);
                Hands.Add(secondHand);
            }
        }
    }
}