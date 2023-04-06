using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok1.BlackJack.UI
{
    internal static class Printer
    {
        private static string PrintCards(List<Card> cards)
        {
            string outputline1 = string.Empty;
            string outputline2 = string.Empty;
            string outputline3 = string.Empty;
            string outputline4 = string.Empty;
            string outputline5 = string.Empty;
            string outputline6 = string.Empty;
            string outputline7 = string.Empty;

            foreach (Card card in cards)
            {
                string asciiLine1 = "┌─────────┐";
                string asciiLine2 = "│ __      │";
                string asciiLine3 = "│         │";
                string asciiLine4 = "│    _    │";
                string asciiLine5 = "│         │";
                string asciiLine6 = "│      __ │";
                string asciiLine7 = "└─────────┘";

                outputline1 += asciiLine1 + "";
                outputline2 += card.FaceUp ? asciiLine2.Replace("__", card.Rank.ToShortString().PadLeft(2)) : asciiLine2.Replace("__", "* " + "");
                outputline3 += asciiLine3 + "";
                outputline4 += card.FaceUp ? asciiLine4.Replace("_", card.Suit.ToCharacter()) : asciiLine4.Replace("_", "*" + "") + "";
                outputline5 += asciiLine5 + "";
                outputline6 += card.FaceUp ? asciiLine6.Replace("__", card.Rank.ToShortString().PadLeft(2)) : asciiLine6.Replace("__", "* " + "") + "";
                outputline7 += asciiLine7 + "";
            }

            outputline1 += "\n";
            outputline2 += "\n";
            outputline3 += "\n";
            outputline4 += "\n";
            outputline5 += "\n";
            outputline6 += "\n";
            outputline7 += "\n";

            return outputline1 + outputline2 + outputline3 + outputline4 + outputline5 + outputline6 + outputline7;
        }

        private static string GetPrintForHand(HandBase handBase)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Cards:");
            sb.AppendLine(Printer.PrintCards(handBase.Cards.ToList()));
            if (handBase.GameResult != GameResult.None)
            {
                sb.AppendLine($"{handBase.GameResult}");
            }
            if (handBase.Cards.All(c => c.FaceUp))
            {
                sb.AppendLine($"Total value: {handBase.TotalValue}");
            }
            return sb.ToString();
        }

        public static void PrintGame(Game game)
        {
            Console.Clear();
            foreach (char character in PrintGameStats(game))
            {
                if (character == '♥' || character == '♦')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(character);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(character);
                }
            }
        }

        private static string PrintGameStats(Game game)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Balance of {game.Player.Name}:\t{game.Player.Balance}");
            if (game.Player.Hands.Count() == 1)
            {
                sb.AppendLine($"{game.Player.Name}'s hand:\n{GetPrintForHand(game.Player.PrimaryHand)}");
                sb.AppendLine();
            }
            else
            {
                sb.AppendLine($"{game.Player.Name}'s hands:\n");
                foreach (PlayerHand hand in game.Player.Hands)
                {
                    sb.AppendLine(GetPrintForHand(hand));
                }
                sb.AppendLine();
            }

            sb.AppendLine($"{game.Dealer.Name} 's hand:\n {GetPrintForHand(game.Dealer.PrimaryHand)}");
            return sb.ToString();
        }

        public static void PrintLogo()
        {
            string logo = @" __      __   _                    _____      ___ _         _      _         _
 \ \    / /__| |__ ___ _ __  ___  |_   _|__  | _ ) |__ _ __| |___ | |__ _ __| |__
  \ \/\/ / -_) / _/ _ \ '  \/ -_)   | |/ _ \ | _ \ / _` / _| / / || / _` / _| / /
   \_/\_/\___|_\__\___/_|_|_\___|   |_|\___/ |___/_\__,_\__|_\_\\__/\__,_\__|_\_\
                                                                                 ";
            Console.WriteLine(logo);
        }

        public static void PrintStart(Game game)
        {
            Console.WriteLine("New Round\r\n===============");
            Console.WriteLine($"{game.Player.Name} has {game.Player.Balance} chips");
        }
    }
}