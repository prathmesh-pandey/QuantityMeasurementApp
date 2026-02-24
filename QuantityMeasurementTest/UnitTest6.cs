using NUnit.Framework;
using QuantityMeasurementApp;
using System;

namespace QuantityMeasurementTest
{
    [TestFixture]
    public class UC6Tests
    {
        private const double EPSILON = 1e-6;

        [Test]
        public void testAddition_SameUnit_FeetPlusFeet()
        {
            var result = new QuantityLength(1.0, LengthUnit.Feet)
                .Add(new QuantityLength(2.0, LengthUnit.Feet));

            Assert.That(result.ToBase(), Is.EqualTo(3.0).Within(EPSILON));
        }

        [Test]
        public void testAddition_SameUnit_InchPlusInch()
        {
            var result = new QuantityLength(6.0, LengthUnit.Inch)
                .Add(new QuantityLength(6.0, LengthUnit.Inch));

            Assert.That(result.ToBase(), Is.EqualTo(
                new QuantityLength(12.0, LengthUnit.Inch).ToBase()
            ).Within(EPSILON));
        }
        [Test]
        public void testAddition_CrossUnit_InchPlusFeet()
        {
            var result = new QuantityLength(12.0, LengthUnit.Inch)
                .Add(new QuantityLength(1.0, LengthUnit.Feet));

            Assert.That(result.ToBase(), Is.EqualTo(
                new QuantityLength(24.0, LengthUnit.Inch).ToBase()
            ).Within(EPSILON));
        }

        [Test]
        public void testAddition_CrossUnit_YardPlusFeet()
        {
            var result = new QuantityLength(1.0, LengthUnit.Yard)
                .Add(new QuantityLength(3.0, LengthUnit.Feet));

            Assert.That(result.ToBase(), Is.EqualTo(
                new QuantityLength(2.0, LengthUnit.Yard).ToBase()
            ).Within(EPSILON));
        }

        [Test]
        public void testAddition_CrossUnit_CentimeterPlusInch()
        {
            var result = new QuantityLength(2.54, LengthUnit.Centimeter)
                .Add(new QuantityLength(1.0, LengthUnit.Inch));

            Assert.That(result.ToBase(), Is.EqualTo(
                new QuantityLength(5.08, LengthUnit.Centimeter).ToBase()
            ).Within(EPSILON));
        }

        [Test]
        public void testAddition_CrossUnit_FeetPlusInches()
        {
            var result = new QuantityLength(1.0, LengthUnit.Feet)
                .Add(new QuantityLength(12.0, LengthUnit.Inch));

            Assert.That(result.ToBase(), Is.EqualTo(
                new QuantityLength(2.0, LengthUnit.Feet).ToBase()
            ).Within(EPSILON));
        }

        [Test]
        public void testAddition_Commutativity()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inch);

            var r1 = a.Add(b);
            var r2 = b.Add(a);

            Assert.That(r1.ToBase(), Is.EqualTo(r2.ToBase()).Within(EPSILON));
        }

        [Test]
        public void testAddition_WithZero()
        {
            var result = new QuantityLength(5.0, LengthUnit.Feet)
                .Add(new QuantityLength(0.0, LengthUnit.Inch));

            Assert.That(result.ToBase(), Is.EqualTo(
                new QuantityLength(5.0, LengthUnit.Feet).ToBase()
            ).Within(EPSILON));
        }

        [Test]
        public void testAddition_NegativeValues()
        {
            var result = new QuantityLength(5.0, LengthUnit.Feet)
                .Add(new QuantityLength(-2.0, LengthUnit.Feet));

            Assert.That(result.ToBase(), Is.EqualTo(
                new QuantityLength(3.0, LengthUnit.Feet).ToBase()
            ).Within(EPSILON));
        }

        [Test]
        public void testAddition_NullSecondOperand()
        {
            Assert.Throws<ArgumentException>(() =>
                new QuantityLength(1.0, LengthUnit.Feet).Add(null));
        }

        [Test]
        public void testAddition_LargeValues()
        {
            var result = new QuantityLength(1e6, LengthUnit.Feet)
                .Add(new QuantityLength(1e6, LengthUnit.Feet));

            Assert.That(result.ToBase(), Is.EqualTo(
                new QuantityLength(2e6, LengthUnit.Feet).ToBase()
            ).Within(EPSILON));
        }

        [Test]
        public void testAddition_SmallValues()
        {
            var result = new QuantityLength(0.001, LengthUnit.Feet)
                .Add(new QuantityLength(0.002, LengthUnit.Feet));

            Assert.That(result.ToBase(), Is.EqualTo(
                new QuantityLength(0.003, LengthUnit.Feet).ToBase()
            ).Within(EPSILON));
        }
    }
}