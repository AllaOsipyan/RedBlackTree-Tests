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
            //���������� ���� � ������� ��������
            TreeAlgorithm tree = new TreeAlgorithm();
            var newNode1 = 12;
            var newNode2 = 65;

            //mainTree
            tree.Add(56);//root black Test1
            
            //���������� ����� ����� 
            tree.Add(newNode1);
            tree.Add(newNode2);
            var result = tree.Root;
            Assert.AreEqual(12, result.Left.Value);
            Assert.AreEqual(Color.R, result.Left.Colour);//���� ������� ����
            Assert.AreEqual(65, result.Right.Value);
            Assert.AreEqual(Color.R, result.Left.Colour);//���� ������� ����
        }
        [TestMethod]
        public void AddWithRedUncleAndRedParent()
        {
            //������ ���������� ���� � ��������  � ���� �� ������ 
            //��� ���������� �������� "��� ������� ������� �������� ���� � ������."
            TreeAlgorithm tree = new TreeAlgorithm();
            var newNode = 16;

            //mainTree
            tree.Add(56);//root black Test1
            tree.Add(12);//red Test2
            tree.Add(65);//red Test2

            //���������� ������ ����
            tree.Add(newNode);

            var result = tree.Root;
            Assert.AreEqual(56, result.Value);
            Assert.AreEqual(12, result.Left.Value);
            Assert.AreEqual(Color.B, result.Left.Colour);//���� ��������
            Assert.AreEqual(65, result.Right.Value);
            Assert.AreEqual(Color.B, result.Left.Colour);//���� ����
            Assert.AreEqual(16, result.Left.Right.Value);
        }

        [TestMethod]
        public void AddWithBlackUncleAndRedParent()
        {
            
            //������ ���� �������� ������� ������������ ��������
            //�������� ������ ����� ������,� ����� ,���� - �������
            //��� ���������� �������� "��� ������� ������� �������� ���� � ������."
            //� �������� "��� ���� �� ������ ������� ���� �� �������� ����� �������� ���������� ����� ������ �����."
            TreeAlgorithm tree = new TreeAlgorithm();
            var newNode = 30;

            //���������� ����� ������� �������� � ������� ����
            tree.Add(56);//root black 
            tree.Add(12);//black
            tree.Add(65);//parent red
            tree.Add(16);//red
            
            //���������� ������ ����
            tree.Add(newNode);
            var result = tree.Root;

            //��������
            Assert.AreEqual(16, result.Left.Value);
            Assert.AreEqual(Color.B, result.Left.Colour);//���� ��������
            Assert.AreEqual(12, result.Left.Left.Value);
            Assert.AreEqual(Color.R, result.Left.Left.Colour);//���� �����
            Assert.AreEqual(30, result.Left.Right.Value);
            Assert.AreEqual(Color.R, result.Left.Right.Colour);//���� ����

        }
    }
}
