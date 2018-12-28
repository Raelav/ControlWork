using System;
using Solution.Interfaces;
using Solution.Classes;

namespace Solution.Factories
{
    class SquareMatrixFactory : SolutionFactory
    {
        public override string Name
        {
            get
            {
                return "Квадратная матрица";
            }
        }

        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            if (values.Length == 0) return new SquareMatrix();
            //if(values[0] is Array[,])
            if (values[0] is double[,])
            {
                return new SquareMatrix((double[,])values[0]);
                //try
                //{
                //    var arr = (double[,])values[0];
                //    return new SquareMatrix(arr);
                //}
                //catch(InvalidCastException e)
                //{
                //    return new SquareMatrix();
                //}             
            } 
            if(values[0] is int && (int)values[0] > 0) return new SquareMatrix((int)values[0]);
            return new SquareMatrix();
        }
    }
}
