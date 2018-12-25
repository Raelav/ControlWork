using NUnit.Framework;
using Solution.Factories;
using Solution.Interfaces;

namespace SolutionUnitTests
{
    class ThreeDVectorTests
    {
        private SolutionFactory Factory = new ThreeDVectorFactory();

        [TestCase("1 2 3", "3 4 5", "(-2, 4, -2)")]
        public void SimpleTests(string value1, string value2, string expected)
        {
            var vector1 = (IThreeDVector)Factory.FactoryMethod(value1);
            var vector2 = (IThreeDVector)Factory.FactoryMethod(value2);

            var actual = vector1.VectorMultiply(vector2).ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
