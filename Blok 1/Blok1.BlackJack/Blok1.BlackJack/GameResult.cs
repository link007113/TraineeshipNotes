using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok1.BlackJack
{
    public enum GameResult
    {
        None,
        Win,
        Lose,
        Push
    }

    public static class ResultFunctions
    {
        public static string ToText(this GameResult result) => result switch
        {
            GameResult.None => "No Contest",
            GameResult.Win => "You've won!",
            GameResult.Lose => "You've lost!",
            GameResult.Push => "You've push!",
            _ => throw new NotImplementedException(),
        };
    }
}