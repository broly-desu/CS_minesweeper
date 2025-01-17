using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Net.NetworkInformation;

namespace CS_minesweeper
{
    class Minelabel : Label
    {
        public Minelabel(int x, int y,
            int width, int height,
            int id)
        {
            Size = new Size(width, height);
            Location = new Point(x, y);
            Name = $"{id}";
            TextAlign = ContentAlignment.MiddleCenter;
            Tag = false;   
        }
        public static void Randombombsetup(int bomb)
        {
            int[] x = new int[bomb];
            x = Form1.Randomgenerate(bomb,100);
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
