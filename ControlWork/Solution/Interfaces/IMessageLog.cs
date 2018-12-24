using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Interfaces
{
    public interface IMessageLog
    {
        void AddMessage(string message);
        void AddComment(string message, string author, string comment);
        void OutputToFile();
    }
}
