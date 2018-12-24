using Solution.Interfaces;
using Solution.Factories;
using System;

namespace Solution.Client
{
    class TitlePageFactory : SolutionFactory
    {
        public override string Name
        {
            get { return "Стартовая страница"; }
        }

        /// <summary>
        /// Не обрабатывает аргументы, возвращает объект типа Title
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            return new Title();
        }
    }
}
