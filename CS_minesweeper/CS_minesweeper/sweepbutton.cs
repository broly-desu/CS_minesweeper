﻿using System;
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
        private bool bombsetup = true;
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
            ///最初に押されたときに爆弾を設置する
            if (bombsetup)
            {
                
                bombsetup = false;
            }
            buttonchain(this,pointx,pointy);
        }
        public void buttonchain(Button panel,int x,int y)
        {
            ///ボタンを押したときボタンを消滅させ後ろのラベルが見えるようにする
            Control control = this;
            Controls.Remove(control);
            control.Dispose();
            ///ボタンを押したとき隣接したマスに爆弾がなければ隣接するボタンを消す
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int ix = x + i;
                    int jy = y + j;
                    if (i == 0 && j == 0 )
                    {
                        break;
                    }
                    else if (ix < 10 && jy < 10 && ix > 0 && jy > 0)
                    {
                        if (Form1.PanelLabels[ix, jy].Text == "")
                        {
                            buttonchain(Form1.PanelButtons[ix, jy], ix, jy);
                        }
                        else
                        {
                                       
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