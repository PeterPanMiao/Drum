using Lei1.Drum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lei1.Play
{
    public class clsBeatDrum
    {
        public clsBeatDrum()
        { }
        public int InRange(clsInstrument drum,Point p)
        {
            for (int i = 0; i < drum.Hots.Count(); i++)
            {
                double min_x = drum.Hots[i].point.X - drum.Hots[i].radius;
                double max_x = drum.Hots[i].point.X + drum.Hots[i].radius;
                double min_y = drum.Hots[i].point.Y - drum.Hots[i].radius;
                double max_y = drum.Hots[i].point.Y + drum.Hots[i].radius;
                if (p.X > min_x && p.X < max_x && p.Y > min_y && p.Y < max_y)
                {
                     return i + 1;
                }
            }
            return 0;
        }
        public List<DrumNote> Hit(Point[] p, clsInstrument drum)  // 返回鼓（Hots）的编号
        {
            //传过来手的坐标
            //判断范围在哪个热点里，
            //返回该热点发出的音符Note
            List<DrumNote> notes=new List<DrumNote>();
            DrumNote note = new DrumNote();
            for (int i = 0; i < 2; i++)
            {
                if (InRange(drum, p[i]) == 1)
                {
                    note.nk = DrumNoteKind.Big_D;
                    note.nl = DrumNoteLength.One;
                    notes.Add(note);
                }
                else if (InRange(drum, p[i]) == 2)
                {
                    note.nk = DrumNoteKind.Little_D1;
                    note.nl = DrumNoteLength.One;
                    notes.Add(note);
                }
                else if(InRange(drum, p[i]) == 3)
                {
                    note.nk = DrumNoteKind.Little_D2;
                    note.nl = DrumNoteLength.One;
                    notes.Add(note);
                }
                else if (InRange(drum, p[i]) == 4)
                {
                    note.nk = DrumNoteKind.Little_D3;
                    note.nl = DrumNoteLength.One;
                    notes.Add(note);
                }
                else if (InRange(drum, p[i]) == 5)
                {
                    note.nk = DrumNoteKind.Little_D4;
                    note.nl = DrumNoteLength.One;
                    notes.Add(note);
                }
                else if (InRange(drum, p[i]) == 6)
                {
                    note.nk = DrumNoteKind.Cymbal_1;
                    note.nl = DrumNoteLength.One;
                    notes.Add(note);
                }
                else if (InRange(drum, p[i]) == 7)
                {
                    note.nk = DrumNoteKind.Cymbal_2;
                    note.nl = DrumNoteLength.One;
                    notes.Add(note);
                }
            }
            return notes;
        }
    }
}
