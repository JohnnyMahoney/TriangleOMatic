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
    static class Coordsys
    {
        public static void Draw_CoordSys(int lex, int ley, Canvas canvas)
        {
            for (int j = 0; j <= canvas.Height; j += ley)
            {
                for (int i = 0; i <= canvas.Width; i += lex)
                {
                    Draw_CoordSys_Point(i, j, canvas);
                }
            }

        }
        public static void Draw_CoordSys_Point(int x, int y, Canvas canvas)
        {
            Ellipse coordDot = new Ellipse() { Width = 1, Height = 1, Stroke = Brushes.Black, StrokeThickness = 1 };
            coordDot.HorizontalAlignment = HorizontalAlignment.Center;
            coordDot.VerticalAlignment = VerticalAlignment.Center;
            canvas.Children.Add(coordDot);
            coordDot.SetValue(Canvas.LeftProperty, (double)x);
            coordDot.SetValue(Canvas.TopProperty, (double)y);
        }
    }
}
