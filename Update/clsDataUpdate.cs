using Lei1.Drum;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lei1
{
    public  class clsDataUpdate
    {
        public static void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            bool dataReceived = false;
            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame != null)
                {
                    if (MainWindow.ck.bodies == null)
                        MainWindow.ck.bodies = new Body[bodyFrame.BodyCount];
                    bodyFrame.GetAndRefreshBodyData(MainWindow.ck.bodies);
                    dataReceived = true;
                }
            }
            if (dataReceived)
            {

                using (DrawingContext dc = MainWindow.drawingGroup.Open())
                {
                    int i = 0;
                    dc.DrawRectangle(Brushes.PaleGreen, null, new Rect(0.0, 0.0, MainWindow.ck.displayWidth, MainWindow.ck.displayHeight));

                    foreach (Body body in MainWindow.ck.bodies)
                    {
                        MainWindow.cs[i] = new clsSkeleton(body, MainWindow.ck);
                        if (body.IsTracked)
                        {
                            MainWindow.cs[i].Draw(body, MainWindow.ck, dc);
                            MainWindow.P[0].X = MainWindow.cs[i].Point2D[JointType.HandLeft].X;
                            MainWindow.P[0].Y = MainWindow.cs[i].Point2D[JointType.HandLeft].Y;

                            MainWindow.P[1].X = MainWindow.cs[i].Point2D[JointType.HandRight].X;
                            MainWindow.P[1].Y = MainWindow.cs[i].Point2D[JointType.HandRight].Y;

                            MainWindow.drumPanel.L2.Content = MainWindow.P[0].X;
                            MainWindow.drumPanel.L3.Content = MainWindow.P[0].Y;

                            MainWindow.drumPanel.L4.Content = MainWindow.P[1].X;
                            MainWindow.drumPanel.L5.Content = MainWindow.P[1].Y;

                            if (MainWindow.mode == 1 || MainWindow.mode == 2)
                            {
                                // MainWindow.drum_note = MainWindow.beat.Hit(MainWindow.P, MainWindow.drum);
                                // MainWindow.sound.Play(MainWindow.drumPanel, MainWindow.drum_note);
                                List<DrumNote> drum_note = MainWindow.beat.Hit(MainWindow.P, MainWindow.drum);
                                 MainWindow.sound.Play(MainWindow.drumPanel,drum_note);
                            }
                            if (MainWindow.mode==2)
                                MainWindow.melodyPanel.L.Content = MainWindow.score;
                        }
                        i++;
                    }
                    MainWindow.drawingGroup.ClipGeometry = new RectangleGeometry(new Rect(0.0, 0.0, MainWindow.ck.displayWidth, MainWindow.ck.displayHeight));
                }
            }
        }
    }
}
