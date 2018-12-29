namespace Solution.Interfaces
{
    public interface ICounter
    {
        /// <summary>
        /// Текущее значение
        /// </summary>
        int Current { get; }

        int Max { get; }
        int Min { get; }

        /// <summary>
        /// Инкремент
        /// </summary>
        void Inc();

        /// <summary>
        /// Декремент
        /// </summary>
        void Dec();

        /// <summary>
        /// Задает новое начальное значение счетчика, в которое и устанавливается счетчик
        /// </summary>
        void Start(int newStart);

        /// <summary>
        /// Задает новое конечное значение, счетчик устаналивается на Min
        /// </summary>
        void End(int newEnd);
    }
}
