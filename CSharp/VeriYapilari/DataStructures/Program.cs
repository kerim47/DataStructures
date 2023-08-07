using DataStructures.LinkedList.DoublyLinkedList;
using DataStructures.LinkedList.SinglyLinkedList;
using DataStructures.Queue;
using DataStructures.Stack;
using DataStructures.Tree.BinaryTree;
using DataStructures.Tree.BST;
using DataStructures.Set;
using DataStructures.Graph.AdjancencySet;
using DataStructures.Graph.Search;
using System.Collections.Generic;
using DataStructures.Graph.MinimumSpanningTree;
using DataStructures.Graph;
using System.Threading.Channels;

var graph = new WeightedGraph<int, int>();

for (int i = 0; i < 12; i++)
    graph.AddVertex(i);

graph.AddEdge(0, 1, 4);
graph.AddEdge(0, 7, 8);
graph.AddEdge(1, 7, 11);
graph.AddEdge(1, 2, 8);
graph.AddEdge(7, 8, 7);


graph.AddEdge(7, 6, 1);
graph.AddEdge(6, 8, 6);
graph.AddEdge(2, 8, 2);
graph.AddEdge(2, 5, 4);
graph.AddEdge(6, 5, 2);

graph.AddEdge(3, 5, 14);
graph.AddEdge(3, 4, 9);
graph.AddEdge(5, 4, 10);


Console.WriteLine("----------------------");
var algorithm = new Kruskals<int, int>();
algorithm.FindMinimumSpanningTree(graph).ForEach(edge => Console.WriteLine(edge));
Console.WriteLine("----------------------");


#region functions



void print<T>(IEnumerable<T> list, string sep = " ")
{
    Console.WriteLine(string.Join(sep, list));
}


static void SinglyLinkedListApp002()
{
    var arr = new char[] { 'a', 'b', 'c' };
    var arr_list = new System.Collections.ArrayList(arr);
    var list = new List<char>(arr);
    var c_linked_list = new LinkedList<char>(arr);

    var linked_list = new SinglyLinkedList<char>(list);
    var new_linkedlist = new SinglyLinkedList<char>(linked_list);
    foreach (var item in linked_list)
    {
        Console.Write(item + " ");
    }
}

static void SinglyLinkedListApp001()
{
    var liste_1 = new LinkedList<int>();
    var liste_2 = new LinkedList<int>();
    liste_1.AddLast(1);
    liste_1.AddLast(2);
    liste_1.AddLast(3);
    liste_1.AddLast(4);
    liste_1.AddLast(5);

    liste_2.AddLast(6);
    liste_2.AddLast(7);
    liste_2.AddLast(8);
    liste_2.AddLast(9);
    liste_2.AddLast(10);

    foreach (var item in liste_1)
    {
        Console.WriteLine(item);
    }
    // linked_list_2.AddAfter(linked_list_2.Head.Next, 32);
    //// 1 30 2 32 3

    // linked_list_2.AddBefore(linked_list_2.Head.Next, 30);
    //// 1 30  2 32 3


    // linked_list_1.AddAfter(linked_list_2.Head.Next, linked_list_1.Head);
}

static void SinglyLinkedListApp003()
{
    /// * Language Integrated Query - (LINQ)
    /// Linq ifadeleri ertelenmis ifadeleri icerir bundan dolayi 
    /// ToList kullanimina ihtiyac duyar

    var rnd = new Random();
    var initial = Enumerable.Range(1, 10).OrderBy(x => rnd.Next()).ToList();
    var linked_list = new SinglyLinkedList<int>(initial);

    var q = from item in linked_list
            where item % 2 == 1
            select item;

    //foreach (var item in q)
    //{
    //    Console.WriteLine(item);
    //}

    //linked_list.Where(x => x > 5).ToList().ForEach(x =>
    // Console.Write(x + " "));
}

void SinglyLinkedListApp005()
{
    var rnd = new Random();
    var initial = Enumerable.Range(1, 10).OrderBy(x => rnd.Next()).ToList();
    var list = new SinglyLinkedList<int>(initial);

    print(list);
    list.RemoveFirst();
    list.RemoveFirst();
    list.RemoveFirst();
    list.RemoveFirst();
    print(list);
}

