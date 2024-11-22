using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CS_minesweeper
{
    class minelabel : Label
    {
        public minelabel(Form1 form,int x, int y, int width, int height)
        {
            Size = new Size(width, height);
            Location = new Point(x, y);
        }
    }
}
