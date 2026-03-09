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
        [TestFixture]
        public class UC9Tests
        {
            private const double EPSILON = 1e-5;

            [Test]
            public void testEquality_KilogramToKilogram_SameValue()
            {
                var q1 = new QuantityWeight(1.0, WeightUnit.Kilogram);
                var q2 = new QuantityWeight(1.0, WeightUnit.Kilogram);

                Assert.That(q1.Equals(q2), Is.True);
            }

            [Test]
            public void testEquality_KilogramToKilogram_DifferentValue()
            {
                var q1 = new QuantityWeight(1.0, WeightUnit.Kilogram);
                var q2 = new QuantityWeight(2.0, WeightUnit.Kilogram);

                Assert.That(q1.Equals(q2), Is.False);
            }

            [Test]
            public void testEquality_KilogramToGram_EquivalentValue()
            {
                var q1 = new QuantityWeight(1.0, WeightUnit.Kilogram);
                var q2 = new QuantityWeight(1000.0, WeightUnit.Gram);

                Assert.That(q1.Equals(q2), Is.True);
            }

            [Test]
            public void testEquality_GramToKilogram_EquivalentValue()
            {
                var q1 = new QuantityWeight(1000.0, WeightUnit.Gram);
                var q2 = new QuantityWeight(1.0, WeightUnit.Kilogram);

                Assert.That(q1.Equals(q2), Is.True);
            }

            [Test]
            public void testEquality_WeightVsLength_Incompatible()
            {
                var weight = new QuantityWeight(1.0, WeightUnit.Kilogram);
                var length = new QuantityLength(1.0, LengthUnit.Feet);

                Assert.That(weight.Equals(length), Is.False);
            }

            [Test]
            public void testEquality_NullComparison()
            {
                var q1 = new QuantityWeight(1.0, WeightUnit.Kilogram);

                Assert.That(q1.Equals(null), Is.False);
            }

            [Test]
            public void testEquality_SameReference()
            {
                var q1 = new QuantityWeight(1.0, WeightUnit.Kilogram);

                Assert.That(q1.Equals(q1), Is.True);
            }

            [Test]
            public void testEquality_NullUnit()
            {
                Assert.Throws<ArgumentException>(() =>
                    new QuantityWeight(1.0, (WeightUnit)999));
            }

            [Test]
            public void testEquality_ZeroValue()
            {
                var a = new QuantityWeight(0.0, WeightUnit.Kilogram);
                var b = new QuantityWeight(0.0, WeightUnit.Gram);

                Assert.That(a.Equals(b), Is.True);
            }

            [Test]
            public void testEquality_NegativeWeight()
            {
                var a = new QuantityWeight(-1.0, WeightUnit.Kilogram);
                var b = new QuantityWeight(-1000.0, WeightUnit.Gram);

                Assert.That(a.Equals(b), Is.True);
            }

            [Test]
            public void testEquality_LargeWeightValue()
            {
                var a = new QuantityWeight(1000000.0, WeightUnit.Gram);
                var b = new QuantityWeight(1000.0, WeightUnit.Kilogram);

                Assert.That(a.Equals(b), Is.True);
            }

            [Test]
            public void testEquality_SmallWeightValue()
            {
                var a = new QuantityWeight(0.001, WeightUnit.Kilogram);
                var b = new QuantityWeight(1.0, WeightUnit.Gram);

                Assert.That(a.Equals(b), Is.True);
            }

            [Test]
            public void testConversion_PoundToKilogram()
            {
                var q = new QuantityWeight(2.20462, WeightUnit.Pound);
                var result = q.ConvertTo(WeightUnit.Kilogram);

                Assert.That(result.ToBase(), Is.EqualTo(1.0).Within(EPSILON));
            }

            [Test]
            public void testConversion_KilogramToPound()
            {
                var q = new QuantityWeight(1.0, WeightUnit.Kilogram);
                var result = q.ConvertTo(WeightUnit.Pound);

                Assert.That(result.ToBase(), Is.EqualTo(q.ToBase()).Within(EPSILON));
            }

            [Test]
            public void testConversion_SameUnit()
            {
                var q = new QuantityWeight(5.0, WeightUnit.Kilogram);
                var result = q.ConvertTo(WeightUnit.Kilogram);

                Assert.That(result.Equals(q), Is.True);
            }

            [Test]
            public void testConversion_ZeroValue()
            {
                var q = new QuantityWeight(0.0, WeightUnit.Kilogram);
                var result = q.ConvertTo(WeightUnit.Gram);

                Assert.That(result.Equals(new QuantityWeight(0.0, WeightUnit.Gram)), Is.True);
            }

            [Test]
            public void testConversion_NegativeValue()
            {
                var q = new QuantityWeight(-1.0, WeightUnit.Kilogram);
                var result = q.ConvertTo(WeightUnit.Gram);

                Assert.That(result.Equals(new QuantityWeight(-1000.0, WeightUnit.Gram)), Is.True);
            }

            [Test]
            public void testConversion_RoundTrip()
            {
                var q = new QuantityWeight(1.5, WeightUnit.Kilogram);
                var result = q.ConvertTo(WeightUnit.Gram).ConvertTo(WeightUnit.Kilogram);

                Assert.That(result.ToBase(), Is.EqualTo(q.ToBase()).Within(EPSILON));
            }

            [Test]
            public void testAddition_SameUnit_KilogramPlusKilogram()
            {
                var a = new QuantityWeight(1.0, WeightUnit.Kilogram);
                var b = new QuantityWeight(2.0, WeightUnit.Kilogram);

                var result = a.Add(b);

                Assert.That(result.Equals(new QuantityWeight(3.0, WeightUnit.Kilogram)), Is.True);
            }

            [Test]
            public void testAddition_CrossUnit_KilogramPlusGram()
            {
                var a = new QuantityWeight(1.0, WeightUnit.Kilogram);
                var b = new QuantityWeight(1000.0, WeightUnit.Gram);

                var result = a.Add(b);

                Assert.That(result.Equals(new QuantityWeight(2.0, WeightUnit.Kilogram)), Is.True);
            }

            [Test]
            public void testAddition_CrossUnit_PoundPlusKilogram()
            {
                var a = new QuantityWeight(2.20462, WeightUnit.Pound);
                var b = new QuantityWeight(1.0, WeightUnit.Kilogram);

                var result = a.Add(b);

                Assert.That(result.ToBase(), Is.EqualTo(2.0).Within(EPSILON));
            }

            [Test]
            public void testAddition_ExplicitTargetUnit_Kilogram()
            {
                var a = new QuantityWeight(1.0, WeightUnit.Kilogram);
                var b = new QuantityWeight(1000.0, WeightUnit.Gram);

                var result = QuantityWeight.Add(a, b, WeightUnit.Gram);

                Assert.That(result.Equals(new QuantityWeight(2000.0, WeightUnit.Gram)), Is.True);
            }

            [Test]
            public void testAddition_Commutativity()
            {
                var a = new QuantityWeight(1.0, WeightUnit.Kilogram);
                var b = new QuantityWeight(1000.0, WeightUnit.Gram);

                Assert.That(a.Add(b).ToBase(), Is.EqualTo(b.Add(a).ToBase()).Within(EPSILON));
            }

            [Test]
            public void testAddition_WithZero()
            {
                var a = new QuantityWeight(5.0, WeightUnit.Kilogram);
                var b = new QuantityWeight(0.0, WeightUnit.Gram);

                Assert.That(a.Add(b).Equals(new QuantityWeight(5.0, WeightUnit.Kilogram)), Is.True);
            }

            [Test]
            public void testAddition_NegativeValues()
            {
                var a = new QuantityWeight(5.0, WeightUnit.Kilogram);
                var b = new QuantityWeight(-2000.0, WeightUnit.Gram);

                Assert.That(a.Add(b).Equals(new QuantityWeight(3.0, WeightUnit.Kilogram)), Is.True);
            }

            [Test]
            public void testAddition_LargeValues()
            {
                var a = new QuantityWeight(1e6, WeightUnit.Kilogram);
                var b = new QuantityWeight(1e6, WeightUnit.Kilogram);

                Assert.That(a.Add(b).Equals(new QuantityWeight(2e6, WeightUnit.Kilogram)), Is.True);
            }
        }
    }
}