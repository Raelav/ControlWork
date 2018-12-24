using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Interfaces
{
    public interface IChainList
    {
        void AddLast(string value);
        void AddFirst(string value);
        void Remove(string value);
        void RemoveFrom();
        void RemoveFrom(string value);
    }
}
