using System.Runtime.CompilerServices;

namespace DataStructures.Queue
{
    public class QueueArray<T> : IQueue<T>
    {
        private readonly List<T> list = new List<T>();
        public int Count { get; private set; }

        public T DeQueue()
        {
            if(Count == 0) throw new ArgumentException("Empy Queue!");
            var temp = list[0];
            list.RemoveAt(0);
            Count--;
            return temp;
        }

        public void EnQueue(T Item)
        {
            if(Item == null) throw new ArgumentNullException("Empy Queue!");
            list.Add(Item);
            Count++;
        }

        public T Peek() => (Count == 0) 
            ? throw new ArgumentNullException("Empty List.")
            : list[Count-1];
    }
}