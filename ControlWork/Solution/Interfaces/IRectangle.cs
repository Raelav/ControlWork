using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Interfaces
{
    public interface IRectangle
    {
        /// <summary>
        /// Х - координата левого нижнего угла прямоугольника
        /// </summary>
        double X { get; }

        /// <summary>
        /// Y - координата левого нижнего угла прямоугольника
        /// </summary>
        double Y { get; }

        /// <summary>
        /// Ширина(длина по оси Х)
        /// </summary>
        double Width { get; }

        /// <summary>
        /// Высота(длина по оси Y)
        /// </summary>
        double Height { get; }

        bool Intesect(IRectangle rectangle);
        IRectangle GetRectangleContainingTwoDate(IRectangle rectangle);
        void Print();
    }
}
