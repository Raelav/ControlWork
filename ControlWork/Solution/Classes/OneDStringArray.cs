using System;
using System.Collections.Generic;
using Solution.Interfaces;
using Solution.Factories;
using Solution.View;

namespace Solution.Classes
{
    class OneDStringArray : IOneDStringArray, IStudyAssignment
    {
        private string[] _array;

        public int Length
        {
            get
            {
                return _array.Length;
            }
            set
            {
                //Можно, конечно и тут ловить IndexOutOfRangeException
                if (value < 0)
                    Console.WriteLine("Нельзя создать массив отрицательной длинны");
                //инициализируем массив
                else
                {
                    _array = new string[value];
                }
            }
        }

        public string this[int index]
        {
            get
            {
                try
                {
                    return _array[index];
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine("Запрошен несуществующий индекс");
                    return string.Empty;
                }
            }

            set
            {
                try
                {
                    _array[index] = value;
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine("Вы пытаетесь обратиться к несуществующему индексу");
                }
            }
        }

        public OneDStringArray(int length)
        {
            Length = length;
        }

        public IOneDStringArray Concat(IOneDStringArray array)
        {
            int length = GetBiggerLength(array);
            var result = new OneDStringArray(length);
            for (var i = 0; i < result.Length; i++)
            {
                if (i < Length && i < array.Length)
                    result[i] = this[i] + array[i];
                else if (i < Length && i >= array.Length)
                    result[i] = this[i];
                else result[i] = array[i];
            }
            return result;
        }

        private int GetBiggerLength(IOneDStringArray array)
        {
            if (Length >= array.Length) return Length;
            return array.Length;
        }

        public IOneDStringArray Merge(IOneDStringArray array)
        {
            var list = new HashSet<string>();
            for(var i = 0; i < Length; i++)
                list.Add(this[i]);
            for(var i = 0; i < array.Length; i++)
            {
                if (!list.Contains(array[i]))
                    list.Add(array[i]);
            }
            return GetMergerResult(new OneDStringArray(list.Count), list);
        }

        private IOneDStringArray GetMergerResult(OneDStringArray array, HashSet<string> list)
        {
            var index = 0;
            foreach(var e in list)
            {
                array[index] = e;
                index++;
            }               
            return array;
        }

        public void Print()
        {
            for(var i = 0; i < Length; i++)
            {
                Console.WriteLine($"[{i}] => {this[i]}");
            }
        }

        public void Print(int index)
        {
            var result = this[index];
            Console.WriteLine(result);
        }

        public void Run()
        {
            new OneDStringArrayView().Main(new OneDStringArrayFactory());
        }
    }
}
