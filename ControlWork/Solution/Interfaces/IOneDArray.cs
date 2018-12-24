using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Interfaces
{
    public interface IOneDArray
    {
        int this[int index] { get;  set; }

        int StartIndex { get; }
        int Length { get; }

        IOneDArray Add(IOneDArray added);
        IOneDArray Sub(IOneDArray subtrahend);

        void Division(int devider);
        void Multiply(int factor);

        int Min();
        int Max();
        void Print(int index);
        void Print();
    }
}
