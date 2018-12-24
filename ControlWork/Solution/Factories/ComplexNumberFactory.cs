using System;
using Solution.Interfaces;
using Solution.Classes;

namespace Solution.Factories
{
    class ComplexNumberFactory : SolutionFactory
    {
        public override string Name
        {
            get { return "Комплексные числа"; }
        }

        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            return new ComplexNumber(); 
        }
    }
}
