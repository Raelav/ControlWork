using System;
using System.Collections.Generic;
using System.IO;
using Solution.Interfaces;

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
            var fileDirectory = $"{Environment.CurrentDirectory}\\MessageLog";
            if (!Directory.Exists(fileDirectory))
                Directory.CreateDirectory(fileDirectory);
            CreateFile(ref fileNum, fileDirectory);
            WriteToFile($"{fileDirectory}//MessageLog{fileNum}.txt");
        }

        private void WriteToFile(string path)
        {
            var result = "";
            foreach(var upElem in magazine)
            {
                result += upElem.Key + "\r\n\r\n";
                foreach(var bottomElem in upElem.Value)
                    result += "\t"+ bottomElem.Value + "\r\n\t" + bottomElem.Key + "\r\n\r\n";
            }
            File.WriteAllText(path, result);
        }

        private void CreateFile(ref int fileNum, string fileDirectory)
        {
            try
            {
                File.Create($"{fileDirectory}//MessageLog{fileNum}.txt").Close();
            }
            catch(IOException e)
            {
                fileNum++;
                CreateFile(ref fileNum, fileDirectory);
            }
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
