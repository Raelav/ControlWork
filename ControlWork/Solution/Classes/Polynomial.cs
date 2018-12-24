using Solution.Interfaces;
using Solution.Factories;
using System;
using System.Collections.Generic;
using Solution.View;

namespace Solution.Classes
{
    class Polynomial : IPolynomial, IStudyAssignment
    {
        private List<double> _polinom = new List<double>();

        public int Count
        {
            get { return _polinom.Count; }
        }

        public double this[int index]
        {
            get { return _polinom[index]; }
            set
            {
                while(index >= Count)
                {
                    _polinom.Add(0);
                }
                _polinom[index] = value;
            }
        }

        public Polynomial()
        {
            _polinom = new List<double> { { 0 } };
        }

        public override string ToString()
        {
            string result = "";
            for(var i = 0; i < Count - 1; i++)
            {
                result += this[i] + " "; 
            }
            result += this[Count - 1];
            return result;
        }

        public IPolynomial Add(IPolynomial addend)
        {
            return Adder(addend, 1);
        }

        /// <summary>
        /// Суммирует или вычитает в зависиости от sym
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sym">1 или -1</param>
        /// <returns></returns>
        private IPolynomial Adder(IPolynomial value, int sym)
        {
            var length = GetBiggerLength(value);

            var result = new Polynomial();
            for (var i = 0; i < length; i++)
            {
                if(i >= Count) result[i] = sym * value[i];
                else if (i >= value.Count) result[i] = this[i];
                else result[i] = this[i] + sym * value[i];
            }
            return result;
        }

        private int GetBiggerLength(IPolynomial addend)
        {
            if (addend.Count > Count) return addend.Count;
            return Count;
        }

        /// <summary>
        /// Либо равны, либо нет
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Либо равны, либо нет</returns>
        public bool CompareTo(IPolynomial value)
        {
            var count = GetBiggerLength(value);
            for(var i = 0; i < count; i++)
            {
                if (this[i] != value[i])
                    return false;
            }
            return true;
        }

        public IPolynomial Inverse()
        {
            var result = new Polynomial();
            for(var i = 0; i < Count; i++)
                result[i] = this[i] * -1;
            return result;
        }

        public IPolynomial Sub(IPolynomial subtrahend)
        {
            return Adder(subtrahend, -1);
        }

        public void Run()
        {
            new PolynomialView().Main(new PolynomialFactory());
        }
    }
}
