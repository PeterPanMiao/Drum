using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lei1
{
    /// <summary>
    /// DrumPanel.xaml 的交互逻辑
    /// </summary>
    public partial class DrumPanel : UserControl
    {
        public Image Cymbal_1 = new Image();//架子鼓的图片
        public Image Cymbal_2 = new Image();//架子鼓的图片
        public Image Little_D1 = new Image();//架子鼓的图片
        public Image Little_D2 = new Image();//架子鼓的图片
        public Image Little_D3 = new Image();//架子鼓的图片
        public Image Little_D4 = new Image();//架子鼓的图片
        public Image Big_D = new Image();//架子鼓的图片
        public Storyboard myStoryboard;

        public DrumPanel()
        {
            InitializeComponent();
            Load_Drum(Big_D, @"Image\大鼓.png", 443, 497, 450, 164);
            Load_Drum(Little_D1, @"Image\小鼓1.png", 294, 269, 321, 214);
            Load_Drum(Little_D2, @"Image\小鼓2.png", 357, 454, 374, -67);
            Load_Drum(Little_D3, @"Image\小鼓3.png", 380, 360, 640, -72);
            Load_Drum(Little_D4, @"Image\小鼓4.png", 265, 426, 743, 230);
            Load_Drum(Cymbal_1, @"Image\锣1.png", 326, 432, 144, -67);
            Load_Drum(Cymbal_2, @"Image\锣2.png", 520, 520, 898, -200);
        }
        public void Load_Drum(Image image, string source, double height, double width, double left, double top)//显示架子鼓
        {
            BitmapImage bitmap = new BitmapImage(new Uri(source, UriKind.Relative));
            image.Source = bitmap;
            image.Width = width;
            image.Height = height;
            Canvas.SetTop(image, top);
            Canvas.SetLeft(image, left);
        }
        public void Show_Drum()
        {
            canvas.Children.Add(Big_D);
            canvas.Children.Add(Cymbal_1);
            canvas.Children.Add(Cymbal_2);
            canvas.Children.Add(Little_D1);
            canvas.Children.Add(Little_D2);
            canvas.Children.Add(Little_D3);
            canvas.Children.Add(Little_D4);
        }
        public void ShakePic(Image image, string name, double start_Position, double end_Position)
        {
            canvas.RegisterName(name, image);
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = start_Position;
            myDoubleAnimation.To = end_Position;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
            myDoubleAnimation.AutoReverse = true;
            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath("(Canvas.Left)"));
            myStoryboard.Begin(canvas);
        }


    }
}
