using NUnit.Framework;
using QuantityMeasurementApp;
using System;

namespace QuantityMeasurementTest
{
    [TestFixture]
    public class UC7Tests
    {
        private const double EPSILON = 1e-6;

        [Test]
        public void testAddition_ExplicitTargetUnit_Feet()
        {
            var result = QuantityLength.Add(
                new QuantityLength(1.0, LengthUnit.Feet),
                new QuantityLength(12.0, LengthUnit.Inch),
                LengthUnit.Feet);

            Assert.That(result.ToBase(),
                Is.EqualTo(new QuantityLength(2.0, LengthUnit.Feet).ToBase())
                .Within(EPSILON));
        }

        [Test]
        public void testAddition_ExplicitTargetUnit_Inches()
        {
            var result = QuantityLength.Add(
                new QuantityLength(1.0, LengthUnit.Feet),
                new QuantityLength(12.0, LengthUnit.Inch),
                LengthUnit.Inch);

            Assert.That(result.ToBase(),
                Is.EqualTo(new QuantityLength(24.0, LengthUnit.Inch).ToBase())
                .Within(EPSILON));
        }

        [Test]
        public void testAddition_ExplicitTargetUnit_Yards()
        {
            var result = QuantityLength.Add(
                new QuantityLength(1.0, LengthUnit.Feet),
                new QuantityLength(12.0, LengthUnit.Inch),
                LengthUnit.Yard);

            Assert.That(result.ToBase(),
                Is.EqualTo(new QuantityLength(2.0, LengthUnit.Feet).ToBase())
                .Within(EPSILON));
        }

        [Test]
        public void testAddition_ExplicitTargetUnit_Centimeters()
        {
            var result = QuantityLength.Add(
                new QuantityLength(1.0, LengthUnit.Inch),
                new QuantityLength(1.0, LengthUnit.Inch),
                LengthUnit.Centimeter);

            Assert.That(result.ToBase(),
                Is.EqualTo(new QuantityLength(5.08, LengthUnit.Centimeter).ToBase())
                .Within(EPSILON));
        }

        [Test]
        public void testAddition_ExplicitTargetUnit_Commutativity()
        {
            var r1 = QuantityLength.Add(
                new QuantityLength(1.0, LengthUnit.Feet),
                new QuantityLength(12.0, LengthUnit.Inch),
                LengthUnit.Yard);

            var r2 = QuantityLength.Add(
                new QuantityLength(12.0, LengthUnit.Inch),
                new QuantityLength(1.0, LengthUnit.Feet),
                LengthUnit.Yard);

            Assert.That(r1.ToBase(), Is.EqualTo(r2.ToBase()).Within(EPSILON));
        }

        [Test]
        public void testAddition_ExplicitTargetUnit_WithZero()
        {
            var result = QuantityLength.Add(
                new QuantityLength(5.0, LengthUnit.Feet),
                new QuantityLength(0.0, LengthUnit.Inch),
                LengthUnit.Yard);

            Assert.That(result.ToBase(),
                Is.EqualTo(new QuantityLength(5.0, LengthUnit.Feet).ToBase())
                .Within(EPSILON));
        }

        [Test]
        public void testAddition_ExplicitTargetUnit_NegativeValues()
        {
            var result = QuantityLength.Add(
                new QuantityLength(5.0, LengthUnit.Feet),
                new QuantityLength(-2.0, LengthUnit.Feet),
                LengthUnit.Inch);

            Assert.That(result.ToBase(),
                Is.EqualTo(new QuantityLength(3.0, LengthUnit.Feet).ToBase())
                .Within(EPSILON));
        }

        [Test]
        public void testAddition_ExplicitTargetUnit_NullTargetUnit()
        {
            Assert.Throws<ArgumentException>(() =>
                QuantityLength.Add(
                    new QuantityLength(1.0, LengthUnit.Feet),
                    new QuantityLength(12.0, LengthUnit.Inch),
                    (LengthUnit)999));
        }

        [Test]
        public void testAddition_ExplicitTargetUnit_LargeToSmallScale()
        {
            var result = QuantityLength.Add(
                new QuantityLength(1000.0, LengthUnit.Feet),
                new QuantityLength(500.0, LengthUnit.Feet),
                LengthUnit.Inch);

            Assert.That(result.ToBase(),
                Is.EqualTo(new QuantityLength(1500.0, LengthUnit.Feet).ToBase())
                .Within(EPSILON));
        }

        [Test]
        public void testAddition_ExplicitTargetUnit_SmallToLargeScale()
        {
            var result = QuantityLength.Add(
                new QuantityLength(12.0, LengthUnit.Inch),
                new QuantityLength(12.0, LengthUnit.Inch),
                LengthUnit.Yard);

            Assert.That(result.ToBase(),
                Is.EqualTo(new QuantityLength(24.0, LengthUnit.Inch).ToBase())
                .Within(EPSILON));
        }
        [Test]
        public void testAddition_ExplicitTargetUnit_SameAsFirstOperand()
        {
            var result = QuantityLength.Add(
                new QuantityLength(2.0, LengthUnit.Yard),
                new QuantityLength(3.0, LengthUnit.Feet),
                LengthUnit.Yard);

            Assert.That(result.ToBase(),
                Is.EqualTo(new QuantityLength(3.0, LengthUnit.Yard).ToBase())
                .Within(EPSILON));
        }
        [Test]
        public void testAddition_ExplicitTargetUnit_SameAsSecondOperand()
        {
            var result = QuantityLength.Add(
                new QuantityLength(2.0, LengthUnit.Yard),
                new QuantityLength(3.0, LengthUnit.Feet),
                LengthUnit.Feet);

            Assert.That(result.ToBase(),
                Is.EqualTo(new QuantityLength(9.0, LengthUnit.Feet).ToBase())
                .Within(EPSILON));
        }
        [Test]
        public void testAddition_ExplicitTargetUnit_AllUnitCombinations()
        {
            var result = QuantityLength.Add(
                new QuantityLength(1.0, LengthUnit.Yard),
                new QuantityLength(36.0, LengthUnit.Inch),
                LengthUnit.Feet);

            Assert.That(result.ToBase(),
                Is.EqualTo(new QuantityLength(6.0, LengthUnit.Feet).ToBase())
                .Within(EPSILON));
        }
        [Test]
        public void testAddition_ExplicitTargetUnit_PrecisionTolerance()
        {
            var result = QuantityLength.Add(
                new QuantityLength(0.1, LengthUnit.Feet),
                new QuantityLength(0.2, LengthUnit.Feet),
                LengthUnit.Inch);

            var expected = new QuantityLength(0.3, LengthUnit.Feet).ConvertTo(LengthUnit.Inch);

            Assert.That(result.ToBase(),
                Is.EqualTo(expected.ToBase())
                .Within(EPSILON));
        }
    }
}