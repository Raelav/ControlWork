using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Interfaces
{
    public interface IDate
    {
        int Day { get; }
        int Month { get; }
        int Year { get; }

        void AddOneDay();
        void ReduceOneDay();
        void SetDate(string value);
        void AddDays(int count);
    }
}
