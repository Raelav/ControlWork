using System;
using Solution.Interfaces;
using Solution.Enums;

namespace Solution.Classes
{
    class OneDArray : IOneDArray, IStudyAssignment
    {
        private int _startIndex;
        private int _length;
        private int[] array;

        public int StartIndex
        {
            get
            {
                return _startIndex;
            }

            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Wrong index of massive!");
                }
                else _startIndex = value;
            }
        }

        public int Length
        {
            get
            {
                return _length;
            }

            set
            {
                if (value < 1)
                {
                    Console.WriteLine("Length cannot be less than one!");
                }
                else _length = value;
            }
        }

        public int this[int index]
        {
            get
            {
                if(index < StartIndex || index > StartIndex + Length - 1)
                {
                    Console.WriteLine("Wrong index of massive!");
                    return 0;
                }
                return array[index];
            }

            set
            {
                if (index < StartIndex || index > StartIndex + Length - 1)
                    Console.WriteLine("Wrong index of massive!");
                else array[index] = value;   
            }
        }

        public OneDArray(int startIndex, int length)
        {
            array = new int[startIndex + length];
        }
        public OneDArray() : this(0, 1) { }

        public IOneDArray Add(IOneDArray added)
        {
            return Adder(added, AdderArgument.Add);
        }

        public IOneDArray Sub(IOneDArray subtrahend)
        {
            return Adder(subtrahend, AdderArgument.Sub);
        }

        public IOneDArray Adder(IOneDArray added, AdderArgument type)
        {
            try
            {
                if (StartIndex != added.StartIndex || Length != added.Length)
                    throw new IndexOutOfRangeException();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Выход за пределы массива");
                return new OneDArray();
            }
            var result = new OneDArray(StartIndex, Length);
            for (var i = StartIndex; i < StartIndex + Length; i++)
                result[i] = this[i] + added[i] * (int)type;
            return result;
        }

        public void Division(int devider)
        {
            for(var i = StartIndex; i < StartIndex + Length; i++)
            {
                this[i] /= devider;
            }
        }

        public void Multiply(int factor)
        {
            for (var i = StartIndex; i < StartIndex + Length; i++)
            {
                this[i] *= factor;
            }
        }

        public int Max()
        {
            var maxIndex = StartIndex;
            for(var i = StartIndex + 1; i < StartIndex + Length; i++)
            {
                if (this[i] > maxIndex) maxIndex = this[i];
            }
            return maxIndex;
        }

        public int Min()
        {
            var minIndex = StartIndex;
            for (var i = StartIndex + 1; i < StartIndex + Length; i++)
            {
                if (this[i] < minIndex) minIndex = this[i];
            }
            return minIndex;
        }

        public void Print()
        {
            for(var i = StartIndex; i < StartIndex + Length; i++)
            {
                Console.WriteLine($"{i} => {this[i]}");
            }
            Console.WriteLine();
        }

        public void Print(int index)
        {
            try
            {
                if (index < StartIndex || index > StartIndex + Length - 1)
                    throw new IndexOutOfRangeException();
                Console.WriteLine($"{index} => {this[index]}");
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("Выход за пределы массива!");
            }
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
