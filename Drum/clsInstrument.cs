using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace Lei1.Drum
{
    public struct Hot
    {
        public Point point;
        public double radius;
    };
    public class clsInstrument
    {

        //Bitmap pic;//把鼓显示在位图上
        public List<Hot> Hots=new List<Hot>();//鼓上存在的热点（击打有效范围）


        public clsInstrument()
        {
            //将热点坐标添加进去
            //每个热点都对应一个音符Note
            Hot hot =new Hot();

            hot.point = new Point(267, 230);//大鼓
            hot.radius = 15.0;
            Hots.Add(hot);

            hot.point = new Point(173, 216);//小鼓1
            hot.radius = 10.0;
            Hots.Add(hot);

            hot.point = new Point(223, 144);//小鼓2
            hot.radius = 10.0;
            Hots.Add(hot);

            hot.point = new Point(309, 146);//小鼓3
            hot.radius = 10.0;
            Hots.Add(hot);

            hot.point = new Point(362, 214);//小鼓4
            hot.radius = 10.0;
            Hots.Add(hot);

            hot.point = new Point(147, 132);//镲左1
            hot.radius = 8.0;
            Hots.Add(hot);


            hot.point = new Point(417, 130);//镲右1
            hot.radius = 15.0;
            Hots.Add(hot);

        }


    }
}
