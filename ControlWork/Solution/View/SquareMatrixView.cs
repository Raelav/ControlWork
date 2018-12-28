using System;
using Solution.Factories;
using Solution.Interfaces;

namespace Solution.View
{
    class SquareMatrixView : IView
    {
        public void Main(SolutionFactory Factory)
        {
            var obj = CreateMatrix(Factory);
            FillMatrixRandomValue(obj);
            Console.WriteLine($"Addition with itself\n{obj.Add(obj).ToString()}");
            Console.WriteLine();
            Console.WriteLine($"Multiplication with itself\n{obj.Multiply(obj).ToString()}");
            Console.WriteLine();
            Console.WriteLine($"Substraction with itself\n{obj.Sub(obj).ToString()}");
            Console.WriteLine();
            Console.WriteLine($"Taking the reverse\n{obj.InverseToAdd().ToString()}");
        }

        private void FillMatrixRandomValue(ISquareMatrix obj)
        {
            var rnd = new Random();
            for (var i = 0; i < obj.Rank; i++)
                for(var j = 0; j < obj.Rank; j++)              
                    obj[i, j] = rnd.Next(100);
             Console.WriteLine(obj.ToString());
        }

        private ISquareMatrix CreateMatrix(SolutionFactory Factory)
        {
            Console.Write("Enter the rank of the matrix\r\n and a random matrix with this rank will be generated - ");
            try
            {
                return (ISquareMatrix)Factory.FactoryMethod(int.Parse(Console.ReadLine()));
            }
            catch
            {
                Console.WriteLine("Please enter valid data!");
                Console.WriteLine();
                return CreateMatrix(Factory);
            }
        }
    }
}
