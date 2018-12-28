using System;
using Solution.Classes;
using Solution.Interfaces;

namespace Solution.Factories
{
    class TriangleABCFactory : SolutionFactory
    {
        public override string Name
        {
            get
            {
                return "Треугольник";
            }
        }

        /// <summary>
        /// Gets object of type of TrinagleABC
        /// </summary>
        /// <param name="values">get 3 values of type DOUBLE which are a sides of triangle</param>
        /// <returns></returns>
        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            if (values.Length == 0) return (new TriangleABC());
            if (values.Length == 3 && inDoubleArr(values))
                return new TriangleABC((double)values[0], (double)values[1], (double)values[2]);
            else
            {
                //Console.WriteLine("Invalid data entered")
                throw new ArgumentException("Invalid data entered!");
                //return (new TriangleABC(3, 4, 5));
            }
        }

        private bool inDoubleArr(object[] values)
        {
            for(var i = 0; i < 3; i++)
            {
                if (!(values[i] is int || values[i] is double))
                    return false;
            }
            return true;
        }
    }
}
