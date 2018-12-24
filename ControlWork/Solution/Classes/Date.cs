using System;
using System.Collections.Generic;
using Solution.Factories;
using Solution.Interfaces;
using Solution.View;

namespace Solution.Classes
{
    enum MonthNameOrCount
    {
        Name = 0,
        Count
    }

    class Date : IDate, IStudyAssignment
    {
        private int _day;
        private int _month;
        private int _year;

        private Dictionary<int, string[]> calendar = new Dictionary<int, string[]>
        {
            {1, new string[] { "January", "31"} },
            {2, new string[] { "February", "28"} },
            {3, new string[] { "March", "31"} },
            {4, new string[] { "April", "30"} },
            {5, new string[] { "May", "31"} },
            {6, new string[] { "June", "30"} },
            {7, new string[] { "July", "31"} },
            {8, new string[] { "August", "31"} },
            {9, new string[] { "September", "30"} },
            {10, new string[] { "October", "31"} },
            {11, new string[] { "November", "30"} },
            {12, new string[] { "December", "31"} }
        };

        public int Day
        {
            get { return _day; }
            set
            {
                if (value > int.Parse(calendar[Month][(int)MonthNameOrCount.Count]))
                    _day = int.Parse(calendar[Month][(int)MonthNameOrCount.Count]);
                else _day = value;
            }
        }

        public int Month
        {
            get { return _month; }
            set
            {
                if (value == 13)
                {
                    _year++;
                    _month = 1;
                }
                else if(value == 0)
                {
                    _year--;
                    _month = 12;
                }
                else _month = value;
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                CheckLeapYear(value);
                _year = value;
            }
        }

        public Date()
        {
            _day = 29;
            _month = 10;
            _year = 1991;
        }
        public Date(int day, int month, int year)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        private void CheckLeapYear(int year)
        {
            if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
                calendar[2] = new string[] { "February", "29" };
            else calendar[2] = new string[] { "February", "28" };
        }

        /// <summary>
        /// Для тестов брал данные о колличестве дней между датами.
        /// И в результате при больших delta возникает погрешность,
        /// которую я пока объяснить не могу
        /// </summary>
        /// <param name="delta">Добавить дней</param>
        private void UpdateDate(int delta)
        {
            var monthCountDay = int.Parse(calendar[Month][(int)MonthNameOrCount.Count]);
            if (delta + Day > monthCountDay)
            {
                delta = delta - monthCountDay + Day;
                Day = 0;
                Month++;
                UpdateDate(delta);
            }           
            else Day = Day + delta;
        }

        public override string ToString()
        {
            return $"{Day} {calendar[Month][(int)MonthNameOrCount.Name]} {Year}г.";
        }

        public void AddDays(int count)
        {
            if (count < 0) return;
            UpdateDate(count);
        }

        public void AddOneDay()
        {
            UpdateDate(1);
        }

        public void ReduceOneDay()
        {
            if (Day - 1 < 1)
            {
                Month--;
                Day = int.Parse(calendar[Month][(int)MonthNameOrCount.Count]);
            }
            else Day--;
        }

        public void SetDate(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return;
            var arr = value.Split(new char[] { '.' });
            var day = int.Parse(arr[0]);
            var month = int.Parse(arr[1]);
            if (day < 1 || day > 31 || month < 1 || month > 12)
            {
                Console.WriteLine("введены некорректные данные");
                return;
            }
            Year = int.Parse(arr[2]);
            Month = month;
            Day = day;  
        }

        public void Run()
        {
            new DateView().Main(new DateFactory());
        }
    }
}
