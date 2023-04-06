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
            foreach (PlayerHand hand in Player.Hands)
            {
                DecideWinnerForHand(hand);
            }
        }

        private void DecideWinnerForHand(PlayerHand hand)
        {
            if (hand.IsCharlie)
            {
                Player.AddWinnings(hand);
                hand.SetGameResult(GameResult.Win);
            }
            else if (hand.IsBust)
            {
                hand.SetGameResult(GameResult.Lose);
            }
            else if (Dealer.PrimaryHand.IsBust)
            {
                Player.AddWinnings(hand);
                hand.SetGameResult(GameResult.Win);
            }
            else if (hand.IsBlackJack && !Dealer.PrimaryHand.IsBlackJack)
            {
                Player.AddWinningsBlackJack(hand);
                hand.SetGameResult(GameResult.Win);
            }
            else if (hand.TotalValue == Dealer.PrimaryHand.TotalValue)
            {
                Player.AddWinningsPush(hand);
                hand.SetGameResult(GameResult.Push);
            }
            else if (hand.TotalValue > Dealer.PrimaryHand.TotalValue)
            {
                Player.AddWinnings(hand);
                hand.SetGameResult(GameResult.Win);
            }
            else if (hand.TotalValue < Dealer.PrimaryHand.TotalValue)
            {
                hand.SetGameResult(GameResult.Lose);
            }
        }

        public void PlayerDoubleDown(PlayerHand hand)
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

        public void PlayerSplit(PlayerHand splittingHand)
        {
            Player.SplitPair(splittingHand);
            foreach (HandBase hand in Player.Hands)
            {
                PlayerHit(hand);
            }
        }

        public void PlayerStand()
        {
            Dealer.Stand(Shoe);
        }

        public void RestartGame()
        {
            Player.ClearHands();
            Dealer.ClearHands();
            if (Shoe.MarkerReached)
            {
                Shoe = new Shoe();
                Shoe.Shuffle();
            }
        }
    }
}