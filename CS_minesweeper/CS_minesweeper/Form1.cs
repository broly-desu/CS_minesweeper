using CS_minesweeper.Properties;
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
        public static TextBox textBox = new TextBox();
        public static bool firstdetect = true;
        public Form1()
        {
            InitializeComponent();
            ///ウィンドウサイズの固定
            this.MaximumSize = new Size(650, 600);
            this.MinimumSize = new Size(650, 600);
            ///爆弾の数を指定できるテキストボックスとラベルの設置
            PublicLabel publicLabel = new PublicLabel("爆弾の数を入力(初期値は10です) ※1から100までの数字で入力してください。", 500, 15, 0, 500);
            Controls.Add(publicLabel);
            PublicTextBox text = new PublicTextBox("bomboption", 400, 15, 0, 525);
            Controls.Add(text);
            textBox = text;
            ControlSetup.FieldSetup();
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
        public static int[] Randomgenerate(int n,int s,int ex)
        {
            int[] random = new int[n];
            for (int i = 0; i < n; i++)
            {
                random[i] = Ransu(s);
                for (int j = 0; random[j] == 0; j++)
                {
                    if (random[i] == random[j] || random[i] == ex)
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
