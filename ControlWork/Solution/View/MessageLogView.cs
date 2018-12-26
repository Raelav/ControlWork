using System;
using Solution.Factories;
using Solution.Interfaces;

namespace Solution.View
{
    class MessageLogView : IView
    {
        public void Main(SolutionFactory Factory)
        {
            var obj = (IMessageLog)Factory.FactoryMethod();
            Console.WriteLine("Simple demonstration");
            Console.WriteLine();
            Console.WriteLine("Enter your message");
            var message = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Please enter your name");
            var name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Enter a comment for this message");
            var comment = Console.ReadLine();
            Console.WriteLine();
            obj.AddMessage(message);
            obj.AddComment(message, name, comment);
            obj.OutputToFile();
            Console.WriteLine("Log saved to file");
        }
    }
}
