using System;
using Solution.Interfaces;
using Solution.Classes;

namespace Solution.Factories
{
    public class ComplexNumberFactory : SolutionFactory
    {
        public override string Name
        {
            get { return "Комплексные числа"; }
        }

        /// <summary>
        /// Создание объекта типа ComplexNumber
        /// </summary>
        /// <param name="values">принимаются два числа, либо строка обозначающая комплексное число
        /// в любом из следующих форматов 1 + 2i, 1, 2i, i</param>
        /// <returns></returns>
        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            if (values.Length == 0) return new ComplexNumber();
            if (values[0] is string) return StringHandler((string)values[0]);
            if (IsNum(values[0]))
            {
                if (values.Length == 1) return new ComplexNumber((double)values[0]);
                else if(IsNum(values[1])) return new ComplexNumber((double)values[0], (double)values[1]);
            }
            return new ComplexNumber();
        }

        private bool IsNum(object value)
        {
            return value is int || value is double;
        }

        private IStudyAssignment StringHandler(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(value))
                return new ComplexNumber();
            var arrNum = value.Trim().Split(new char[] { ' ' });
            var length = arrNum.Length;
            return ToAnalizeString(arrNum, length);
        }

        private IStudyAssignment ToAnalizeString(string[] arrNum, int length)
        {
            double real = 0;
            double imaginary = 0;
            if (length == 1 &&
                (CheckImaginaryPart(out imaginary, arrNum[0]) || CheckRealPart(out real, arrNum[0])))
                return new ComplexNumber(real, imaginary);
            if (arrNum.Length == 3 && CheckImaginaryPart(out imaginary, arrNum[2]) &&
                CheckRealPart(out real, arrNum[0]))
            {
                if (arrNum[1] == "+") return new ComplexNumber(real, imaginary);
                if (arrNum[1] == "-") return new ComplexNumber(real, -imaginary);
            }
            return new ComplexNumber();
        }

        private bool CheckImaginaryPart(out double imaginary, string part)
        {
            imaginary = 0;
            var length = part.Length;
            if (part == "i")
            {
                imaginary = 1;
                return true;
            }
            return part[length - 1] == 'i' && double.TryParse(part.Substring(0, length - 1), out imaginary);
        }

        private bool CheckRealPart(out double real, string part)
        {
            real = 0;
            return double.TryParse(part, out real);
        }
    }
}
