namespace Solution.Interfaces
{
    public interface IPolynomial
    {
        int Count { get; }

        /// <summary>
        /// Возвращает коэффицент по заданному номеру
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        double this[int index]
        {
            get;
            set;
        }

        IPolynomial Add(IPolynomial addend);
        IPolynomial Sub(IPolynomial subtrahend);

        /// <summary>
        /// В рамках этого класса полиномы могут быть либо равны, либо нет
        /// </summary>
        /// <returns></returns>
        bool CompareTo(IPolynomial value);

        /// <summary>
        /// Возвращает полином с противоположными коэффицентами
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IPolynomial Inverse();

    }
}
