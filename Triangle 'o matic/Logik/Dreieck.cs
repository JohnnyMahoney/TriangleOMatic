using System.Windows;
using System.Windows.Shapes;
using static Triangle__o_matic.MainWindow;

namespace Triangle__o_matic
{
    public class Dreieck
    {

        private Point _pt1;
        private Point _pt2;
        private Point _pt3;
        private int _value;
        public Point Pt1 { get { return _pt1; } set { _pt1 = value; } }
        public Point Pt2 { get { return _pt2; } set { _pt2 = value; } }
        public Point Pt3 { get { return _pt3; } set { _pt3 = value; } }
        public int Orientation;

        public void Convert(int factorx, int factory)
        {
            _pt1.X *= factorx;
            _pt1.Y *= factory;
            _pt2.X *= factorx;
            _pt2.Y *= factory;
            _pt3.X *= factorx;
            _pt3.Y *= factory;
        }
        public Point GetMax()
        {
            double x, y;
            if (this.Pt1.X >= this.Pt2.X)
            {
                x = this.Pt1.X;
            }
            else
            {
                x = this.Pt2.X;
            }
            if (this.Pt1.Y >= this.Pt2.Y)
            {
                y = this.Pt1.Y;
            }
            else
            {
                y = this.Pt2.Y;
            }

            return new Point(x, y);
        }
        public Point GetMin()
        {
            double x, y;
            if (this.Pt1.X >= this.Pt2.X)
            {
                x = this.Pt2.X;
            }
            else
            {
                x = this.Pt1.X;
            }
            if (this.Pt1.Y >= this.Pt2.Y)
            {
                y = this.Pt2.Y;
            }
            else
            {
                y = this.Pt1.Y;
            }

            return new Point(x, y);
        }
    }
}
