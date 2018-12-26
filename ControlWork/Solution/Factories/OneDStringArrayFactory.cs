using System;
using Solution.Interfaces;
using Solution.Classes;

namespace Solution.Factories
{
    class OneDStringArrayFactory : SolutionFactory
    {
        public override string Name
        {
            get
            {
                return "Одномерный массив строк";
            }
        }

        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            if (values.Length == 0) return new OneDStringArray(0);
            var length = 0;
            if (values[0] is int) return new OneDStringArray((int)values[0]);
            if (values[0] is string && int.TryParse((string)values[0], out length))
                return new OneDStringArray(length);
            return new OneDStringArray(0);
        }
    }
}
