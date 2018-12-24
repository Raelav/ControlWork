using System;
using Solution.Factories;
using Solution.Interfaces;

namespace Solution.View
{
    class RationalFractionView : IView
    {
        public void Main(SolutionFactory Factory)
        {
            Console.WriteLine(
@"Рациональные дроби

Введите поочередно 2 рациональных дроби в любом из следующих форматов: 
1/2, 24/7");
            Console.WriteLine();
            Console.WriteLine();

            var first = (IRationalFraction)Factory.FactoryMethod(Console.ReadLine());
            var second = (IRationalFraction)Factory.FactoryMethod(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine($"Сумма этих чисел равна {first.Add(second)}");
            Console.WriteLine();
            Console.WriteLine($"Разность этих чисел равна {first.Sub(second)}");
            Console.WriteLine();
            Console.WriteLine($"Произведение этих чисел равно {first.Multiply(second)}");
            Console.WriteLine();
            Console.WriteLine($"Частное этих чисел равно {first.Division(second)}");
        }
    }
}
