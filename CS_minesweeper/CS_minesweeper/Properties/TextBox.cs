using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CS_minesweeper.Properties
{
    internal class PublicTextBox : TextBox
    {
        public PublicTextBox(string name,int w,int h,int x,int y)
        {
            Name = name;
            Size = new Size(w,h);
            Location = new Point(x,y);
            Font = new Font(Font.FontFamily, h);
            ImeMode = ImeMode.Disable;
        }

    }
}
