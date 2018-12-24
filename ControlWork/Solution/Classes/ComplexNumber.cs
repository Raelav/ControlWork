using System;
using Solution.Interfaces;
using Solution.Enums;
using Solution.Factories;

namespace Solution.Classes
{
    class ComplexNumber : IComplexNumber, IStudyAssignment
    {
        private double _imaginaryPart;
        private double _realPart;

        /// <summary>
        /// Мнимая часть
        /// </summary>
        public double ImaginaryPart
        {
            get { return _imaginaryPart; }
            set { _imaginaryPart = value; }
        }

        /// <summary>
        /// Действительная часть
        /// </summary>
        public double RealPart
        {
            get { return _realPart; }
            set { _realPart = value; }
        }

        /// <summary>
        /// Класс комплексных чисел
        /// </summary>
        /// <param name="realPart">Действительная часть</param>
        /// <param name="imaginaryPart">Мнимая часть</param>
        public ComplexNumber(double realPart, double imaginaryPart)
        {
            RealPart = realPart;
            ImaginaryPart = imaginaryPart;
        }

        /// <summary>
        /// Класс комплексных чисел
        /// </summary>
        /// <param name="realPart">Действительная часть</param>
        public ComplexNumber(double realPart) : this(realPart, 0) { }

        /// <summary>
        /// Класс комплексных чисел
        /// </summary>
        public ComplexNumber() : this(0, 0) { }

        public override string ToString()
        {
            if (ImaginaryPart == 0) return $"{RealPart}";
            if (RealPart == 0)
            {
                if (ImaginaryPart == 1) return "i";
                if (ImaginaryPart == -1) return "-i";
                return $"{ImaginaryPart}i";
            }
            if (ImaginaryPart < 0)
            {
                if (ImaginaryPart == -1) return "-i";
                return $"({RealPart} - {-ImaginaryPart}i)";
            }
            if (ImaginaryPart == 1) return $"({RealPart} + i)";
            return $"({RealPart} + {ImaginaryPart}i)";
        }

        /// <summary>
        /// Сумма двух комлпексных чисел
        /// </summary>
        /// <param name="addend">слагаемое</param>
        /// <returns>Новый объект</returns>
        public IStudyAssignment Add(IComplexNumber addend)
        {
            return Adder(addend, AdderArgument.Add);
        }

        /// <summary>
        /// Разность комплексных чисел
        /// </summary>
        /// <param name="subtrahend">Вычитаемое</param>
        /// <returns>новый объект</returns>
        /// 
        public IStudyAssignment Sub(IComplexNumber subtrahend)
        {
            return Adder(subtrahend, AdderArgument.Sub);
        }

        private IStudyAssignment Adder(IComplexNumber addend, AdderArgument type)
        {
            var result = new ComplexNumber(RealPart + addend.RealPart * (int)type,
    ImaginaryPart + addend.ImaginaryPart * (int)type);
            return result;
        }

        public IStudyAssignment Multiply(IComplexNumber factor)
        {
            return new ComplexNumber(RealPart * factor.RealPart -
    ImaginaryPart * factor.ImaginaryPart,
    ImaginaryPart * factor.RealPart + RealPart * factor.ImaginaryPart);
        }

        public void Run()
        {
            Console.WriteLine(
    @"Комплексные числа

Введите поочередно 2 комплексных числа в любом из следующих форматов: 
1 + 2i, 1, 2i, i");
            Console.WriteLine();
            Console.WriteLine();

            SolutionFactory factory = new ComplexNumberFactory();
            var first = (IComplexNumber)factory.FactoryMethod(Console.ReadLine());
            var second = (IComplexNumber)factory.FactoryMethod(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine($"Сумма этих чисел равна {first.Add(second)}");
            Console.WriteLine();
            Console.WriteLine($"Разность этих чисел равна {first.Sub(second)}");
            Console.WriteLine();
            Console.WriteLine($"Произведение этих чисел равно {first.Multiply(second)}");
        }
    }
}