void SinglyLinkedListApp006(SinglyLinkedList<char> linked_list)
{
    //linked_list.RemoveFirst();
    //linked_list.RemoveFirst();

    linked_list.RemoveLast();

    foreach (var item in linked_list)
    {
        Console.WriteLine(item);
    }
}

void SinglyLinkedListApp007()
{
    LinkedList<int> liste_1 = new LinkedList<int>();
    LinkedListNode<int> liste_2 = new LinkedListNode<int>(10);
    liste_1.AddLast(1);
    liste_1.AddLast(2);
    liste_1.AddLast(3);

    liste_1.AddLast(liste_2);


    print(liste_1);

    //var arr = new char[] { 'a', 'b', 'c' ,'a', 'd', 'e' , 'a'};
    //var list = new List<char>(arr);
    //var linked_list = new SinglyLinkedList<char>(list);

    //linked_list.Remove('a');
    //print(linked_list);
}

static void DoublyLinkedListApp001()
{
    DoublyLinkedList<int> liste_1 = new DoublyLinkedList<int>();

    liste_1.AddFirst(1);
    liste_1.AddFirst(2);
    liste_1.AddFirst(3);
    liste_1.AddFirst(4);

    //liste_1.AddAfter(liste_1.Head.Next, new DoublyLinkedListNode<int>(12));
    liste_1.AddBefore(liste_1.Head, new DoublyLinkedListNode<int>(12));
}

static void Stack()
{
    var int_set = new int[] { 1, 2, 3, 4 };
    var stack_1 = new DataStructures.Stack.Stack<int>();
    var stack_2 = new DataStructures.Stack.Stack<int>(StackType.LinkedList);

    foreach (var item in int_set)
    {
        Console.WriteLine(item);
        stack_1.Push(item);
        stack_2.Push(item);
    }

    Console.WriteLine("Peek");
    Console.WriteLine($"{stack_1.Peek()}");
    Console.WriteLine($"{stack_2.Peek()}");

    Console.WriteLine("\nPop");
    Console.WriteLine($"{stack_1.Pop()}");
    Console.WriteLine($"{stack_2.Pop()}");
    stack_1.Clear();

    Console.WriteLine("\nCount");
    Console.WriteLine($"{stack_1.Count}");
    Console.WriteLine($"{stack_2.Count}");
}

static void Queue()
{
    var numbers = new int[] { 1, 2, 3 };

    var q_1 = new DataStructures.Queue.Queue<int>();
    var q_2 = new DataStructures.Queue.Queue<int>(QueueType.LinkedList);

    foreach (var item in numbers)
    {
        Console.WriteLine(item);
        q_1.EnQueue(item);
        q_2.EnQueue(item);
    }

    Console.WriteLine($"q1 Count : {q_1.Count}");
    Console.WriteLine($"q2 Count : {q_2.Count}");


    Console.WriteLine($"q1 DeQueue: {q_1.DeQueue()}");
    Console.WriteLine($"q2 DeQueue: {q_2.DeQueue()}");

    Console.WriteLine($"q1 Count : {q_1.Count}");
    Console.WriteLine($"q2 Count : {q_2.Count}");


    Console.WriteLine($"q1 Last Value : {q_1.Peek()}");
    Console.WriteLine($"q2 Last Value : {q_2.Peek()}");
}

static void OPP(BST<int> BST, BinaryTree<int> bt)
{
    bt.InOrder(BST.Root).ForEach(node => Console.Write(node + " "));
    bt.ClearList();
    Console.WriteLine("\nInOrder Recursive");
    Console.WriteLine();
    bt.ClearList();
    bt.PreOrder(BST.Root).ForEach(node => Console.Write(node + " "));
    bt.ClearList();
    Console.WriteLine("\nPreOrder Recursive");
    bt.PostOrder(BST.Root).ForEach(node => Console.Write(node + " "));
    Console.WriteLine("\nPostOrder Recursive");
    bt.PostOrder(BST.Root).ForEach(node => Console.Write(node + " "));
    bt.ClearList();
    Console.WriteLine("\nInOrderNonRecursiveTraversal Recursive");
    bt.InOrderNonRecursiveTraversal(BST.Root).ForEach(node => Console.Write(node + " "));
    Console.ReadKey();
}

