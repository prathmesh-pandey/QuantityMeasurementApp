using NUnit.Framework;
using QuantityMeasurementApp;

namespace QuantityMeasurementTest
{
    [TestFixture]
    public class UC2Tests
    {
        [Test]
        public void TestFeetEquality_SameValue()
        {
            Assert.That(Equality.CheckFeetEquality(1.0, 1.0), Is.True);
        }

        [Test]
        public void TestFeetEquality_DifferentValue()
        {
            Assert.That(Equality.CheckFeetEquality(1.0, 2.0), Is.False);
        }

        [Test]
        public void TestInchesEquality_SameValue()
        {
            Assert.That(Equality.CheckInchesEquality(1.0, 1.0), Is.True);
        }

        [Test]
        public void TestInchesEquality_DifferentValue()
        {
            Assert.That(Equality.CheckInchesEquality(1.0, 2.0), Is.False);
        }

        [Test]
        public void TestInchesEquality_NullComparison()
        {
            Inches i = new Inches(1.0);
            Assert.That(i.Equals(null), Is.False);
        }

        [Test]
        public void TestFeetEquality_SameReference()
        {
            Feet f = new Feet(1.0);
            Assert.That(f.Equals(f), Is.True);
        }
    }
}