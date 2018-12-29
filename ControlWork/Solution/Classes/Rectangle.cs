using System;
using Solution.Interfaces;

namespace Solution.Classes
{
    class Rectangle : IRectangle, IStudyAssignment
    {
        private readonly double _x;
        private readonly double _y;
        private readonly double _width;
        private readonly double _height;

        public double X
        {
            get
            {
                return _x;
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }
        }

        public double Width
        {
            get
            {
                return _width;
            }
        }

        public double Height
        {
            get
            {
                return _height;
            }
        }

        public Rectangle(double x, double y, double width, double height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height; 
        }
        public Rectangle() : this(0,0,1,1) { }

        public IRectangle GetRectangleContainingTwoDate(IRectangle rectangle)
        {
            var x = Math.Min(X, rectangle.X);
            var y = Math.Min(Y, rectangle.Y);
            var xEnd = Math.Max(X + Width, rectangle.X + rectangle.Width);
            var yEnd = Math.Max(Y + Height, rectangle.Y + rectangle.Height);
            return (new Rectangle(x, y, xEnd - x, yEnd - y));
        }

        public void Print()
        {
            Console.WriteLine($"Координаты нижнего левого угла прямоугольника - ({X},{Y}),\r\nВысота - {Height}, Длина - {Width}");
        }

        public bool Intesect(IRectangle rectangle)
        {
            return !(Y > rectangle.Y + rectangle.Height ||
                Y + Height < rectangle.Y ||
                X > rectangle.X + rectangle.Width ||
                X + Width < rectangle.X);
        }

        public void Run()
        {
            new View.RectangleView().Main(new Factories.RectangleFactory());
        }
    }
}
