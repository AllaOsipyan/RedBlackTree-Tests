using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tree.TreeTests
{
    [TestClass()]
    public class FindTests
    {
        TreeAlgorithm tree = new TreeAlgorithm();
        public void TreeComplite()
        {
            int[] values = { 22, 4, 61, 25, 66, 27, 10, 9, 7, 43 };
            for (int i = 0; i < values.Length; i++)
            {
                tree.Add(values[i]);
            }
        }

        [TestMethod()]
        public void MaxTest()
        {
            if (tree.Root == null)
                TreeComplite();
            TreeAlgorithm tree1 = new TreeAlgorithm();
            tree1.Add(-23);
            tree1.Add(-36);
            tree1.Add(-43);
            tree1.Add(-2);
            TreeAlgorithm tree2 = new TreeAlgorithm();
            Assert.AreEqual(66, tree.Max().Value);
            Assert.AreEqual(-2, tree1.Max().Value);
            Assert.IsNull(tree2.Max());
        }

        [TestMethod()]
        public void MinTest()
        {
            if (tree.Root == null)
                TreeComplite();
            TreeAlgorithm tree1 = new TreeAlgorithm();
            tree1.Add(-69);
            tree1.Add(-15);
            tree1.Add(-36);
            tree1.Add(-17);
            TreeAlgorithm tree2 = new TreeAlgorithm();
            Assert.AreEqual(4, tree.Min().Value);
            Assert.AreEqual(-69, tree1.Min().Value);
            Assert.IsNull(tree2.Max());
        }

        [TestMethod()]
        public void FindNextTest()
        {
            if (tree.Root == null)
                TreeComplite();
            Assert.AreEqual(43, tree.FindNext(27).Value);
            Assert.AreEqual(22, tree.FindNext(10).Value);
            Assert.AreEqual(7, tree.FindNext(4).Value);
            Assert.AreEqual(66, tree.FindNext(61).Value);
            Assert.IsNull(tree.FindNext(66));
        }

        [TestMethod]
        public void FindPrevTest()
        {
            if (tree.Root == null)
                TreeComplite();
            Assert.AreEqual(10, tree.FindPrev(22).Value);
            Assert.AreEqual(7, tree.FindPrev(9).Value);
            Assert.AreEqual(61, tree.FindPrev(66).Value);
            Assert.IsNull(tree.FindPrev(4));

        }
    }
}