using System;

namespace QuantityMeasurementApp
{
    public class Inches
    {
        private readonly double inchesValue;

        public Inches(double value)
        {
            inchesValue = value;
        }

        public double Value => inchesValue;

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj == null || obj.GetType() != typeof(Inches))
                return false;

            Inches other = (Inches)obj;

            return inchesValue.Equals(other.inchesValue);
        }

        public override int GetHashCode()
        {
            return inchesValue.GetHashCode();
        }
    }
}