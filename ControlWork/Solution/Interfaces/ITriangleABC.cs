using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Interfaces
{
    interface ITriangleABC
    {
        double Perimeter { get; }
        double Area { get; }

        void PrintType();
        void PrintView();
        void Print(); 
    }
}
