using Lei1.Play;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lei1.Drum
{
    public enum DrumNoteKind
    {
        Big_D, Little_D1, Little_D2, Little_D3, Little_D4, Cymbal_1, Cymbal_2
    };
    public enum DrumNoteLength
    {
        One
    };
    public struct DrumNote
    {
        public DrumNoteKind nk;
        public DrumNoteLength nl;
    };

    public class clsSoundPlayer
    {
        public MediaPlayer player1 = new MediaPlayer();
        public MediaPlayer player2 = new MediaPlayer();
        public clsSoundPlayer()
        { }
        public void Play(DrumPanel drum, List<DrumNote> note)//播放每个音符，并不能同时播放两个音频！！！！！！！！！！！！
        {
            for (int i = 0; i < note.Count(); i++)
            {
                if (note[i].nk == DrumNoteKind.Big_D)
                {
                    if (i == 0)
                        player1.Open(new Uri(@"大鼓.wav", UriKind.Relative));
                    else
                        player2.Open(new Uri(@"大鼓.wav", UriKind.Relative));
                    drum.ShakePic(drum.Big_D,"dagu",450,460);
                }
                else if (note[i].nk == DrumNoteKind.Little_D1)
                {
                    if (i == 0)
                        player1.Open(new Uri(@"小鼓1.wav", UriKind.Relative));
                    else
                        player2.Open(new Uri(@"小鼓1.wav", UriKind.Relative));
                    drum.ShakePic(drum.Little_D1,"xiaogu",321,331);
                }
                else if (note[i].nk == DrumNoteKind.Little_D2)
                {
                    if (i == 0)
                        player1.Open(new Uri(@"小鼓2.wav", UriKind.Relative));
                    else
                        player2.Open(new Uri(@"小鼓2.wav", UriKind.Relative));
                    drum.ShakePic(drum.Little_D2,"xiaoguer",374,384);
                }
                else if (note[i].nk == DrumNoteKind.Little_D3)
                {
                    if (i == 0)
                        player1.Open(new Uri(@"小鼓3.wav", UriKind.Relative));
                    else
                        player2.Open(new Uri(@"小鼓3.wav", UriKind.Relative));
                    drum.ShakePic(drum.Little_D3,"xiaogusan",640,650);
                }
                else if (note[i].nk == DrumNoteKind.Little_D4)
                {
                    if (i == 0)
                        player1.Open(new Uri(@"小鼓4.wav", UriKind.Relative));
                    else
                        player2.Open(new Uri(@"小鼓4.wav", UriKind.Relative));
                    drum.ShakePic(drum.Little_D4,"siaogusi",743,753);
                }
                else if (note[i].nk == DrumNoteKind.Cymbal_1)
                {
                    if (i == 0)
                        player1.Open(new Uri(@"锣1.wav", UriKind.Relative));
                    else
                        player2.Open(new Uri(@"锣1.wav", UriKind.Relative));
                    drum.ShakePic(drum.Cymbal_1,"luoyi",144,154);
                }
                else if (note[i].nk == DrumNoteKind.Cymbal_2)
                {
                    if (i == 0)
                        player1.Open(new Uri(@"锣2.wav", UriKind.Relative));
                    else
                        player2.Open(new Uri(@"锣2.wav", UriKind.Relative));
                    drum.ShakePic(drum.Cymbal_2,"luoer",898,908);
                }
            }
            player1.Play();
            player2.Play();
        }
    }

}
