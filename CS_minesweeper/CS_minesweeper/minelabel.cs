using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CS_minesweeper
{
    class minelabel : Label
    {
        public minelabel(Form1 form, int x, int y,
            int width, int height,
            int id)
        {
            Size = new Size(width, height);
            Location = new Point(x, y);
        }
        public static void randombombsetup(object sender, EventArgs e)
        {
            int[] pointx = new int[10];
            int[] pointy = new int[10];
            pointx = Form1.randomgenerate(10);
            pointy = Form1.randomgenerate(10);
            for (int i = 0; i < 10; i++)
            {
                Form1.PanelLabels[pointx[i],pointy[i]].Text = "bomb";
            }
            for (int i = 0;i < 100;i++)
            {
                if (Form1.PanelLabels[i % 10, i / 10].Text == "")
                {
                    int bombvalue = 0;
                    for (int j = 0; j < 9; j++)
                    {
                        if (Form1.PanelLabels[j % 3,j / 3].Text == "bomb")
                        {
                            Form1.PanelLabels[i % 10,i / 10].Text = $"{bombvalue++}"; 
                        }
                    }
                }

            }
        }
    }
}
