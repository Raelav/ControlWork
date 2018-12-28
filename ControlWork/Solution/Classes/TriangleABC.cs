using System;
using Solution.Interfaces;

namespace Solution.Classes
{
    class TriangleABC : ITriangleABC, IStudyAssignment
    {
        private double _ab;
        private double _bc;
        private double _ca;

        public double AB
        {
            get
            {
                return _ab;
            }
            set
            {
                if (value < 0)
                    Console.WriteLine("Длина не может быть отрицательной");
                else _ab = value;
            }
        }

        public double BC
        {
            get
            {
                return _bc;
            }
            set
            {
                if (value < 0)
                    Console.WriteLine("Длина не может быть отрицательной");
                else _bc = value;
            }
        }

        public double CA
        {
            get
            {
                return _ca;
            }
            set
            {
                if (value < 0)
                    Console.WriteLine("Длина не может быть отрицательной");
                else _ca = value;
            }
        }

        public TriangleABC(double ab, double bc, double ca)
        {
            AB = ab;
            BC = bc;
            CA = ca;
        }

        /// <summary>
        /// Pythagorean triangle default
        /// </summary>
        public TriangleABC() : this(3, 4, 5) { }

        public double Area
        {
            get
            {
                if (TestWrongTriangle()) return -1;
                //Формула Герона
                var p = (AB + BC + CA) / 2;
                return Math.Sqrt(p * (p - AB) * (p - BC) * (p - CA));
            }
        }

        public double Perimeter
        {
            get
            {
                return AB + BC + CA;
            }
        }

        private bool TestWrongTriangle()
        {
            if(!((AB + BC > CA) && (AB + CA > BC) && (BC + CA > AB)))
            {
                Console.WriteLine("Такой треугольник не построить");
                return true;
            }
            return false;
        }

        public void Print()
        {
            Console.WriteLine($"AB = {AB}, BC = {BC}, CA = {CA}");
        }

        public void PrintType()
        {
            if (TestWrongTriangle()) return;
            double squareLongerSide;
            double sumSquareOtherSides;
            GetSpecialValues(out squareLongerSide, out sumSquareOtherSides);

            if (squareLongerSide == sumSquareOtherSides)
                Console.Write("Треугольник прямоугольный");
            else if (squareLongerSide < sumSquareOtherSides)
                Console.Write("Треугольник остроугольный");
            else Console.Write("Треугольник тупоугольный");
        }

        private void GetSpecialValues(out double squareLongerSide, out double sumSquareOtherSides)
        {
            if(AB >= BC && AB >= CA)
            {
                squareLongerSide = AB * AB;
                sumSquareOtherSides = BC * BC + CA * CA;
            }
            else if (BC >= AB && BC >= CA)
            {
                squareLongerSide = BC * BC;
                sumSquareOtherSides = AB * AB + CA * CA;
            }
            else 
            {
                squareLongerSide = CA * CA;
                sumSquareOtherSides = BC * BC + AB * AB;
            }
        }

        public void PrintView()
        {
            if (AB == BC && BC == CA)
                Console.Write("Треугольник равносторонний");
            else if(AB != BC && AB != CA && BC != CA)
                Console.Write("Треугольник разносторонний");
            else Console.Write("Треугольник равнобедренный");
        }

        public void Run()
        {
            new View.TriangleABCView().Main(new Factories.TriangleABCFactory());
        }
    }
}
