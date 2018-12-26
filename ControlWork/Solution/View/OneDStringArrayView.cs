using System;
using Solution.Factories;
using Solution.Interfaces;
using System.Linq;

namespace Solution.View
{
    class OneDStringArrayView : IView
    {
        public void Main(SolutionFactory Factory)
        {
            var obj = CreateObj(Factory);
            FillArr(obj);
            obj.Print();
            Console.WriteLine();
            GetValue(obj);
            DoConcatenate(obj);
            DoMerge(obj);           
        }

        private void DoMerge(IOneDStringArray obj)
        {
            Console.WriteLine("Merge an array with itself. If successful, \r\nthe resulting array will match the original");
            obj.Merge(obj).Print();
            Console.WriteLine();
        }

        private void DoConcatenate(IOneDStringArray obj)
        {
            Console.WriteLine("Concatenate an array with itself");
            obj.Concat(obj).Print();
            Console.WriteLine();
        }

        private void GetValue(IOneDStringArray obj)
        {
            var index = 0;
            Console.Write("Enter string number - ");
            if (int.TryParse(Console.ReadLine(), out index))
                Console.WriteLine($"Line Number {index} - {obj[index]}");
            Console.WriteLine();
        }

        private void FillArr(IOneDStringArray obj)
        {
            Random random = new Random();
            for(var i = 0; i < obj.Length; i++)
            {
                obj[i] = RandomString(5, random);
            }
        }
      
        private static string RandomString(int length, Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    

        private IOneDStringArray CreateObj(SolutionFactory Factory)
        {
            Console.Write("Enter the length of the array to be created - ");
            var length = 0;
            if(int.TryParse(Console.ReadLine(), out length) && length >= 0)
            {
                Console.WriteLine();
                return (IOneDStringArray)Factory.FactoryMethod(length);
            }
            Console.WriteLine("Incorrect data entered. Try again");
            return CreateObj(Factory);
        }
    }
}
