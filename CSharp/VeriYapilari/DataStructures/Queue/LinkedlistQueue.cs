using DataStructures.LinkedList.DoublyLinkedList;

namespace DataStructures.Queue
{
    public class LinkedlistQueue<T> : IQueue<T>
    {
        DoublyLinkedList<T> list = new DoublyLinkedList<T>();
        public int Count { get; private set; }

        public T DeQueue()
        {
            if(Count == 0) throw new ArgumentException("Empy Queue!");
            var temp = list.RemoveFirst();
            Count--;
            return temp;
        }

        public void EnQueue(T Item)
        {
            if(Item == null) throw new ArgumentNullException("Empy Queue!");
            list.AddLast(Item);
            Count++;
        }

        public T Peek() => (Count == 0) 
            ? throw new ArgumentException("Empy Queue!")
            : list.Tail.Value;
    }
}