using Blok1.BlackJack;

namespace Blok1.BlackJack
{
    public class Player : PlayerBase
    {
        private List<PlayerHand> _hands = new List<PlayerHand>();

        public decimal Balance { get; internal set; }

        public IEnumerable<PlayerHand> Hands
        {
            get
            {
                for (int i = 0; i < _hands.Count; i++)
                {
                    yield return _hands[i];
                }
            }
        }

        public PlayerHand PrimaryHand => _hands.First();

        public Player(string name, decimal balance = 20M)
        {
            Name = name;
            Balance = balance;
            _hands.Add(new());
        }

        public void AddWinnings() => AddWinnings(PrimaryHand);

        public void AddWinnings(PlayerHand hand)
        {
            Balance += hand.Bet * 2;
        }

        public void AddWinningsBlackJack() => AddWinningsBlackJack(PrimaryHand);

        public void AddWinningsBlackJack(PlayerHand hand)
        {
            Balance += hand.Bet * 2.5M;
        }

        public PlayerHand GetPlayerHand(int index) => _hands[index];

        public void AddWinningsPush(PlayerHand hand)
        {
            Balance += hand.Bet;
        }

        public override void ClearHands()
        {
            _hands = new List<PlayerHand>
            {
                new PlayerHand()
            };
        }

        public bool GetCanDoubleDown(PlayerHand hand)
        {
            return hand.CanDoubleDown && Balance > hand.Bet;
        }

        public bool GetCanSplit(PlayerHand hand)
        {
            return hand.CanSplit && Balance > hand.Bet;
        }

        public void PlaceBet(decimal bet) => PlaceBet(bet, PrimaryHand);

        public void PlaceBet(decimal bet, PlayerHand hand)
        {
            if (bet > Balance)
            {
                throw new ArgumentOutOfRangeException("Not enough money");
            }
            Balance -= bet;
            hand.PlaceBet(bet);
        }

        public void SplitPair() => SplitPair(PrimaryHand);

        public void SplitPair(PlayerHand hand)
        {
            if (hand.CanSplit)
            {
                var secondHand = new PlayerHand(true);
                hand.IsSplit = true;
                PlaceBet(hand.Bet, secondHand);
                secondHand.AddCard(hand.Cards.Skip(1).First());
                hand.RemoveCard(hand.Cards.Skip(1).First());
                _hands.Add(secondHand);
            }
        }
    }
}