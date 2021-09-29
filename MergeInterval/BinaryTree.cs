using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MergeInterval
{
    public class BinaryTree
    {
        public Node root { get; set; }
        public int mergeDistance { get; set; }

        public StringBuilder AddInterval(Interval interval)
        {
            Node newNode = new Node(interval);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                root = AddInterval(root, newNode);
                root = Balance(root);
            }
            StringBuilder s = new StringBuilder();
            foreach (Interval mergedinterval in MergeInterval(root).OrderBy(i => i.start))
            {
                s.Append(Display(mergedinterval));
            }
            return s;

        }

        private Node AddInterval(Node node, Node newNode)
        {
            if (node == null)
            {
                node = newNode;
            }
            else if (newNode.intervaldata.start <= node.intervaldata.start)
            {
                node.left = AddInterval(node.left, newNode);
            }
            else if (newNode.intervaldata.start > node.intervaldata.start)
            {
                node.right = AddInterval(node.right, newNode);

            }
            //node = Balance(node);
            return node;
        }

        public StringBuilder RemoveInterval(Interval interval)
        {
            root = RemoveInterval(root, interval);
            root = Balance(root);
            StringBuilder s = new StringBuilder();
            foreach (Interval mergedinterval in MergeInterval(root).OrderBy(i => i.start))
            {
                s.Append(Display(mergedinterval));
            }
            return s;
        }

        private Node RemoveInterval(Node node, Interval interval)
        {
            Node parent;
            if (node == null)
            {
                return null;
            }
            else
            {
                //search left subtree if value is less than current
                if (interval.start <= node.intervaldata.start && interval.end != node.intervaldata.end)
                {
                    node.left = RemoveInterval(node.left, interval);
                }
                //search right subtree if value is greater than current
                else if (interval.start > node.intervaldata.start && interval.end != node.intervaldata.end)
                {
                    node.right = RemoveInterval(node.right, interval);
                }
                //node to delete found
                else
                {
                    //Check if left children
                    if (node.left != null)
                    {
                        parent = node.left;
                        while (parent.right != null)
                        {
                            parent = parent.right;
                        }
                        node.intervaldata = parent.intervaldata;
                        node.left = RemoveInterval(node.left, parent.intervaldata);
                    }
                    //check if right children
                    else if (node.right != null)
                    {
                        parent = node.right;
                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }
                        node.intervaldata = parent.intervaldata;
                        node.right = RemoveInterval(node.right, parent.intervaldata);
                    }
                    //if no children
                    else
                    {
                        return node.left;
                    }
                }
                //node = Balance(node);
                return node;
            }
        }

        public StringBuilder DeleteInterval(Interval delete_interval)
        {
            StringBuilder s = new StringBuilder();
            foreach (Interval mergedinterval in MergeInterval(root).OrderBy(i => i.start))
            {
                if (mergedinterval.start == delete_interval.start)
                {
                    s.Append(Display(new Interval(delete_interval.end, mergedinterval.end)));
                }
                else if (mergedinterval.end == delete_interval.start)
                {
                    s.Append(Display(new Interval(mergedinterval.start, delete_interval.start)));
                }
                else if (mergedinterval.start < delete_interval.start && mergedinterval.end > delete_interval.end)
                {
                    s.Append(Display(new Interval(mergedinterval.start, delete_interval.start)));
                    s.Append(Display(new Interval(delete_interval.end, mergedinterval.end)));
                }
                else
                {
                    s.Append(Display(mergedinterval));
                }
            }

            return s;
        }

        private Node Balance(Node node)
        {
            int to_balance = GetHeight(node.left) - GetHeight(node.right);
            if (to_balance > 1 && node.intervaldata.start < node.left.intervaldata.start)
            {
                return RotateRight(node);
            }
            else if (to_balance < -1 && node.intervaldata.start < node.right.intervaldata.start)
            {
                return RotateLeft(node);
            }
            else if (to_balance > 1 && node.intervaldata.start > node.left.intervaldata.start)
            {
                if (node.left.right != null)
                    node.left = RotateLeft(node.left);
                return RotateRight(node);
            }
            else if (to_balance < -1 && node.intervaldata.start > node.right.intervaldata.start)
            {
                if (node.right.left != null)
                    node.right = RotateRight(node.right);
                return RotateLeft(node);
            }
            return node;
        }

        private int GetHeight(Node node)
        {
            int h = 0;
            if (node != null)
            {
                int left = GetHeight(node.left);
                int right = GetHeight(node.right);
                h = Math.Max(left, right) + 1;
            }
            return h;
        }

        private Node RotateRight(Node node)
        {
            Node pivot = node.left;
            Node n = pivot?.right;
            pivot.right = node;
            node.left = n;

            return pivot;
        }
        private Node RotateLeft(Node node)
        {
            Node pivot = node.right;
            Node n = pivot.left;
            pivot.left = node;
            node.right = n;
            return pivot;
        }

        private string Display(Interval interval)
        {
            return "[" + interval.start + "," + interval.end + "]";
        }

        private Queue<Interval> MergeInterval(Node node)
        {
            Queue<Interval> mergedInterval = new Queue<Interval>();
            if (node == null)
            {
                return null;
            }
            Interval interval = InOrderTraverse(node, ref mergedInterval, node.intervaldata.start, node.intervaldata.end);
            if(mergedInterval.Where(i=>i.start <= interval.start && i.end >= interval.end).Count() == 0)
            {
                mergedInterval.Enqueue(InOrderTraverse(node, ref mergedInterval, node.intervaldata.start, node.intervaldata.end));
            }
            
            return mergedInterval;
        }

        private Interval InOrderTraverse(Node node, ref Queue<Interval> mergedInterval, int start, int end)
        {
            if (node == null)
            {
                return null;
            }
            Interval interval = new Interval(node.intervaldata.start, node.intervaldata.end);
            if (node.left != null)
            {
                Interval leftnode = InOrderTraverse(node.left, ref mergedInterval, start, end);
                if (interval.start - mergeDistance <= leftnode.end)
                {
                    interval.start = Math.Min(leftnode.start, interval.start);
                    interval.end = Math.Max(leftnode.end, interval.end);
                    start = interval.start;
                    end = interval.end;
                }
                else if (interval.start - mergeDistance > leftnode.end)
                {
                    if (mergedInterval.Where(i => i.start <= leftnode.start && i.end >= leftnode.end).Count() == 0)
                    {
                        mergedInterval.Enqueue(leftnode);
                    }
                }
            }
            if (interval.start <= end + mergeDistance && interval.end + mergeDistance >= start)
            {
                interval.start = Math.Min(start, interval.start);
                interval.end = Math.Max(end, interval.end);
                start = interval.start;
                end = interval.end;
            }
            if (node.right != null)
            {
                Interval rightnode = InOrderTraverse(node.right, ref mergedInterval, start, end);
                if (rightnode.start <= interval.end + mergeDistance)
                {
                    interval.start = Math.Min(interval.start, rightnode.start);
                    interval.end = Math.Max(interval.end, rightnode.end);
                    start = interval.start;
                    end = interval.end;
                }
                else if (rightnode.start > interval.end + mergeDistance)
                {
                    if (mergedInterval.Where(i => i.start <= rightnode.start && i.end >= rightnode.end).Count() == 0)
                    {
                        mergedInterval.Enqueue(rightnode);
                    }
                }
            }
            return interval;
        }
    }
}
