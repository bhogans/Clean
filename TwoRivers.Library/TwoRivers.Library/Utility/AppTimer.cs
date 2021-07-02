using System;
using System.Diagnostics;
using System.Threading;

namespace TwoRivers.Library.Utility
{
    public class AppTimer
    {
        public string Name { get; set; }

        public DateTime Start { get; set; }
        public DateTime Last { get; set; }

        public AppTimer()
        {
            Start = DateTime.Now;
            Last = Start;
        }

        public AppTimer(string name)
        {
            Name = name;

            Debug.WriteLine($"S:   0s   0ms\tL:   0s   0ms\t{Name} : Started");

            Start = DateTime.Now;
            Last = Start;
        }

        public void Next(string step)
        {
#if (DEBUG)
            var tss = DateTime.Now.Subtract(Start);
            var tsl = DateTime.Now.Subtract(Last);

            Debug.WriteLine(string.Format("S: {0}s {1}ms\tL: {2}s {3}ms\t{4} : {5}",
                tss.Seconds.ToString().PadLeft(3, ' '),
                tss.Milliseconds.ToString().PadLeft(3, ' '),
                tsl.Seconds.ToString().PadLeft(3, ' '),
                tsl.Milliseconds.ToString().PadLeft(3, ' '),
                Name, step));

            Last = DateTime.Now;
#endif
        }
    }
}
