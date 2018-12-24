namespace Solution.Interfaces
{
    public interface INDimensionalVector
    {
        double this[int index]
        {
            get;
            set;
        }

        int Count { get; }

        INDimensionalVector Add(INDimensionalVector addend);
        INDimensionalVector Sub(INDimensionalVector subtrahend);
        INDimensionalVector Inverse();
        INDimensionalVector ScalarMultiply(INDimensionalVector factor);

        //Хотел сделать перегрузку опрераторов, но интерфейсы к такому не располагает
        int CoordinateComparsion(INDimensionalVector vector);

        double GetLength();
    }
}
