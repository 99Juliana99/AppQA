namespace ConsoleApplication
{
    struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    class Program
    {
        private const double delta = 0.01;

        static void Main(string[] args)
        {
            Point a = GetPointFromConsole("A");
            Point b = GetPointFromConsole("B");
            Point c = GetPointFromConsole("C");

            double ab = GetLengthOfTriangleSides(a, b);
            double bc = GetLengthOfTriangleSides(b, c);
            double ca = GetLengthOfTriangleSides(c, a);

            Console.WriteLine($"Length of AB is: '{ab}'");
            Console.WriteLine($"Length of BC is: '{bc}'");
            Console.WriteLine($"Length of AC is: '{ca}'");

            bool isItEquilateralTriangle = IsItEquilateralTriangle(ab, bc, ca);
            string notEquilateralTriangle = isItEquilateralTriangle ? string.Empty : "NOT";

            Console.WriteLine($"Triangle IS {notEquilateralTriangle} 'Equilateral'");

            bool isItIsoscelesTriangle = IsItIsoscelesTriangle(ab, bc, ca);
            string notIsoscelesTriangle = isItIsoscelesTriangle ? string.Empty : "NOT";

            Console.WriteLine($"Triangle IS {notIsoscelesTriangle} 'Isosceles'");

            bool isItRightTriangle = IsItRightTriangle(ab, bc, ca);
            string notRightTriangle = isItRightTriangle ? string.Empty : "NOT";

            Console.WriteLine($"Triangle IS {notRightTriangle} 'Right'");

            double perimeter = GetPerimeter(ab, bc, ca);

            Console.WriteLine($"Perimeter: '{perimeter}'");

            var evenNumbersFromZeroToN = GetEvenNumbersFromZeroToN(perimeter);

            Console.WriteLine($"Parity numbers in range from 0 to triangle perimeter:");
            foreach (var evenNumber in evenNumbersFromZeroToN)
            {
                Console.WriteLine(evenNumber);
            }
        }

        private static Point GetPointFromConsole(string nameOfPoint)
        {
            Console.WriteLine($"Enter coordinate x of dot {nameOfPoint}:");
            string? temp = Console.ReadLine();
            double x = Convert.ToDouble(temp);
            Console.WriteLine($"Enter coordinate y of dot {nameOfPoint}:");
            temp = Console.ReadLine();

            double y = Convert.ToDouble(temp);
            return new Point()
            {
                X = x,
                Y = y
            };
        }

        static double GetLengthOfTriangleSides(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }

        static double GetPerimeter(double side1, double side2, double side3)
        {
            return side1 + side2 + side3;
        }

        private static bool IsItEquilateralTriangle(double side1, double side2, double side3)
        {
            return Math.Abs(side1 - side2) <= delta && Math.Abs(side2 - side3) <= delta;
        }

        private static bool IsItIsoscelesTriangle(double side1, double side2, double side3)
        {
            return Math.Abs(side1 - side2) <= delta || Math.Abs(side2 - side3) <= delta || Math.Abs(side3 - side1) <= delta;
        }

        private static bool IsItRightTriangle(double side1, double side2, double side3)
        {
            if (side1 > side2 && side1 > side3)
            {
                return IsItRightTriangleByPiphagor(side1, side2, side3);
            }
            else if (side2 > side1 && side2 > side3)
            {
                return IsItRightTriangleByPiphagor(side2, side1, side3);
            }
            else if (side3 > side1 && side3 > side2)
            {
                return IsItRightTriangleByPiphagor(side3, side1, side2);
            }
            else
            {
                return false;
            }
        }

        private static bool IsItRightTriangleByPiphagor(double hupotenuse, double oppositeSide1, double oppositeSide2)
        {
            return Math.Abs(hupotenuse - Math.Sqrt(Math.Pow(oppositeSide1, 2) + Math.Pow(oppositeSide2, 2))) <= delta;
        }

        private static IEnumerable<double> GetEvenNumbersFromZeroToN(double n)
        {
            double start = 0;
            while (start <= n)
            {
                yield return start;
                start += 2;
            }
        }
    }
}
