using Solution.Enums;

namespace Solution.Interfaces
{
    public interface IPlayingCard
    {
        CardSuit CardSuit { get; }


        /// <summary>
        /// Цвет масти
        /// </summary>
        string Color { get; }

        /// <summary>
        /// Видимость карты
        /// </summary>
        bool Visibility { get; }

        /// <summary>
        /// Перевернуть карту
        /// </summary>
        void TurnOver();

        /// <summary>
        /// Вывести результат в консоль
        /// </summary>
        void Print();
    }
}
