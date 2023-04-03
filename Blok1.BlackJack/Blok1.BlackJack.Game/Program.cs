using Blok1.BlackJack.Enums;
using Blok1.BlackJack.Classes;

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
                AskPlayerChoice(game);
                PrintGame(game);
                DecideWinner(game);
            } while (RestartGame(game));
        }

        private static bool RestartGame(Game game)
        {
            Console.WriteLine("Do you want to play another round?");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void PrintGame(Game game)
        {
            Console.Clear();
            Console.WriteLine(game);
        }

        private static void AskPlayerChoice(Game game)
        {
            Console.WriteLine("(H)it or (S)tand?");
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
            game.DealCards();
        }

        public static void ProcessPlayerChoice(Game game, string playerChoice)
        {
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
                    game.PlayerDoubleDown();
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
            Console.WriteLine(game.DecideWinner());
        }
    }
}