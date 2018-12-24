using Solution.Factories;
using Solution.Interfaces;
using NUnit.Framework;

namespace TaskUnitTests
{
    class ComplexNumberTests
    {
        private SolutionFactory factory = new ComplexNumberFactory();

        [TestCase(1, 3, 2, 6, @"(3 + 9i)")]
        [TestCase(-4.2, -2, 0.2, -4, @"(-4 - 6i)")]
        [TestCase(0, 0, 0, 0, @"0")]
        [TestCase(0, 2, 0, 6, @"8i")]
        [TestCase(1, 0, 2, 0, @"3")]
        public void ComplexNumberAddTests(double real1, double imagin1, double real2, double imagin2, string expected)
        {
            var value1 = (IComplexNumber)factory.FactoryMethod(real1, imagin1);
            var value2 = (IComplexNumber)factory.FactoryMethod(real2, imagin2);

            var actual = value1.Add(value2);

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestCase("-1 + 2i", "", "(-1 + 2i)")]
        [TestCase("-0,241", "1 - 2i", "(0,759 - 2i)")]
        [TestCase("test", "test", "0")]
        public void ComplexNumberStringsAddTests(string first, string second, string expected)
        {
            var value1 = (IComplexNumber)factory.FactoryMethod(first);
            var value2 = (IComplexNumber)factory.FactoryMethod(second);

            var actual = value1.Add(value2);

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestCase(1, 3, 2, 6, @"(-1 - 3i)")]
        [TestCase(-4.2, -2, 0.2, -4, @"(-4,4 + 2i)")]
        [TestCase(0, 0, 0, 0, @"0")]
        [TestCase(0, 2, 0, 6, @"-4i")]
        [TestCase(1, 0, 2, 0, @"-1")]
        public void ComplexNumberSubTest(double real1, double imagin1, double real2, double imagin2, string expected)
        {
            var value1 = (IComplexNumber)factory.FactoryMethod(real1, imagin1);
            var value2 = (IComplexNumber)factory.FactoryMethod(real2, imagin2);

            var actual = value1.Sub(value2).ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestCase("-1 + 2i", "", "(-1 + 2i)")]
        [TestCase("-0,241", "1 - 2i", "(-1,241 + 2i)")]
        [TestCase("test", "test", "0")]
        public void ComplexNumberStringsSubTests(string first, string second, string expected)
        {
            var value1 = (IComplexNumber)factory.FactoryMethod(first);
            var value2 = (IComplexNumber)factory.FactoryMethod(second);

            var actual = value1.Sub(value2);

            Assert.AreEqual(expected, actual.ToString());
        }

        [TestCase(1, 3, 2, 6, @"(-16 + 12i)")]
        [TestCase(-4.2, -2, 0.2, -4, @"(-8,84 + 16,4i)")]
        [TestCase(0, 0, 0, 0, @"0")]
        [TestCase(0, 2, 0, 6, @"-12")]
        [TestCase(1, 0, 2, 0, @"2")]
        public void ComplexNumberMulyiplyTest(double real1, double imagin1, double real2, double imagin2, string expected)
        {
            var value1 = (IComplexNumber)factory.FactoryMethod(real1, imagin1);
            var value2 = (IComplexNumber)factory.FactoryMethod(real2, imagin2);

            var actual = value1.Multiply(value2).ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestCase("-1 + 2i", "", "0")]
        [TestCase("-0,241", "1 - 2i", "(-0,241 + 0,482i)")]
        [TestCase("test", "test", "0")]
        public void ComplexNumberStringsMultiplyTests(string first, string second, string expected)
        {
            var value1 = (IComplexNumber)factory.FactoryMethod(first);
            var value2 = (IComplexNumber)factory.FactoryMethod(second);

            var actual = value1.Multiply(value2);

            Assert.AreEqual(expected, actual.ToString());
        }
    }
}

