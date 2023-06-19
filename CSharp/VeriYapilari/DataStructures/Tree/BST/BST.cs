using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tree.BinaryTree;

namespace DataStructures.Tree.BST
{
    class BST<T> : IEnumerable<T> where T : IComparable 
    {
        public Node<T> Root { get; set; }

        public BST()
        {
            
        }

        public BST(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new BSTEnumerator<T>(Root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T Value) {
            if (Value == null)
                throw new ArgumentNullException();
            var newNode = new Node<T>(Value);
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                var current = Root;
                Node<T> parent;
                while (true)
                {
                    parent = current;
                    // Sol alt ağaç
                    if (Value.CompareTo(parent.Value) < 0)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                    }
                    // Sag alt ağaç
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        public Node<T> FindMin(Node<T> root)
        {
            var current = root;
            while (current.Left != null)
                current = current.Left;
            return current;
        }

        public Node<T> FindMax(Node<T> root)
        {
            var current = root;
            while (current.Right != null)
                current = current.Right;
            return current;
        }

        public Node<T> Remove(Node<T> root, T key) 
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));

            if(key.CompareTo(root.Value) < 0)
                root.Left = Remove(root.Left, key);
            else if(key.CompareTo(root.Value) < 0)
                root.Right = Remove(root.Right, key);
            else
            {
                Console.WriteLine(root.Value);
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;
                else
                {
                    root.Value = FindMin(root.Right).Value;
                    root.Right = Remove(root.Right, Root.Value);
                }

            }
            return root;
        }

    }
}
