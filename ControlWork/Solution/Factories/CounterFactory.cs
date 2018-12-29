using System;
using Solution.Interfaces;
using Solution.Classes;

namespace Solution.Factories
{
    class CounterFactory : SolutionFactory
    {
        public override string Name
        {
            get
            {
                return "Счетчик";
            }
        }

        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            if (values.Length == 0) return new Counter();

            if(values.Length >= 2 && values[0] is int && values[1] is int)
                return new Counter(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));
            return new Counter();
        }
    }
}
