using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_minesweeper
{
    internal class ControlSetup : Control
    {
        /// <summary>
        /// ボタンとラベルを消去する、初期化用。
        /// 実装が難しかったため放置
        /// </summary>
        /// <param name="f"></param>
        public static void FieldReset(Form f)
        { 
            for (int i = 0; i < 100; i++)
            {
                Button button = Form1.PanelButtons[i % 10, i / 10];
                f.Controls.Remove(button);
                if (button != null)
                {
                    button.Dispose();
                }
                Label label = Form1.PanelLabels[i % 10, i / 10];
                f.Controls.Remove(label);
                label.Dispose();
            }
        }
        ///<summary>
        ///フォームにボタンとラベルを配置する。
        ///ボタンはマインスイーパーのパネルとして使い、ラベルは爆弾などが描かれた背景として使用する
        ///</summary>
        public static void FieldSetup(Form f)
        {
            for (int i = 0; i < 100; i++)
            {
                Sweepbutton button = new Sweepbutton(i % 10 * 50, i / 10 * 50, 50, 50, i.ToString());
                f.Controls.Add(button);
                Form1.PanelButtons[i % 10, i / 10] = button;
                Minelabel labels = new Minelabel(i % 10 * 50, i / 10 * 50, 50, 50, i);
                f.Controls.Add(labels);
                Form1.PanelLabels[i % 10, i / 10] = labels;
            }
        }
    }
}
