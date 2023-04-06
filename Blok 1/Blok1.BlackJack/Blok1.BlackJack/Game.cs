using System.Text;

namespace Blok1.BlackJack
{
    public class Game
    {
        public Dealer Dealer { get; }
        public Player Player { get; }
        public Shoe Shoe { get; private set; }

        public Game(string name)
        {
            Player = new Player(name);
            Dealer = new Dealer();
            Shoe = new Shoe();
            Shoe.Shuffle();
        }

        public void DealCards()
        {
            Player.PrimaryHand.AddCard(Shoe.DrawCard());
            Dealer.PrimaryHand.AddCard(Shoe.DrawCard());

            Player.PrimaryHand.AddCard(Shoe.DrawCard());
            Dealer.PrimaryHand.AddCard(Shoe.DrawCard(true));
        }

        public void DecideWinner()
        {
            string win = "You win!";
            string lose = "You lose!";
            string push = "Push!";

            foreach (HandPlayer hand in Player.Hands)
            {
                if (hand.IsCharlie)
                {
                    Player.AddWinnings(hand);
                    hand.SetGameResult(win);
                }
                else if (hand.IsBust)
                {
                    hand.SetGameResult(lose);
                }
                else if (Dealer.PrimaryHand.IsBust)
                {
                    Player.AddWinnings(hand);
                    hand.SetGameResult(win);
                }
                else if (hand.IsBlackJack && !Dealer.PrimaryHand.IsBlackJack)
                {
                    Player.AddWinningsBlackJack(hand);
                    hand.SetGameResult(win);
                }
                else if (hand.TotalValue == Dealer.PrimaryHand.TotalValue)
                {
                    Player.AddWinningsPush(hand);
                    hand.SetGameResult(push);
                }
                else if (hand.TotalValue > Dealer.PrimaryHand.TotalValue)
                {
                    Player.AddWinnings(hand);
                    hand.SetGameResult(win);
                }
                else if (hand.TotalValue < Dealer.PrimaryHand.TotalValue)
                {
                    hand.SetGameResult(lose);
                }
            }
        }

        public void PlayerDoubleDown(HandPlayer hand)
        {
            Player.PlaceBet(hand.Bet, hand);
            PlayerHit(hand);
            PlayerStand();
        }

        public void PlayerHit(HandBase hand)
        {
            hand.AddCard(Shoe.DrawCard());
        }

        public void PlayerPlaceBet(decimal bet)
        {
            Player.PlaceBet(bet);
        }

        public void PlayerSplit(HandPlayer splittingHand)
        {
            Player.SplitPair(splittingHand);
            foreach (HandBase hand in Player.Hands)
            {
                PlayerHit(hand);
            }
        }

        public void PlayerStand()
        {
            var dealerHand = Dealer.PrimaryHand;
            dealerHand.ShowAllCards();
            while (Dealer.PrimaryHand.TotalValue < 17)
            {
                Dealer.PrimaryHand.AddCard(Shoe.DrawCard());
            }
        }

        public void RestartGame()
        {
            Player.ClearHands();
            Dealer.ClearHands();
            Shoe = new Shoe();
            Shoe.Shuffle();
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
                foreach (HandPlayer hand in Player.Hands)
                {
                    sb.AppendLine($"{hand}");
                }
                sb.AppendLine();
            }

            sb.AppendLine($"{Dealer.Name}'s hand:\n{Dealer.PrimaryHand}");
            return sb.ToString();
        }
    }
}