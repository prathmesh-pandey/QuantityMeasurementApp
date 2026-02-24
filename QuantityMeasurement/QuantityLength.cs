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
        public QuantityLength Add(QuantityLength other)
        {
            if (other == null)
                throw new ArgumentException("Second operand cannot be null");

            double baseSum = this.ToBase() + other.ToBase();

            double resultValue = baseSum / this.unit.ToBaseUnit();

            return new QuantityLength(resultValue, this.unit);
        }

        public static QuantityLength Add(
    QuantityLength first,
    QuantityLength second,
    LengthUnit targetUnit)
        {
            if (first == null)
                throw new ArgumentException("First operand cannot be null");

            if (second == null)
                throw new ArgumentException("Second operand cannot be null");

            if (!Enum.IsDefined(typeof(LengthUnit), targetUnit))
                throw new ArgumentException("Invalid target unit");

            double baseSum = first.ToBase() + second.ToBase();

            double resultValue = baseSum / targetUnit.ToBaseUnit();

            return new QuantityLength(resultValue, targetUnit);
        }
    }
}