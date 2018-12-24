using Solution.Factories;
using Solution.Interfaces;
using NUnit.Framework;

namespace TaskUnitTests
{
    class RationalFractionTests
    {
        private SolutionFactory factory = new RationalFractionFactory();

        [TestCase("1/5", "4/5", "1")]
        [TestCase("7/10", "93/10", "10")]
        [TestCase("7/3", "8/4", "13/3")]
        public void RationalFractionStringAddTests(string num1, string num2, string expected)
        {
            var value1 = (IRationalFraction)factory.FactoryMethod(num1);
            var value2 = (IRationalFraction)factory.FactoryMethod(num2);

            var actual = value1.Add(value2);

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestCase("1/5", "4/5", "-3/5")]
        [TestCase("7/10", "93/10", "-43/5")]
        [TestCase("2/7", "4/5", "-18/35")]
        public void RationalFractionStringSubTests(string num1, string num2, string expected)
        {
            var value1 = (IRationalFraction)factory.FactoryMethod(num1);
            var value2 = (IRationalFraction)factory.FactoryMethod(num2);

            var actual = value1.Sub(value2);

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestCase("1/5", "4/5", "4/25")]
        [TestCase("7/10", "2/4", "7/20")]
        public void RationalFractionStringMultiplyTests(string num1, string num2, string expected)
        {
            var value1 = (IRationalFraction)factory.FactoryMethod(num1);
            var value2 = (IRationalFraction)factory.FactoryMethod(num2);

            var actual = value1.Multiply(value2);

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestCase("1/5", "4/5", "1/4")]
        [TestCase("7/10", "93/10", "7/93")]
        public void RationalFractionStringDivisionTests(string num1, string num2, string expected)
        {
            var value1 = (IRationalFraction)factory.FactoryMethod(num1);
            var value2 = (IRationalFraction)factory.FactoryMethod(num2);

            var actual = value1.Division(value2);

            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
