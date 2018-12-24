using NUnit.Framework;
using Solution.Factories;
using Solution.Interfaces;

namespace TaskUnitTests
{
    class DateTests
    {
        SolutionFactory Factory = new DateFactory();

        [TestCase("23.10.2011", "23 October 2011г.")]
        [TestCase("29.02.2001", "28 February 2001г.")]
        [TestCase("29.02.2000", "29 February 2000г.")]
        public void DateSetDateTest(string input,string expected)
        {
            var value = (IDate)Factory.FactoryMethod(input);

            Assert.AreEqual(expected, value.ToString());
        }

        [TestCase("23.10.2011", "24 October 2011г.")]
        [TestCase("29.02.2001", "1 March 2001г.")]
        public void DateAddOneDayTests(string input, string expected)
        {
            var value = (IDate)Factory.FactoryMethod(input);
            value.AddOneDay();

            Assert.AreEqual(expected, value.ToString());
        }

        [TestCase("23.10.2011", "22 October 2011г.")]
        [TestCase("1.01.2001", "31 December 2000г.")]
        public void DateReduceOneDayTests(string input, string expected)
        {
            var value = (IDate)Factory.FactoryMethod(input);
            value.ReduceOneDay();

            Assert.AreEqual(expected, value.ToString());
        }

        [TestCase(10, "8 November 1991г.")]
        [TestCase(100, "6 February 1992г.")]
        //[TestCase(9905, "11 Декабря 2018г.")]
        public void DateAddDaysTests(int input, string expected)
        {

            var value = (IDate)Factory.FactoryMethod("29.10.1991");
            value.AddDays(input);

            Assert.AreEqual(expected, value.ToString());
        }
    }
}
