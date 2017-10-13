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
            var tmpDate = new ChineseCalendarDate(DateTime.Now);
            this.labelDate.Text = tmpDate.ToString();
            var r = Divination.DivineNow();
            string s = BuildContent(r);
            this.labelName.Text = $"{r.Name} {r.ChangingIndexName}爻動";
            
            this.textBoxContent.Text = s;
            this.textBoxContent.Select(0, 0);
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
            sb.AppendLine("《主占斷》");
            sb.AppendLine();
            sb.AppendLine(hg.GetJudgementDesc());

            sb.AppendLine();
            sb.AppendLine("《分類占斷》");
            sb.AppendLine();
            sb.AppendLine(hg.GetJudgementClassifiedDesc());

            sb.AppendLine();
            sb.AppendLine("《偈語》");
            sb.AppendLine();
            sb.AppendLine(hg.GetPoemsDesc());

            sb.AppendLine();
            sb.AppendLine("《偈語》");
            sb.AppendLine();
            sb.AppendLine(hg.GetSymbolDesc());

            return sb.ToString();
        }
    }
}
