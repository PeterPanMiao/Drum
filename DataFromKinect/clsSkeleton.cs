using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Lei1
{
    public class clsSkeleton
    {
        public Dictionary<JointType, clsJointPoint> SkeletonPoints = new Dictionary<JointType, clsJointPoint>();
        public List<clsLine> SkeletonLines = new List<clsLine>();
        public Dictionary<JointType, DepthSpacePoint> Point2D = new Dictionary<JointType, DepthSpacePoint>();
        public clsSkeleton(Body bbb, clsKinect ck)
        {
            foreach (var item in bbb.Joints)
            {
                SkeletonPoints.Add(item.Key, new clsJointPoint(item.Value));
                CameraSpacePoint position = bbb.Joints[item.Key].Position;
                if (position.Z < 0)
                    position.Z = 0.1f;
                Point2D.Add(item.Key, ck.coordinateMapper.MapCameraPointToDepthSpace(position));
            }
            SkeletonLines.Add(new clsLine(JointType.Head, JointType.Neck));
            SkeletonLines.Add(new clsLine(JointType.Neck, JointType.SpineShoulder));
            SkeletonLines.Add(new clsLine(JointType.SpineShoulder, JointType.SpineMid));
            SkeletonLines.Add(new clsLine(JointType.SpineMid, JointType.SpineBase));
            SkeletonLines.Add(new clsLine(JointType.SpineShoulder, JointType.ShoulderRight));
            SkeletonLines.Add(new clsLine(JointType.SpineShoulder, JointType.ShoulderLeft));
            SkeletonLines.Add(new clsLine(JointType.SpineBase, JointType.HipRight));
            SkeletonLines.Add(new clsLine(JointType.SpineBase, JointType.HipLeft));
            SkeletonLines.Add(new clsLine(JointType.ShoulderRight, JointType.ElbowRight));
            SkeletonLines.Add(new clsLine(JointType.ElbowRight, JointType.WristRight));
            SkeletonLines.Add(new clsLine(JointType.WristRight, JointType.HandRight));
            SkeletonLines.Add(new clsLine(JointType.HandRight, JointType.HandTipRight));
            SkeletonLines.Add(new clsLine(JointType.WristRight, JointType.ThumbRight));
            SkeletonLines.Add(new clsLine(JointType.ShoulderLeft, JointType.ElbowLeft));
            SkeletonLines.Add(new clsLine(JointType.ElbowLeft, JointType.WristLeft));
            SkeletonLines.Add(new clsLine(JointType.WristLeft, JointType.HandLeft));
            SkeletonLines.Add(new clsLine(JointType.HandLeft, JointType.HandTipLeft));
            SkeletonLines.Add(new clsLine(JointType.WristLeft, JointType.ThumbLeft));
            SkeletonLines.Add(new clsLine(JointType.HipRight, JointType.KneeRight));
            SkeletonLines.Add(new clsLine(JointType.KneeRight, JointType.AnkleRight));
            SkeletonLines.Add(new clsLine(JointType.AnkleRight, JointType.FootRight));
            SkeletonLines.Add(new clsLine(JointType.HipLeft, JointType.KneeLeft));
            SkeletonLines.Add(new clsLine(JointType.KneeLeft, JointType.AnkleLeft));
            SkeletonLines.Add(new clsLine(JointType.AnkleLeft, JointType.FootLeft));


        }


        public void Draw(Body b, clsKinect ck, DrawingContext drawingContext)
        {
            /*  foreach (JointType jointType in b.Joints.Keys)
              {
                  DepthSpacePoint p = Point2D[jointType];
                 // Brush drawBrush = new SolidColorBrush(Color.FromArgb(128, 0, 0, 255));
                  drawingContext.DrawEllipse(Brushes.DeepPink, null, new System.Windows.Point(p.X, p.Y), 10, 10);
              }
              */
            DepthSpacePoint p = Point2D[JointType.HandRight];
            drawingContext.DrawEllipse(Brushes.Blue, null, new System.Windows.Point(p.X, p.Y), 10, 10);
            p = Point2D[JointType.HandLeft];
            drawingContext.DrawEllipse(Brushes.Blue, null, new System.Windows.Point(p.X, p.Y), 10, 10);


            Pen drawPen = new Pen(Brushes.Black, 5);
            foreach (clsLine line in SkeletonLines)
            {
                double x = Point2D[line.sp].X;
                double y = Point2D[line.sp].Y;
                Point a = new Point(x,y);
                x = Point2D[line.ep].X;
                y = Point2D[line.ep].Y;
                Point bb = new Point(x, y);
                drawingContext.DrawLine(drawPen,a,bb);
            }
        }

        public void DispalyAngle(/*Angle a*/)  //放在ListBox中
        {

        }

        public void DisplayerPoint()
        { }
    }
}
