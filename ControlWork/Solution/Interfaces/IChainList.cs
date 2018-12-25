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

        /// <summary>
        /// delete string from list by value
        /// </summary>
        /// <param name="value">string for delete</param>
        void Remove(string value);

        /// <summary>
        /// Delete all list
        /// </summary>
        void RemoveFrom();

        /// <summary>
        /// Delete list starting with value
        /// </summary>
        /// <param name="value"></param>
        void RemoveFrom(string value);
    }
}
