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
        private bool bombsetup = true;
        private int pointx, pointy;
        public sweepbutton(Form1 form
            , int x, int y,
            int width, int height,
            int id)
        {
            pointx = x / 50;
            pointy = y / 50;
            Size = new Size(width, height);
            Location = new Point(x, y);
            Click += Onclick;
        }
        public void openbutton(int x,int y)
        {
            ///マスを開く(ボタンを消すことで開いたように見せる)
            Control control = Form1.PanelButtons[x, y];
            Controls.Remove(control);
            control.Dispose();
        }
        public void Onclick(object sender, EventArgs e)
        {
            ///最初に押されたときに爆弾を設置する(未実装)
            if (bombsetup)
            {
                bombsetup = false;
            }
            ///開こうとしてるマスが爆弾かどうか判断する
            if (Form1.PanelLabels[pointx,pointy].Text == "bomb")
            {
                ///爆弾だったらすべての爆弾を開いてゲームオーバーとする
                for (int i = 0; i < 100; i++)
                {
                    if (Form1.PanelLabels[i % 10,i / 10].Text == "bomb")
                    {
                        openbutton(i % 10,i / 10);
                    }
                }
                MessageBox.Show("ゲームオーバー");
            }
            else
            {
                buttonchain(this, pointx, pointy);
            }
        }
        public void buttonchain(Button panel,int x,int y)
        {
            ///ボタンを押したときボタンを消滅させる
            openbutton(x,y);
            ///ボタンを押したとき数字が0(周囲に爆弾が一切ない)なら周囲のマスを開ける
            if (Form1.PanelLabels[x, y].Text == "0")
            {
                arounddispose(x, y);
            }
        }
        private void arounddispose(int x,int y)
        {
            ///周囲の8マスを開く
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (x + i < 10 && y + j < 10 && x + i >= 0 && y + j >= 0)
                    {
                        if (Form1.PanelLabels[x + i,y + j].Text != "bomb")
                        {
                            openbutton(x + i,y + j);
                        }
                    }
                }
            }
        }
    }
}