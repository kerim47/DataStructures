using DataStructures.LinkedList.SinglyLinkedList;

namespace DataStructures.Stack
{
    internal class SinglyLinkedListStack<T> : IStack<T>
    {

        private readonly SinglyLinkedList<T> list = new SinglyLinkedList<T>();
        public int Count { get; private set; }

        public void Clear()
        {
            if (Count == 0)
                throw new ArgumentException("Empty List.");
            foreach (var item in list)
                list.RemoveFirst();

            Count = 0;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new ArgumentException("Empty List.");
            return list.Head.Value;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new ArgumentException("Empty List.");
            var temp = list.RemoveFirst();
            Count--;
            return temp;
        }

        public void Push(T item)
        {
            if (Count == 0)
                throw new ArgumentNullException();
            list.AddFirst(item);
            Count++;
        }
    }
}