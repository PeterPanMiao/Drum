using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace Lei1
{
    public class clsLine
    {
        public JointType sp, ep;
        public clsLine()
        {
        }
        public clsLine(JointType s, JointType e)
        {
            sp = s;
            ep = e;
        }
        public void Draw()
        {
        }
    }
}
