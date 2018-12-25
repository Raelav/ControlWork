using System;
using Solution.Interfaces;
using Solution.Classes;

namespace Solution.Factories
{
    class ChainListFactory : SolutionFactory
    {
        public override string Name
        {
            get
            {
                return "Цепные списки";
            }
        }

        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            return new ChainList();
        }
    }
}
