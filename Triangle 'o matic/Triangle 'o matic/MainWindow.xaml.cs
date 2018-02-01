using System;
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
                case "dr":
                    temp.Pt2 = new Point(pt1.X, pt1.Y + 1);
                    temp.Pt3 = new Point(pt1.X + 1, pt1.Y + 1);
                    break;
                case "ur":
                    temp.Pt2 = new Point(pt1.X, pt1.Y - 1);
                    temp.Pt3 = new Point(pt1.X + 1, pt1.Y - 1);
                    break;
                case "dl":
                    temp.Pt2 = new Point(pt1.X, pt1.Y + 1);
                    temp.Pt3 = new Point(pt1.X - 1, pt1.Y + 1);
                    break;
                case "ul":
                    temp.Pt2 = new Point(pt1.X, pt1.Y - 1);
                    temp.Pt3 = new Point(pt1.X - 1, pt1.Y - 1);
                    break;
                default:
                    break;
            }

            temp.Convert(leX, leY);

            if (!(temp.GetMax().X >= CoordSys.Width | temp.GetMax().Y >= CoordSys.Height))
            {
                for (int i = 0; i < DreieckListe.Count; i++)
                {
                    if (DreieckListe[i].Pt1 == temp.Pt1 && DreieckListe[i].Pt2 == temp.Pt2 && DreieckListe[i].Pt3 == temp.Pt3)
                    {
                        temp = null;
                        MessageBox.Show("Dieses Dreieck existiert bereits!");
                        break;
                    }//das if als switch um alle möglichkeiten zu handeln, wie dreiecke liegen (dass sie sich nur berühren und nicht überlappen)

                }
                if (temp != null)
                {
                    Draw_Triangle(temp);
                }
            }
            else
            {
                MessageBox.Show("Das Dreieck liegt ausserhalb des zulässigen Bereichs!");
            }


        }
        private Point RandomPointGen()
        {
            var rnd = new Random(new System.DateTime().Millisecond + Guid.NewGuid().GetHashCode());
            return new Point(rnd.Next(int.Parse(CoordSys.Width.ToString()) / leX), rnd.Next(int.Parse(CoordSys.Height.ToString()) / leY));
        }
        private string RandomDirection()
        {
            var rnd = new Random(new System.DateTime().Millisecond + Guid.NewGuid().GetHashCode());
            string[] directions = new string[] { "rd", "ru", "dr", "ur", "ld", "lu", "dl", "ul" };
            return directions[rnd.Next(0, 7)];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Make_Triangle(RandomPointGen(), RandomDirection());
        }
    }
}
