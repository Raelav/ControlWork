using System;
using Solution.Factories;
using Solution.Interfaces;

namespace Solution.View
{
    class ChainListView : IView
    {
        public void Main(SolutionFactory Factory)
        {
            var obj = (IChainList)Factory.FactoryMethod();
            AddToList(obj);
            DeleteStringFromObjByValue(obj);
            DeleteListStartingFrom(obj);
            ClearAllList(obj);
        }

        private void ClearAllList(IChainList obj)
        {
            Console.WriteLine("Right now will be deleted all list");
            Console.ReadLine();
            obj.RemoveFrom();
            Rendering(obj);
        }

        private void DeleteListStartingFrom(IChainList obj)
        {
            Console.WriteLine("Enter the line from which you want to clear the list");
            obj.RemoveFrom(Console.ReadLine());
            Rendering(obj);
        }

        private void DeleteStringFromObjByValue(IChainList obj)
        {
            Console.WriteLine("Enter the line you want to delete");
            obj.Remove(Console.ReadLine());
            Rendering(obj);
        }

        private void AddToList(IChainList obj)
        {
            Console.WriteLine("Enter lines to continue enter empty line");
            var inputString = "";
            do
            {
                inputString = Console.ReadLine();
                if(inputString != "")
                    obj.AddLast(inputString);
            } while (inputString != "");
            Rendering(obj);
        }

        private void Rendering(IChainList obj)
        {
            Console.Clear();
            Console.WriteLine(obj.ToString());
        }
    }
}
