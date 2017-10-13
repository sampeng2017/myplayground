using SamPeng.IChing;
using SamPeng.IChing.BaGua;
using SamPeng.IChing.ChineseCalendar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IChingWinForm
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DevineNow();
        }

        private void DevineNow()
        {
            var tmpDate = new ChineseCalendarDate(DateTime.Now);
            this.labelDate.Text = tmpDate.ToString();
            var r = Divination.DivineNow();
            string s = BuildContent(r);
            this.labelName.Text = $"{r.Name} {r.ChangingIndexName}爻動";

            this.textBoxContent.Text = s;
            this.textBoxContent.Select(0, 0);

            using (var imageSteam = r.GetImageBinary())
            {
                this.pictureBoxGua.Image = Image.FromStream(imageSteam);
            }
        }

        private string BuildContent(Hexagram hg )
        {
            var sb = new StringBuilder();

            sb.AppendLine("《卦辭》");
            sb.AppendLine();
            sb.AppendLine(hg.GetMainDesc());
            sb.AppendLine(hg.GetChangeDesc());

            sb.AppendLine();
            sb.AppendLine("《梅花易術》");
            sb.AppendLine();
            sb.AppendLine(hg.GetMeiHuaYiShu());

            sb.AppendLine();
            sb.AppendLine("《偈語》");
            sb.AppendLine();
            sb.AppendLine(hg.GetPoemsDesc());

            sb.AppendLine();
            sb.AppendLine("《卦象》");
            sb.AppendLine();
            sb.AppendLine(hg.GetSymbolDesc());

            sb.AppendLine();
            sb.AppendLine("《主占斷》");
            sb.AppendLine();
            sb.AppendLine(hg.GetJudgementDesc());

            sb.AppendLine();
            sb.AppendLine("《分類占斷》");
            sb.AppendLine();
            sb.AppendLine(hg.GetJudgementClassifiedDesc());

            return sb.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"這是一個易經占蔔工具。

[即時起卦]：用當前時間起卦。由於一天共分十二個時辰，因此在同一天同一時辰所起的卦是相同的。

[隨機起卦]：用隨機數生成卦。

[卦辭]，[卦象]以及其它選項從不同角度解釋所得卦之含義。其中[梅花易數]為動態生成用於預測吉兇和時間。除[梅花易數]外各項解釋均引自易經原文和互聯網絡。

作者：彭晟 Sam Peng
聯系：sam.s.peng@gmail.com");
        }

        private void pictureBoxGua_Click(object sender, EventArgs e)
        {
            DevineNow();
        }
    }
}
