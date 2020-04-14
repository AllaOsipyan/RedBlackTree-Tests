using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tree.TreeTests
{
    [TestClass()]
    public class DeleteTests
    {
        
        public void TreeComplite(TreeAlgorithm tree, int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                tree.Add(values[i]);
            }
        }

        [TestMethod()]
        public void DeleteNonexistentNodeTest()
        {
            TreeAlgorithm tree = new TreeAlgorithm();
            int[] values = { 56, 12, 65, 16, 30 };
            TreeComplite(tree, values);
            

            var result = tree.Delete1(70);;
            Assert.AreEqual(double.NaN, result);
        }

        [TestMethod()]
        public void DeleteWithRedPrevTest()
        {
            TreeAlgorithm tree = new TreeAlgorithm();
            int[] values = { 56, 12, 65, 16, 30 };
            TreeComplite(tree, values);
            tree.Delete1(56);

            var result = tree.Root;
            Assert.AreEqual(30, result.Value);
            Assert.AreEqual(16, result.Left.Value);
            Assert.IsNull(result.Left.Right);//старое местоположение узла 30 теперь должно быть пустым
            Assert.IsNull(tree.FindKey(56));
        }

        [TestMethod()]
        public void DeleteWithRedPrevChildTest()
        {
            TreeAlgorithm tree = new TreeAlgorithm();
            int[] values = { 56, 12, 65, 16, 30, 20 };
            TreeComplite(tree, values);
            tree.Delete1(56);

            var result = tree.Root;
            Assert.AreEqual(30, result.Value);
            Assert.AreEqual(16, result.Left.Value);
            Assert.AreEqual(Color.R, result.Left.Colour);//цвет узла 16(родителя) lдолжен поменяться на красный
            Assert.AreEqual(20, result.Left.Right.Value);//на месте узла 30 теперь должен быть его потомок - узел 20
            Assert.IsNull(tree.FindKey(56));
        }

        [TestMethod()]
        public void DeleteWithoutChildPrevTest()
        {
            TreeAlgorithm tree = new TreeAlgorithm();
            int[] values = { 56, 12, 65, 16, 30, 20 };
            TreeComplite(tree, values);
            tree.Delete1(16);

            var result = tree.Root;
            Assert.AreEqual(56, result.Value);
            Assert.AreEqual(20, result.Left.Value);//после поворота должен стать потомком корневого узла
            Assert.AreEqual(Color.R, result.Left.Colour);
            Assert.AreEqual(12, result.Left.Left.Value);// узел 12 должен стать потомком узла 20
            Assert.AreEqual(Color.B, result.Left.Left.Colour);
            Assert.AreEqual(30, result.Left.Right.Value);// узел 30 должен стать потомком узла 20
            Assert.IsNull(tree.FindKey(16));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            TreeAlgorithm tree = new TreeAlgorithm();
            int[] values = { 22, 4, 61, 25, 66, 27, 10, 9, 7, 43, 36, 75, 46, 11 };
            TreeComplite(tree, values);

            //удаление всего дерева полностью
            
            for(int i = 0; i < values.Length; i++)
            {
                tree.Delete1(values[i]);
            }
            Assert.IsNull(tree.Root);
        }

        
        
    }
}