using System;
using Solution.Interfaces;

namespace Solution.Client
{
    class Title : IStudyAssignment
    {
        public void Run()
        {
            for (var i = 1; i < Client.Contents.Count; i++)
            {
                Console.WriteLine($"{i}. {Client.Contents[i].Name}");
            }
        }
    }
}
