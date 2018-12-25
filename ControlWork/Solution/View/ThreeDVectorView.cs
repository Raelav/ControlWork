using System;
using Solution.Factories;
using Solution.Interfaces;

namespace Solution.View
{
    class ThreeDVectorView : IView
    {
        public void Main(SolutionFactory Factory)
        {
            Console.WriteLine("Enter the three coordinates of the first vector separated by a space");
            var vector1 = (IThreeDVector)Factory.FactoryMethod(Console.ReadLine());
            Console.WriteLine("Enter the three coordinates of the second vector separated by a space");
            var vector2 = (IThreeDVector)Factory.FactoryMethod(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine($"The Sum of the vectors is {vector1.Add(vector2)}");
            Console.WriteLine();
            Console.WriteLine($"The vectors difference is {vector1.Sub(vector2)}");
            Console.WriteLine();
            Console.WriteLine($"vector multiply is {vector1.VectorMultiply(vector2)}");
            Console.WriteLine();
            Console.WriteLine($"scalar multiply is {vector1.ScalarMultiply(vector2)}");
            Console.WriteLine();
            CompareLengths(vector1, vector2);
            Console.WriteLine();
            GetCoordinateByIndex(vector1);
        }

        private void CompareLengths(IThreeDVector vector1, IThreeDVector vector2)
        {
            var result = "";
            switch (vector1.Compare(vector2))
            {
                case -1:
                    result = "vector1 < vector2";
                    break;
                case 0:
                    result = "vector1 = vector2";
                    break;
                case 1:
                    result = "vector1 > vector2";
                    break;
            }

            Console.Write($"Compare their lengths: {result}");
            Console.WriteLine();
        }

        private void GetCoordinateByIndex(IThreeDVector vector)
        {
            Console.Write($"Enter the index of vector1 ");
            var result = 0;
            var index = Console.ReadLine();
            if (int.TryParse(index, out result) && result >= 0 && result < 3)
                Console.WriteLine($"Coodinate at index {result} is {vector[result]}");
            else Console.WriteLine("Invalid number entered");
        }
    }
}
