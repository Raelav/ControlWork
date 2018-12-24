using Solution.Interfaces;

namespace Solution.Factories
{
    public abstract class SolutionFactory
    {
        /// <summary>
        /// Имя фабрики
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Создает объект требуемого класса
        /// </summary>
        /// <param name="values">Массив объектов</param>
        /// <returns></returns>
        public abstract IStudyAssignment FactoryMethod(params object[] values);
    }
}
