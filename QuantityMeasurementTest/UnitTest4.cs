using NUnit.Framework;
using QuantityMeasurementApp;

namespace QuantityMeasurementTest
{
    [TestFixture]
    public class UC4Tests
    {
        // 1
        [Test]
        public void testEquality_YardToYard_SameValue()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Yard);
            var q2 = new QuantityLength(1.0, LengthUnit.Yard);
            Assert.That(q1.Equals(q2), Is.True);
        }

        // 2
        [Test]
        public void testEquality_YardToYard_DifferentValue()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Yard);
            var q2 = new QuantityLength(2.0, LengthUnit.Yard);
            Assert.That(q1.Equals(q2), Is.False);
        }

        // 3
        [Test]
        public void testEquality_YardToFeet_EquivalentValue()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yard);
            var feet = new QuantityLength(3.0, LengthUnit.Feet);
            Assert.That(yard.Equals(feet), Is.True);
        }

        // 4
        [Test]
        public void testEquality_FeetToYard_EquivalentValue()
        {
            var feet = new QuantityLength(3.0, LengthUnit.Feet);
            var yard = new QuantityLength(1.0, LengthUnit.Yard);
            Assert.That(feet.Equals(yard), Is.True);
        }

        // 5
        [Test]
        public void testEquality_YardToInches_EquivalentValue()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yard);
            var inch = new QuantityLength(36.0, LengthUnit.Inch);
            Assert.That(yard.Equals(inch), Is.True);
        }

        // 6
        [Test]
        public void testEquality_InchesToYard_EquivalentValue()
        {
            var inch = new QuantityLength(36.0, LengthUnit.Inch);
            var yard = new QuantityLength(1.0, LengthUnit.Yard);
            Assert.That(inch.Equals(yard), Is.True);
        }

        // 7
        [Test]
        public void testEquality_YardToFeet_NonEquivalentValue()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yard);
            var feet = new QuantityLength(2.0, LengthUnit.Feet);
            Assert.That(yard.Equals(feet), Is.False);
        }

        // 8
        [Test]
        public void testEquality_centimetersToInches_EquivalentValue()
        {
            var cm = new QuantityLength(1.0, LengthUnit.Centimeter);
            var inch = new QuantityLength(0.393701, LengthUnit.Inch);
            Assert.That(cm.Equals(inch), Is.True);
        }

        // 9
        [Test]
        public void testEquality_centimetersToFeet_NonEquivalentValue()
        {
            var cm = new QuantityLength(1.0, LengthUnit.Centimeter);
            var feet = new QuantityLength(1.0, LengthUnit.Feet);
            Assert.That(cm.Equals(feet), Is.False);
        }

        // 10
        [Test]
        public void testEquality_MultiUnit_TransitiveProperty()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yard);
            var feet = new QuantityLength(3.0, LengthUnit.Feet);
            var inch = new QuantityLength(36.0, LengthUnit.Inch);

            Assert.That(yard.Equals(feet), Is.True);
            Assert.That(feet.Equals(inch), Is.True);
            Assert.That(yard.Equals(inch), Is.True);
        }

        // 11
        [Test]
        public void testEquality_YardWithNullUnit()
        {
            Assert.Throws<System.ArgumentException>(() =>
                new QuantityLength(1.0, (LengthUnit)999));
        }

        // 12
        [Test]
        public void testEquality_YardSameReference()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yard);
            Assert.That(yard.Equals(yard), Is.True);
        }

        // 13
        [Test]
        public void testEquality_YardNullComparison()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yard);
            Assert.That(yard.Equals(null), Is.False);
        }

        // 14
        [Test]
        public void testEquality_CentimetersWithNullUnit()
        {
            Assert.Throws<System.ArgumentException>(() =>
                new QuantityLength(1.0, (LengthUnit)999));
        }

        // 15
        [Test]
        public void testEquality_CentimetersSameReference()
        {
            var cm = new QuantityLength(1.0, LengthUnit.Centimeter);
            Assert.That(cm.Equals(cm), Is.True);
        }

        // 16
        [Test]
        public void testEquality_CentimetersNullComparison()
        {
            var cm = new QuantityLength(1.0, LengthUnit.Centimeter);
            Assert.That(cm.Equals(null), Is.False);
        }

        // 17
        [Test]
        public void testEquality_AllUnits_ComplexScenario()
        {
            var yard = new QuantityLength(2.0, LengthUnit.Yard);
            var feet = new QuantityLength(6.0, LengthUnit.Feet);
            var inch = new QuantityLength(72.0, LengthUnit.Inch);

            Assert.That(yard.Equals(feet), Is.True);
            Assert.That(feet.Equals(inch), Is.True);
            Assert.That(yard.Equals(inch), Is.True);
        }
    }
}