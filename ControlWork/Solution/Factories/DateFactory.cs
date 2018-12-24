using System;
using Solution.Interfaces;
using Solution.Classes;

namespace Solution.Factories
{
    public class DateFactory : SolutionFactory
    {
        public override string Name
        {
            get
            {
                return "Класс Дата";
            }
        }

        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            if (values.Length == 0) return new Date();
            if (values[0] is string) return StringHandler((string)values[0]);
            return new Date();
        }

        private IStudyAssignment StringHandler(string value)
        {
            var arr = value.Split(new char[] { '.' });
            if(arr.Length == 3)
            {
                return new Date(int.Parse(arr[0]), int.Parse(arr[1]), int.Parse(arr[2]));
            }
            //implement processing the wrong format of the entered data
            return new Date();
        }
    }
}
