using Lei1.ShowMusic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lei1
{
    /// <summary>
    /// MelodyPanel.xaml 的交互逻辑
    /// </summary>
    public partial class MelodyPanel : UserControl
    {
        public clsNote note;
        public List<clsNote> Melody;//一首完整乐谱
        System.Threading.Timer timer2;
        public static int count = 0;
        public static int i = 0;

        public MelodyPanel(Window window)
        {
            InitializeComponent();
            Melody = new List<clsNote>();
            StreamReader sr = new StreamReader("Melody.txt", Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] str = line.Split(' ');
                BrushConverter brushConverter = new BrushConverter();
                Brush brush = (Brush)brushConverter.ConvertFromString(str[0]);
                note = new clsNote(brush, int.Parse(str[1]), "rectangle" + Melody.Count(), canvas, window);
                Melody.Add(note);
            }
        }
        public void ShowMelody()
        {
            //timer.Start();
            timer2 = new System.Threading.Timer(new System.Threading.TimerCallback(timer_Elapsed2), this, 0, 1000);

        }

        private void timer_Elapsed2(object state)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (i < Melody.Count())
                {
                    count++;
                    while (count == Melody[i].pre_time)
                    {
                        Melody[i++].ShowNote();
                        if (i >= Melody.Count())
                            break;
                    }
                }
                else
                    timer2.Dispose();
            }), null);

        }
    }
}
