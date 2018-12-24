using System;
using Solution.Interfaces;
using Solution.Classes;

namespace Solution.Factories
{
    class NDimensionalVectorFactory : SolutionFactory
    {
        public override string Name
        {
            get
            {
                return "N-Мерные векторы";
            }
        }

        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            throw new NotImplementedException();
        }
    }
}
