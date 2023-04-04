using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok1.BlackJack.Classes
{
    public class Game
    {
        public Player Player { get; }
        public Player Dealer { get; }
        public Shoe Shoe { get; private set; }

        public Game(string name)
        {
            Player = new Player(name);
            Dealer = new Player("Dealer", 0, true);
            Shoe = new Shoe();
            Shoe.Shuffle();
        }

        public void PlayerPlaceBet(decimal bet)
        {
            Player.PlaceBet(bet);
        }

        public void DealCards()
        {
            Player.Hand.AddCard(Shoe.DrawCard());
            Dealer.Hand.AddCard(Shoe.DrawCard());

            Player.Hand.AddCard(Shoe.DrawCard());
            Dealer.Hand.AddCard(Shoe.DrawCard(false));
        }

        public void PlayerHit(Hand hand)
        {
            hand.AddCard(Shoe.DrawCard());
        }

        public void PlayerHit() => PlayerHit(Player.Hand);

        public void PlayerStand()
        {
            Dealer.Hand.ShowAllCards();
            while (Dealer.Hand.TotalValue < 17)
            {
                Dealer.Hand.AddCard(Shoe.DrawCard());
            }
        }

        public void PlayerDoubleDown() => PlayerDoubleDown(Player.Hand);

        public void PlayerDoubleDown(Hand hand)
        {
            Player.PlaceBet(hand.Bet, hand);
            PlayerHit(hand);
            PlayerStand();
        }

        public void PlayerSplit()
        {
            Player.SplitPair();
            foreach (Hand hand in Player.Hands)
            {
                PlayerHit(hand);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Balance of {Player.Name}:\t{Player.Balance}");
            if (Player.Hands.Count == 1)
            {
                sb.AppendLine($"{Player.Name}'s hand:\n{Player.Hand}");
                sb.AppendLine();
            }
            else
            {
                sb.AppendLine($"{Player.Name}'s hands:\n");
                foreach (Hand hand in Player.Hands)
                {
                    sb.AppendLine($"{hand}");
                }
                sb.AppendLine();
            }

            sb.AppendLine($"{Dealer.Name}'s hand:\n{Dealer.Hand}");
            return sb.ToString();
        }

        public void DecideWinner()
        {
            foreach (Hand hand in Player.Hands)
            {
                if (hand.IsBust)
                {
                    hand.GameResult = "You lose!";
                }
                else if (Dealer.Hand.IsBust)
                {
                    Player.AddWinnings(hand);
                    hand.GameResult = "You win!";
                }
                else if (hand.TotalValue == 21 && Dealer.Hand.TotalValue != 21)
                {
                    Player.AddWinningsBlackJack(hand);
                    hand.GameResult = "You win!";
                }
                else if (hand.TotalValue == Dealer.Hand.TotalValue)
                {
                    Player.AddWinningsPush(hand);
                    hand.GameResult = "Push!";
                }
                else if (hand.TotalValue > Dealer.Hand.TotalValue)
                {
                    Player.AddWinnings(hand);
                    hand.GameResult = "You win!";
                }
                else if (hand.TotalValue < Dealer.Hand.TotalValue)
                {
                    hand.GameResult = "You lose!";
                }
            }

        }

        public void RestartGame()
        {
            Player.ClearHand();
            Dealer.ClearHand();
            Shoe = new Shoe();
            Shoe.Shuffle();
        }
    }
}