using Lei1.Drum;
using Lei1.Play;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Lei1.ShowMusic
{
    public class clsNote
    {
        public Rectangle myRectangle;
        public Brush color;
        public double pre_time;
        //DispatcherTimer timer;
        public int line;
        public Storyboard myStoryboard;
        Canvas canvas;
        Window window;
        public clsNote(Brush color,double pre_time,string name,Canvas canvas, Window window)
        {
            this.window = window;
            this.canvas = canvas;
            myRectangle = new Rectangle();
            myRectangle.Name = name;
            canvas.RegisterName(myRectangle.Name, myRectangle);
            myRectangle.Width = 40;
            myRectangle.Height = 40;
            myRectangle.Fill = color;

            this.color = color;
            this.pre_time = pre_time;
            if (color == Brushes.Red)
            {
                line = 0;//第一行
            }
            else if (color == Brushes.Pink)
            {
                line = 10;//第二行
            }
            else if (color == Brushes.Green)
            {
                line = 20;
            }
            else if (color == Brushes.Orange)
            {
                line = 30;
            }
            else if (color == Brushes.Yellow)
            {
                line = 40;
            }
            else if (color == Brushes.Magenta)
            {
                line = 50;
            }


        //    timer = new DispatcherTimer();
         //   timer.Tick += new EventHandler(timer_Tick);
          //  timer.Interval = TimeSpan.FromSeconds(pre_time);
        }
/*
        private void timer_Tick(object sender, EventArgs e)
        {
            ShowNote();
            timer.Stop();
        }
        public void run()
        {
            timer.Start();
        }*/
        public void ShowNote()
        {
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 0.0;
            myDoubleAnimation.To = 1200;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(4));
            myDoubleAnimation.AutoReverse = false;

            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, myRectangle.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath("(Canvas.Right)"));

            myRectangle.Loaded += new RoutedEventHandler(myRectangleLoaded);
            myStoryboard.Completed += new EventHandler(Storyboard_Completed);

            canvas.Children.Add(myRectangle);
            Canvas.SetTop(myRectangle, line);
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            canvas.Children.Remove(myRectangle);
            clsBeatDrum beat = new clsBeatDrum();
            clsWindowShake windowShake = new clsWindowShake();
            bool flag = false;
            for(int i=0;i<2&&flag==false;i++)
            {
                if (beat.InRange(MainWindow.drum, MainWindow.P[i]) == 1 && myRectangle.Fill == Brushes.Red)
                    flag = true;
                else if (beat.InRange(MainWindow.drum, MainWindow.P[i]) == 2 && myRectangle.Fill == Brushes.Orange)
                    flag = true;
                else if (beat.InRange(MainWindow.drum, MainWindow.P[i]) == 3 && myRectangle.Fill == Brushes.Yellow)
                    flag = true;
                else if (beat.InRange(MainWindow.drum, MainWindow.P[i]) == 4 && myRectangle.Fill == Brushes.Green)
                    flag = true;
                else if (beat.InRange(MainWindow.drum, MainWindow.P[i]) == 5 && myRectangle.Fill == Brushes.Blue)
                    flag = true;
                else if (beat.InRange(MainWindow.drum, MainWindow.P[i]) == 6 && myRectangle.Fill == Brushes.Cyan)
                    flag = true;
                else if (beat.InRange(MainWindow.drum, MainWindow.P[i]) == 7 && myRectangle.Fill == Brushes.Pink)
                    flag = true;
                if(flag==true)
                {
                    MainWindow.score = MainWindow.score+ 10;
                    windowShake.shake(window);
                }
            }
        }
        private void myRectangleLoaded(object sender, RoutedEventArgs e)
        {
            myStoryboard.Begin(canvas);
        }
    }
}
