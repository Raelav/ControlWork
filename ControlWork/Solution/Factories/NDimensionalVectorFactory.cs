﻿using System;
using Solution.Interfaces;
using Solution.Classes;

namespace Solution.Factories
{
    public class NDimensionalVectorFactory : SolutionFactory
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
            if (values.Length == 0) return new NDimensionalVector();
            if (values[0] is string) return StringHandler((string)values[0]);
            return new NDimensionalVector();
        }

        private IStudyAssignment StringHandler(string value)
        {
            var result = new NDimensionalVector();
            var coeffArr = value.Trim().Split(new char[] { ' ' });
            double coeff = 0;

            for (var i = 0; i < coeffArr.Length; i++)
            {
                if (!double.TryParse(coeffArr[i], out coeff))
                {
                    return result;
                }
                result[i] = coeff;
            }
            //implement processing the wrong format of the entered data
            return result;
        }
    }
}
