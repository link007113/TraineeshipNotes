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
            string[] output = new string[7];

            foreach (Card card in cards)
            {
                AddCardToArray(output, card);
            }

            return ConvertAsciiArrayToString(output);
        }

        private static string ConvertAsciiArrayToString(string[] output)
        {
            output[0] += "\n";
            output[1] += "\n";
            output[2] += "\n";
            output[3] += "\n";
            output[4] += "\n";
            output[5] += "\n";
            output[6] += "\n";
            return string.Concat(output);
        }

        private static void AddCardToArray(string[] output, Card card)
        {
            string[] asciiLine = new string[7];
            asciiLine[0] = "┌─────────┐";
            asciiLine[1] = "│ __      │";
            asciiLine[2] = "│         │";
            asciiLine[3] = "│    _    │";
            asciiLine[4] = "│         │";
            asciiLine[5] = "│      __ │";
            asciiLine[6] = "└─────────┘";

            output[0] += asciiLine[0] + "";
            output[1] += card.FaceUp ? asciiLine[1].Replace("__", card.Rank.ToShortString().PadRight(2)) : asciiLine[1].Replace("__", "*".PadRight(2) + "");
            output[2] += asciiLine[2] + "";
            output[3] += card.FaceUp ? asciiLine[3].Replace("_", card.Suit.ToCharacter()) : asciiLine[3].Replace("_", "*" + "") + "";
            output[4] += asciiLine[4] + "";
            output[5] += card.FaceUp ? asciiLine[5].Replace("__", card.Rank.ToShortString().PadLeft(2)) : asciiLine[5].Replace("__", "*".PadLeft(2) + "") + "";
            output[6] += asciiLine[6] + "";
        }

        internal static string GetPrintForHand(HandBase handBase, bool print = false)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Cards:");
            sb.AppendLine(Printer.PrintCards(handBase.Cards.ToList()));
            if (handBase.GameResult != GameResult.None)
            {
                sb.AppendLine($"{handBase.GameResult.ToText()}");
            }
            if (handBase.Cards.All(c => c.FaceUp))
            {
                sb.AppendLine($"Total value: {handBase.TotalValue}");
            }
            if (print)
            {
                AddColorToCards(sb.ToString());
                return "";
            }

            return sb.ToString();
        }

        public static void PrintGame(Game game)
        {
            Console.Clear();
            string[] lines = PrintGameStats(game).Split(Environment.NewLine);
            for (int i = 0; i < lines.Length; i++)
            {
                string? line = lines[i];
                if (!line.EndsWith("\n"))
                {
                    line += "\n";
                }

                if (AddColorToGameResult(line))
                {
                    continue;
                }

                AddColorToCards(line);
            }
        }

        private static bool AddColorToGameResult(string line)
        {
            if (line.Contains(GameResult.Win.ToText()))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(line);
                return true;
            }
            if (line.Contains(GameResult.Lose.ToText()))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(line);
                return true;
            }
            if (line.Contains(GameResult.Push.ToText()))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(line);
                return true;
            }
            return false;
        }

        private static void AddColorToCards(string line)
        {
            foreach (char character in line)
            {
                if (character == '♥' || character == '♦')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(character);
                }
                else if (character == '┌' || character == '└' || character == '┘' || character == '┐' || character == '─')
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
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