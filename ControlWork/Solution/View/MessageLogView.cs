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
            string message = EnterMessage(obj);
            string name = EnterName(obj);
            string comment = EnterComment(obj);
            AddSaveOpenFile(obj, message, name, comment);
        }

        private void AddSaveOpenFile(IMessageLog obj, string message, string name, string comment)
        {
            Console.WriteLine();
            obj.AddMessage(message);
            obj.AddComment(message, name, comment);
            obj.OutputToFile();
            Console.WriteLine("Log saved to file");
        }

        private string EnterComment(IMessageLog obj)
        {
            Console.WriteLine();
            Console.WriteLine("Enter a comment for this message");
            return Console.ReadLine();
        }

        private string EnterName(IMessageLog obj)
        {
            Console.WriteLine();
            Console.WriteLine("Please enter your name");
            return Console.ReadLine();
        }

        private string EnterMessage(IMessageLog obj)
        {
            Console.WriteLine();
            Console.WriteLine("Enter your message");
            return Console.ReadLine();
        }
    }
}
