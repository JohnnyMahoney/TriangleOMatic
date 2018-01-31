using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Triangle__o_matic
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int leX = 20;
        int leY = 20;
        List<Dreieck> DreieckListe = new List<Dreieck>();
        public MainWindow()
        {

            InitializeComponent();
            Draw_CoordSys(leX, leY);

            Make_Triangle(new Point(5, 5), "ld");
            Make_Triangle(new Point(31, 5), "ld");

        }

        private void Draw_CoordSys(int lex, int ley)
        {
            for (int j = 0; j <= CoordSys.Height; j += ley)
            {
                for (int i = 0; i <= CoordSys.Width; i += lex)
                {
                    Draw_Point(i, j);
                }
            }

        }
        private void Draw_Point(int x, int y)
        {
            Ellipse coordDot = new Ellipse() { Width = 1, Height = 1, Stroke = Brushes.Black, StrokeThickness = 1 };
            coordDot.HorizontalAlignment = HorizontalAlignment.Center;
            coordDot.VerticalAlignment = VerticalAlignment.Center;
            CoordSys.Children.Add(coordDot);
            coordDot.SetValue(Canvas.LeftProperty, (double)x);
            coordDot.SetValue(Canvas.TopProperty, (double)y);
        }
        private void Draw_Triangle(Dreieck dreieck)
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
            CoordSys.Children.Add(triangle);
            DreieckListe.Add(dreieck);
        }
        private void Make_Triangle(Point pt1, string direction)
        {
            Dreieck temp = new Dreieck();

            temp.Pt1 = pt1;

            switch (direction)
            {


                case "rd":
                    temp.Pt2 = new Point(pt1.X + 1, pt1.Y);
                    temp.Pt3 = new Point(pt1.X + 1, pt1.Y + 1);
                    break;
                case "ru":
                    temp.Pt2 = new Point(pt1.X + 1, pt1.Y);
                    temp.Pt3 = new Point(pt1.X + 1, pt1.Y - 1);
                    break;
                case "ld":
                    temp.Pt2 = new Point(pt1.X - 1, pt1.Y);
                    temp.Pt3 = new Point(pt1.X - 1, pt1.Y + 1);
                    break;
                case "lu":
                    temp.Pt2 = new Point(pt1.X - 1, pt1.Y);
                    temp.Pt3 = new Point(pt1.X - 1, pt1.Y - 1);
                    break;
                default:
                    break;
            }

            temp.Convert(leX, leY);

            if (temp.GetMax().X >= CoordSys.Width | temp.GetMax().Y >= CoordSys.Height)
            {
                temp = null;
            }
            else
            {
                Draw_Triangle(temp);
            }

        }


    }
}
