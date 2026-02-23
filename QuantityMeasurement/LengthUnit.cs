using System;

namespace QuantityMeasurementApp
{
    public enum LengthUnit
    {
        Feet,
        Inch
    }

    public static class LengthUnitExtensions
    {
        public static double ToBaseUnit(this LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.Feet => 1.0,
                LengthUnit.Inch => 1.0 / 12.0,
                _ => throw new ArgumentException("Unsupported unit")
            };
        }
    }
}