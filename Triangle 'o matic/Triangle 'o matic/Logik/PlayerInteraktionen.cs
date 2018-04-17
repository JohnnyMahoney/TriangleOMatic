using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using static Triangle__o_matic.Grafik;
using static Triangle__o_matic.MainWindow;

namespace Triangle__o_matic
{
    static class Interaktionen
    {
        static public void OnTriangleHover(object sender, MouseEventArgs e)
        {
            Polygon test = (Polygon)e.OriginalSource;
            test.Fill = Brushes.Blue;
        }
        static public void OnTriangleAway(object sender, MouseEventArgs e)
        {
            Polygon test = (Polygon)e.OriginalSource;
            test.Fill = Brushes.OrangeRed;
        }



        






    }
}
