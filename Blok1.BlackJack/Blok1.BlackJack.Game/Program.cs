using Blok1.BlackJack.Enums;
using Blok1.BlackJack.Classes;
using System.Text;
using System.Numerics;

namespace Blok1.BlackJack.Games
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int roundNumber = 0;
            Game game = new Game("Anthony");
            do
            {
                roundNumber++;
                Console.Clear();
                Console.WriteLine($"BlackJack Round:{roundNumber}");
                PlaceBets(game);
                DealCards(game);
                PrintGame(game);
                if (game.Player.Hand.IsBlackJack)
                {
                    DecideWinner(game);
                    PrintGame(game);
                }
                else
                {
                    AskPlayerChoice(game);                    
                    DecideWinner(game);
                    PrintGame(game);
                }
            } while (RestartGame(game));
        }

        private static void PrintGame(Game game)
        {
            Console.Clear();
            Console.WriteLine(game);
        }

        private static void AskPlayerChoice(Game game)
        {
            string extraOptions = string.Empty;

            if (game.Player.Hand.CanDoubleDown)
            {
                extraOptions += " or (D)ouble Down";
            }
            if (game.Player.Hand.CanSplit)
            {
                extraOptions += " or Split (P)airs";
            }

            Console.WriteLine($"(H)it or (S)tand{extraOptions}?");
            string playerChoice = Console.ReadLine();
            ProcessPlayerChoice(game, playerChoice);
        }

        private static void PlaceBets(Game game)
        {
            Console.WriteLine($"Place your Bets (1-10):");
            string bet = Console.ReadLine();
            decimal betAmount;
            while (decimal.TryParse(bet, out betAmount) == false || betAmount > 10)
            {
                Console.WriteLine("Please enter a valid number");
                bet = Console.ReadLine();
            }
            game.PlayerPlaceBet(betAmount);
        }

        private static void DealCards(Game game)
        {
            Console.WriteLine("Press a key to deal the cards");
            Console.ReadKey();
            //game.DealCards();
            game.Player.Hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            game.Player.Hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            game.Dealer.Hand.AddCard(new Card(Suit.Clubs, Rank.Three));
            game.Dealer.Hand.AddCard(new Card(Suit.Clubs, Rank.Two));
        }

        public static void ProcessPlayerChoice(Game game, string playerChoice)
        {
            bool canDoubleDown = game.Player.Hand.CanDoubleDown;
            bool canSplit = game.Player.Hand.CanSplit;

            switch (playerChoice.ToUpper())
            {
                case "H":
                    game.PlayerHit();
                    PrintGame(game);
                    if (game.Player.Hand.TotalValue <= 21)
                    {
                        AskPlayerChoice(game);
                    }
                    break;

                case "S":
                    game.PlayerStand();
                    break;

                case "D":
                    if (canDoubleDown)
                    {
                        game.PlayerDoubleDown();
                    }
                    else
                    {
                        Console.WriteLine("Double down is not allowed in this situation.");
                        AskPlayerChoice(game);
                    }
                    break;

                case "P":
                    if (canSplit)
                    {
                        game.PlayerSplit();
                    }
                    else
                    {
                        Console.WriteLine("Splitting pairs is not allowed in this situation.");
                        AskPlayerChoice(game);
                    }
                    break;

                default:
                    Console.WriteLine("Please enter a valid choice");
                    playerChoice = Console.ReadLine();
                    ProcessPlayerChoice(game, playerChoice);
                    break;
            }
        }

        public static void DecideWinner(Game game)
        {
            game.DecideWinner();
        }

        private static bool RestartGame(Game game)
        {
            if (game.Player.Balance > 0)
            {
                Console.WriteLine("Do you want to play another round?");
                string answer = Console.ReadLine();
                if (answer.ToUpper() == "Y" || answer == "")
                {
                    game.RestartGame();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("You don't have any money left.. ");
                return false;
            }
        }
    }
}