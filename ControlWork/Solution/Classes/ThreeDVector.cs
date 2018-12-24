using System;
using Solution.Interfaces;
using Solution.Enums;

namespace Solution.Classes
{
    public class ThreeDVector : IThreeDVector, IStudyAssignment
    {
        private double _x;
        private double _y;
        private double _z;
        private double[] _vector = new double[3];

        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
                _vector[0] = value;
            }
        }
        public double Y
        {
            get { return _y; }
            set
            {
                _y = value;
                _vector[1] = value;
            }
        }
        public double Z
        {
            get { return _z; }
            set
            {
                _z = value;
                _vector[2] = value;
            }
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public double this[int index]
        {
            get
            {
                try
                {
                    return _vector[index];
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine("Запрошен несуществующий индекс. Было возвращено значение под индексом 0");
                    return _vector[0];
                }
            }

            set
            {
                try
                {
                    _vector[index] = value;
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine("В данном классе существуют значения только под индексами 0,1,2");
                }
            }
        }

        public ThreeDVector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public ThreeDVector() : this(0, 0, 0) { }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

        public IThreeDVector Add(IThreeDVector added)
        {
            return Adder(added, AdderArgument.Add);
        }

        public IThreeDVector Sub(IThreeDVector subtrahend)
        {
            return Adder(subtrahend, AdderArgument.Sub);
        }

        private IThreeDVector Adder(IThreeDVector vector, AdderArgument type)
        {
            return new ThreeDVector()
            { X = vector[0] * (int)type, Y = vector[1] * (int)type, Z = vector[2] * (int)type }; 
        }

        public int Compare(IThreeDVector value)
        {
            return Length.CompareTo(value.Length);
        }

        public double ScalarMultiply(IThreeDVector factor)
        {
            return X * factor[0] + Y * factor[1] + Z * factor[2];
        }

        public IThreeDVector VectorMultiply(IThreeDVector factor)
        {
            var result = new ThreeDVector();
            result[0] = Y * factor[2] - Z * factor[1];
            result[1] = Z * factor[0] - X * factor[2];
            result[2] = X * factor[1] - Y * factor[0];
            return result; 
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
