using System;

namespace QuantityMeasurementApp
{
    public class QuantityLength
    {
        private readonly double value;
        private readonly LengthUnit unit;

        public QuantityLength(double value, LengthUnit unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid numeric value");

            if (!Enum.IsDefined(typeof(LengthUnit), unit))
                throw new ArgumentException("Invalid unit type");

            this.value = value;
            this.unit = unit;
        }

        public double ToBase()
        {
            return value * unit.ToBaseUnit();
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj == null || obj.GetType() != typeof(QuantityLength))
                return false;

            QuantityLength other = (QuantityLength)obj;

            return ToBase().Equals(other.ToBase());
        }

        public override int GetHashCode()
        {
            return ToBase().GetHashCode();
        }

        public override string ToString()
        {
            return $"Quantity({value}, {unit})";
        }
        public static double Convert(double value, LengthUnit source, LengthUnit target)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid numeric value");

            if (!Enum.IsDefined(typeof(LengthUnit), source))
                throw new ArgumentException("Invalid source unit");

            if (!Enum.IsDefined(typeof(LengthUnit), target))
                throw new ArgumentException("Invalid target unit");

            if (source == target)
                return value;

            double baseValue = value * source.ToBaseUnit();

            return baseValue / target.ToBaseUnit();
        }

        public QuantityLength ConvertTo(LengthUnit target)
        {
            double convertedValue = Convert(this.value, this.unit, target);
            return new QuantityLength(convertedValue, target);
        }

    }
}