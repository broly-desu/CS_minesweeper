using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_minesweeper
{
    internal class Sweepbutton : Button
    {
        private int pointx, pointy;
        public Sweepbutton( int x, int y,
            int width, int height)
        {
            pointx = x / 50;
            pointy = y / 50;
            Size = new Size(width, height);
            Location = new Point(x, y);
            MouseClick += Onclick;
            
        }
        public void Openbutton(int x, int y) 
        {
            ///マスを開く(ボタンを消すことで開いたように見せる)
            Control control = Form1.PanelButtons[x, y];
            Controls.Remove(control);
            control.Dispose();
        }
        public void Onclick(object sender,MouseEventArgs e)
        {
            ///マスを右クリック（マスに旗を立てる）時
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        break;
                    }
                ///マスを左クリック（マスを開ける）時
                case MouseButtons.Left:
                    {
                        int mineval = 0;
                        ///最初に押されたときに爆弾を設置する(未実装)
                        if (Form1.firstdetect)
                        {
                            mineval = 10;
                            if (Form1.textBox.Text != "")
                            {
                                mineval = int.Parse(Form1.textBox.Text);
                            }
                            Form1.firstdetect = false;
                            Minelabel.Randombombsetup(mineval);
                        }
                        ///開こうとしてるマスが爆弾かどうか判断する
                        if (Form1.PanelLabels[pointx, pointy].Text == "bomb")
                        {
                            ///爆弾だったらすべての爆弾を開いてゲームオーバーとする
                            for (int i = 0; i < 100; i++)
                            {
                                if (Form1.PanelLabels[i % 10, i / 10].Text == "bomb")
                                {
                                    Openbutton(i % 10, i / 10);
                                }
                            }
                            MessageBox.Show("ゲームオーバー");
                        }
                        else
                        {
                            Buttonchain(pointx, pointy);
                        }
                        ///クリアチェック
                        int L = 0;
                        for(int k = 0; k < 100;k++)
                        {
                            if (Form1.PanelButtons[k % 10, k / 10] != null)
                            {
                                L = L + 1;
                            }
                        }
                        if (L == 100 - mineval)
                        {
                            MessageBox.Show("ゲームクリア");
                        }
                        break;
                    }
                }
            }
        
        public void Buttonchain(int x,int y)
        {
            Openbutton(x,y);
            ///ボタンを押したとき数字が0(周囲に爆弾が一切ない)なら周囲のマスを開ける
            if (Form1.PanelLabels[x, y].Text == "0")
            {
                Arounddispose(x, y);
            }
        }
        private void Arounddispose(int x,int y)
        {
            Openbutton(x, y);
            ///周囲の8マスを開く
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int nextx = x + i;
                    int nexty = y + j;
                    if (nextx < 10 && nexty < 10 && nextx >= 0 && nexty >= 0 && Form1.PanelLabels[nextx,nexty].Text != "bomb")
                    {
                        Openbutton(nextx, nexty);
                        if (Convert.ToBoolean(Form1.PanelLabels[nextx, nexty].Tag) == false)
                        {
                            if (Form1.PanelLabels[nextx, nexty].Text == "0")
                            {
                                Form1.PanelLabels[nextx, nexty].Tag = "true";
                                Arounddispose(nextx, nexty);
                            }
                        }
                    }
                }
            }
        }
    }
}