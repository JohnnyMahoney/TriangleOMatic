using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using static Triangle__o_matic.MainWindow;

namespace Triangle__o_matic
{
    static class Spiellogik
    {
        public static Point RandomPointGen(Canvas canvas)
        {
            var rnd = new Random(new System.DateTime().Millisecond + Guid.NewGuid().GetHashCode());
            return new Point(rnd.Next(int.Parse(canvas.Width.ToString()) / leX), rnd.Next(int.Parse(canvas.Height.ToString()) / leY));
        }
        public static string RandomDirection()
        {
            var rnd = new Random(new System.DateTime().Millisecond + Guid.NewGuid().GetHashCode());
            string[] directions = new string[] { "rd", "ru", "dr", "ur", "ld", "lu", "dl", "ul", "q1", "q2", "q3", "q4" };
            return directions[rnd.Next(0, 11)];
        }
        public static bool Validate_Triangle(Dreieck _dreieck, Canvas canvas)
        {
            /* 1. Dreieck im Koordinatenbereich
             * 2. Dreieck noch nicht vorhanden
             * 3. Dreieck muss 2 Punkte mit einem Dreieck gemeinsam haben
             * 4. Dreieck darf andere Dreiecke nicht überlappen (Mehrzahl!!!)*/
             
            //1)
            if (_dreieck.GetMax().X >= canvas.Width | _dreieck.GetMax().Y >= canvas.Height | _dreieck.GetMin().X <= 0 | _dreieck.GetMin().Y <= 0)
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
    }
}
