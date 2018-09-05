using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Microsoft.Kinect;

namespace Lei1
{
    public class clsJointPoint
    {
        public double X, Y, Z;
        public clsJointPoint()
        {
            X = Y = Z = 0;
        }
        public clsJointPoint(Joint j)
        {
            X = j.Position.X;
            Y = j.Position.Y;
            Z = j.Position.Z;
        }
    
    }
}
