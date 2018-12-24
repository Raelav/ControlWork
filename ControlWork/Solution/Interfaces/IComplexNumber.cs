namespace Solution.Interfaces
{
    public interface IComplexNumber
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
        /// получает новый объект равный сумме комплексных чисел
        /// </summary>
        /// <param name="addend">слагаемое 2</param>
        /// <returns>Новый экземпляр IStudyAssignment</returns>
        IStudyAssignment Add(IComplexNumber addend);

        /// <summary>
        /// получает новый объект равный разности комплексных чисел
        /// </summary>
        /// <param name="subtrahend">вычитаемое</param>
        /// <returns>Новый экземпляр IStudyAssignment</returns>
        IStudyAssignment Sub(IComplexNumber subtrahend);

        /// <summary>
        /// получает новый объект равный произведению комплексных чисел
        /// </summary>
        /// <param name="factor">множитель</param>
        /// <returns>Новый экземпляр IStudyAssignment</returns>
        IStudyAssignment Multiply(IComplexNumber factor);
    }
}
