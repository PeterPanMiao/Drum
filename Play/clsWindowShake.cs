using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lei1.Play
{
    class clsWindowShake
    {
        public void shake(Window window)
        {
            for (int i = 1; i <= 3; i++) //循环次数
            {
                for (int j = 1; j <= 10; j++)
                {

                    window.Top += 1;
                    window.Left += 1;
                    System.Threading.Thread.Sleep(3); //当前线程指定挂起的时间
                }
                for (int k = 1; k <= 10; k++)
                {
                    window.Top -= 1;
                    window.Left -= 1;
                    System.Threading.Thread.Sleep(3);
                }
            }

        }
    }
}