static void BST()
{
    var BST = new BST<int>(new int[]
    {
    23, 16, 45, 3, 22, 37, 99
    });

    var bt = new BinaryTree<int>();
    bt.ClearList();

    bt.ClearList();
    Console.WriteLine("\nPostOrder Recursive");
    bt.PostOrder(BST.Root).ForEach(node => Console.Write(node + " "));
    Console.WriteLine();
    //bt.PostOrderNonRecursiveTraversal(BST.Root).ForEach(node => Console.Write(node + " "));
    bt.PostOrder(BST.Root);
}

static void AyrikSet()
{
    var distjoint_set = new DisjointSet<int>(new int[] { 0, 1, 2, 3, 4, 5, 6 });

    distjoint_set.Union(5, 6);
    distjoint_set.Union(1, 2);
    distjoint_set.Union(0, 2);

    for (int i = 0; i < 7; i++)
    {
        Console.WriteLine($"Find({i}) = {distjoint_set.FindSet(i)}");
    }
}

void Graph()
{
    var graf = new Graph<char>(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G' });

    graf.AddEdge('A', 'B');
    graf.AddEdge('A', 'D');
    graf.AddEdge('C', 'D');
    graf.AddEdge('C', 'E');
    graf.AddEdge('D', 'E');
    graf.AddEdge('E', 'F');
    graf.AddEdge('F', 'G');

    Console.WriteLine("Is there an edge between A and B ? {0}", graf.HasEdge('A', 'B') ? "Yes" : "No");
    Console.WriteLine("Is there an edge between B and A ? {0}", graf.HasEdge('B', 'A') ? "Yes" : "No");
    Console.WriteLine("Is there an edge between B and D ? {0}", graf.HasEdge('B', 'D') ? "Yes" : "No");
    Console.WriteLine("Is there an edge between D and B ? {0}", graf.HasEdge('D', 'B') ? "Yes" : "No");

    foreach (var key in graf)
    {
        Console.Write("{0} -> ", key);
        foreach (var vertex in graf.GetVertex(key))
        {
            Console.Write("{0} ", vertex);
        }
        Console.WriteLine();
    }

    print<char>(graf);

    Console.WriteLine($"Count vertex : {graf.Count}");
}

void WeightedGraph()
{
    var graf = new WeightedGraph<char, double>(new char[] { 'A', 'B', 'C', 'D' });



    graf.AddEdge('A', 'B', 1.2);
    graf.AddEdge('A', 'D', 2.3);
    graf.AddEdge('D', 'C', 5.5);

    Console.WriteLine("Is there an edge between A and B ? {0}", graf.HasEdge('A', 'B') ? "Yes" : "No");
    Console.WriteLine("Is there an edge between B and A ? {0}", graf.HasEdge('B', 'A') ? "Yes" : "No");
    Console.WriteLine("Is there an edge between B and D ? {0}", graf.HasEdge('B', 'D') ? "Yes" : "No");
    Console.WriteLine("Is there an edge between D and B ? {0}", graf.HasEdge('D', 'B') ? "Yes" : "No");

    foreach (char vertex in graf)
    {
        Console.WriteLine("----- {0} -----", vertex);
        foreach (char key in graf.GetVertex(vertex))
        {
            var node = graf.GetVertex(key);
            Console.WriteLine(
                $"{key} " +
                $"-- {node.GetEdge(graf.GetVertex(vertex)).Weight<Double>()} " +
                $"-- {vertex}");
        }
        Console.WriteLine();
    }

    //print<char>(graf);

    Console.WriteLine($"Count vertex : {graf.Count}");
}

static void DiGraph()
{
    var graf = new DiGraph<char>(new char[] { 'A', 'B', 'C', 'D', 'E' });

    graf.AddEdge('A', 'D');
    graf.AddEdge('B', 'A');
    graf.AddEdge('C', 'A');
    graf.AddEdge('C', 'B');
    graf.AddEdge('C', 'D');
    graf.AddEdge('C', 'E');
    graf.AddEdge('D', 'E');

    Console.WriteLine("Is there an edge between A and B ? {0}", graf.HasEdge('A', 'B') ? "Yes" : "No");
    Console.WriteLine("Is there an edge between B and A ? {0}", graf.HasEdge('B', 'A') ? "Yes" : "No");

    //print<char>(graf);
    Console.WriteLine("Removed Before");
    foreach (var key in graf)
    {
        Console.Write("{0} -> ", key);
        foreach (var vertex in graf.GetVertex(key))
        {
            Console.Write("{0} ", vertex);
        }
        Console.WriteLine();
    }

    Console.WriteLine("Removed After");
    graf.RemoveVertex('C');

    foreach (var key in graf)
    {
        Console.Write("{0} -> ", key);
        foreach (var vertex in graf.GetVertex(key))
        {
            Console.Write("{0} ", vertex);
        }
        Console.WriteLine();
    }


    Console.WriteLine($"Count vertex : {graf.Count}");
}

static void WeightedDiGraphMain()
{
    var graf = new WeightedDiGraph<char, int>(new char[] { 'A', 'B', 'C', 'D', 'E' });

    graf.AddEdge('A', 'D', 60);
    graf.AddEdge('A', 'C', 12);
    graf.AddEdge('B', 'A', 10);
    graf.AddEdge('C', 'B', 20);
    graf.AddEdge('C', 'D', 32);
    graf.AddEdge('E', 'A', 7);

    Console.WriteLine("Is there an edge between A and B ? {0}", graf.HasEdge('A', 'B') ? "Yes" : "No");
    Console.WriteLine("Is there an edge between B and A ? {0}", graf.HasEdge('B', 'A') ? "Yes" : "No");

    Console.WriteLine("Removed Before");

    foreach (var vertex in graf)
    {
        Console.WriteLine("----- {0} -----", vertex);
        foreach (char key in graf.GetVertex(vertex))
        {
            var nodeU = graf.GetVertex(vertex);
            var nodeV = graf.GetVertex(key);
            var w = nodeU.GetEdge(nodeV).Weight<int>();

            Console.WriteLine(
                $"{vertex} " +
                $"-- {w} " +
                $"-- {key}");
        }
        Console.WriteLine();
    }

    Console.WriteLine("Removed After");
    graf.RemoveVertex('C');

    foreach (var key in graf)
    {
        Console.Write("{0} -> ", key);
        foreach (var vertex in graf.GetVertex(key))
        {
            Console.Write("{0} ", vertex);
        }
        Console.WriteLine();
    }

    Console.WriteLine($"Count vertex : {graf.Count}");
}

static void DepthFirstSearch(Graph<int> graph)
{
    var algorithm = new DepthFirst<int>();
    Console.WriteLine("{0}", algorithm.Find(graph, 5) ? "Yes." : "No!");
}

static void deneme()
{
    var graph = new Graph<int>();

    for (int i = 0; i <= 11; i++)
        graph.AddVertex(i);

    graph.AddEdge(0, 1);
    graph.AddEdge(1, 4);
    graph.AddEdge(0, 4);
    graph.AddEdge(0, 2);


    graph.AddEdge(2, 5);
    graph.AddEdge(2, 9);
    graph.AddEdge(2, 10);
    graph.AddEdge(9, 11);
    graph.AddEdge(10, 11);

    graph.AddEdge(5, 6);
    graph.AddEdge(5, 7);
    graph.AddEdge(5, 8);
    graph.AddEdge(7, 8);

    var algorithm = new BreadthFirst<int>();
    Console.WriteLine("{0}", algorithm.Find(graph, -1) ? "Yes." : "No!");
}

public class MyRandomGenerator
{
    private Random a;
    private List<int> randomList;
    private int currentIndex;

    public MyRandomGenerator(int length)
    {
        a = new Random(DateTime.Now.Ticks.GetHashCode());
        randomList = new List<int>();
        for (int i = 0; i < length; i++)
        {
            randomList.Add(i);
        }
        Shuffle(randomList);
        currentIndex = 0;
    }

    private void Shuffle(List<int> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = a.Next(n + 1);
            int value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public int GetNextNumber()
    {
        if (currentIndex < randomList.Count)
        {
            int nextNumber = randomList[currentIndex];
            currentIndex++;
            return nextNumber;
        }
        else
        {
            throw new InvalidOperationException("All numbers have been consumed.");
        }
    }
}
#endregion
