using NUnit.Framework;
using System;
using func;

namespace func.Tests
{
    [TestFixture(1.618)]
    public class Tests
    {
        static double search_value_func(double x) { return Math.Pow(x + 1, 3) + 5 * x * x; }
        private CalculatorExtremum CE;
        private double PHI;
        public Tests(double phi)
        {
            PHI = phi;
        }
        [SetUp]
        public void Setup()
        {
            CE = new CalculatorExtremum();
        }

        [Test]
        public void Test1()
        {
            var result = CE.calc_golden_section((x)=> x * x, 0, 3, 0.001, PHI, "MAX");
            Assert.That(result >= (3-0.001) && result <= (3+0.001));
        }

        [Test]
        public void Test2()
        {
            var result = CE.calc_golden_section((x) => x * x - Math.Sqrt(x/6), 0, 5, 0.001, PHI, "MIN");
            Assert.That(result >= (0.2 - 0.001) && result <= (0.2 + 0.1));
        }

        [Test]
        public void Test3()
        {
            var result = CE.calc_golden_section((x) => x * x * x, -3, 0, 0.001, PHI, "MIN");
            Assert.That(result >= (-3 - 0.001) && result <= (-3 + 0.001));
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}