using System;

namespace QuantityMeasurementApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("\n UC6 Addition ");

            QuantityLength a1 = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength a2 = new QuantityLength(12.0, LengthUnit.Inch);

            Console.WriteLine($"1 ft + 12 in = {a1.Add(a2)}");

            QuantityLength b1 = new QuantityLength(12.0, LengthUnit.Inch);
            QuantityLength b2 = new QuantityLength(1.0, LengthUnit.Feet);

            Console.WriteLine($"12 in + 1 ft = {b1.Add(b2)}");

            QuantityLength c1 = new QuantityLength(1.0, LengthUnit.Yard);
            QuantityLength c2 = new QuantityLength(3.0, LengthUnit.Feet);

            Console.WriteLine($"1 yd + 3 ft = {c1.Add(c2)}");

            QuantityLength d1 = new QuantityLength(2.54, LengthUnit.Centimeter);
            QuantityLength d2 = new QuantityLength(1.0, LengthUnit.Inch);

            Console.WriteLine($"2.54 cm + 1 in = {d1.Add(d2)}");

            QuantityLength e1 = new QuantityLength(5.0, LengthUnit.Feet);
            QuantityLength e2 = new QuantityLength(0.0, LengthUnit.Inch);

            Console.WriteLine($"5 ft + 0 in = {e1.Add(e2)}");
        }
    }
}