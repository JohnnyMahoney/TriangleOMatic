using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static Triangle__o_matic.Interaktionen;
using static Triangle__o_matic.Spiellogik;
using static Triangle__o_matic.MainWindow;
using static Triangle__o_matic.Spiellogik;

namespace Triangle__o_matic
{
    static class Grafik
    {
        public static void Draw_Triangle(Dreieck dreieck, Canvas target)
        {
            Polygon triangle = new Polygon();
            var points = new PointCollection();

            triangle.Stroke = Brushes.Black;
            triangle.StrokeThickness = 1;
            triangle.Fill = Brushes.OrangeRed;

            points.Add(dreieck.Pt1);
            points.Add(dreieck.Pt2);
            points.Add(dreieck.Pt3);
            triangle.Points = points;

            triangle.MouseEnter += OnTriangleHover;
            triangle.MouseLeave += OnTriangleAway;

            target.Children.Add(triangle);

        }
        public static void Generate_Triangle(Point pt1, string direction, Canvas canvas)
        {
            Dreieck temp = new Dreieck();

            temp.Pt1 = pt1;

            switch (direction)
            {


                case "rd":
                    temp.Pt2 = new Point(pt1.X + 1, pt1.Y);
                    temp.Pt3 = new Point(pt1.X + 1, pt1.Y + 1);
                    temp.Orientation = 3;
                    break;
                case "ru":
                    temp.Pt2 = new Point(pt1.X + 1, pt1.Y);
                    temp.Pt3 = new Point(pt1.X + 1, pt1.Y - 1);
                    temp.Orientation = 2;
                    break;
                case "ld":
                    temp.Pt2 = new Point(pt1.X - 1, pt1.Y);
                    temp.Pt3 = new Point(pt1.X - 1, pt1.Y + 1);
                    temp.Orientation = 4;
                    break;
                case "lu":
                    temp.Pt2 = new Point(pt1.X - 1, pt1.Y);
                    temp.Pt3 = new Point(pt1.X - 1, pt1.Y - 1);
                    temp.Orientation = 1;
                    break;
                case "dr":
                    temp.Pt2 = new Point(pt1.X, pt1.Y + 1);
                    temp.Pt3 = new Point(pt1.X + 1, pt1.Y + 1);
                    temp.Orientation = 1;
                    break;
                case "ur":
                    temp.Pt2 = new Point(pt1.X, pt1.Y - 1);
                    temp.Pt3 = new Point(pt1.X + 1, pt1.Y - 1);
                    temp.Orientation = 4;
                    break;
                case "dl":
                    temp.Pt2 = new Point(pt1.X, pt1.Y + 1);
                    temp.Pt3 = new Point(pt1.X - 1, pt1.Y + 1);
                    temp.Orientation = 2;
                    break;
                case "ul":
                    temp.Pt2 = new Point(pt1.X, pt1.Y - 1);
                    temp.Pt3 = new Point(pt1.X - 1, pt1.Y - 1);
                    temp.Orientation = 3;
                    break;
                case "q1":
                    temp.Pt2 = new Point(pt1.X + 1, pt1.Y);
                    temp.Pt3 = new Point(pt1.X, pt1.Y - 1);
                    temp.Orientation = 1;
                    break;
                case "q2":
                    temp.Pt2 = new Point(pt1.X - 1, pt1.Y);
                    temp.Pt3 = new Point(pt1.X, pt1.Y - 1);
                    temp.Orientation = 2;
                    break;
                case "q3":
                    temp.Pt2 = new Point(pt1.X - 1, pt1.Y);
                    temp.Pt3 = new Point(pt1.X, pt1.Y + 1);
                    temp.Orientation = 3;
                    break;
                case "q4":
                    temp.Pt2 = new Point(pt1.X + 1, pt1.Y);
                    temp.Pt3 = new Point(pt1.X, pt1.Y + 1);
                    temp.Orientation = 4;
                    break;
                default:
                    break;
            }

            temp.Convert(leX, leY);

            if (Validate_Triangle(temp, canvas))
            {
                Draw_Triangle(temp, canvas);
                DreieckListe.Add(temp);
                //Controls(direction);
            }
        }
        public static void MakeRandomTriangle(Canvas canvas)
        {
            Generate_Triangle(RandomPointGen(canvas), RandomDirection(), canvas);
        }
    }
}
