using System.Text;

namespace Blok1.BlackJack.UI
{
    internal static class GameUI
    {
        private static Game Game = new("Anthony");

        internal static void StartGame()
        {
            int roundNumber = 0;

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            do
            {
                roundNumber++;
                Console.Clear();
                Console.Title = $"BlackJack Round: {roundNumber}";
                Printer.PrintLogo();
                Printer.PrintStart(Game);
                GameController.PlaceBets(Game);
                GameController.DealCards(Game);
                Printer.PrintGame(Game);
                if (Game.Player.PrimaryHand.IsBlackJack)
                {
                    GameController.DecideWinner(Game);
                    Printer.PrintGame(Game);
                }
                else
                {
                    GameController.AskPlayerChoice(Game);
                    GameController.DecideWinner(Game);
                    Printer.PrintGame(Game);
                }
            } while (GameController.RestartGame(Game));
        }
    }
}