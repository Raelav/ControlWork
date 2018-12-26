using System;
using System.Collections.Generic;
using System.IO;
using Solution.Interfaces;
using Solution.View;
using Solution.Factories;
using System.Diagnostics;

namespace Solution.Classes
{
    public class MessageLog : IMessageLog, IStudyAssignment
    {
        private Dictionary<string, Dictionary<string, string>> magazine =
            new Dictionary<string, Dictionary<string, string>>();

        public void AddComment(string message, string author, string comment)
        {
            if (!magazine.ContainsKey(message))
                Console.WriteLine("Сообщение, к которому Вы хотите оставить комментарий не существует");
            else if (magazine[message].ContainsKey(comment))
                Console.WriteLine("Такой комментарий уже существует");
            else magazine[message].Add(comment, author);
        }

        public void AddMessage(string message)
        {
            if (magazine.ContainsKey(message))
                Console.WriteLine("Такое сообщение уже существует");
            magazine.Add(message, new Dictionary<string, string>());
        }

        public void OutputToFile()
        {
            int fileNum = 1;
            var fileDirectory = $"{Environment.CurrentDirectory}";
            if (!Directory.Exists(fileDirectory))
                Directory.CreateDirectory(fileDirectory);
            CreateFile(ref fileNum, fileDirectory);
            WriteToFile($"{fileDirectory}//message{fileNum}.txt");
        }

        private void WriteToFile(string path)
        {
            var result = "";
            foreach(var message in magazine)
            {
                result += message.Key + "\r\n\r\n";
                foreach(var author in message.Value)
                    result += "\tAuthor:   "+ author.Value + "\r\n\tMessage: " + author.Key + "\r\n\r\n";
            }
            File.WriteAllText(path, result);
            Process.Start(path);
        }

        private void CreateFile(ref int fileNum, string fileDirectory)
        {
            try
            {
                File.Create($"{fileDirectory}//message{fileNum}.txt").Close();
            }
            catch(IOException e)
            {
                fileNum++;
                CreateFile(ref fileNum, fileDirectory);
            }
        }

        public void Run()
        {
            new MessageLogView().Main(new MessageLogFactory());
        }
    }
}
