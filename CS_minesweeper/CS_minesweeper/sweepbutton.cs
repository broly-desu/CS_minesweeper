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
            , int x, int y,
            int width, int height,
            int id)
        {
            pointx = x / 50;
            pointy = y / 50;
            Name = id.ToString();
            Size = new Size(width, height);
            Location = new Point(x, y);
            Click += Onclick;

        }
        public void Onclick(object sender, EventArgs e)
        {
            buttonchain(this,pointx,pointy);
        }
        public void buttonchain(Button panel,int x,int y)
        {
            bool end = false;
            ///ボタンを押したときボタンを消滅させ後ろのラベルが見えるようにする
            Control control = this;
            Controls.Remove(control);
            control.Dispose();
            ///ボタンを押したとき隣接したマスに爆弾がなければ隣接するボタンを消す
            for (int i = -1; i <= 1; i++, end = false)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int ix = x + i;
                    int jy = y + j;
                    if (i == 0 && j == 0 || ix >= 10 && ix <= 0 && jy >= 10 && jy <= 0)
                    {
                        end = true; break;
                    }
                    else if (ix < 10 && jy < 10 && ix > 0 && jy > 0)
                    {
                        if (Form1.PanelLabels[ix, jy].Text == "bomb")
                        {

                        }
                        else
                        {
                            buttonchain(Form1.PanelButtons[ix, jy], ix, jy);
                        }
                    }
                    else
                    {
                        break;
                    }                
                }
            }
        }
    }
}