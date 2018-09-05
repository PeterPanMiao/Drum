using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;
using System.Media;

namespace Lei1
{
    public class clsKinect// //INotifyPropertyChanged
    {
        public KinectSensor kinectSensor = null;
        public BodyFrameReader bodyFrameReader = null;
        public string statusText = null;
        public CoordinateMapper coordinateMapper = null;
        public Body[] bodies = null;
        public int displayWidth;
        public int displayHeight;
       
        public clsKinect()
        {
            this.kinectSensor = KinectSensor.GetDefault();
            this.coordinateMapper = this.kinectSensor.CoordinateMapper;
            FrameDescription frameDescription = this.kinectSensor.DepthFrameSource.FrameDescription;
            this.displayWidth = frameDescription.Width;
            this.displayHeight = frameDescription.Height;
            this.bodyFrameReader = this.kinectSensor.BodyFrameSource.OpenReader();
       //     this.kinectSensor.IsAvailableChanged += Sensor_IsAvailableChanged;
        //    this.bodyFrameReader.FrameArrived += Reader_FrameArrived;
            this.kinectSensor.Open();
      //      this.StatusText = this.kinectSensor.IsAvailable ? Properties.Resources.RunningStatusText
                                                  //         : Properties.Resources.NoSensorStatusText;
          //  this.DataContext = this;
         //   
        }

      /*  public void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame != null)
                {
                    if (this.bodies == null)
                        this.bodies = new Body[bodyFrame.BodyCount];
                    bodyFrame.GetAndRefreshBodyData(this.bodies);
                }
            }
        }

            public void Sensor_IsAvailableChanged(object sender, IsAvailableChangedEventArgs e)
        {
            this.StatusText = this.kinectSensor.IsAvailable ? Properties.Resources.RunningStatusText
                                                            : Properties.Resources.SensorNotAvailableStatusText;
        }*/
       /*
        public string StatusText
        {
            get
            {
                return this.statusText;
            }

            set
            {
                if (this.statusText != value)
                {
                    this.statusText = value;

                    // notify any bound elements that the text has changed
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new PropertyChangedEventArgs("StatusText"));
                    }
                }
            }
        }*/

       
    }
}
