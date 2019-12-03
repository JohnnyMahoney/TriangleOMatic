using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;
using static Triangle__o_matic.MainWindow;

namespace Triangle__o_matic
{
    public class Dreieck
    {
        public int Value { get; }
        public Point PunktA { get; set; }
        public Point PunktB { get; set; }
        public Point PunktC { get; set; }
        public int Orientation { get; set; }

        public Dreieck()
        {
            PunktA = new Point();
            PunktB = new Point();
            PunktC = new Point();
        }
        public Dreieck (Point punktA, Point punktB, Point punktC)
        {
            PunktA = punktA;
            PunktB = punktB;
            PunktC = punktC;
        }

        public void Convert(int factorX, int factorY)
        {
            PunktA = new Point(PunktA.X * factorX, PunktA.Y * factorY);
            PunktB = new Point(PunktB.X * factorX, PunktB.Y * factorY);
            PunktC = new Point(PunktC.X * factorX, PunktC.Y * factorY);
        }
        public Point GetMax()
        {
            double x, y;

            if (PunktA.X < PunktB.X)
            {
                x = PunktB.X;
            }
            else if (PunktA.X < PunktC.X)
            {
                x = PunktC.X;
            }
            else
            {
                x = PunktA.X;
            }

            if (PunktA.Y < PunktB.Y)
            {
                y = PunktB.Y;
            }
            else if (PunktA.Y < PunktC.Y)
            {
                y = PunktC.Y;
            }
            else
            {
                y = PunktA.Y;
            }

            return new Point(x, y);
        }
        public Point GetMin()
        {
            double x, y;

            if (PunktA.X < PunktB.X)
            {
                x = PunktA.X;
            }
            else if (PunktA.X < PunktC.X)
            {
                x = PunktA.X;
            }
            else
            {
                x = PunktC.X;
            }

            if (PunktA.Y < PunktB.Y)
            {
                y = PunktA.Y;
            }
            else if (PunktA.Y < PunktC.Y)
            {
                y = PunktA.Y;
            }
            else
            {
                y = PunktC.Y;
            }

            return new Point(x, y);
        }
    }
}
