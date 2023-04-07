namespace Blok1.BlackJack.UI
{
    internal static class GameController
    {
        public static void AskPlayerChoice(Game game)
        {
            for (int handIndex = 0; handIndex < game.Player.Hands.Count(); handIndex++)
            {
                PlayerHand hand = game.Player.GetPlayerHand(handIndex);
                string extraOptions = string.Empty;

                if (game.Player.GetCanDoubleDown(hand))
                {
                    extraOptions += " or (D)ouble Down";
                }
                if (game.Player.GetCanSplit(hand))
                {
                    extraOptions += " or Split (P)airs";
                }

                if (game.Player.Hands.Count() > 1)
                {
                    Console.WriteLine("Which option would you choose for the following hand:\n");
                    Console.WriteLine(hand);
                }

                Console.WriteLine($"(H)it or (S)tand{extraOptions}?");
                var playerChoice = Console.ReadKey();
                ProcessPlayerChoice(game, hand, playerChoice);
            }
        }

        public static void DealCards(Game game)
        {
            Console.WriteLine("Press a key to deal the cards");
            Console.ReadKey();
            game.DealCards();
        }

        public static void DecideWinner(Game game)
        {
            game.DecideWinner();
        }

        public static void PlaceBets(Game game)
        {
            decimal betAmount = 0;
            bool isValidBet = false;

            while (!isValidBet)
            {
                Console.Write("Place your bets (1-10): ");

                if (decimal.TryParse(Console.ReadLine(), out betAmount))
                {
                    if (betAmount > 0 && betAmount <= 10 && betAmount <= game.Player.Balance)
                    {
                        isValidBet = true;
                    }
                    else
                    {
                        if (betAmount <= 0)
                        {
                            Console.WriteLine("Please enter a positive number.");
                        }
                        else if (betAmount > 10)
                        {
                            Console.WriteLine("The maximum bet amount is 10.");
                        }
                        else if (betAmount > game.Player.Balance)
                        {
                            Console.WriteLine("You don't have enough chips to place this bet.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }

            game.PlayerPlaceBet(betAmount);
        }

        private static void ProcessPlayerChoice(Game game, PlayerHand hand, ConsoleKeyInfo playerChoice)
        {
            bool canDoubleDown = hand.CanDoubleDown;
            bool canSplit = hand.CanSplit;

            switch (playerChoice.Key)
            {
                case ConsoleKey.H:
                    game.PlayerHit(hand);
                    Printer.PrintGame(game);
                    if (game.Player.PrimaryHand.TotalValue <= 21)
                    {
                        AskPlayerChoice(game);
                    }
                    break;

                case ConsoleKey.S:
                    game.PlayerStand();
                    break;

                case ConsoleKey.D:
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

                case ConsoleKey.P:
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
                    playerChoice = Console.ReadKey();
                    ProcessPlayerChoice(game, hand, playerChoice);
                    break;
            }
        }

        private static bool RestartChoice(Game game, ConsoleKeyInfo playerChoice)
        {
            switch (playerChoice.Key)
            {
                case ConsoleKey.Y:
                case ConsoleKey.Enter:
                    {
                        game.RestartGame();
                        return true;
                    }
                case ConsoleKey.N:
                    {
                        return false;
                    }
                default:
                    {
                        Console.WriteLine("Please enter a valid choice");
                        playerChoice = Console.ReadKey();
                        return RestartChoice(game, playerChoice);
                    }
            }
        }

        public static bool RestartGame(Game game)
        {
            if (game.Player.Balance > 0)
            {
                Console.WriteLine("Do you want to play another round? (Y/N)");
                var playerChoice = Console.ReadKey();
                return RestartChoice(game, playerChoice);
            }
            else
            {
                Console.WriteLine("You don't have any chips left.. ");
                return false;
            }
        }
    }
}