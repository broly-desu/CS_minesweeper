using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CS_minesweeper
{
    internal class PublicLabel:Label
    {
        public PublicLabel(string text,int w,int h,int x,int y)
        {
            Text = text;
            TextAlign = ContentAlignment.TopCenter;
            Size = new Size(w,h);
            Location = new Point(x,y);
            Font = new Font(Font.FontFamily, h-5);
        }
    }
}
