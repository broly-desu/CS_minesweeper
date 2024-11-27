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
        Form1 _form1;
        private int pointx, pointy;
        public sweepbutton(Form1 form 
            ,int x,int y,
            int width,int height,
            int id) 
        {
            pointx = x;
            pointy = y;
            Name = id.ToString();
            Size = new Size(width,height);
            Location = new Point(x,y);
            Click += Onclick;
            
        }
        public void Onclick(object sender, EventArgs e)
        {
            buttonchain(this);
        }
        public void buttonchain(Button panel)
        { 
            ///ボタンを押したときボタンを消滅させ後ろのラベルが見えるようにする
            Control control = panel;
            Controls.Remove(control);
            control.Dispose();
            ///ボタンを押したとき隣接したマスに爆弾がなければ隣接するボタンを消す
            int buttonname = int.Parse(this.Name);
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Form1.PanelLabels[pointx + i, pointy + i].Text  "") 
                {
                    break;
                }
                else
                {
                    buttonchain(Form1.PanelButtons[pointx, pointy]);
                }
            }
        }
    }
}
