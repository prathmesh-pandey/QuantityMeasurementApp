using System;

namespace QuantityMeasurementApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double inch1 = 1.0;
            double inch2 = 1.0;

            double feet1 = 1.0;
            double feet2 = 1.0;

            bool inchResult = Equality.CheckInchesEquality(inch1, inch2);
            bool feetResult = Equality.CheckFeetEquality(feet1, feet2);

            Console.WriteLine($"Input: {inch1} inch and {inch2} inch");
            Console.WriteLine($"Output: Equal ({inchResult.ToString().ToLower()})");

            Console.WriteLine($"Input: {feet1} ft and {feet2} ft");
            Console.WriteLine($"Output: Equal ({feetResult.ToString().ToLower()})");
        }
    }
}