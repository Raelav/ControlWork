using System;
using Solution.Interfaces;
using Solution.Classes;

namespace Solution.Factories
{
    class OneDArrayFactory : SolutionFactory
    {
        public override string Name
        {
            get
            {
                return "Одномерные целочисленные массивы";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values">takes two INT type values</param>
        /// <returns></returns>
        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            if(values.Length == 2 && values[0] is int && values[1] is int)
            {
                return new OneDArray((int)values[0], (int)values[1]);
            }
            return new OneDArray();          
        }
    }
}
