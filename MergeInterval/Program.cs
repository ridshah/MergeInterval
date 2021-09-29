using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MergeInterval
{
    public class Program
    {
        public static void Main()
        {
            BinaryTree tree = new BinaryTree();
            Console.WriteLine("Provide path to input file");
            string path = Console.ReadLine();
            Console.WriteLine("Provide merge distance");
            tree.mergeDistance = Convert.ToInt32(Console.ReadLine());
            using var csvreader = new StreamReader(path);
            int i = 0;
            while (!csvreader.EndOfStream)
            {
                string[] line = csvreader.ReadLine().Split(',');
                Interval interval = new Interval();
                int start = Convert.ToInt32(line[1]);
                int end = Convert.ToInt32(line[2]);
                int sequence = i++;
                string action = line[3].ToLower();
                Console.WriteLine(ProcessInput(start, end, action, tree));
            }
        }

        public static string ProcessInput(int start, int end, string action, BinaryTree tree)
        {
            switch (action)
            {
                case "added":
                    return tree.AddInterval(new Interval(start, end)).ToString();
                case "removed":
                    return tree.RemoveInterval(new Interval(start, end)).ToString();
                case "deleted":
                    return tree.DeleteInterval(new Interval(start, end)).ToString();
                default:
                    return "Action not recognized!";
            }
        }
    }
}
