using System;
using Solution.Interfaces;

namespace Solution.Classes
{
    class Counter : ICounter, IStudyAssignment
    {
        private int _current;
        private int _min;
        private int _max;

        public int Min
        {
            get { return _min; }
            set
            {
                _min = value;
            }
        }

        public int Max
        {
            get { return _max; }
            set
            {
                _max = value;
            }
        }

        public int Current
        {
            get
            {
                return _current;
            }

            set
            {
                if (value < Min)
                    _current = Max;
                else if (value > Max)
                    _current = Min;
                else _current = value;
            }
        }

        public Counter(int border1, int border2)
        {
            if(border1 <= border2)
            {
                Min = border1;
                Current = border1;
                Max = border2;
            }
            else
            {
                Min = border2;
                Current = border2;
                Max = border1;
            }
        }
        public Counter() : this(0, 23) { }

        public override string ToString()
        {
            return $"{Current} ({Min} - {Max})";
        }

        public void Dec()
        {
            Current--;
        }

        public void End(int newEnd)
        {
            if (newEnd > Min)
            {
                Max = newEnd;
                Current = Min;
            }
        }

        public void Inc()
        {
            Current++;
        }

        public void Start(int newStart)
        {
            if (newStart < Max)
            {
                Min = newStart;
                Current = Min;
            }
        }

        public void Run()
        {
            new View.CounterView().Main(new Factories.CounterFactory());
        }
    }
}
