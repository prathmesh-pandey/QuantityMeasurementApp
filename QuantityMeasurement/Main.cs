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

            Console.WriteLine("\n UC9 Weight Equality ");

            QuantityWeight w1 = new QuantityWeight(1.0, WeightUnit.Kilogram);
            QuantityWeight w2 = new QuantityWeight(1000.0, WeightUnit.Gram);

            Console.WriteLine($"1 kg == 1000 g → {w1.Equals(w2)}");

            QuantityWeight w3 = new QuantityWeight(1.0, WeightUnit.Kilogram);
            QuantityWeight w4 = new QuantityWeight(2.20462, WeightUnit.Pound);

            Console.WriteLine($"1 kg == 2.20462 lb → {w3.Equals(w4)}");

            Console.WriteLine("\n UC9 Weight Conversion ");

            QuantityWeight cc1 = new QuantityWeight(1.0, WeightUnit.Kilogram);

            Console.WriteLine($"1 kg → grams = {w2.ConvertTo(WeightUnit.Gram)}");
            Console.WriteLine($"1 kg → pounds = {w4.ConvertTo(WeightUnit.Pound)}");

            Console.WriteLine("\n UC9 Weight Addition ");

            QuantityWeight aa1 = new QuantityWeight(1.0, WeightUnit.Kilogram);
            QuantityWeight aa2 = new QuantityWeight(1000.0, WeightUnit.Gram);

            Console.WriteLine($"1 kg + 1000 g = {a1.Add(a2)}");

            QuantityWeight p1 = new QuantityWeight(1.0, WeightUnit.Pound);
            QuantityWeight p2 = new QuantityWeight(453.592, WeightUnit.Gram);

            Console.WriteLine($"1 lb + 453.592 g = {p1.Add(p2)}");
        }
    }
}