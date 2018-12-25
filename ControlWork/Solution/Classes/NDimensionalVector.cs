using Solution.Interfaces;
using Solution.Factories;
using System;
using System.Collections.Generic;
using Solution.Enums;
using Solution.View;

namespace Solution.Classes
{
    public class NDimensionalVector : INDimensionalVector, IStudyAssignment
    {
        private List<double> _vector = new List<double>();

        public int Count
        {
            get
            {
                return _vector.Count;
            }
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    return 0;
                return _vector[index];
            }

            set
            {
                while (index >= Count)
                {
                    _vector.Add(0);
                }
                _vector[index] = value;
            }
        }

        public NDimensionalVector(double[] value)
        {
            for(var i = 0; i < value.Length; i++)
                _vector.Add(value[i]);
        }
        public NDimensionalVector() : this(new double[] { 0 }) { }

        public override string ToString()
        {
            string result = "";
            for (var i = 0; i < Count - 1; i++)
            {
                result += this[i] + " ";
            }
            result += this[Count - 1];
            return result;
        }

        public INDimensionalVector Add(INDimensionalVector addend)
        {
            return Adder(addend, AdderArgument.Add);
        }

        public INDimensionalVector Sub(INDimensionalVector subtrahend)
        {
            return Adder(subtrahend, AdderArgument.Sub);
        }

        private INDimensionalVector Adder(INDimensionalVector value, AdderArgument type)
        {
            var length = GetBiggerLength(value);

            var result = new NDimensionalVector();
            for (var i = 0; i < length; i++)
            {
                if (i >= _vector.Count) result[i] = (int)type * value[i];
                else if (i >= value.Count) result[i] = this[i];
                else result[i] = this[i] + (int)type * value[i];
            }
            return result;
        }

        private int GetBiggerLength(INDimensionalVector addend)
        {
            if (addend.Count > Count) return addend.Count;
            return Count;
        }

        public double GetLength()
        {
            double result = 0;
            for(var i = 0; i < Count; i++)
                result += this[i] * this[i];
            return Math.Sqrt(result);
        }

        public INDimensionalVector Inverse()
        {
            var result = new NDimensionalVector();
            for(var i = 0; i < Count; i++)
                result[i] = -this[i];
            return result;
        }

        public INDimensionalVector ScalarMultiply(INDimensionalVector factor)
        {
            var result = new NDimensionalVector();
            for (var i = 0; i < Count && i < factor.Count; i++)
                result[i] = this[i] * factor[i];
            return result;
        }

        /// <summary>
        /// Сранивает объекты класса
        /// </summary>
        /// <param name="vector"></param>
        /// <returns>если равны 0, меньше -1, больше 1, 
        /// если несравнимы выбрасывает ArgumentException
        /// так как перегрузку операторов не сделать и я не смог найти адекватного
        /// способа вывода 4х различных итогов</returns>
        public int CoordinateComparsion(INDimensionalVector vector)
        {
            var result = 0;
            for(var i = 0; i < Count && i < vector.Count; i++)
            {
                if (this[i] > vector[i] && (result == 1 || result == 0))
                    result = 1;
                else if (this[i] < vector[i] && (result == -1 || result == 0))
                    result = -1;
                else if (this[i] == vector[i])
                    continue;
                else throw new ArgumentException("Несравнимые векторы");
            }
            if (result == 1 && Count >= vector.Count)
                return 1;
            if (result == -1 && Count <= vector.Count)
                return -1;
            if (result == 0) return Count.CompareTo(vector.Count);
            throw new ArgumentException("Несравнимые векторы");
        }

        public void Run()
        {
            new NDimensionalVectorView().Main(new NDimensionalVectorFactory());
        }
    }
}
