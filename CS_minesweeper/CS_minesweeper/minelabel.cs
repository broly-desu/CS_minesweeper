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
            Name = "";
        }
        public static void randombombsetup(object sender, EventArgs e)
        {
            int[] x = new int[10];
            int[] y = new int[10];
            x = Form1.randomgenerate(10);
            y = Form1.randomgenerate(10);
            for (int i = 0; i < 9; i++)
            {
                Form1.PanelLabels[x[i],y[i]].Text = $"bomb";
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
