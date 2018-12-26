using System;
using Solution.Factories;
using Solution.Interfaces;
using Solution.Classes;

namespace Solution.View
{
    class NDimensionalVectorView : IView
    {
        public void Main(SolutionFactory Factory)
        {
            var obj1 = EnterVector(Factory);
            Console.WriteLine();
            var obj2 = EnterVector(Factory);
            SomeOperations(obj1, obj2);
            ReverseVectors(obj1, obj2);
            CompareVectors(obj1, obj2);
            VectorLengths(obj1, obj2);
            ViewValueByIndex(obj1);
        }

        private void ViewValueByIndex(INDimensionalVector obj1)
        {
            Console.Write("Enter index of first vector - ");
            var str = Console.ReadLine();
            var index = 0;
            if (int.TryParse(str, out index))
            {
                Console.WriteLine($"Vector1[{index}] = {obj1[index]}");
            }
            else Console.WriteLine("invalid data entered");
        }

        private void VectorLengths(INDimensionalVector obj1, INDimensionalVector obj2)
        {
            Console.WriteLine();
            Console.WriteLine($"First vector length - {obj1.GetLength()}");
            Console.WriteLine($"Second vector length - {obj2.GetLength()}");
            Console.WriteLine();
        }

        private void CompareVectors(INDimensionalVector obj1, INDimensionalVector obj2)
        {
            Console.WriteLine();
            var result = obj1.CoordinateComparsion(obj2);
            switch (result)
            {
                case -1:
                    Console.WriteLine("vector1 < vector2");
                    break;
                case 0:
                    Console.WriteLine("vector1 = vector2");
                    break;
                case 1:
                    Console.WriteLine("vector1 > vector2");
                    break;
            }
        }

        private void ReverseVectors(INDimensionalVector obj1, INDimensionalVector obj2)
        {
            Console.WriteLine("Taking inverse vectors");
            Console.WriteLine(obj1.Inverse());
            Console.WriteLine(obj2.Inverse());
        }

        private void SomeOperations(INDimensionalVector obj1, INDimensionalVector obj2)
        {
            Console.WriteLine();
            Console.WriteLine($"Their sum is - {obj1.Add(obj2)}");
            Console.WriteLine();
            Console.WriteLine($"Their difference is - {obj1.Sub(obj2)}");
            Console.WriteLine();
            Console.WriteLine($"Their scalar multiplication is - {obj1.ScalarMultiply(obj2)}");
            Console.WriteLine();
        }

        private INDimensionalVector EnterVector(SolutionFactory Factory)
        {
            Console.WriteLine("Space separated vector coordinates");
            return (INDimensionalVector)Factory.FactoryMethod(Console.ReadLine());
        }
    }
}
