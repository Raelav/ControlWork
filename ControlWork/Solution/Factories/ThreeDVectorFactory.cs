using System;
using Solution.Interfaces;
using Solution.Classes;

namespace Solution.Factories
{
    public class ThreeDVectorFactory : SolutionFactory
    {
        public override string Name
        {
            get
            {
                return "Трехмерные вектора";
            }
        }

        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            if (values.Length == 0) return new ThreeDVector();
            if (values.Length == 1 && values[0] is string) return StringHandler((string)values[0]);
            return Handler(values);
        }

        private IStudyAssignment StringHandler(string value)
        {
            return Handler(value.Split(new char[] { ' ' }));
        }

        private IStudyAssignment Handler(object[] values)
        {
            double[] vector = new double[3];
            for(var i = 0; i < values.Length && i < 3; i++)
            {
                if (values[i] is string)
                    double.TryParse((string)values[i], out vector[i]);
                else if (IsNum(values[i]))
                    vector[i] = (double)values[i];
            }
            return new ThreeDVector(vector[0], vector[1], vector[2]);
        }

        bool IsNum(object value)
        {
            return value is int || value is double;
        }
    }
}
