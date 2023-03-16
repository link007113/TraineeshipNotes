using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises_Dag_1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (Options())
            {
                Console.WriteLine("Press Enter to restart...");
                Console.ReadKey();
                Console.Clear();              
            }           
        }

        static bool Options()
        {
            bool retval;
            Console.WriteLine("Give the corresponding number to execute the exercise or press Enter to quit:\n" +
                   "1.\tReverse Chars\n" +
                   "2.\tCalculator\n" +
                   "3.\tMultiplication of three factors\n" +
                   "4.\tAverage\n" +
                   "5.\tCelsius to Kelvin and Fahrenheit\n" +
                   "6.\tSpeed Calculator (Float value)\n" +
                   "7.\tBlack Slope");
            switch (Console.ReadLine())
            {

                case "1":
                    Console.Clear();
                    ReverseChars();
                    retval = true;
                    break;
                case "2":
                    Console.Clear();
                    Calculator();
                    retval = true;
                    break;
                case "3":
                    Console.Clear();
                    MultiplucationTimesThree();
                    retval = true;
                    break;
                case "4":
                    Console.Clear();
                    CalculateAverage();
                    retval = true;
                    break;
                case "5":
                    Console.Clear();
                    CelsiusToOtherConverter();
                    retval = true;
                    break;
                case "6":
                    Console.Clear();
                    SpeedCalculator();
                    retval = true;
                    break;
                case "7":
                    Console.Clear();
                    BlackSlope();
                    retval = true;
                    break;
                default:
                    retval = false;
                    break;
            }

            return retval;
        }
        #region Functions
        static void ReverseChars()
        {
            List<string> inputs = new List<string>();
            Console.WriteLine("Enter a series of 3 characters:");
            inputs.Add(Console.ReadLine());
            inputs.Add(Console.ReadLine());
            inputs.Add(Console.ReadLine());

            Console.WriteLine("In reverse order:");
            for (int i = inputs.Count - 1; i >= 0; i--)
            {
                string input = inputs[i];
                Console.WriteLine(input);
            }
        }

        static void Calculator()
        {
            double result;
            char op;
            double num1 = ParseInputToDouble("Enter the first number: ");
            double num2 = ParseInputToDouble("Enter the second number: ");

            Console.WriteLine("Enter an operator (+, -, *, /): ");
            string input = Console.ReadLine();
            while (!char.TryParse(input, out op))
            {
                Console.Clear();
                Console.WriteLine("Enter an operator (+, -, *, /): ");
                input = Console.ReadLine();
            }

            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    Console.WriteLine($"Result: {result}");
                    break;

                case '-':
                    result = num1 - num2;
                    Console.WriteLine($"Result: {result}");
                    break;

                case '*':
                    result = num1 * num2;
                    Console.WriteLine($"Result: {result}");
                    break;

                case '/':
                    if (num1 == 0 || num2 == 0)
                    {
                        Console.WriteLine("This is not possible");
                    }
                    else
                    {
                        result = num1 / num2;
                        Console.WriteLine($"Result: {result}");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid operator");
                    break;
            }

        }
        private static void MultiplucationTimesThree()
        {
            double num1 = ParseInputToDouble("Enter the first number: ");
            double num2 = ParseInputToDouble("Enter the second number: ");
            double num3 = ParseInputToDouble("Enter the third number: ");
            Console.WriteLine($"The result is {num1 * num2 * num3}");
        }

        private static void CalculateAverage()
        {
            List<double> numbers = new List<double>();
            
            numbers.Add(ParseInputToDouble("Enter the first number: "));
            numbers.Add(ParseInputToDouble("Enter the second number: "));
            numbers.Add(ParseInputToDouble("Enter the third number: "));
            numbers.Add(ParseInputToDouble("Enter the fourth number: "));

            Console.WriteLine($"The average is than: {numbers.Average(x => x)}");
        }

        private static void CelsiusToOtherConverter()
        {
            double celsius = ParseInputToDouble("What is the temperature in celsius that you want to convert?");
            Console.WriteLine($"Unit\t\tValue\n" +
                              $"Celsius\t\t{celsius}\n" +
                              $"Kelvin\t\t{celsius + 273}\n" +
                              $"Fahrenheit\t{celsius * 18 / 10 + 32}");
        }

        private static void SpeedCalculator()
        {
            float distance = ParseInputToFloat("What is the distance in meters?");
            float hour = ParseInputToFloat("In how many hours?");
            float min = ParseInputToFloat("In how many minutes?");
            float sec = ParseInputToFloat("In how many seconds?");

            float totalTime = (hour * 3600) + (min * 60) + sec;
            float milesPerSeconds = distance / totalTime;
            float kilometerPerHour = (distance / 1000.0f) / (totalTime / 3600.0f);
            float milesPerHour = kilometerPerHour / 1.609f;

            Console.WriteLine($"Speed in meters/sec is {milesPerSeconds}\n" +
                              $"Speed in km/h is {kilometerPerHour}\n" +
                              $"Speed in miles/h is {milesPerHour}");

        }

        private static void BlackSlope()
        {
            Console.WriteLine($"X\tX+1");
            double X = Double.PositiveInfinity;
            if (X == X + 1)
            {
                Console.WriteLine($"{X}\t{X + 1}\tPositiveInfinity\tRepresents positive infinity.");

            }

            X = Double.NegativeInfinity;
            if (X == X + 1)
            {
                Console.WriteLine($"{X}\t{X + 1}\tNegativeInfinity\tRepresents negative infinity.");

            }

            X = double.Epsilon;

            if (X == X + 1)
            {
                Console.WriteLine($"{X}\t{X + 1}\t Epsilon\tRepresents the smallest positive Double value that is greater than zero. This field is constant.");

            }


        }
        #endregion
        #region Helpers

        private static double ParseInputToDouble(string message)
        {
            double result = 0;
            Console.WriteLine(message);
            string input = Console.ReadLine();

            while (!double.TryParse(input, out result))
            {
                Console.WriteLine($"That's not a valid input. {message}");
                input = Console.ReadLine();
            }
            return result;
        }

        private static float ParseInputToFloat(string message)
        {
            float result = 0F;
            Console.WriteLine(message);
            string input = Console.ReadLine();

            while (!float.TryParse(input, out result))
            {
                Console.WriteLine($"That's not a valid input. {message}");
                input = Console.ReadLine();
            }
            return result;
        }
        #endregion
    }
}
