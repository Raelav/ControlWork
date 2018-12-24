using Solution.Interfaces;
using Solution.Factories;
using System;

namespace Solution.Classes
{
    class RationalFraction : IRationalFraction, IStudyAssignment
    {
        private int numerator;
        private int denumenator;

        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public int Value
        {
            get { return Numerator / Denumenator; }
        }

        /// <summary>
        /// Знаменатель.
        /// Ноль отсекается на фабрике
        /// </summary>
        public int Denumenator
        {
            get { return denumenator; }
            set
            {
                if (value == 0) throw new ArgumentException("Деление на 0 запрещено");
                else denumenator = value;
            }
        }

        public RationalFraction(int numerator, int denumenator)
        {
            Numerator = numerator;
            Denumenator = denumenator;
        }
        public RationalFraction() : this(0, 1) { }

        public override string ToString()
        {
            if (Denumenator == 1)
                return $"{Numerator}";
            if (Numerator == 0)
                return "0";
            return $"{Numerator}/{Denumenator}";
        }

        /// <summary>
        /// Метод сокращения дроби
        /// </summary>
        public void Reduction()
        {
            var NOD = Math.Abs(GetGreatestCommonDivisor(Numerator, Denumenator));
            Numerator /= NOD;
            Denumenator /= NOD;
        }

        /// <summary>
        /// НОД, Алгоритм Евклида
        /// </summary>
        private int GetGreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
                b = a % (a = b);
            return a;
        }

        /// <summary>
        /// НОК, Наименьшее общее кратное
        /// </summary>
        private int GetLeastCommonMultiple(int a, int b)
        {
            var nod = GetGreatestCommonDivisor(a, b);
            return b / nod * a;
        }

        public IStudyAssignment Add(IRationalFraction addend)
        {
            var result = Adder(addend.Numerator, addend.Denumenator);
            result.Reduction();
            //Console.Write($"{ToString()} + {addend.ToString()} = {result.ToString()}");
            return result;
        }

        private RationalFraction Adder(int numerator2, int denumenator2)
        {
            if (Denumenator == denumenator2)
                return new RationalFraction(Numerator + numerator2, Denumenator);
            var NOK = GetLeastCommonMultiple(Denumenator, denumenator2);
            int addend1 = GetNewNumerator(Numerator, Denumenator, NOK);
            int addend2 = GetNewNumerator(numerator2, denumenator2, NOK);
            var result = new RationalFraction(addend1 + addend2, NOK);
            result.Reduction();
            return result;
        }

        private int GetNewNumerator(int num, int denum, int nok)
        {
            return nok / denum * num;
        }

        public IStudyAssignment Sub(IRationalFraction subtrahend)
        {
            var result = Adder(-subtrahend.Numerator, subtrahend.Denumenator);
            result.Reduction();
            //Console.Write($"{ToString()} - {subtrahend.ToString()} = {result.ToString()}");
            return result;
        }

        public IStudyAssignment Division(IRationalFraction divider)
        {
            if (divider.Numerator == 0)
            {
                Console.WriteLine("Деление на 0 запрещено!");
                return new RationalFraction();
            }
            var result = new RationalFraction(Numerator * divider.Denumenator, Denumenator * divider.Numerator);
            result.Reduction();
            //Console.Write($"{ToString()} / {divider.ToString()} = {result.ToString()}");
            return result;
        }

        public IStudyAssignment Multiply(IRationalFraction factor)
        {
            var result = new RationalFraction(Numerator * factor.Numerator, Denumenator * factor.Denumenator);
            result.Reduction();
            //Console.Write($"{ToString()} * {factor.ToString()} = {result.ToString()}");
            return result;
        }

        public void Run()
        {
            Console.WriteLine(
@"Рациональные дроби

Введите поочередно 2 рациональных дроби в любом из следующих форматов: 
1/2, 24/7");
            Console.WriteLine();
            Console.WriteLine();

            SolutionFactory factory = new RationalFractionFactory();
            var first = (IRationalFraction)factory.FactoryMethod(Console.ReadLine());
            var second = (IRationalFraction)factory.FactoryMethod(Console.ReadLine());

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
