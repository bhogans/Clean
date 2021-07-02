using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoRivers.Library.Utility
{
    internal class DebugCounter
    {
        private static Dictionary<string, int> Counters;

        public static void Init()
        {
#if (DEBUG)
            Counters = new Dictionary<string, int>();
            Counters.Clear();
#endif
        }

        public static void Count(string key, int count = 1)
        {
#if (DEBUG)
            if (Counters == null)
                Counters = new Dictionary<string, int>();

            if (Counters.ContainsKey(key) == false)
                Counters.Add(key, 0);

            Counters[key] += count;
#endif
        }

        public static string Dump()
        {
            var r = "";

#if (DEBUG)
            if (Counters != null)
                foreach (var key in Counters.Keys.OrderBy(k => k))
                    r += $"{key} : {Counters[key]}" + Environment.NewLine;
#endif

            return r;
        }
    }
}