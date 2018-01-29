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
        public MainWindow()
        {
            InitializeComponent();
            Draw_CoordSys();
            Draw_Triangle();



        }

        private void Draw_CoordSys()
        {
            for (int j = 0; j <= CoordSys.Height; j += 10)
            {
                for (int i = 0; i <= CoordSys.Width; i += 10)
                {
                    Draw_Point(i, j);
                }
            }

        }
        private void Draw_Point(int x, int y)
        {
            Ellipse coordDot = new Ellipse() { Width = 2, Height = 2, Stroke = Brushes.Black, StrokeThickness = 2 };

            CoordSys.Children.Add(coordDot);

            coordDot.SetValue(Canvas.LeftProperty, (double)x);
            coordDot.SetValue(Canvas.TopProperty, (double)y);
        }
        private void Draw_Triangle()
        {
            Line side1 = new Line() { Width = 2, Height = 2, Stroke = Brushes.Red, StrokeThickness = 2 };
            side1.X1 = 5;
            side1.Y1 = 2;
            side1.X2 = 15;
            side1.Y2 = 2;
            CoordSys.Children.Add(side1);
            side1.SetValue(Canvas.LeftProperty, (double)0);
            side1.SetValue(Canvas.TopProperty, (double)0);
        }
    }
}
