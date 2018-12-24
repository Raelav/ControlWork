using System;
using Solution.Interfaces;
using Solution.Classes;

namespace Solution.Factories
{
    public class RationalFractionFactory : SolutionFactory
    {
        public override string Name
        {
            get
            {
                return "Рациональная дробь";
            }
        }

        /// <summary>
        /// Возвращает новый объект класса RationalFraction
        /// </summary>
        /// <param name="values">Принимает пару чисел - числитель, знаменатель; либо строку в формате "{int}/{int}",
        /// если второй параметр равен 0 выбрасывает исключение DivideByZeroException</param>
        /// <returns>Возвращает новый объект класса RationalFraction</returns>
        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            if (values.Length == 0) return new RationalFraction();
            if (values[0] is string) return StringHandler((string)values[0]);
            if (values[0] is int)
            {
                if (values.Length > 1 && values[1] is int)
                    return new RationalFraction((int)values[0], (int)values[1]);
                return new RationalFraction((int)values[0], 1);
            }
            return new RationalFraction();
        }

        private IStudyAssignment StringHandler(string value)
        {
            var numerator = 0;
            var denumenator = 1;
            var fraction = value.Split(new char[] { '/' });
            if(fraction.Length == 2 && 
                int.TryParse(fraction[0], out numerator) && int.TryParse(fraction[1], out denumenator))
            {
                if (denumenator == 0) throw new DivideByZeroException();
                return new RationalFraction(numerator, denumenator);
            }
            return new RationalFraction();
        }
    }
}
