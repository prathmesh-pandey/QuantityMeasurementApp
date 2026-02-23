using System;

namespace QuantityMeasurementApp
{
    public static class Equality
    {
        public static bool CheckFeetEquality(double value1, double value2)
        {
            Feet f1 = new Feet(value1);
            Feet f2 = new Feet(value2);

            return f1.Equals(f2);
        }

        public static bool CheckInchesEquality(double value1, double value2)
        {
            Inches i1 = new Inches(value1);
            Inches i2 = new Inches(value2);

            return i1.Equals(i2);
        }
    }
}