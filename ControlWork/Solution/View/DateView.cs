using System;
using Solution.Factories;
using Solution.Interfaces;

namespace Solution.View
{
    class DateView : IView
    {
        public void Main(SolutionFactory Factory)
        {
            int service = 0;
            Console.WriteLine(
    @"Класс Дата

Введите некоторую дату в следующем формате: 
01.01.2001");
            Console.WriteLine();
            Console.WriteLine();

            var first = (IDate)Factory.FactoryMethod();

            first.SetDate(Console.ReadLine());
            Console.WriteLine($"Вы ввели дату {first.ToString()}");
            Console.WriteLine();
            first.AddOneDay();
            Console.WriteLine($"Добавим один день - {first.ToString()}");

            Console.WriteLine();
            first.ReduceOneDay();
            Console.WriteLine($"Убавим один день - {first.ToString()}");

            Console.WriteLine();
            Console.Write($"Теперь добавим дней к текущей дате ");
            var addDays = Console.ReadLine();
            if (!(string.IsNullOrEmpty(addDays) || string.IsNullOrWhiteSpace(addDays)) &&
                int.TryParse(addDays, out service))
                first.AddDays(service);
            Console.WriteLine();
            Console.WriteLine(first.ToString());
        }
    }
}
