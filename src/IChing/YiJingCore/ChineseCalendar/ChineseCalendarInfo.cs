﻿
using System;
using System.Diagnostics;
using YiJingCore.Resources;

namespace SamPeng.IChing.ChineseCalendar
{
    public static class ChineseCalendarInfo
    {
        //from 1900 to 2050
        static readonly long[] LunarInfoTable = new long[]   
        {0x04bd8, 0x04ae0, 0x0a570, 0x054d5, 0x0d260, 0x0d950, 0x16554, 0x056a0, 0x09ad0, 0x055d2,   
         0x04ae0, 0x0a5b6, 0x0a4d0, 0x0d250, 0x1d255, 0x0b540, 0x0d6a0, 0x0ada2, 0x095b0, 0x14977,   
         0x04970, 0x0a4b0, 0x0b4b5, 0x06a50, 0x06d40, 0x1ab54, 0x02b60, 0x09570, 0x052f2, 0x04970,   
         0x06566, 0x0d4a0, 0x0ea50, 0x06e95, 0x05ad0, 0x02b60, 0x186e3, 0x092e0, 0x1c8d7, 0x0c950,   
         0x0d4a0, 0x1d8a6, 0x0b550, 0x056a0, 0x1a5b4, 0x025d0, 0x092d0, 0x0d2b2, 0x0a950, 0x0b557,   
         0x06ca0, 0x0b550, 0x15355, 0x04da0, 0x0a5d0, 0x14573, 0x052d0, 0x0a9a8, 0x0e950, 0x06aa0,   
         0x0aea6, 0x0ab50, 0x04b60, 0x0aae4, 0x0a570, 0x05260, 0x0f263, 0x0d950, 0x05b57, 0x056a0,   
         0x096d0, 0x04dd5, 0x04ad0, 0x0a4d0, 0x0d4d4, 0x0d250, 0x0d558, 0x0b540, 0x0b5a0, 0x195a6,   
         0x095b0, 0x049b0, 0x0a974, 0x0a4b0, 0x0b27a, 0x06a50, 0x06d40, 0x0af46, 0x0ab60, 0x09570,   
         0x04af5, 0x04970, 0x064b0, 0x074a3, 0x0ea50, 0x06b58, 0x055c0, 0x0ab60, 0x096d5, 0x092e0,   
         0x0c960, 0x0d954, 0x0d4a0, 0x0da50, 0x07552, 0x056a0, 0x0abb7, 0x025d0, 0x092d0, 0x0cab5,   
         0x0a950, 0x0b4a0, 0x0baa4, 0x0ad50, 0x055d9, 0x04ba0, 0x0a5b0, 0x15176, 0x052b0, 0x0a930,   
         0x07954, 0x06aa0, 0x0ad50, 0x05b52, 0x04b60, 0x0a6e6, 0x0a4e0, 0x0d260, 0x0ea65, 0x0d530,   
         0x05aa0, 0x076a3, 0x096d0, 0x04bd7, 0x04ad0, 0x0a4d0, 0x1d0b6, 0x0d250, 0x0d520, 0x0dd45,   
         0x0b5a0, 0x056d0, 0x055b2, 0x049b0, 0x0a577, 0x0a4b0, 0x0aa50, 0x1b255, 0x06d20, 0x0ada0};

        static readonly string[] chineseNumber = new string[] { 
            Main.ChineseOne, 
            Main.ChineseTwo,
            Main.ChineseThree,
            Main.ChineseFour,
            Main.ChineseFive,
            Main.ChineseSix,
            Main.ChineseSeven,
            Main.ChineseEight,
            Main.ChineseNine,
            Main.ChineseTen,
            Main.ChineseEleven,
            Main.ChineseTwo};

        public static readonly String[] AnimalSigns = new String[] { 
            Main.ChineseZodiacRat,
            Main.ChineseZodiacOx,
            Main.ChineseZodiacTiger,
            Main.ChineseZodiacRabbit,
            Main.ChineseZodiacDragon,
            Main.ChineseZodiacSnake,
            Main.ChineseZodiacHorse,
            Main.ChineseZodiacRam,
            Main.ChineseZodiacMonkey,
            Main.ChineseZodiacRooster,
            Main.ChineseZodiacDog,
            Main.ChineseZodiacPig};

        public static readonly String[] HeavenlyStems = new String[] { 
            Main.HeavenlyStemsJia,
            Main.HeavenlyStemsYi,
            Main.HeavenlyStemsBing,
            Main.HeavenlyStemsDing,
            Main.HeavenlyStemsWu,
            Main.HeavenlyStemsJi,
            Main.HeavenlyStemsGeng,
            Main.HeavenlyStemsXin,
            Main.HeavenlyStemsRen,
            Main.HeavenlyStemsKui};

        public static readonly String[] EarthlyBranches = new String[] { 
            Main.EarthlyBranchesZi,
            Main.EarthlyBranchesChou,
            Main.EarthlyBranchesYin,
            Main.EarthlyBranchesMao,
            Main.EarthlyBranchesChen,
            Main.EarthlyBranchesSi,
            Main.EarthlyBranchesWu,
            Main.EarthlyBranchesWei,
            Main.EarthlyBranchesShen,
            Main.EarthlyBranchesYou,
            Main.EarthlyBranchesXu,
            Main.EarthlyBranchesHai};

        //====== 传回农历 y年闰月的天数   
        public static int LeapDays(int y)
        {
            if (LeapMonth(y) != 0)
            {
                if ((ChineseCalendarInfo.LunarInfoTable[y - 1900] & 0x10000) != 0)
                    return 30;
                else
                    return 29;
            }
            else
                return 0;
        }

        //====== 传回农历 y年闰哪个月 1-12 , 没闰传回 0   
        public static int LeapMonth(int y)
        {
            return (int)(ChineseCalendarInfo.LunarInfoTable[y - 1900] & 0xf);
        }

        //====== 传回农历 y年m月的总天数   
        public static int MonthDays(int y, int m)
        {
            //var tmp1 = ChineseCalendarInfo.LunarInfoTable[y - 1900];
            //var tmp2 = (0x10000 >> m);
            //var tmp3 = tmp1 & tmp2;
            //return tmp3 == 0 ? 29 : 30;
            if ((ChineseCalendarInfo.LunarInfoTable[y - 1900] & (0x10000 >> m)) == 0)
                return 29;
            else
                return 30;
        }

        public static string ToChineseNumber(int num)
        {
            Debug.Assert(num > 0 && num < 32);
            int tenth = num / 10;

            string result = string.Empty; ;
            if (tenth > 0)
            {
                result = chineseNumber[9];
                if (tenth > 1)
                    result = chineseNumber[tenth - 1] + result;
            }
            if (num % 10 > 0)
                result += chineseNumber[num % 10 - 1];

            return result;
        }

        //====== 传回农历 y年的总天数   
        public static int YearDays(int y)
        {
            int sum = 348;
            for (int i = 0x8000; i > 0x8; i >>= 1)
            {
                if ((ChineseCalendarInfo.LunarInfoTable[y - 1900] & i) != 0)
                    sum += 1;
            }
            return (sum + LeapDays(y));
        }
    }
}
