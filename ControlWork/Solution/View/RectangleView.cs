using System;
using Solution.Factories;
using Solution.Interfaces;

namespace Solution.View
{
    class RectangleView : IView
    {
        public void Main(SolutionFactory Factory)
        {
            var obj = GetRectangleObj(Factory);
            Console.WriteLine();
            obj.Print();
            var testObj = (IRectangle)Factory.FactoryMethod(0, 0, 5, 5);
            Console.WriteLine();
            TestIntersect(obj, testObj);
            Console.WriteLine();
            FindRectangleContains(obj, testObj);
        }

        private void FindRectangleContains(IRectangle obj, IRectangle testObj)
        {
            Console.WriteLine("A rectangle contains of two others is:");
            obj.GetRectangleContainingTwoDate(testObj).Print();
        }

        private void TestIntersect(IRectangle obj, IRectangle testObj)
        {
            Console.WriteLine("For the demonstration will be used a rectangle with\r\nstart on (0, 0), width = 5 and height = 5");
            Console.WriteLine();
            Console.Write("Do the rectangles intersect? - ");
            Console.WriteLine(obj.Intesect(testObj) ? "Yes" : "No");
        }

        private IRectangle GetRectangleObj(SolutionFactory Factory)
        {
            Console.WriteLine("Enter the rectangle data");
            var x = GetValue("X -      ");
            var y = GetValue("Y -      ");
            var width = GetValue("Width -  ");
            var heght = GetValue("Height - ");
            return (IRectangle)Factory.FactoryMethod(x, y, width, heght);
        }

        private double GetValue(string message)
        {
            Console.Write(message);
            try
            {
                var result = double.Parse(Console.ReadLine());
                if (result <= 0) throw new FormatException();
                return result;     
            }
            catch(FormatException e)
            {
                Console.WriteLine("Please enter valid data");
                Console.WriteLine();
                return GetValue(message);
            }           
        }
    }
}
