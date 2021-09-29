using NUnit.Framework;
using MergeInterval;
using System.Collections.Generic;

namespace MergeIntervalTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            BinaryTree tree = new BinaryTree
            {
                mergeDistance = 5
            };
            //List<Interval> tree = new List<Interval>();
            //Program.merge_distance = 5;
            Assert.AreEqual("[1,20]", Program.ProcessInput(1, 20, "added", tree));
            Assert.AreEqual("[1,20][55,58]", Program.ProcessInput(55, 58, "added", tree));
            Assert.AreEqual("[1,20][55,89]", Program.ProcessInput(60, 89, "added", tree));
            Assert.AreEqual("[1,31][55,89]", Program.ProcessInput(15, 31, "added", tree));
            Assert.AreEqual("[1,31][55,89]", Program.ProcessInput(10, 15, "added", tree));
            Assert.AreEqual("[10,31][55,89]", Program.ProcessInput(1, 20, "removed", tree));
        }

        [Test]
        public void Test2()
        {
            BinaryTree tree = new BinaryTree
            {
                mergeDistance = 5
            };
            //List<Interval> tree = new List<Interval>();
            //Program.merge_distance = 5;
            Assert.AreEqual("[1,6]", Program.ProcessInput(1, 6, "added", tree));
            Assert.AreEqual("[1,7]", Program.ProcessInput(5, 7, "added", tree));
            Assert.AreEqual("[1,2][3,7]", Program.ProcessInput(2, 3, "deleted", tree));
        }
        [Test]
        public void Test3()
        {
            BinaryTree tree = new BinaryTree
            {
                mergeDistance = 5
            };
            //List<Interval> tree = new List<Interval>();
            //Program.merge_distance = 5;
            Assert.AreEqual("[1,20]", Program.ProcessInput(1, 20, "added", tree));
            Assert.AreEqual("[1,20][55,58]", Program.ProcessInput(55, 58, "added", tree));
            Assert.AreEqual("[1,20][55,89]", Program.ProcessInput(60, 89, "added", tree));
            Assert.AreEqual("[1,31][55,89]", Program.ProcessInput(15, 31, "added", tree));
            Assert.AreEqual("[1,33][55,89]", Program.ProcessInput(32, 33, "added", tree));
            Assert.AreEqual("[1,33][39,40][55,89]", Program.ProcessInput(39, 40, "added", tree));
            Assert.AreEqual("[15,33][39,40][55,89]", Program.ProcessInput(1, 20, "removed", tree));
            Assert.AreEqual("[15,20][30,33][39,40][55,89]", Program.ProcessInput(20, 30, "deleted", tree));
        }
        [Test]
        public void Test4()
        {
            BinaryTree tree = new BinaryTree
            {
                mergeDistance = 5
            };
            Assert.AreEqual("[1,20]", Program.ProcessInput(1, 20, "added", tree));
            Assert.AreEqual("[1,20][55,58]", Program.ProcessInput(55, 58, "added", tree));
            Assert.AreEqual("[1,20][55,89]", Program.ProcessInput(60, 89, "added", tree));
            Assert.AreEqual("[1,31][55,89]", Program.ProcessInput(15, 31, "added", tree));
            Assert.AreEqual("[15,31][55,89]", Program.ProcessInput(1, 20, "removed", tree));
            Assert.AreEqual("[15,33][55,89]", Program.ProcessInput(32, 33, "added", tree));
            Assert.AreEqual("[15,33][39,40][55,89]", Program.ProcessInput(39, 40, "added", tree));
            Assert.AreEqual("[16,33][39,40][55,89]", Program.ProcessInput(15, 16, "deleted", tree));
        }
        [Test]
        public void Test5()
        {
            BinaryTree tree = new BinaryTree
            {
                mergeDistance = 5
            };
            Assert.AreEqual("[1,20]", Program.ProcessInput(1, 20, "added", tree));
            Assert.AreEqual("[1,20][55,58]", Program.ProcessInput(55, 58, "added", tree));
            Assert.AreEqual("[1,20][55,89]", Program.ProcessInput(60, 89, "added", tree));
            Assert.AreEqual("[55,89]", Program.ProcessInput(1, 20, "removed", tree));
            Assert.AreEqual("[32,33][55,89]", Program.ProcessInput(32, 33, "added", tree));
            Assert.AreEqual("[15,33][55,89]", Program.ProcessInput(15, 31, "added", tree));
            Assert.AreEqual("[15,33][39,40][55,89]", Program.ProcessInput(39, 40, "added", tree));
            Assert.AreEqual("[16,33][39,40][55,89]", Program.ProcessInput(15, 16, "deleted", tree));
        }
        [Test]
        public void Test6()
        {
            BinaryTree tree = new BinaryTree
            {
                mergeDistance = 5
            };
            Assert.AreEqual("[1,14]", Program.ProcessInput(1, 14, "added", tree));
            Assert.AreEqual("[1,15]", Program.ProcessInput(14, 15, "added", tree));
            Assert.AreEqual("[1,21]", Program.ProcessInput(20, 21, "added", tree));
            Assert.AreEqual("[1,21][55,58]", Program.ProcessInput(55, 58, "added", tree));
            Assert.AreEqual("[1,21][55,89]", Program.ProcessInput(60, 89, "added", tree));
            Assert.AreEqual("[14,21][55,89]", Program.ProcessInput(1, 14, "removed", tree));
            Assert.AreEqual("[14,21][32,33][55,89]", Program.ProcessInput(32, 33, "added", tree));
            Assert.AreEqual("[14,33][55,89]", Program.ProcessInput(15, 31, "added", tree));
            Assert.AreEqual("[14,33][39,40][55,89]", Program.ProcessInput(39, 40, "added", tree));
            Assert.AreEqual("[14,15][16,33][39,40][55,89]", Program.ProcessInput(15, 16, "deleted", tree));
        }
        [Test]
        public void Test7()
        {
            BinaryTree tree = new BinaryTree
            {
                mergeDistance = 5
            };
            Assert.AreEqual("[1,14]", Program.ProcessInput(1, 14, "added", tree));
            Assert.AreEqual("[1,15]", Program.ProcessInput(14, 15, "added", tree));
            Assert.AreEqual("[1,21]", Program.ProcessInput(20, 21, "added", tree));
            Assert.AreEqual("[1,21][55,58]", Program.ProcessInput(55, 58, "added", tree));
            Assert.AreEqual("[1,21][55,89]", Program.ProcessInput(60, 89, "added", tree));
            Assert.AreEqual("[1,21][55,58]", Program.ProcessInput(60, 89, "removed", tree));
            Assert.AreEqual("[1,21][32,33][55,58]", Program.ProcessInput(32, 33, "added", tree));
            Assert.AreEqual("[1,33][55,58]", Program.ProcessInput(15, 31, "added", tree));
            Assert.AreEqual("[1,33][39,40][55,58]", Program.ProcessInput(39, 40, "added", tree));
            Assert.AreEqual("[1,15][16,33][39,40][55,58]", Program.ProcessInput(15, 16, "deleted", tree));
        }
        [Test]
        public void Test8()
        {
            BinaryTree tree = new BinaryTree
            {
                mergeDistance = 5
            };
            Assert.AreEqual("[1,14]", Program.ProcessInput(1, 14, "added", tree));
            Assert.AreEqual("[1,15]", Program.ProcessInput(14, 15, "added", tree));
            Assert.AreEqual("[1,21]", Program.ProcessInput(20, 21, "added", tree));
            Assert.AreEqual("[1,21][55,58]", Program.ProcessInput(55, 58, "added", tree));
            Assert.AreEqual("[1,21][55,89]", Program.ProcessInput(60, 89, "added", tree));
            Assert.AreEqual("[1,21][60,89]", Program.ProcessInput(55, 58, "removed", tree));
            Assert.AreEqual("[1,21][32,33][60,89]", Program.ProcessInput(32, 33, "added", tree));
            Assert.AreEqual("[1,33][60,89]", Program.ProcessInput(15, 31, "added", tree));
            Assert.AreEqual("[1,33][39,40][60,89]", Program.ProcessInput(39, 40, "added", tree));
            Assert.AreEqual("[1,15][16,33][39,40][60,89]", Program.ProcessInput(15, 16, "deleted", tree));
        }
    }
}