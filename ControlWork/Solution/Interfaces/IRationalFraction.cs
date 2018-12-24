using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Interfaces
{
    public interface IRationalFraction
    {
        int Numerator { get; set; }
        int Denumenator { get; set; }

        IStudyAssignment Add(IRationalFraction addend);
        IStudyAssignment Sub(IRationalFraction subtrahend);
        IStudyAssignment Multiply(IRationalFraction factor);
        IStudyAssignment Division(IRationalFraction divider);
    }
}
