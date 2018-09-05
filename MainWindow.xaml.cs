using Lei1.Drum;
using Lei1.Play;
using Lei1.ShowMusic;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public static clsKinect ck = new clsKinect();
        public static clsSkeleton[] cs = new clsSkeleton[6];
        public static DrawingGroup drawingGroup;
        DrawingImage imageSource;
        public static clsSoundPlayer sound=new clsSoundPlayer();
        clsBackgroudPlay backgroudPlay = new clsBackgroudPlay();
        public static clsInstrument drum ;
        public static clsBeatDrum beat = new clsBeatDrum();
        public static Point[] P = new Point[2];
        public static int score=0;
        //public static List<DrumNote> drum_note;
        public static int mode=2;
        public static DrumPanel drumPanel;
        public static MelodyPanel melodyPanel;
        public MainWindow()
        {
           drawingGroup = new DrawingGroup();
           this.imageSource = new DrawingImage(drawingGroup);
           ck.kinectSensor.IsAvailableChanged += Sensor_IsAvailableChanged;
            if (ck.bodyFrameReader != null)
                ck.bodyFrameReader.FrameArrived += clsDataUpdate.Reader_FrameArrived;
            this.DataContext = this;
            InitializeComponent();
            drum = new clsInstrument();

            this.ResizeMode = System.Windows.ResizeMode.NoResize;//禁止窗口大小发生改变
            if (mode == 1)
                Show_Drum();
            else if (mode == 2)
            {
                Show_Melody();
                Show_Drum();
            }
        }
        public void Show_Drum()
        {
            drumPanel = new DrumPanel();
            grid.Children.Add(drumPanel);
            Grid.SetRow(drumPanel, 1);
            drumPanel.Show_Drum();
        }
        public void Show_Melody()
        {
            melodyPanel = new MelodyPanel(window);
            grid.Children.Add(melodyPanel);
            Grid.SetRow(melodyPanel, 0);
            //clsMelody melody = new clsMelody(melodyPanel.canvas,window);
            melodyPanel.ShowMelody();
          // backgroudPlay.BackgroundPlay();
        }
        public event PropertyChangedEventHandler PropertyChanged;
       public ImageSource ImageSource
         {
             get
             {
                 return this.imageSource;
             }
         }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (ck.bodyFrameReader != null)
            {
                ck.bodyFrameReader.FrameArrived += clsDataUpdate.Reader_FrameArrived;
            }
        }

         public void Sensor_IsAvailableChanged(object sender, IsAvailableChangedEventArgs e)
         {                                  
         }

    }
}
