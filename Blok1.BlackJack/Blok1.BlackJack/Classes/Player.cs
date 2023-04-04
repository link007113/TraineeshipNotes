using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok1.BlackJack.Classes
{
    public class Player
    {
        public string Name { get; set; }
        //public List<Hand> Hands { get; set; } = new List<Hand>();

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
        public Hand Hand { get; set; }

        public decimal Balance { get; set; }
        public bool IsDealer { get; }

        public Player(string name, decimal balance = 20M)
        {
            Name = name;
            Balance = balance;
            //Hands.Add(new Hand());
            Hand = new Hand();
        }

        public Player(string name, decimal balance, bool isDealer = false) : this(name, balance = 20M)
        {
            IsDealer = isDealer;
        }

        public void PlaceBet(decimal bet)
        {
            if (bet > Balance)
            {
                throw new ArgumentOutOfRangeException("Not enough money");
            }
            Balance -= bet;
            Hand.PlaceBet(bet);
        }

        public void ClearHand()
        {
            //Hands = new List<Hand>();
            Hand = new Hand();
        }

        public void AddWinnings()
        {
            Balance += Hand.Bet * 2;
            ClearHand();
        }

        public void AddWinningsBlackJack()
        {
            Balance += Hand.Bet * 2.5M;
            ClearHand();
        }

        //public void SplitPair()
        //{
        //    if (Hand.CanPair())
        //    {
        //        var secondHand = new Hand();
        //        secondHand.Cards.Add(Hand.Cards[1]);
        //        Hand.Cards.RemoveAt(1);
        //        Hands.Add(secondHand);
        //    }
        //}
    }
}