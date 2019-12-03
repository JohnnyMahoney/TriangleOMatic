using System.Collections.Generic;
using System.Windows;
using static Triangle__o_matic.Coordsys;
using static Triangle__o_matic.Grafik;

namespace Triangle__o_matic
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int leX = 20;
        public static int leY = 20;
        public static List<Dreieck> DreieckListe = new List<Dreieck>();
        public MainWindow()
        {

            InitializeComponent();
            Draw_CoordSys(leX, leY, CoordSys);

            

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            while (DreieckListe.Count < 250)
            {
                MakeRandomTriangle(CoordSys);
            }
            //MakeRandomTriangle();
        }


        //public static void Controls(string currentDir)
        //{
        //    CanvasControls.Children.Clear();
        //    Draw_Triangle(DreieckListe[DreieckListe.Count - 1], CanvasControls);

        //}













    }
}
