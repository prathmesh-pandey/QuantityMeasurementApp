using System;

namespace QuantityMeasurementApp
{
    public class QuantityMeasurementAppMain
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter first value in feet:");
            string input1 = Console.ReadLine();

            Console.WriteLine("Enter second value in feet:");
            string input2 = Console.ReadLine();

            if (!double.TryParse(input1, out double value1) ||
                !double.TryParse(input2, out double value2))
            {
                Console.WriteLine("Invalid input. Please enter numeric values.");
                return;
            }

            Feet feet1 = new Feet(value1);
            Feet feet2 = new Feet(value2);

            EqualityChecker checker = new EqualityChecker();

            bool result = checker.AreEqual(feet1, feet2);

            Console.WriteLine($"Input: {value1} ft and {value2} ft");
            Console.WriteLine($"Output: Equal ({result.ToString().ToLowerInvariant()})");
        }
    }
}