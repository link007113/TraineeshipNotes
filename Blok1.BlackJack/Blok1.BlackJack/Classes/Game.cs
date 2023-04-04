using Blok1.BlackJack.Enums;
using System.Text;

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
            Player.PrimaryHand.AddCard(Shoe.DrawCard());
            Dealer.PrimaryHand.AddCard(Shoe.DrawCard());

            Player.PrimaryHand.AddCard(Shoe.DrawCard());
            Dealer.PrimaryHand.AddCard(Shoe.DrawCard(false));
        }

        public void PlayerHit(Hand hand)
        {
            hand.AddCard(Shoe.DrawCard(Rank.Ace));
        }

        public void PlayerStand()
        {
            Dealer.PrimaryHand.ShowAllCards();
            while (Dealer.PrimaryHand.TotalValue < 17)
            {
                Dealer.PrimaryHand.AddCard(Shoe.DrawCard());
            }
        }

        public void PlayerDoubleDown(Hand hand)
        {
            Player.PlaceBet(hand.Bet, hand);
            PlayerHit(hand);
            PlayerStand();
        }

        public void PlayerSplit(Hand splittingHand)
        {
            Player.SplitPair(splittingHand);
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
                sb.AppendLine($"{Player.Name}'s hand:\n{Player.PrimaryHand}");
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

            sb.AppendLine($"{Dealer.Name}'s hand:\n{Dealer.PrimaryHand}");
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
                else if (Dealer.PrimaryHand.IsBust)
                {
                    Player.AddWinnings(hand);
                    hand.GameResult = "You win!";
                }
                else if (hand.TotalValue == 21 && Dealer.PrimaryHand.TotalValue != 21)
                {
                    Player.AddWinningsBlackJack(hand);
                    hand.GameResult = "You win!";
                }
                else if (hand.TotalValue == Dealer.PrimaryHand.TotalValue)
                {
                    Player.AddWinningsPush(hand);
                    hand.GameResult = "Push!";
                }
                else if (hand.TotalValue > Dealer.PrimaryHand.TotalValue)
                {
                    Player.AddWinnings(hand);
                    hand.GameResult = "You win!";
                }
                else if (hand.TotalValue < Dealer.PrimaryHand.TotalValue)
                {
                    hand.GameResult = "You lose!";
                }
            }
        }

        public void RestartGame()
        {
            Player.ClearHands();
            Dealer.ClearHands();
            Shoe = new Shoe();
            Shoe.Shuffle();
        }
    }
}