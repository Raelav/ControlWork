using System;
using Solution.Factories;
using Solution.Interfaces;

namespace Solution.View
{
    class OneDArrayView : IView
    {
        public void Main(SolutionFactory Factory)
        {
            IOneDArray obj = CreateObj(Factory);
            Console.WriteLine();
            FillArrayRandomValue(obj);
            Console.WriteLine(obj.ToString());
            Console.WriteLine();
            GetElem(obj);
            Console.WriteLine();
            MakeAddition(obj);
            DivisionAndMultiplication(obj);
            Console.WriteLine();
            Console.WriteLine($"Max - {obj.Max()}");
            Console.WriteLine($"Min - {obj.Min()}");
            Console.WriteLine();
            obj.Print();
        }

        private void DivisionAndMultiplication(IOneDArray obj)
        {
            Console.WriteLine();
            Console.WriteLine("Get the sum of the current array with itself");
            var Sum = obj.Add(obj);
            Console.WriteLine(Sum);
            Console.WriteLine("Now subtract the starting array from the result");
            Console.WriteLine(Sum.Sub(obj));
        }

        private void MakeAddition(IOneDArray obj)
        {
            Console.WriteLine("First, multiply the array by 8, then divide the result by 2");
            obj.Multiply(8);
            Console.WriteLine(obj);
            obj.Division(2);
            Console.WriteLine(obj);           
        }

        private void FillArrayRandomValue(IOneDArray obj)
        {
            var rnd = new Random();
            for(var i = obj.StartIndex; i < obj.Length + obj.StartIndex; i++)
            {
                obj[i] = rnd.Next();
            }
        }

        private void GetElem(IOneDArray obj)
        {
            var index = 0;
            Console.Write("Get item with index - ");
            
            if(int.TryParse(Console.ReadLine(), out index))
                Console.WriteLine(obj[index]);
            else
            {
                Console.WriteLine("Invalid value. Please enter INT type value.");
                GetElem(obj);
            }
        }

        private IOneDArray CreateObj(SolutionFactory Factory)
        {
            var startIndex = 0;
            var length = 1;

            Console.WriteLine("Create an array");
            Console.Write("Starting index -                       ");
            int.TryParse(Console.ReadLine(), out startIndex);
            Console.Write("Array length starting at given index - ");
            int.TryParse(Console.ReadLine(), out length);

            return (IOneDArray)Factory.FactoryMethod(startIndex, length);
        }
    }
}
