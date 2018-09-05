using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lei1.ShowMusic
{
    class clsBackgroudPlay
    {
        public MediaPlayer player = new MediaPlayer();
        public void BackgroundPlay()
        {
            player.Open(new Uri("a.mp3", UriKind.Relative));
            player.Play();
        }

    }
}
