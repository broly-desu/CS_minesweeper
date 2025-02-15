﻿using CS_minesweeper.Properties;
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
        private int mineval = 0;
        private int pointx, pointy;
        public Sweepbutton(int x, int y,
            int width, int height,string name)
        {
            Name = name;
            pointx = x / 50;
            pointy = y / 50;
            Size = new Size(width, height);
            Location = new Point(x, y);
            MouseDown += Onclick;
            Tag = "test";

        }
        public void Openbutton(int x, int y)
        {
            if (Form1.PanelButtons[x, y] != null)
            {
                ///マスを開く(ボタンを消すことで開いたように見せる)
                Control control = Form1.PanelButtons[x, y];
                Controls.Remove(control);
                control.Dispose();
            }
            Form1.PanelButtons[x, y] = null;
        }
        public void Onclick(object sender, MouseEventArgs e)
        { 
            int mineval = 10;
            try
            {
                if (Form1.textBox.Text == "" || int.Parse(Form1.textBox.Text) <= 100)
                {
                    if (Form1.textBox.Text != "")
                    {
                        mineval = int.Parse(Form1.textBox.Text);
                    }
                }
                else
                {
                    throw new ApplicationException("");
                }
            }
            catch
            {
                MessageBox.Show("1から99までの数字で入力してください");
                return;
            }
                switch (e.Button)
            {
                ///マスを右クリック（マスに旗を立てる）時                
                case MouseButtons.Right:
                    {
                        ///旗を立てる
                        if (Form1.PanelButtons[pointx, pointy].Text == "")
                        {
                            Form1.PanelButtons[pointx, pointy].Text = "🚩";
                        }
                        else
                        {
                            Form1.PanelButtons[pointx, pointy].Text = "";
                        }
                        break;
                    }
                ///マスを左クリック（マスを開ける）時
                case MouseButtons.Left:
                    {
                        if (Text == "")
                        {
                            ///最初に押されたときに爆弾を設置する
                            if (Form1.firstdetect)
                            {
                                Form1.firstdetect = false;
                                Minelabel.Randombombsetup(mineval, int.Parse(Name));
                            }
                            ///開こうとしてるマスが爆弾かどうか判断する
                            if (Form1.PanelLabels[pointx, pointy].Text == "bomb")
                            {
                                Gameover();
                            }
                            else
                            {
                                Buttonchain(pointx, pointy);
                            }
                        }
                        break;                        
                    }
            }
            ///クリアチェック
            int L = 0;
            for (int i = 0; i < 100; i++)
            {
                if (Form1.PanelButtons[i % 10, i / 10] != null)
                {
                    if (Form1.PanelButtons[i % 10, i / 10].Text == "" || Form1.PanelButtons[i % 10, i / 10].Text == "🚩")
                    {
                        L++;
                    }
                }
            }
            if (mineval == L)
            {
                MessageBox.Show("ゲームクリア");
            }
        }
        private void Gameover()
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
        public void Buttonchain(int x, int y)
        {
            Openbutton(x, y);
            ///ボタンを押したとき数字が0(周囲に爆弾が一切ない)なら周囲のマスを開ける
            if (Form1.PanelLabels[x, y].Text == "0" || Name == "flag")
            {
                Arounddispose(x, y);
            }
        }     
        public void Arounddisposeflag(int x,int y)
        {
            MouseEventArgs Vbutton = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int nextx = x + i;
                    int nexty = y + j;
                    if (nextx < 10 && nexty < 10 && nextx >= 0 && nexty >= 0)
                    {
                        if (Form1.PanelButtons[nextx, nexty] != null)
                        {
                            Onclick(Form1.PanelButtons[nextx, nexty],Vbutton);
                        }
                    }
                }
            }
        }
        public void Arounddispose(int x, int y)
        {
            Openbutton(x, y);
            ///周囲の8マスを開く
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int nextx = x + i;
                    int nexty = y + j;
                    if (nextx < 10 && nexty < 10 && nextx >= 0 && nexty >= 0 && Form1.PanelLabels[nextx, nexty].Text != "bomb")
                    {
                        Openbutton(nextx, nexty);
                        if (Convert.ToBoolean(Form1.PanelLabels[nextx, nexty].Tag) == false)
                        {
                            if (Form1.PanelLabels[nextx, nexty].Text == "0")
                            {
                                ///無限ループ防止のために消したボタンを参照しないようにする
                                Form1.PanelLabels[nextx, nexty].Tag = true;
                                Arounddispose(nextx, nexty);
                            }
                        }
                    }
                }
            }
        }
    }
}