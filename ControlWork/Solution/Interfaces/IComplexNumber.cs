namespace Solution.Interfaces
{
    interface IComplexNumber
    {
        /// <summary>
        /// Действительная часть
        /// </summary>
        double RealPart { get; set; }

        /// <summary>
        /// Мнимая часть
        /// </summary>
        double ImaginaryPart { get; set; }

        /// <summary>
        /// получает сумму комплексных чисел
        /// </summary>
        /// <param name="addend">слагаемое 2</param>
        /// <returns>Новый экземпляр IStudyAssignment</returns>
        IStudyAssignment Add(IComplexNumber addend);

        /// <summary>
        /// получает разность комплексных чисел
        /// </summary>
        /// <param name="subtrahend">вычитаемое</param>
        /// <returns>Новый экземпляр IStudyAssignment</returns>
        IStudyAssignment Sub(IComplexNumber subtrahend);

        /// <summary>
        /// получает произведение комплексных чисел
        /// </summary>
        /// <param name="factor">множитель</param>
        /// <returns>Новый экземпляр IStudyAssignment</returns>
        IStudyAssignment Multiply(IComplexNumber factor);
    }
}
