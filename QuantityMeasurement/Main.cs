using System;

namespace QuantityMeasurementApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("\n UC5 Conversion Demo ");

            Console.WriteLine($"convert(1.0, Feet, Inch) -> {QuantityLength.Convert(1.0, LengthUnit.Feet, LengthUnit.Inch)}");
            Console.WriteLine($"convert(3.0, Yard, Feet) -> {QuantityLength.Convert(3.0, LengthUnit.Yard, LengthUnit.Feet)}");
            Console.WriteLine($"convert(36.0, Inch, Yard) -> {QuantityLength.Convert(36.0, LengthUnit.Inch, LengthUnit.Yard)}");
            Console.WriteLine($"convert(1.0, Centimeter, Inch) -> {QuantityLength.Convert(1.0, LengthUnit.Centimeter, LengthUnit.Inch)}");
            Console.WriteLine($"convert(0.0, Feet, Inch) -> {QuantityLength.Convert(0.0, LengthUnit.Feet, LengthUnit.Inch)}");

            QuantityLength yard = new QuantityLength(2.0, LengthUnit.Yard);
            QuantityLength converted = yard.ConvertTo(LengthUnit.Inch);
            Console.WriteLine($"{yard} -> {converted}");
        }
    }
}