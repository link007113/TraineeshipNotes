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
                Console.Title = $"BlackJack Round: {roundNumber}";
                PrintLogo();
                PlaceBets(game);
                DealCards(game);
                PrintGame(game);
                if (game.Player.PrimaryHand.IsBlackJack)
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

        private static void DecideWinner(Game game)
        {
            game.DecideWinner();
        }

        private static void ProcessPlayerChoice(Game game, Hand hand, string playerChoice)
        {
            bool canDoubleDown = hand.CanDoubleDown;
            bool canSplit = hand.CanSplit;

            switch (playerChoice.ToUpper())
            {
                case "H":
                    game.PlayerHit(hand);
                    PrintGame(game);
                    if (game.Player.PrimaryHand.TotalValue <= 21)
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
                        game.PlayerDoubleDown(hand);
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
                        game.PlayerSplit(hand);
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
                    ProcessPlayerChoice(game, hand, playerChoice);
                    break;
            }
        }

        private static void AskPlayerChoice(Game game)
        {
            for (int i = 0; i < game.Player.Hands.Count; i++)
            {
                Hand hand = game.Player.Hands[i];
                string extraOptions = string.Empty;

                if (game.Player.PrimaryHand.CanDoubleDown)
                {
                    extraOptions += " or (D)ouble Down";
                }
                if (game.Player.PrimaryHand.CanSplit)
                {
                    extraOptions += " or Split (P)airs";
                }
                Console.WriteLine("Which option would you choose for the following hand:\n");
                Console.WriteLine(hand);
                Console.WriteLine($"(H)it or (S)tand{extraOptions}?");
                string playerChoice = Console.ReadLine();
                ProcessPlayerChoice(game, hand, playerChoice);
            }
        }

        private static void DealCards(Game game)
        {
            Console.WriteLine("Press a key to deal the cards");
            Console.ReadKey();
            game.DealCards();

            // used for testing Splitting
            //game.Player.Hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            //game.Player.Hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            //game.Dealer.Hand.AddCard(new Card(Suit.Clubs, Rank.Three));
            //game.Dealer.Hand.AddCard(new Card(Suit.Clubs, Rank.Two));
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

        private static void PrintGame(Game game)
        {
            Console.Clear();
            Console.WriteLine(game);
        }

        private static void PrintLogo()
        {
            string logo = @" __      __   _                    _____      ___ _         _      _         _
 \ \    / /__| |__ ___ _ __  ___  |_   _|__  | _ ) |__ _ __| |___ | |__ _ __| |__
  \ \/\/ / -_) / _/ _ \ '  \/ -_)   | |/ _ \ | _ \ / _` / _| / / || / _` / _| / /
   \_/\_/\___|_\__\___/_|_|_\___|   |_|\___/ |___/_\__,_\__|_\_\\__/\__,_\__|_\_\
                                                                                 ";
            Console.WriteLine(logo);
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