using System;
using System.Collections.Generic;
using System.Text;

namespace MergeInterval
{
    public class Node
    {
        public Interval intervaldata;
        public Node left;
        public Node right;
        public Node(Interval intervaldata)
        {
            this.intervaldata = intervaldata;
        }
    }
}
