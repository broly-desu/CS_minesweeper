using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_minesweeper
{
    public partial class Form1 : Form
    {
        public static Button[,] PanelButtons = new Button[10, 10];
        public static Label[,] PanelLabels = new Label[10, 10];
        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = new System.Drawing.Size(550, 550);
            this.MinimumSize = new System.Drawing.Size(550, 550);
            ///フォームにボタンとラベルを配置する。
            ///ボタンはマインスイーパーのパネルとして使い、ラベルは爆弾などが描かれた背景として使用する
            for (int i = 0; i < 100; i++)
            {
                Sweepbutton button = new Sweepbutton(i % 10 * 50, i / 10 * 50, 50, 50);
                Controls.Add(button);
                PanelButtons[i % 10, i / 10] = button;
                Minelabel labels = new Minelabel(i % 10 * 50, i / 10 * 50, 50, 50, i);
                Controls.Add(labels);
                PanelLabels[i % 10, i / 10] = labels;
            }
            Minelabel.Randombombsetup(this, EventArgs.Empty);
        }

        /// <summary>
        /// 最初にクリックされたときに爆弾を設置するコード
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 乱数を生成する、yahoo知恵袋からパクってきたもの
        /// </summary>
        public static int[] Randomgenerate(int n,int s)
        {
            int[] random = new int[n];
            for (int i = 0; i < n; i++)
            {
                random[i] = Ransu(s);
                for (int j = 0; random[j] == 0; j++)
                {
                    if (random[i] == random[j])
                    {
                        random[i] = Ransu(s);
                        j = 0;
                    }
                }
            }
        return random;
        }
        static Random rand;
        static int Ransu(int n)
        {
            if (rand == null)
            {
                rand = new Random();
            }
            return rand.Next(n);
        }
    }
}
