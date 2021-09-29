using System;
using System.Collections.Generic;
using System.Text;

namespace MergeInterval
{
    public class Interval
    {
        public int start { get; set; }
        public int end { get; set; }
        public bool ismerged;

        public Interval() { }

        public Interval(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }
}
