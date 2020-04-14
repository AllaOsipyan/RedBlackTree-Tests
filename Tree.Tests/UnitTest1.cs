using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tree.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddRoot()
        {
            TreeAlgorithm tree = new TreeAlgorithm();
            
            tree.Add(56);
            var expectedColor = Color.B;
            var resultColor = tree.FindKey(56).Colour;
            Assert.AreEqual(expectedColor, resultColor);

        }

        [TestMethod]
        public void AddWithRedParrent()
        {
            //Добавление узла к черному родителю
            TreeAlgorithm tree = new TreeAlgorithm();
            var newNode1 = 12;
            var newNode2 = 65;

            //mainTree
            tree.Add(56);//root black Test1
            
            //добавление новых узлов 
            tree.Add(newNode1);
            tree.Add(newNode2);
            var result = tree.Root;
            Assert.AreEqual(12, result.Left.Value);
            Assert.AreEqual(Color.R, result.Left.Colour);//цвет первого узла
            Assert.AreEqual(65, result.Right.Value);
            Assert.AreEqual(Color.R, result.Left.Colour);//цвет второго узла
        }
        [TestMethod]
        public void AddWithRedUncleAndRedParent()
        {
            //должен поменяться цвет у родителя  и дяди на черный 
            //для сохранения свойства "Оба потомка каждого красного узла — чёрные."
            TreeAlgorithm tree = new TreeAlgorithm();
            var newNode = 16;

            //mainTree
            tree.Add(56);//root black Test1
            tree.Add(12);//red Test2
            tree.Add(65);//red Test2

            //Добавление нового узла
            tree.Add(newNode);

            var result = tree.Root;
            Assert.AreEqual(56, result.Value);
            Assert.AreEqual(12, result.Left.Value);
            Assert.AreEqual(Color.B, result.Left.Colour);//цвет родителя
            Assert.AreEqual(65, result.Right.Value);
            Assert.AreEqual(Color.B, result.Left.Colour);//цвет дяди
            Assert.AreEqual(16, result.Left.Right.Value);
        }

        [TestMethod]
        public void AddWithBlackUncleAndRedParent()
        {
            
            //должен быть совершен поворот относительно родителя
            //родитель должен стать черным,а новый ,брат - красным
            //для сохранения свойства "Оба потомка каждого красного узла — чёрные."
            //и свойства "Все пути от любого данного узла до листовых узлов содержат одинаковое число чёрных узлов."
            TreeAlgorithm tree = new TreeAlgorithm();
            var newNode = 30;

            //изначально имеет касного родителя и черного дядю
            tree.Add(56);//root black 
            tree.Add(12);//black
            tree.Add(65);//parent red
            tree.Add(16);//red
            
            //добавление нового узла
            tree.Add(newNode);
            var result = tree.Root;

            //проверка
            Assert.AreEqual(16, result.Left.Value);
            Assert.AreEqual(Color.B, result.Left.Colour);//цвет родителя
            Assert.AreEqual(12, result.Left.Left.Value);
            Assert.AreEqual(Color.R, result.Left.Left.Colour);//цвет брата
            Assert.AreEqual(30, result.Left.Right.Value);
            Assert.AreEqual(Color.R, result.Left.Right.Colour);//цвет узла

        }
    }
}
