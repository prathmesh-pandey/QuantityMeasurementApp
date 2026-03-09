using System;

namespace QuantityMeasurementApp
{
    public enum LengthUnit
    {
        Feet,
        Inch,
        Yard,
        Centimeter
    }

    public static class LengthUnitExtensions
    {
        public static double ConvertToBaseUnit(this LengthUnit unit, double value)
        {
            return unit switch
            {
                LengthUnit.Feet => value,
                LengthUnit.Inch => value / 12.0,
                LengthUnit.Yard => value * 3.0,
                LengthUnit.Centimeter => value / 30.48,
                _ => throw new ArgumentException("Unsupported unit")
            };
        }

        public static double ConvertFromBaseUnit(this LengthUnit unit, double baseValue)
        {
            return unit switch
            {
                LengthUnit.Feet => baseValue,
                LengthUnit.Inch => baseValue * 12.0,
                LengthUnit.Yard => baseValue / 3.0,
                LengthUnit.Centimeter => baseValue * 30.48,
                _ => throw new ArgumentException("Unsupported unit")
            };
        }
    }
}