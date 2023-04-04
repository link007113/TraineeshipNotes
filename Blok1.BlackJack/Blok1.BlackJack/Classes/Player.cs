using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok1.BlackJack.Classes
{
    public class Player
    {
        public Player(string name, decimal balance = 20M)
        {
            Name = name;
            Balance = balance;
            Hands.Add(new Hand());
        }

        public Player(string name, decimal balance, bool isDealer = false) : this(name, balance = 20M)
        {
            IsDealer = isDealer;
        }

        public decimal Balance { get; set; }
        public Hand Hand => Hands.FirstOrDefault();
        public List<Hand> Hands { get; set; } = new List<Hand>();

        //public IEnumerable<Hand> Hand
        //{
        //    get
        //    {
        //        for (int i = 0; i < Hands.Count; i++)
        //        {
        //            yield return Hands[i];
        //        }
        //    }
        //}
        public bool IsDealer { get; }

        public string Name { get; set; }

        public void AddWinnings() => AddWinnings(Hand);

        public void AddWinnings(Hand hand)
        {
            Balance += hand.Bet * 2;
        }

        public void AddWinningsBlackJack() => AddWinningsBlackJack(Hand);

        public void AddWinningsBlackJack(Hand hand)
        {
            Balance += hand.Bet * 2.5M;
        }

        public void ReturnBet() => AddWinningsPush(Hand);

        public void AddWinningsPush(Hand hand)
        {
            Balance += hand.Bet;
        }

        public void ClearHand()
        {
            Hands = new List<Hand>();
            Hands.Add(new Hand());
        }

        public void PlaceBet(decimal bet) => PlaceBet(bet, Hand);

        public void PlaceBet(decimal bet, Hand hand)
        {
            if (bet > Balance)
            {
                throw new ArgumentOutOfRangeException("Not enough money");
            }
            Balance -= bet;
            hand.PlaceBet(bet);
        }

        public void SplitPair() => SplitPair(Hand);

        public void SplitPair(Hand hand)
        {
            if (hand.CanPair())
            {
                var secondHand = new Hand();
                PlaceBet(hand.Bet, secondHand);
                secondHand.Cards.Add(hand.Cards[1]);
                hand.Cards.Remove(hand.Cards[1]);
                Hands.Add(secondHand);
            }
        }
    }
}