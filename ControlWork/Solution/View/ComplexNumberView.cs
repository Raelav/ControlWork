using Solution.Factories;
using Solution.Interfaces;
using System;

namespace Solution.View
{
    public class ComplexNumberView : IView
    {
        public void Main(SolutionFactory Factory)
        {
            Console.WriteLine(
@"Комплексные числа

Введите поочередно 2 комплексных числа в любом из следующих форматов: 
1 + 2i, 1, 2i, i");
            Console.WriteLine();
            Console.WriteLine();

            var first = (IComplexNumber)Factory.FactoryMethod(Console.ReadLine());
            var second = (IComplexNumber)Factory.FactoryMethod(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine($"Сумма этих чисел равна {first.Add(second)}");
            Console.WriteLine();
            Console.WriteLine($"Разность этих чисел равна {first.Sub(second)}");
            Console.WriteLine();
            Console.WriteLine($"Произведение этих чисел равно {first.Multiply(second)}");
        }
    }
}
