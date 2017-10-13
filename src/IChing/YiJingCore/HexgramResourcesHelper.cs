using System;
using System.Globalization;
using System.Text;
using SamPeng.IChing.BaGua;

namespace SamPeng.IChing
{
    public static class HexgramResourcesHelper
    {
        const string changeDescKeyTmpl = @"H_{0}_Change{1}";
        const string deductionDescKeyTmpl = @"H_{0}_Deduction";
        const string healthDescKeyTmpl = @"H_{0}_Health";
        const string judgementDescKeyTmpl = @"H_{0}_Judgement";
        const string lawsuitDescKeyTmpl = @"H_{0}_Lawsuit";
        const string lostDescKeyTmpl = @"H_{0}_Lost";
        const string loveDescKeyTmpl = @"H_{0}_Love";
        const string luckDescKeyTmpl = @"H_{0}_Luck";
        const string mainDescKeyTmpl = @"H_{0}_Main";
        const string meaningDescKeyTmpl = @"H_{0}_Meaning";
        const string omenDescKeyTmpl = @"H_{0}_Omen";
        const string poem1DescKeyTmpl = @"H_{0}_Poem1";
        const string poem2DescKeyTmpl = @"H_{0}_Poem2";

        const string imageFolder = "Images";
        public static string GetChangeDesc(this Hexagram hexaGram)
        {
            string key = string.Format(CultureInfo.InvariantCulture,
                changeDescKeyTmpl, hexaGram.StoreSequence, hexaGram.ChangingIndex); ;
            return YiJingCore.Resources.IChing.ResourceManager.GetString(key);
        }

        public static Uri GetImageUri(this Hexagram hexaGram)
        {
            return new Uri(string.Format(CultureInfo.InvariantCulture,
                "{0}/h{1}.png", imageFolder, hexaGram.StoreSequence),
                UriKind.RelativeOrAbsolute);
        }

        public static string GetJudgementClassifiedDesc(this Hexagram hexaGram)
        {
            string key = string.Format(CultureInfo.InvariantCulture,
                luckDescKeyTmpl, hexaGram.StoreSequence);
            string part1 = YiJingCore.Resources.IChing.ResourceManager.GetString(key);

            key = string.Format(CultureInfo.InvariantCulture,
                healthDescKeyTmpl, hexaGram.StoreSequence);
            string part2 = YiJingCore.Resources.IChing.ResourceManager.GetString(key);

            key = string.Format(CultureInfo.InvariantCulture,
    loveDescKeyTmpl, hexaGram.StoreSequence);
            string part3 = YiJingCore.Resources.IChing.ResourceManager.GetString(key);

            key = string.Format(CultureInfo.InvariantCulture,
    lawsuitDescKeyTmpl, hexaGram.StoreSequence);
            string part4 = YiJingCore.Resources.IChing.ResourceManager.GetString(key);

            key = string.Format(CultureInfo.InvariantCulture,
                lostDescKeyTmpl, hexaGram.StoreSequence);
            string part5 = YiJingCore.Resources.IChing.ResourceManager.GetString(key);

            return string.Format(CultureInfo.InvariantCulture,
                "{0}{1}{1}{2}{1}{1}{3}{1}{1}{4}{1}{1}{5}", part1, System.Environment.NewLine, part2, part3, part4, part5);
        }

        public static string GetJudgementDesc(this Hexagram hexaGram)
        {
            string key = string.Format(CultureInfo.InvariantCulture,
                deductionDescKeyTmpl, hexaGram.StoreSequence);
            string part1 = YiJingCore.Resources.IChing.ResourceManager.GetString(key);

            key = string.Format(CultureInfo.InvariantCulture,
                judgementDescKeyTmpl, hexaGram.StoreSequence);
            string part2 = YiJingCore.Resources.IChing.ResourceManager.GetString(key);

            return string.Format(CultureInfo.InvariantCulture,
                "{0}{1}{1}{2}", part1, System.Environment.NewLine, part2);
        }

        public static string GetMainDesc(this Hexagram hexaGram)
        {
            string key = string.Format(CultureInfo.InvariantCulture,
                mainDescKeyTmpl, hexaGram.StoreSequence); ;
            return YiJingCore.Resources.IChing.ResourceManager.GetString(key);
        }

        public static string GetMeiHuaYiShu(this Hexagram hexaGram)
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendFormat(CultureInfo.InvariantCulture,
                "{0} {1} {2}", hexaGram.Name, YiJingCore.Resources.Main.ChineseChange, hexaGram.ChangesTo.Name);
            strBuilder.AppendLine();

            var intExtRelation1 = hexaGram.GetInternalExternalRelation();
            var intExtRelation2 = hexaGram.ChangesTo.GetInternalExternalRelation();

            string rel1Str = YiJingCore.Resources.Main.ResourceManager.GetString(intExtRelation1.ToString());
            string rel2Str = YiJingCore.Resources.Main.ResourceManager.GetString(intExtRelation2.ToString());

            strBuilder.AppendFormat(CultureInfo.InvariantCulture,
                "{0} {1} {2}", rel1Str, YiJingCore.Resources.Main.ChineseChange, rel2Str);
            strBuilder.AppendLine();

            strBuilder.AppendFormat(CultureInfo.InvariantCulture,
                "{0}: {1}", YiJingCore.Resources.Main.HexgramSymbolNumber, hexaGram.SymbolicNumber);
            strBuilder.AppendLine();

            return strBuilder.ToString();
        }

        public static string GetPoemsDesc(this Hexagram hexaGram)
        {
            string key = string.Format(CultureInfo.InvariantCulture,
                poem1DescKeyTmpl, hexaGram.StoreSequence);
            string p1 = YiJingCore.Resources.IChing.ResourceManager.GetString(key);

            key = string.Format(CultureInfo.InvariantCulture,
                poem2DescKeyTmpl, hexaGram.StoreSequence);
            string p2 = YiJingCore.Resources.IChing.ResourceManager.GetString(key);

            return string.Format(CultureInfo.InvariantCulture,
    "{0}{1}{1}{2}", p1, System.Environment.NewLine, p2);

        }

        public static string GetSymbolDesc(this Hexagram hexaGram)
        {
            string key = string.Format(CultureInfo.InvariantCulture,
                meaningDescKeyTmpl, hexaGram.StoreSequence);
            string part1 = YiJingCore.Resources.IChing.ResourceManager.GetString(key);

            key = string.Format(CultureInfo.InvariantCulture,
                omenDescKeyTmpl, hexaGram.StoreSequence);
            string part2 = YiJingCore.Resources.IChing.ResourceManager.GetString(key);

            return string.Format(CultureInfo.InvariantCulture,
                "{0}{1}{1}{2}", part1, System.Environment.NewLine, part2);
        }
    }
}
