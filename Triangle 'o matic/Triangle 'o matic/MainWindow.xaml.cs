using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        private void Draw_Triangle(Dreieck dreieck, Canvas target)
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
        private void Generate_Triangle(Point pt1, string direction)
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

            if (Validate_Triangle(temp))
            {
                Draw_Triangle(temp, CoordSys);
                DreieckListe.Add(temp);
                Controls(direction);
            }
        }
        private bool Validate_Triangle(Dreieck _dreieck)
        {
            /* 1. Dreieck im Koordinatenbereich
             * 2. Dreieck noch nicht vorhanden
             * 3. Dreieck muss 2 Punkte mit einem Dreieck gemeinsam haben
             * 4. Dreieck darf andere Dreiecke nicht überlappen (Mehrzahl!!!)*/

            //1)
            if (_dreieck.GetMax().X >= CoordSys.Width | _dreieck.GetMax().Y >= CoordSys.Height | _dreieck.GetMin().X <= 0 | _dreieck.GetMin().Y <= 0)
            {
                return false;
            }

            //2) und 3) und 4)
            var PointListCurrentListItem = new List<Point>();
            var samePoints = new List<Point>();
            var eligibleDreieckeToAddTo = new List<Dreieck>();
            bool overlap = false;
            if (DreieckListe.Count > 0)
            {
                foreach (var listItem in DreieckListe)
                {
                    PointListCurrentListItem.Add(_dreieck.Pt1);
                    PointListCurrentListItem.Add(_dreieck.Pt2);
                    PointListCurrentListItem.Add(_dreieck.Pt3);
                    PointListCurrentListItem.Add(listItem.Pt1);
                    PointListCurrentListItem.Add(listItem.Pt2);
                    PointListCurrentListItem.Add(listItem.Pt3);


                    if (_dreieck.Pt1 == listItem.Pt1 | _dreieck.Pt1 == listItem.Pt2 | _dreieck.Pt1 == listItem.Pt3)
                    {
                        samePoints.Add(_dreieck.Pt1);
                    }
                    if (_dreieck.Pt2 == listItem.Pt1 | _dreieck.Pt2 == listItem.Pt2 | _dreieck.Pt2 == listItem.Pt3)
                    {
                        samePoints.Add(_dreieck.Pt2);
                    }
                    if (_dreieck.Pt3 == listItem.Pt1 | _dreieck.Pt3 == listItem.Pt2 | _dreieck.Pt3 == listItem.Pt3)
                    {
                        samePoints.Add(_dreieck.Pt3);
                    }

                    switch (samePoints.Count)
                    {
                        case 2://3)
                            eligibleDreieckeToAddTo.Add(listItem);
                            switch (_dreieck.Orientation)
                            {
                                case 1:
                                    if ((listItem.Orientation == 2 && _dreieck.GetMin().X != listItem.GetMax().X) | (listItem.Orientation == 4 && _dreieck.GetMax().Y != listItem.GetMin().Y))
                                    {
                                        overlap = true;
                                    }
                                    break;
                                case 2:
                                    if ((listItem.Orientation == 1 && _dreieck.GetMax().X != listItem.GetMin().X) | (listItem.Orientation == 3 && _dreieck.GetMax().Y != listItem.GetMin().Y))
                                    {
                                        overlap = true;
                                    }
                                    break;
                                case 3:
                                    if ((listItem.Orientation == 2 && _dreieck.GetMax().X == listItem.GetMax().X) | (listItem.Orientation == 4 && _dreieck.GetMin().Y == listItem.GetMin().Y))
                                    {
                                        overlap = true;
                                    }
                                    break;
                                case 4:
                                    if ((listItem.Orientation == 1 && _dreieck.GetMin().X == listItem.GetMin().X) | (listItem.Orientation == 3 && _dreieck.GetMin().Y == listItem.GetMin().Y))
                                    {
                                        overlap = true;
                                    }
                                    break;
                            }
                            break;
                        case 3://2)
                            return false;
                        default:
                            break;
                    }

                    samePoints.Clear();
                    PointListCurrentListItem.Clear();
                }
            }
            else //erstes dreieck
            {
                return true;
            }

            if (eligibleDreieckeToAddTo.Count != 0 && !overlap)
            {
                return true;
            }
            else
            {
                return false;
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
            string[] directions = new string[] { "rd", "ru", "dr", "ur", "ld", "lu", "dl", "ul", "q1", "q2", "q3", "q4" };
            return directions[rnd.Next(0, 11)];
        }
        private void MakeRandomTriangle()
        {
            Generate_Triangle(RandomPointGen(), RandomDirection());
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            while (DreieckListe.Count < 250)
            {
                MakeRandomTriangle();
            }
            //MakeRandomTriangle();
        }


        private void Controls(string currentDir)
        {
            CanvasControls.Children.Clear();
            Draw_Triangle(DreieckListe[DreieckListe.Count - 1], CanvasControls);

        }







        void OnTriangleHover(object sender, MouseEventArgs e)
        {
            Polygon test = (Polygon)e.OriginalSource;
            test.Fill = Brushes.Blue;
        }
        void OnTriangleAway(object sender, MouseEventArgs e)
        {
            Polygon test = (Polygon)e.OriginalSource;
            test.Fill = Brushes.OrangeRed;
        }

    }
}
