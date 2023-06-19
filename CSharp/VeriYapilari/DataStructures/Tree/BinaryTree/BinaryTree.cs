using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructures.Tree.BinaryTree
{
    public class BinaryTree<T>  where T :IComparable
    {
        public List<Node<T>> list{ get; private set; }

        public BinaryTree()
        {
            list = new List<Node<T>>();
        }

        public List<Node<T>> PreOrder(Node<T> root)
        {
            if (root != null)
            {
                list.Add(root);
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
            return list;
        }

        public List<Node<T>> PostOrder(Node<T> root)
        {
            if (root != null)
            {
                PostOrder(root.Right);
                PostOrder(root.Left);
                list.Add(root);
            }
            return list;
        }

        public List<Node<T>> InOrder(Node<T> root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                list.Add(root);
                InOrder(root.Right);
            }
            return list;
        }

        private void Postorder(Node<T> head)
        {
            if (head == null)
            {
                return;
            }

            var stack = new DataStructures.Stack.Stack<Node<T>>();
            stack.Push(head);

            while (stack.Count > 0)
            {
                var next = stack.Peek();

                bool finishedSubtrees = (next.Right == head || next.Left == head);
                bool isLeaf = (next.Left == null && next.Right == null);

                if (finishedSubtrees || isLeaf)
                {
                    stack.Pop();
                    Console.WriteLine(next.Value);
                    head = next;
                }
                else
                {
                    if (next.Right != null)
                    {
                        stack.Push(next.Right);
                    }
                    if (next.Left != null)
                    {
                        stack.Push(next.Left);
                    }
                }
                Console.WriteLine(next.Value);
            }
        }

        public List<Node<T>> InOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var S    = new DataStructures.Stack.Stack<Node<T>>();
            Node< T> current_node = root;

            bool done = false;

            while (!done)
            {
                if (current_node != null)
                {
                    S.Push(current_node);
                    current_node = current_node.Left;
                }
                else
                {
                    if (S.Count == 0)
                        done = true;
                    else
                    {
                        current_node = S.Pop();
                        list.Add(current_node);
                        current_node = current_node.Right;
                    }
                }
            }
            return list;
        }

        public List<Node<T>> PreOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            if (root == null)
                throw new ArgumentNullException("Stack is empty!");

            var S    = new DataStructures.Stack.Stack<Node<T>>();
            S.Push(root);

            while (S.Count != 0)
            {
                var tmp = S.Pop();
                list.Add(tmp);
                if (tmp.Right != null)
                    S.Push(tmp.Right);
                if(tmp.Left != null)
                    S.Push(tmp.Left);
            }
            return list;
        }

        public List<Node<T>> LevelOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();

            var Q = new DataStructures.Queue.Queue<Node<T>>();
            Q.EnQueue(root);

            while (Q.Count > 0)
            {
                var temp = Q.DeQueue();
                list.Add(temp);
                if (temp.Left != null)
                    Q.EnQueue(temp.Left);
                if(temp.Right != null)
                    Q.EnQueue(temp.Right);
            }

            return list;
        }

        public static int MaxDepth(Node<T> root)
        {
            if(root == null) return 0;

            int LeftDepth = MaxDepth(root.Left);
            int RightDepth = MaxDepth(root.Right);

            return (LeftDepth > RightDepth) ? LeftDepth + 1 : RightDepth + 1 ;

        }
        public Node<T> DeepestNode(Node<T> root)
        {
            Node<T> temp = null;
            if(root == null) throw new ArgumentNullException("root");

            var q = new DataStructures.Queue.Queue<Node<T>>();

            q.EnQueue(root);

            while (q.Count > 0)
            {
                temp = q.DeQueue();
                if (temp.Left != null)
                    q.EnQueue(temp.Left);
                if (temp.Right != null)
                    q.EnQueue(temp.Right);
            }

            return temp;

        }
        public Node<T> Deepestnode(Node<T> root)
        {
            var list = LevelOrderNonRecursiveTraversal(root);
            return list[list.Count - 1];

        }
        public static int LeafCount(Node<T> root)
        {
            //if(root == null)
            //    return 0;
            //var Q = new DataStructures.Queue.Queue<Node<T>>();
            //Q.EnQueue(root);
            //int Count = 0;
            //while(Q.Count > 0)
            //{
            //    var temp = Q.DeQueue();
            //    if (temp.Left == null && temp.Right == null)
            //        Count++;
            //    if(temp.Left != null)
            //        Q.EnQueue(temp.Left);
            //    if(temp.Right != null)
            //        Q.EnQueue(temp.Right);
            //}
            //return Count;

            return new BinaryTree<T>()
                .LevelOrderNonRecursiveTraversal(root)
                .Where(x => x.Left == null && x.Right == null)
                .ToList()
                .Count;
        }

        public static int NumberOfFullNodes(Node<T> root) => 
            new BinaryTree<T>()
                .LevelOrderNonRecursiveTraversal(root)
                .Where(x => x.Left != null && x.Right != null)
                .ToList()
                .Count;

        public static int NumberOfHalfNodes(Node<T> root) => 
            new BinaryTree<T>()
                .LevelOrderNonRecursiveTraversal(root)
                .Where(x => (x.Left != null && x.Right == null) ||  (x.Left == null && x.Right != null))
                .ToList()
                .Count;

        public void PrintPaths(Node<T> root)
        {
            var Path = new T[256];
            PrintPaths(root, Path, 0);
        }

        private void PrintPaths(Node<T> root, T[] path, int Lenght)
        {
            if (root == null) return;
            path[Lenght] = root.Value;
            Lenght++;

            if (root.Left == null && root.Right == null)
            {
                PrintArray(path, Lenght);
            }
            else
            {
                PrintPaths(root.Left, path, Lenght);
                PrintPaths(root.Right, path, Lenght);
            }
        }

        private void PrintArray(T[] path, int len)
        {
            for (int i = 0; i < len; i++)
                Console.Write($"{path[i]} ");
            Console.WriteLine();
        }

        public void ClearList() => list.Clear();
    }
}
