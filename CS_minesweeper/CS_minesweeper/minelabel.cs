using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace CS_minesweeper
{
    class Minelabel : Label
    {
        int pointx;
        int pointy;
        public Minelabel(int x, int y,
            int width, int height,
            int id)
        {
            pointx = x / 50;
            pointy = y / 50;
            Size = new Size(width, height);
            Location = new Point(x, y);
            Name = $"{id}";
            TextAlign = ContentAlignment.MiddleCenter;
            Tag = false;
            MouseDoubleClick += Flagopen;
        }
        private void Flagopen(object sender, EventArgs e)
        {
            if (Text != "bomb")
            {
                int count = 0;
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        int Aroundx = pointx + i;
                        int Aroundy = pointy + j;
                        if (Aroundx >= 0 && Aroundy >= 0 && Aroundx < 10 && Aroundy < 10)
                        {
                            if (Form1.PanelButtons[Aroundx, Aroundy] != null)
                            {
                                if (Form1.PanelButtons[pointx + i, pointy + j].Text == "🚩")
                                {
                                    count++;
                                }
                            }
                        }
                    }
                }
                if (count == int.Parse(Text))
                {
                    Sweepbutton sweepbutton = new Sweepbutton(pointx * 50, pointy * 50, 1, 1, "flag");
                    Controls.Add(sweepbutton);
                    MouseEventArgs Vbutton = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
                    sweepbutton.Onclick(sender, Vbutton);
                }
            }
        }
        public static void Randombombsetup(int bomb,int ex)
        {
            int[] x = new int[bomb];
            x = Form1.Randomgenerate(bomb,100,ex);
            for (int i = 0; i < x.Length; i++)
            {
                int x1 = x[i] % 10;
                int x2 = x[i] / 10;
                Form1.PanelLabels[x1,x2].Text = "bomb";
            }
            for (int i = 0;i < 100;i++)
            {
                int pointx = i % 10;
                int pointy = i / 10;
                if (Form1.PanelLabels[pointx, pointy].Text == "")
                {
                    int valbomb = 0;
                    for (int j = -1; j <= 1; j++)
                    {
                        for (int k = -1; k <= 1; k++)
                        {
                            int detectx = pointx + j;
                            int detecty = pointy + k;
                            if (detectx < 10 && detecty < 10 && detectx >= 0 && detecty >= 0)
                            {
                                if (Form1.PanelLabels[detectx, detecty].Text == "bomb")
                                {
                                    valbomb++;
                                }
                            }
                        }
                    }
                    Form1.PanelLabels[pointx, pointy].Text = $"{valbomb}";
                }
            }
        }
    }
}
