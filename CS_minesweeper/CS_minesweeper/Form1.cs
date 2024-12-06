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
        public static Button[,] PanelButtons = new Button[10,10];
        public static Label[,] PanelLabels = new Label[10,10];
        public Form1()
        {
            
            InitializeComponent();
            ///フォームにボタンとラベルを配置する。
            ///ボタンはマインスイーパーのパネルとして使い、ラベルは爆弾などが描かれた背景として使用する
            for (int i = 0; i < 100; i++)
            {
                sweepbutton button = new sweepbutton(this, i % 10 * 50, i / 10 * 50, 50, 50, i);
                Controls.Add(button);
                PanelButtons[i % 10, i / 10] = button;
                minelabel labels = new minelabel(this, i % 10 * 50, i / 10 * 50, 50, 50, i);
                Controls.Add(labels);
                PanelLabels[i % 10, i / 10] = labels;
            }
        }
        /// <summary>
        /// 最初にクリックされたときに爆弾を設置するコード
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
