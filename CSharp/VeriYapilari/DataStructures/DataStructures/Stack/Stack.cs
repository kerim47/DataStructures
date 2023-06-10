using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    public class Stack<T>
    {
        private readonly IStack<T> stack;
        public int Count => stack.Count;
        public Stack(StackType type = StackType.Array)
        {
            if (type == StackType.Array)
            {
                stack = new ArrayStack<T>();
            }
            else if(type == StackType.LinkedList)
            {
                stack = new LinkedListStack<T>();
            }
            else if(type == StackType.SinglyLinkedList)
            {
                stack = new SinglyLinkedListStack<T>();
            }
        }

        public T Pop() => stack.Pop();


        public T Peek() => stack.Peek();


        public void Push(T item) => stack.Push(item);

        public void Clear() => stack.Clear();
    }
    public enum StackType
    {
        Array = 0,              // List of T List<T>
        SinglyLinkedList = 1,   // SinglyLinkedList<T>
        LinkedList = 1,         // LinkedList<T>
        None,
    }
}
