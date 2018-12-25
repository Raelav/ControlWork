using NUnit.Framework;
using Solution.Factories;
using Solution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskUnitTests
{
    class NDimensionalVectorTests
    {
        private SolutionFactory Factory = new NDimensionalVectorFactory();

        [TestCase("1 2 3 4", "2 4 6 8")]
        [TestCase("", "0")]
        [TestCase("  asd", "0")]
        [TestCase("1,2 -2", "2,4 -4")]
        public void PolinomialAddTests(string input, string expected)
        {
            var value = (INDimensionalVector)Factory.FactoryMethod(input);
            var actual = value.Add(value).ToString();

            Assert.AreEqual(actual, expected);
        }

        [TestCase("1 2 3 4", "0 0 0 0")]
        [TestCase("", "0")]
        [TestCase("  asd", "0")]
        [TestCase("1,2 -2", "0 0")]
        public void PolinomialSubTests(string input, string expected)
        {
            var value = (INDimensionalVector)Factory.FactoryMethod(input);
            var actual = value.Sub(value).ToString();

            Assert.AreEqual(actual, expected);
        }

        [TestCase("1 2 3 4", "-1 -2 -3 -4")]
        [TestCase("", "0")]
        [TestCase("  asd", "0")]
        [TestCase("1,2 -2", "-1,2 2")]
        public void PolinomialInverseTests(string input, string expected)
        {
            var value = (INDimensionalVector)Factory.FactoryMethod(input);
            var actual = value.Inverse().ToString();

            Assert.AreEqual(actual, expected);
        }
    }
}
