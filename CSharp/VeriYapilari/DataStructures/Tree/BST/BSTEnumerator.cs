using DataStructures.Tree.BinaryTree;
using System.Collections;

namespace DataStructures.Tree.BST
{
    internal class BSTEnumerator<T> : IEnumerator<T> where T : IComparable
    {
        private List<Node<T>> List;
        private int indexer = -1;
        public BSTEnumerator(Node<T> root)
        {
            List = new BinaryTree.BinaryTree<T>().LevelOrderNonRecursiveTraversal(root);
        }
        public T Current => List[indexer].Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            List = null;
        }

        public bool MoveNext()
        {
            indexer++;
            return indexer < List.Count;
        }

        public void Reset()
        {
            indexer=0;
        }
    }
}