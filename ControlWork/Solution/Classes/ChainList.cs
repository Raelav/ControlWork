using System;
using System.Collections.Generic;
using Solution.Interfaces;

namespace Solution.Classes
{
    /// <summary>
    /// Односвязный список. Задание довольно расплывчатое,
    /// поэтому сделал попроще.
    /// </summary>
    class ChainList : IChainList, IStudyAssignment
    {
        private LinkedList<string> _list = new LinkedList<string>();

        public void AddLast(string value)
        {
            _list.AddLast(value);
        }

        public void AddFirst(string value)
        {
            _list.AddFirst(value);
        }

        public void Remove(string value)
        {
            _list.Remove(value);
        }

        public void RemoveFrom()
        {
            _list.Clear();
        }

        public void RemoveFrom(string value)
        {
            var node = _list.FindLast(value);
            RemoveFromSupport(node);
        }

        private void RemoveFromSupport(LinkedListNode<string> node)
        {
            if (node == _list.Last) return;
            var nextNode = node.Next;
            _list.Remove(node);
            RemoveFromSupport(nextNode);
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
