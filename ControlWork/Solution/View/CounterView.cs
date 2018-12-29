using System;
using Solution.Factories;
using Solution.Interfaces;

namespace Solution.View
{
    class CounterView : IView
    {
        public void Main(SolutionFactory Factory)
        {
            ICounter obj = GetCounterObj(Factory);
            Console.WriteLine(obj.ToString());
            ToChangeCounter(obj);
            Console.WriteLine("Two time increase of counter");
            obj.Inc();
            obj.Inc();
            Console.WriteLine("One time decrease of counter");
            obj.Dec();
            Console.WriteLine($"Current value of counter - {obj.Current}");
        }

        private void ToChangeCounter(ICounter obj)
        {
            newMaxValue(obj);
            newMinValue(obj);
            Console.WriteLine(obj.ToString());
        }

        private void newMinValue(ICounter obj)
        {
            Console.Write("New minimal value of counter - ");
            try
            {
                var result = int.Parse(Console.ReadLine());
                if (result >= obj.Max) throw new FormatException();
                obj.Start(result);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please enter valid date!");
                Console.WriteLine();
                newMinValue(obj);
            }
        }

        private void newMaxValue(ICounter obj)
        {
            Console.Write("New maximal value of counter - ");
            try
            {
                var result = int.Parse(Console.ReadLine());
                if (result <= obj.Min) throw new FormatException();
                obj.End(result);
            }
            catch(FormatException e)
            {
                Console.WriteLine("Please enter valid date!");
                Console.WriteLine();
                newMaxValue(obj);
            }
        }

        private ICounter GetCounterObj(SolutionFactory Factory)
        {
            Console.WriteLine("Enter the borders this counter:");
            int border1 = GetBorder("Border 1 - ");
            var border2 = GetBorder("Border 2 - ");
            return (ICounter)Factory.FactoryMethod(border1, border2);
        }

        private int GetBorder(string message)
        {
            Console.Write(message);
            try
            {
                var result = int.Parse(Console.ReadLine());
                return result;
            }
            catch(FormatException e)
            {
                Console.WriteLine("Please enter valid data");
                return GetBorder(message);
            }
        }
    }
}
