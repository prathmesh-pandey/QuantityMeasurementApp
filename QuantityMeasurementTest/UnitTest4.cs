using NUnit.Framework;
using QuantityMeasurementApp;
using System;

namespace QuantityMeasurementTest
{
    [TestFixture]
    public class UC5Tests
    {
        private const double EPSILON = 1e-6;


        [Test]
        public void testConversion_FeetToInches()
        {
            Assert.That(
                QuantityLength.Convert(1.0, LengthUnit.Feet, LengthUnit.Inch),
                Is.EqualTo(12.0).Within(EPSILON));
        }

        [Test]
        public void testConversion_InchesToFeet()
        {
            Assert.That(
                QuantityLength.Convert(24.0, LengthUnit.Inch, LengthUnit.Feet),
                Is.EqualTo(2.0).Within(EPSILON));
        }

        [Test]
        public void testConversion_YardsToInches()
        {
            Assert.That(
                QuantityLength.Convert(1.0, LengthUnit.Yard, LengthUnit.Inch),
                Is.EqualTo(36.0).Within(EPSILON));
        }

        [Test]
        public void testConversion_InchesToYards()
        {
            Assert.That(
                QuantityLength.Convert(72.0, LengthUnit.Inch, LengthUnit.Yard),
                Is.EqualTo(2.0).Within(EPSILON));
        }

        [Test]
        public void testConversion_CentimetersToInches()
        {
            Assert.That(
                QuantityLength.Convert(2.54, LengthUnit.Centimeter, LengthUnit.Inch),
                Is.EqualTo(1.0).Within(EPSILON));
        }

        [Test]
        public void testConversion_FeetToYard()
        {
            Assert.That(
                QuantityLength.Convert(6.0, LengthUnit.Feet, LengthUnit.Yard),
                Is.EqualTo(2.0).Within(EPSILON));
        }

        [Test]
        public void testConversion_RoundTrip_PreservesValue()
        {
            double original = 5.75;

            double converted = QuantityLength.Convert(original, LengthUnit.Feet, LengthUnit.Yard);
            double roundTrip = QuantityLength.Convert(converted, LengthUnit.Yard, LengthUnit.Feet);

            Assert.That(roundTrip, Is.EqualTo(original).Within(EPSILON));
        }

        [Test]
        public void testConversion_ZeroValue()
        {
            Assert.That(
                QuantityLength.Convert(0.0, LengthUnit.Feet, LengthUnit.Inch),
                Is.EqualTo(0.0));
        }

        [Test]
        public void testConversion_NegativeValue()
        {
            Assert.That(
                QuantityLength.Convert(-1.0, LengthUnit.Feet, LengthUnit.Inch),
                Is.EqualTo(-12.0).Within(EPSILON));
        }

        [Test]
        public void testConversion_SameUnit()
        {
            Assert.That(
                QuantityLength.Convert(5.0, LengthUnit.Feet, LengthUnit.Feet),
                Is.EqualTo(5.0));
        }

        [Test]
        public void testConversion_LargeValue()
        {
            Assert.That(
                QuantityLength.Convert(1000000.0, LengthUnit.Feet, LengthUnit.Inch),
                Is.EqualTo(12000000.0).Within(EPSILON));
        }

        [Test]
        public void testConversion_SmallValue()
        {
            Assert.That(
                QuantityLength.Convert(0.0001, LengthUnit.Feet, LengthUnit.Inch),
                Is.EqualTo(0.0012).Within(EPSILON));
        }

        [Test]
        public void testConversion_InvalidSourceUnit_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                QuantityLength.Convert(1.0, (LengthUnit)999, LengthUnit.Feet));
        }

        [Test]
        public void testConversion_InvalidTargetUnit_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                QuantityLength.Convert(1.0, LengthUnit.Feet, (LengthUnit)999));
        }

        [Test]
        public void testConversion_NaN_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                QuantityLength.Convert(double.NaN, LengthUnit.Feet, LengthUnit.Inch));
        }

        [Test]
        public void testConversion_Infinite_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                QuantityLength.Convert(double.PositiveInfinity, LengthUnit.Feet, LengthUnit.Inch));
        }

        [Test]
        public void testConversion_MultiStepConsistency()
        {
            double value = 2.0;

            double feet = QuantityLength.Convert(value, LengthUnit.Yard, LengthUnit.Feet);
            double inches = QuantityLength.Convert(feet, LengthUnit.Feet, LengthUnit.Inch);
            double backToYard = QuantityLength.Convert(inches, LengthUnit.Inch, LengthUnit.Yard);

            Assert.That(backToYard, Is.EqualTo(value).Within(EPSILON));
        }
    }
}