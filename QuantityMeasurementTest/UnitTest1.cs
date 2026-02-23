using NUnit.Framework;
using QuantityMeasurementApp;  
namespace QuantityMeasurementApp 
{
    [TestFixture]
    public class FeetTests
    {   
        private EqualityChecker checker;

        [SetUp]
        public void Setup()
        {
            checker = new EqualityChecker();
        }

        [Test]
        public void TestEquality_SameValue()
        {
            Feet f1 = new Feet(1.0);
            Feet f2 = new Feet(1.0);

            bool result = checker.AreEqual(f1, f2);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestEquality_DifferentValue()
        {
            Feet f1 = new Feet(1.0);
            Feet f2 = new Feet(2.0);

            bool result = checker.AreEqual(f1, f2);

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestEquality_NullComparison()
        {
            Feet f1 = new Feet(1.0);

            bool result = checker.AreEqual(f1, null);

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestEquality_SameReference()
        {
            Feet f1 = new Feet(1.0);

            bool result = checker.AreEqual(f1, f1);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestEquality_DifferentObjectType()
        {
            Feet f1 = new Feet(1.0);
            object obj = new object();

            bool result = f1.Equals(obj);

            Assert.That(result, Is.False);
        }
    }
}