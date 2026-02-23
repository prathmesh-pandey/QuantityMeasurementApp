using System;

namespace QuantityMeasurementApp
{
    public class Feet
    {
        private readonly double feetValue;

        public Feet(double value)
        {
            feetValue = value;
        }

        public double Value
        {
            get { return feetValue; }
        }

        public override bool Equals(object obj)
        {
            // Reflexive check
            if (ReferenceEquals(this, obj))
                return true;

            // Null and type check
            if (obj == null || obj.GetType() != typeof(Feet))
                return false;

            Feet other = (Feet)obj;

            // Proper floating-point comparison
            return feetValue.Equals(other.feetValue);
        }

        public override int GetHashCode()
        {
            return feetValue.GetHashCode();
        }
    }
}