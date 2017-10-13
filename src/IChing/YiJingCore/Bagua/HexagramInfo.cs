
using System.Collections.Generic;
using YiJingCore.Resources;

namespace SamPeng.IChing.BaGua
{
    public static class HexagramInfo
    {
        //{"乾为天", "天泽履", "天火同人", "天雷无妄", "天风姤","天水讼", "天山遁", "天地否"},
        //{"泽天夬", "兑为泽", "泽火革", "泽雷随", "泽风大过","泽水困", "泽山咸", "泽地萃"},
        //{"火天大有", "火泽睽", "离为火", "火雷噬嗑", "火风鼎","火水未济", "火山旅", "火地晋"},
        //{"雷天大壮", "雷泽归妹", "雷火丰", "震为雷", "雷风恒","雷水解", "雷山小过", "雷地豫"},
        //{"风天小畜", "风泽中孚", "风火家人", "风雷益", "巽为风","风水涣", "风山渐", "风地观"},
        //{"水天需", "水泽节", "水火既济", "水雷屯", "水风井","坎为水", "水山蹇", "水地比"},
        //{"山天大畜", "山泽损", "山火贲", "山雷颐", "山风蛊","山水蒙", "艮为山", "山地剥"},
        //{"地天泰", "地泽临", "地火明夷", "地雷复", "地风升","地水师", "地山谦", "坤为地"},
        public static readonly string[,] Hexagrams = new string[,] { 
            {
                Main.HexagramQian, 
                Main.HexagramLv, 
                Main.HexagramTongRen, 
                Main.HexagramWuWang, 
                Main.HexagramGou,
                Main.HexagramSong, 
                Main.HexagramDun, 
                Main.HexagramPi
            },

            {
                Main.HexagramGuai,
                Main.HexagramDui,
                Main.HexagramGe,
                Main.HexagramSui,
                Main.HexagramDaGuo,
                Main.HexagramKun,
                Main.HexagramXian,
                Main.HexagramCui
            },

            {
                Main.HexagramDaYou, 
                Main.HexagramKui, 
                Main.HexagramLi, 
                Main.HexagramShiKe, 
                Main.HexagramDing,
                Main.HexagramWeiJi, 
                Main.HexagramLv_Travel, 
                Main.HexagramJin
            },
            
            {
                Main.HexagramDaZhuang, 
                Main.HexagramGuiMei, 
                Main.HexagramFeng, 
                Main.HexagramZhen, 
                Main.HexagramHeng,
                Main.HexagramJie, 
                Main.HexagramXiaoGuo, 
                Main.HexagramYu
            },

            {
                Main.HexagramXiaoXu, 
                Main.HexagramZhongFu, 
                Main.HexagramJiaRen, 
                Main.HexagramYi, 
                Main.HexagramXun,
                Main.HexagramHuan, 
                Main.HexagramJian, 
                Main.HexagramGuan
            },
            
            {
                Main.HexagramXu, 
                Main.HexagramJie_ShuiZe, 
                Main.HexagramJiJi, 
                Main.HexagramTun, 
                Main.HexagramJing,
                Main.HexagramKan, 
                Main.HexagramJian_ShuiShan, 
                Main.HexagramBi
            },

            {
                Main.HexagramDaXu, 
                Main.HexagramSun, 
                Main.HexagramBi_ShanHuo, 
                Main.HexagramYi_ShanLei, 
                Main.HexagramGu,
                Main.HexagramMeng, 
                Main.HexagramGen, 
                Main.HexagramBo
            },
            
            {
                Main.HexagramTai, 
                Main.HexagramLin, 
                Main.HexagramMingYi, 
                Main.HexagramFu, 
                Main.HexagramSheng,
                Main.HexagramShi, 
                Main.HexagramQian_DiShan, 
                Main.HexagramKun_WeiDi
            },
        };

        static readonly Dictionary<string, IList<string>> HexagramExplanations = new Dictionary<string, IList<string>>();
        //public static IList<string> GetHexagramExplanation(string hexagram)
        //{
        //    if (HexagramExplanations.ContainsKey(hexagram))
        //    {
        //        return HexagramExplanations[hexagram];
        //    }

        //    using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ShengPeng.GuaGenerator.Hexagrams.txt"))
        //    using (StreamReader sr = new StreamReader(stream))
        //    {
        //        string currentLine = string.Empty;
        //        string currentGraphName = string.Empty;
        //        string lineToStopRead = "===" + hexagram + "===";
        //        while (!lineToStopRead.Equals(currentLine))
        //        {
        //            currentLine = sr.ReadLine();
        //            if (currentLine.StartsWith("+++"))
        //            {
        //                currentGraphName = currentLine.Substring(3, currentLine.Length - 6);
        //                if (HexagramExplanations.ContainsKey(currentGraphName))
        //                {
        //                    continue;
        //                }

        //                var tmpList = new List<string>();
        //                while (!currentLine.StartsWith("==="))
        //                {
        //                    currentLine = sr.ReadLine();
        //                    tmpList.Add(currentLine);
        //                }
        //                HexagramExplanations.Add(currentGraphName, tmpList.ToArray());
        //            }
        //        }
        //    }

        //    return HexagramExplanations[hexagram];
        //}
    }
}
