using System.Net;

namespace DataStructures.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        public int Count { get; private set; }
        private readonly List<T> list = new List<T>();

        public T Peek()
        {
            if (Count == 0)
                throw new ArgumentException("Empty List.");

            return list[list.Count - 1];
        }

        public T Pop()
        {
            if (Count == 0)
                throw new ArgumentException("Empty List.");
            var temp_value = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            Count--;
            return temp_value;
        }

        public void Push(T item)
        {
            if (item == null)
                throw new ArgumentNullException();
            list.Add(item);
            Count++;
        }

        public void Clear()
        {
            list.Clear();
            Count = 0;
        }
    }
}