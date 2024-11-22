using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_minesweeper
{
    internal class sweepbutton : Button
    {
        public sweepbutton(Form1 form 
            ,int x,int y,
            int width,int height) 
        {
            Size = new Size(width,height);
            Location = new Point(x,y);
            Click += Onclick;
            
        }
        public void Onclick(object sender, EventArgs e)
        {
        }
    }
}
