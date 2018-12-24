using System;

namespace ControlWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new object[] { 1 };

            Console.WriteLine(x.GetType());

            Console.WriteLine(x[0].GetType());

            if (x[0] is int)
                Console.WriteLine("Yes");
            else Console.WriteLine("No");
            Console.ReadLine();
        }
    }
}
