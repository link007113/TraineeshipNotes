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
        public Shoe Shoe { get; }

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

        public void PlayerHit()
        {
            Player.Hand.AddCard(Shoe.DrawCard());
        }

        public void PlayerStand()
        {
            Dealer.Hand.ShowAllCards();
            while (Dealer.Hand.TotalValue < 17)
            {
                Dealer.Hand.AddCard(Shoe.DrawCard());
            }
        }

        public void PlayerDoubleDown()
        {
            Player.PlaceBet(Player.Hand.Bet);
            PlayerHit();
            PlayerStand();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Player:\t{Player.Name}");
            sb.AppendLine($"Balance:\t{Player.Balance}");
            sb.AppendLine($"Hand:");
            sb.AppendLine($"{Player.Hand}");
            sb.AppendLine();
            sb.AppendLine($"Dealer:\t{Dealer.Name}");
            sb.AppendLine($"Hand:");
            sb.AppendLine($"{Dealer.Hand}");
            return sb.ToString();
        }

        public string DecideWinner()
        {
            string outcome = "";

            if (Player.Hand.IsBust)
            {
                outcome = "You lose!";
            }
            else if (Dealer.Hand.IsBust)
            {
                outcome = "You win!";
                Player.AddWinnings();
            }
            else if (Player.Hand.TotalValue > Dealer.Hand.TotalValue)
            {
                outcome = "You win!";
                Player.AddWinnings();
            }
            else if (Player.Hand.TotalValue < Dealer.Hand.TotalValue)
            {
                outcome = "You lose!";
            }
            else
            {
                outcome = "Push!";
                Player.Balance += Player.Hand.Bet;
            }

            return outcome;
        }
    }
}