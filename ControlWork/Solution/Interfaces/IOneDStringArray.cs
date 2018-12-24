namespace Solution.Interfaces
{
    public interface IOneDStringArray
    {
        int Length { get; }

        string this[int index] { get; set; }

        /// <summary>
        /// Поэлементное сцепление двух массивов
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        IOneDStringArray Concat(IOneDStringArray array);

        /// <summary>
        /// Cлияния двух массивов с исключением повторяющихся элементов
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        IOneDStringArray Merge(IOneDStringArray array);

        /// <summary>
        /// вывод на экран элементов массива
        /// </summary>
        /// <param name="index"></param>
        void Print(int index);

        /// <summary>
        /// всего массива
        /// </summary>
        void Print();
    }
}
