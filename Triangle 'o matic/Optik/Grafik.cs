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

            points.Add(dreieck.PunktA);
            points.Add(dreieck.PunktB);
            points.Add(dreieck.PunktC);
            triangle.Points = points;

            triangle.MouseEnter += OnTriangleHover;
            triangle.MouseLeave += OnTriangleAway;

            target.Children.Add(triangle);

        }
        public static void Generate_Triangle(Point pt1, string direction, Canvas canvas)
        {
            Dreieck temp = new Dreieck();

            temp.PunktA = pt1;

            switch (direction)
            {
                case "rd":
                    temp.PunktB = new Point(pt1.X + 1, pt1.Y);
                    temp.PunktC = new Point(pt1.X + 1, pt1.Y + 1);
                    temp.Orientation = 3;
                    break;
                case "ru":
                    temp.PunktB = new Point(pt1.X + 1, pt1.Y);
                    temp.PunktC = new Point(pt1.X + 1, pt1.Y - 1);
                    temp.Orientation = 2;
                    break;
                case "ld":
                    temp.PunktB = new Point(pt1.X - 1, pt1.Y);
                    temp.PunktC = new Point(pt1.X - 1, pt1.Y + 1);
                    temp.Orientation = 4;
                    break;
                case "lu":
                    temp.PunktB = new Point(pt1.X - 1, pt1.Y);
                    temp.PunktC = new Point(pt1.X - 1, pt1.Y - 1);
                    temp.Orientation = 1;
                    break;
                case "dr":
                    temp.PunktB = new Point(pt1.X, pt1.Y + 1);
                    temp.PunktC = new Point(pt1.X + 1, pt1.Y + 1);
                    temp.Orientation = 1;
                    break;
                case "ur":
                    temp.PunktB = new Point(pt1.X, pt1.Y - 1);
                    temp.PunktC = new Point(pt1.X + 1, pt1.Y - 1);
                    temp.Orientation = 4;
                    break;
                case "dl":
                    temp.PunktB = new Point(pt1.X, pt1.Y + 1);
                    temp.PunktC = new Point(pt1.X - 1, pt1.Y + 1);
                    temp.Orientation = 2;
                    break;
                case "ul":
                    temp.PunktB = new Point(pt1.X, pt1.Y - 1);
                    temp.PunktC = new Point(pt1.X - 1, pt1.Y - 1);
                    temp.Orientation = 3;
                    break;
                case "q1":
                    temp.PunktB = new Point(pt1.X + 1, pt1.Y);
                    temp.PunktC = new Point(pt1.X, pt1.Y - 1);
                    temp.Orientation = 1;
                    break;
                case "q2":
                    temp.PunktB = new Point(pt1.X - 1, pt1.Y);
                    temp.PunktC = new Point(pt1.X, pt1.Y - 1);
                    temp.Orientation = 2;
                    break;
                case "q3":
                    temp.PunktB = new Point(pt1.X - 1, pt1.Y);
                    temp.PunktC = new Point(pt1.X, pt1.Y + 1);
                    temp.Orientation = 3;
                    break;
                case "q4":
                    temp.PunktB = new Point(pt1.X + 1, pt1.Y);
                    temp.PunktC = new Point(pt1.X, pt1.Y + 1);
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
