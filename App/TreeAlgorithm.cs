using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace Tree
{
    public enum Color
    {
        R,
        B,
        NaN
    }
    public class TreeAlgorithm
    {
        public class Node
        {
            public Color Colour;
            public Node Left;
            public Node Right;
            public Node Parent;
            public double Value;
            public Node() { }
            public Node(double data)
            {
                this.Value = data;
                this.Colour = Color.R;
                this.Left = null;
                this.Right = null;
            }
        }
        /// <summary> 
        /// Корневой узел 
        /// </summary> 
        public Node Root;
        public TreeAlgorithm() { }
        private Node Grandpa(Node key)
        {
            if (key != null && key.Parent != null)
                return key.Parent.Parent;
            else return null;
        }

        private Node Uncle(Node key)
        {
            var root = Grandpa(key);
            if (root == null)
                return null;
            if (key.Parent == root.Left)
                return root.Right;
            else return root.Left;
        }
     
        private void LeftRotate(Node n)
        {
            var isRoot = false;
            if (n.Parent == null)
                isRoot = true;
            var pivot = n.Right;
            //pivot может стать корнем дерева 
            pivot.Parent = n.Parent;
            if (n.Parent != null)
            {
                if (n.Parent.Left == n)
                    n.Parent.Left = pivot;
                else n.Parent.Right = pivot;
            }
            n.Right = pivot.Left;
            if (pivot.Left != null)
                pivot.Left.Parent = n;
            n.Parent = pivot;
            pivot.Left = n;
            if (isRoot)
                Root = pivot;
        }
        
        private void RightRotate(Node n)
        {
            var isRoot = false;
            if (n.Parent == null)
                isRoot = true;
            var pivot = n.Left;
            //pivot может стать корнем дерева 
            pivot.Parent = n.Parent;
            if (n.Parent != null)
            {
                if (n.Parent.Left == n)
                    n.Parent.Left = pivot;
                else n.Parent.Right = pivot;
            }
            n.Left = pivot.Right;
            if (pivot.Right != null)
                pivot.Right.Parent = n;
            n.Parent = pivot;
            pivot.Right = n;
            if (isRoot)
                Root = pivot;
        }
     
        public Node FindKey(double key)
        {
            bool isFound = false;
            Node temp = Root;

            while (!isFound)
            {
                if (temp == null) break;

                if (temp != null && key < temp.Value)
                    temp = temp.Left;

                if (temp != null && key > temp.Value)
                    temp = temp.Right;

                if (temp != null && key == temp.Value)
                    isFound = true;
            }
            if (isFound) return temp;
            else return null;
        }

        private void Insert(double key)
        {
            if (Root == null)
                Root = new Node(key);
            else
            {
                var node = Root;
                while (node != null)
                {
                    var nextNode = key < node.Value ? node.Left : node.Right;

                    if (nextNode == null)
                        if (key < node.Value)
                        {
                            node.Left = new Node(key);
                            node.Left.Parent = node;
                        }
                        else
                        {
                            node.Right = new Node(key);
                            node.Right.Parent = node;
                        }
                    node = nextNode;
                }
            }
        }
   
   
        public void Add(double key)
        {
            if (FindKey(key) != null) return; 
            Insert(key);
            Node newItem = FindKey(key);
            newItem.Colour = Color.R;
            Add1(newItem);

        }
        private void Add1(Node newItem)
        {
            if (newItem.Parent == null)
            {
                newItem.Colour = Color.B;
                Root = newItem;
            }
            else Add2(newItem);
        }

        private void Add2(Node newItem)
        {
            if (newItem.Parent.Colour == Color.B)
                return;
            else Add3(newItem);
        }

        private void Add3(Node newItem)
        {
            if (Uncle(newItem) != null && Uncle(newItem).Colour == Color.R)
            {
                newItem.Parent.Colour = Color.B;
                Uncle(newItem).Colour = Color.B;
                Grandpa(newItem).Colour = Color.R;
                Add1(Grandpa(newItem));
            }
            else Add4(newItem);
        }

        private void Add4(Node newItem)
        {
            var P = newItem.Parent;
            var G = Grandpa(newItem);
            if (newItem == P.Right && P == G.Left)
            {
                LeftRotate(P);
                newItem = newItem.Left;
            }
            else if (newItem == newItem.Parent.Left && newItem.Parent == G.Right)
            {
                RightRotate(P);
                newItem = newItem.Right;
            }
            Add5(newItem);
        }

        private void Add5(Node newItem)
        {
            var grandpa = Grandpa(newItem);
            newItem.Parent.Colour = Color.B;
            grandpa.Colour = Color.R;
            if (newItem == newItem.Parent.Left && newItem.Parent == grandpa.Left)

                RightRotate(grandpa);
            else
                LeftRotate(grandpa);
        }
        
    }
}