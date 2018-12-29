using System;
using Solution.Interfaces;
using Solution.Classes;

namespace Solution.Factories
{
    class RectangleFactory : SolutionFactory
    {
        public override string Name
        {
            get
            {
                return "Прямоугольники";
            }
        }

        /// <summary>
        /// Get new object of class Rectangle
        /// </summary>
        /// <param name="values">Double parameters X, Y, Width, Height</param>
        /// <returns></returns>
        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            if (values.Length == 0) return new Rectangle();

            if (values.Length >= 4 && isDouble(values))
                //return new Rectangle((double)values[0], (double)values[1], (double)values[2], (double)values[3]);
                return new Rectangle(Convert.ToDouble(values[0]), Convert.ToDouble(values[1]), 
                    Convert.ToDouble(values[2]), Convert.ToDouble(values[3]));
            return new Rectangle();
        }

        private bool isDouble(object[] values)
        {
            for(var i = 0; i < 4; i++)
            {
                if (!(values[i] is double || values[i] is int))
                    return false;
            }
            return true;
        }
    }
}
