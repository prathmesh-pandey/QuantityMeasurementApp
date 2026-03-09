using System;

namespace QuantityMeasurementApp
{
    public class QuantityWeight
    {
        private readonly double value;
        private readonly WeightUnit unit;

        public QuantityWeight(double value, WeightUnit unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid numeric value");

            if (!Enum.IsDefined(typeof(WeightUnit), unit))
                throw new ArgumentException("Invalid unit");

            this.value = value;
            this.unit = unit;
        }

        public double ToBase()
        {
            return unit.ConvertToBaseUnit(value);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj == null || obj.GetType() != typeof(QuantityWeight))
                return false;

            QuantityWeight other = (QuantityWeight)obj;

            return Math.Abs(this.ToBase() - other.ToBase()) < 1e-6;
        }

        public override int GetHashCode()
        {
            return ToBase().GetHashCode();
        }

        public QuantityWeight ConvertTo(WeightUnit target)
        {
            double baseValue = ToBase();
            double converted = target.ConvertFromBaseUnit(baseValue);

            return new QuantityWeight(converted, target);
        }

        public QuantityWeight Add(QuantityWeight other)
        {
            if (other == null)
                throw new ArgumentException("Second operand cannot be null");

            double baseSum = this.ToBase() + other.ToBase();
            double resultValue = unit.ConvertFromBaseUnit(baseSum);

            return new QuantityWeight(resultValue, unit);
        }

        public static QuantityWeight Add(
            QuantityWeight first,
            QuantityWeight second,
            WeightUnit targetUnit)
        {
            if (first == null || second == null)
                throw new ArgumentException("Operands cannot be null");

            double baseSum = first.ToBase() + second.ToBase();
            double resultValue = targetUnit.ConvertFromBaseUnit(baseSum);

            return new QuantityWeight(resultValue, targetUnit);
        }

        public override string ToString()
        {
            return $"Quantity({value}, {unit})";
        }
    }
}