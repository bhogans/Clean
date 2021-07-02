using System;
using System.Collections.Generic;
using System.Text;

namespace TwoRivers.Library.Utility
{
    class AtomicLog
    {


        /// <summary>
        /// SQL string Builder Helper. 
        /// Returns proper string if field in MongoDb is Null, NOT Null, or Empty
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ParseValue(string key, string value)
        {
            if (value == null)
                return key + " IS NULL";
            if (value == "!null")
                return key + " IS NOT NULL";
            if (value.Trim() == "")
                return "";
            else
                return key + " = '" + value + "'";
        }

        public class DailyStat
        {
            public int Month;
            public int Day;
            public int Year;
            public int Metric;
        }
    }
}
