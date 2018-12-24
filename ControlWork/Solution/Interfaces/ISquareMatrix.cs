using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Interfaces
{
    interface ISquareMatrix
    {
        double this[int indexX, int indexY] { get; set; }
        int Rank { get; }

        ISquareMatrix Add(ISquareMatrix added);
        ISquareMatrix Multiply(ISquareMatrix factor);
        ISquareMatrix Sub(ISquareMatrix subtrahend);
        ISquareMatrix InverseToAdd();
    }
}
