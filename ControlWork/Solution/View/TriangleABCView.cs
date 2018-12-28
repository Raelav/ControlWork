using System;
using Solution.Factories;
using Solution.Interfaces;

namespace Solution.View
{
    class TriangleABCView : IView
    {
        public void Main(SolutionFactory Factory)
        {
            var obj = GetObj(Factory);
            PrintPerimetetr(obj);
            PrintArea(obj);
            PrintTypeOfThriangle(obj);
            PrintViewOfThriangle(obj);
            Print(obj);
        }

        private ITriangleABC GetObj(SolutionFactory Factory)
        {
            Console.WriteLine("Enter three side of triangle");

            double ab = 0;
            double bc = 0;
            double ca = 0;

            if(double.TryParse(Console.ReadLine(), out ab) &&
            double.TryParse(Console.ReadLine(), out bc) &&
            double.TryParse(Console.ReadLine(), out ca) &&
            ab > 0 && bc > 0 && ca > 0)
                return (ITriangleABC)Factory.FactoryMethod(ab, bc, ca);

            Console.WriteLine();
            Console.WriteLine("Please enter valid data");
            return GetObj(Factory);
        }

        private void Print(ITriangleABC obj)
        {
            Console.WriteLine();
            obj.Print();
        }

        private void PrintPerimetetr(ITriangleABC obj)
        {
            Console.WriteLine();
            Console.WriteLine($"Perimeter of the triangle - {obj.Perimeter}");         
        }

        private void PrintArea(ITriangleABC obj)
        {
            Console.WriteLine();
            Console.WriteLine($"Area of the triangle - {obj.Area}");
        }

        private void PrintTypeOfThriangle(ITriangleABC obj)
        {
            Console.WriteLine();
            Console.Write($"Type of the triangle - ");
            obj.PrintType();
            Console.WriteLine();
        }

        private void PrintViewOfThriangle(ITriangleABC obj)
        {
            Console.WriteLine();
            Console.Write($"View of the triangle - ");
            obj.PrintView();
            Console.WriteLine();
        }
    }
}
