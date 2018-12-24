using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Interfaces
{
    public interface IThreeDVector
    {
        double this[int index] { get; set; }
        double Length { get; }

        IThreeDVector Add(IThreeDVector added);
        IThreeDVector Sub(IThreeDVector subtrahend);
        double ScalarMultiply(IThreeDVector factor);
        IThreeDVector VectorMultiply(IThreeDVector factor);

        /// <summary>
        /// Будет сравнивать длины векторов
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int Compare(IThreeDVector value);
    }
}
