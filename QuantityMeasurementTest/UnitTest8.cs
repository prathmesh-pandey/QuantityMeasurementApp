using NUnit.Framework;
using QuantityMeasurementApp;
using System;

namespace QuantityMeasurementTest
{
    [TestFixture]
    public class UC8Tests
    {
        private const double EPSILON = 1e-6;

        [Test]
        public void testLengthUnitEnum_FeetConstant()
        {
            double result = LengthUnit.Feet.ConvertToBaseUnit(1.0);
            Assert.That(result, Is.EqualTo(1.0));
        }

        [Test]
        public void testLengthUnitEnum_InchesConstant()
        {
            double result = LengthUnit.Inch.ConvertToBaseUnit(12.0);
            Assert.That(result, Is.EqualTo(1.0).Within(EPSILON));
        }

        [Test]
        public void testLengthUnitEnum_YardsConstant()
        {
            double result = LengthUnit.Yard.ConvertToBaseUnit(1.0);
            Assert.That(result, Is.EqualTo(3.0));
        }

        [Test]
        public void testLengthUnitEnum_CentimetersConstant()
        {
            double result = LengthUnit.Centimeter.ConvertToBaseUnit(30.48);
            Assert.That(result, Is.EqualTo(1.0).Within(EPSILON));
        }

        [Test]
        public void testConvertToBaseUnit_FeetToFeet()
        {
            double result = LengthUnit.Feet.ConvertToBaseUnit(5.0);
            Assert.That(result, Is.EqualTo(5.0));
        }

        [Test]
        public void testConvertToBaseUnit_InchesToFeet()
        {
            double result = LengthUnit.Inch.ConvertToBaseUnit(12.0);
            Assert.That(result, Is.EqualTo(1.0).Within(EPSILON));
        }

        [Test]
        public void testConvertToBaseUnit_YardsToFeet()
        {
            double result = LengthUnit.Yard.ConvertToBaseUnit(1.0);
            Assert.That(result, Is.EqualTo(3.0));
        }

        [Test]
        public void testConvertToBaseUnit_CentimetersToFeet()
        {
            double result = LengthUnit.Centimeter.ConvertToBaseUnit(30.48);
            Assert.That(result, Is.EqualTo(1.0).Within(EPSILON));
        }

        [Test]
        public void testConvertFromBaseUnit_FeetToFeet()
        {
            double result = LengthUnit.Feet.ConvertFromBaseUnit(2.0);
            Assert.That(result, Is.EqualTo(2.0));
        }

        [Test]
        public void testConvertFromBaseUnit_FeetToInches()
        {
            double result = LengthUnit.Inch.ConvertFromBaseUnit(1.0);
            Assert.That(result, Is.EqualTo(12.0));
        }

        [Test]
        public void testConvertFromBaseUnit_FeetToYards()
        {
            double result = LengthUnit.Yard.ConvertFromBaseUnit(3.0);
            Assert.That(result, Is.EqualTo(1.0));
        }

        [Test]
        public void testConvertFromBaseUnit_FeetToCentimeters()
        {
            double result = LengthUnit.Centimeter.ConvertFromBaseUnit(1.0);
            Assert.That(result, Is.EqualTo(30.48).Within(EPSILON));
        }

        [Test]
        public void testQuantityLengthRefactored_Equality()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength q2 = new QuantityLength(12.0, LengthUnit.Inch);

            Assert.That(q1.Equals(q2), Is.True);
        }

        [Test]
        public void testQuantityLengthRefactored_ConvertTo()
        {
            QuantityLength q = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength result = q.ConvertTo(LengthUnit.Inch);

            Assert.That(result.Equals(new QuantityLength(12.0, LengthUnit.Inch)), Is.True);
        }

        [Test]
        public void testQuantityLengthRefactored_Add()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength q2 = new QuantityLength(12.0, LengthUnit.Inch);

            QuantityLength result = q1.Add(q2);

            Assert.That(result.Equals(new QuantityLength(2.0, LengthUnit.Feet)), Is.True);
        }

        [Test]
        public void testQuantityLengthRefactored_AddWithTargetUnit()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength q2 = new QuantityLength(12.0, LengthUnit.Inch);

            QuantityLength result = QuantityLength.Add(q1, q2, LengthUnit.Yard);

            Assert.That(result.ToBase(), Is.EqualTo(new QuantityLength(2.0, LengthUnit.Feet).ToBase()).Within(EPSILON));
        }

        [Test]
        public void testQuantityLengthRefactored_NullUnit()
        {
            Assert.Throws<ArgumentException>(() =>
                new QuantityLength(1.0, (LengthUnit)999));
        }

        [Test]
        public void testQuantityLengthRefactored_InvalidValue()
        {
            Assert.Throws<ArgumentException>(() =>
                new QuantityLength(double.NaN, LengthUnit.Feet));
        }

        [Test]
        public void testBackwardCompatibility_UC1EqualityTests()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength q2 = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.That(q1.Equals(q2), Is.True);
        }

        [Test]
        public void testBackwardCompatibility_UC5ConversionTests()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.Feet, LengthUnit.Inch);

            Assert.That(result, Is.EqualTo(12.0));
        }

        [Test]
        public void testBackwardCompatibility_UC6AdditionTests()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength q2 = new QuantityLength(12.0, LengthUnit.Inch);

            QuantityLength result = q1.Add(q2);

            Assert.That(result.Equals(new QuantityLength(2.0, LengthUnit.Feet)), Is.True);
        }

        [Test]
        public void testBackwardCompatibility_UC7AdditionWithTargetUnitTests()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength q2 = new QuantityLength(12.0, LengthUnit.Inch);

            QuantityLength result = QuantityLength.Add(q1, q2, LengthUnit.Inch);

            Assert.That(result.Equals(new QuantityLength(24.0, LengthUnit.Inch)), Is.True);
        }

        [Test]
        public void testArchitecturalScalability_MultipleCategories()
        {
            bool isEnum = typeof(LengthUnit).IsEnum;
            Assert.That(isEnum, Is.True);
        }

        [Test]
        public void testRoundTripConversion_RefactoredDesign()
        {
            double value = 5.0;

            double inches = QuantityLength.Convert(value, LengthUnit.Feet, LengthUnit.Inch);
            double feetBack = QuantityLength.Convert(inches, LengthUnit.Inch, LengthUnit.Feet);

            Assert.That(feetBack, Is.EqualTo(value).Within(EPSILON));
        }

        [Test]
        public void testUnitImmutability()
        {
            Assert.That(Enum.IsDefined(typeof(LengthUnit), LengthUnit.Feet), Is.True);
        }
    }
}