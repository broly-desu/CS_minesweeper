using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CS_minesweeper
{
    internal class Resetbutton : Button
    {
        Form1 _form1;
        public Resetbutton(Form1 form1)
        {
            _form1 = form1;
            Name = "リセット";
            Location = new Point(400, 525);
            Size = new Size(100, 30);
            Text = "盤面のリセット";
            Click += OnClick;
        }
        private void OnClick(object sender, EventArgs e)
        {
            ControlSetup.FieldReset(_form1);
            ControlSetup.FieldSetup(_form1);
            Form1.firstdetect = true;
        }
    }
}
