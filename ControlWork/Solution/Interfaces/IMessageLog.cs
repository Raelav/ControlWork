namespace Solution.Interfaces
{
    public interface IMessageLog
    {
        void AddMessage(string message);
        void AddComment(string message, string author, string comment);
        void OutputToFile();
    }
}
