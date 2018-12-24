using System;
using Solution.Interfaces;
using Solution.Enums;

namespace Solution.Classes
{
    class SquareMatrix : ISquareMatrix, IStudyAssignment
    {
        private double[,] _matrix;

        public double this[int indexX, int indexY]
        {
            get
            {
                try
                {
                    return _matrix[indexX, indexY];
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine("Запрошен несуществующий элемент матрицы");
                    return 0;
                }
            }
            set
            {
                try
                {
                    _matrix[indexX, indexY] = value;
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine("Запрошен несуществующий элемент матрицы");
                }
            }
        }

        public int Rank
        {
            get
            {
                return _matrix.GetLength(0);
            }
        }

        public SquareMatrix(double[,] matrix)
        {
            _matrix = matrix;
        }
        public SquareMatrix() : this(new double[3,3]){}

        public ISquareMatrix Add(ISquareMatrix added)
        {
            return Adder(added, AdderArgument.Add);
        }

        public ISquareMatrix Sub(ISquareMatrix subtrahend)
        {
            return Adder(subtrahend, AdderArgument.Sub);
        }

        private ISquareMatrix Adder(ISquareMatrix added, AdderArgument type)
        {
            if (Rank != added.Rank)
                throw new ArgumentException();
            var result = GetZeroMatrix();
            for(var i = 0; i < Rank; i++)
            {
                for(var j = 0; j < Rank; j++)
                {
                    result[i, j] = this[i, j] + added[i, j] * (int)type;
                }
            }
            return result;
        }

        public ISquareMatrix InverseToAdd()
        {
            var zeroMatrix = GetZeroMatrix();
            return zeroMatrix.Sub(this);
        }

        public ISquareMatrix Multiply(ISquareMatrix factor)
        {
            if (Rank != factor.Rank)
                throw new ArgumentException();
            var result = GetZeroMatrix();
            for (var i = 0; i < Rank; i++)
                for (var j = 0; j < Rank; j++)
                    for (var k = 0; k < Rank; k++)
                        result[i, j] = this[i, k] * factor[k, j];
            return result;
        }

        private ISquareMatrix GetZeroMatrix()
        {
            return new SquareMatrix(new double[Rank, Rank]);
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
