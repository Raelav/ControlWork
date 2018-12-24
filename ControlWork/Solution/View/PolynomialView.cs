using System;
using Solution.Factories;
using Solution.Interfaces;

namespace Solution.View
{
    class PolynomialView : IView
    {
        public void Main(SolutionFactory Factory)
        {
            Console.WriteLine(
    @"Многочлены

Введите через пробел коэффиценты чначала первого потом второго многочлена:");

            var value1 = Console.ReadLine();
            var value2 = Console.ReadLine();
            var polinom1 = (IPolynomial)Factory.FactoryMethod(value1);
            var polinom2 = (IPolynomial)Factory.FactoryMethod(value2);

            DoOperations(polinom1, polinom2);
            TakeCoeff(polinom1);

            Console.Write("Получить коэффицент первого полинома на позиции ");
            var index = Console.ReadLine();
            //if()
            Console.WriteLine();
            if (int.Parse(index) >= polinom1.Count)
                Console.WriteLine("Такой коэффицент отсутствует");
            else Console.WriteLine(polinom1[int.Parse(index)]);
        }

        private void TakeCoeff(IPolynomial polinom1)
        {
            throw new NotImplementedException();
        }

        private void DoOperations(IPolynomial polinom1, IPolynomial polinom2)
        {
            Console.WriteLine($"Сумма полиномов - {polinom1.Add(polinom2).ToString()}");
            Console.WriteLine();
            Console.WriteLine($"Разность полиномов - {polinom1.Sub(polinom2).ToString()}");
            Console.WriteLine();
            Console.WriteLine("Обратные полиномы");
            Console.WriteLine(polinom1.Inverse().ToString());
            Console.WriteLine(polinom2.Inverse().ToString());
            Console.WriteLine();
        }
    }
}
